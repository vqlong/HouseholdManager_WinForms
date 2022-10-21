using DevExpress.XtraEditors;
using HouseholdManager.BUS;
using HouseholdManager.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace HouseholdManager.GUI
{
    public partial class pageAdmin : DevExpress.XtraEditors.XtraUserControl
    {
        public pageAdmin(Account account)
        {
            InitializeComponent();

            Account = account;

            Initialize();

            LoadBinding();

            LoadEvent();
        }

        #region Property

        Account _account;
        public Account Account
        {
            get => _account;
            set
            {
                _account = value;

                CheckAccount(_account.Type);
            }
        }
        
        BindingSource accountBindingSource = new BindingSource();

        public event EventHandler AccountDeleted;

        public SimpleButton AcceptButton { get; private set; }

        /// <summary>
        /// Danh sách các control nhận binding từ pagePerson để có thể cài đặt Enabled = true/false bởi admin.
        /// </summary>
        public List<Control> listPersonPrivilege { get; set; }
        public List<Control> listHouseholdPrivilege { get; set; }
        public List<Control> listDonatePrivilege { get; set; }
        public List<Control> listFeePrivilege { get; set; }

        /// <summary>
        /// account đang được chọn trên dtgvData.
        /// </summary>
        Account currentAccount;
        /// <summary>
        /// AppSetting tương ứng của currentAccount.
        /// </summary>
        AppSetting currentSetting;

        private Font _fontHeader;
        public Font HeaderFont
        {
            get => _fontHeader;
            set
            {
                _fontHeader = value;
                Help.SetHeaderFont(new List<DataGridView> { dtgvData, dtgvPerson, dtgvHousehold, dtgvDonate, dtgvFee }, _fontHeader);
            }
        }

        private Font _rowFont;
        public Font RowFont
        {
            get => _rowFont;
            set
            {
                _rowFont = value;
                Help.SetRowFont(new List<DataGridView> { dtgvData, dtgvPerson, dtgvHousehold, dtgvDonate, dtgvFee }, _rowFont);
            }
        }

        private Font _buttonFont;
        public Font ButtonFont
        {
            get => _buttonFont;
            set
            {
                _buttonFont = value;
                Help.SetControlFont(
                    new List<Control>
                    { btnSearch,
                        btnShow,
                        btnInsert,
                        btnUpdate,
                        btnDelete,
                        btnResetPassword,
                        btnSavePrivilege
                    },
                    _buttonFont);
            }
        }

        private Color _textColor;
        public Color TextColor
        {
            get => _textColor;
            set
            {
                _textColor = value;
                Help.SetTextColor(
                    new List<object>
                    { btnSearch,
                        btnShow,
                        btnInsert,
                        btnUpdate,
                        btnDelete,
                        btnResetPassword,
                        btnSavePrivilege
                    },
                    _textColor);
            }
        }
        #endregion

        #region Method
        
        void CheckAccount(AccountType type)
        {
            //Nếu account không phải admin thì thoát luôn pageAdmin này
            if (type != AccountType.Admin)
                Parent?.Controls.Clear();
        }

        void Initialize()
        {
            //Khởi tạo DataSource cho các ComboBox
            var listAccountType = new List<Tuple<string, AccountType>>()
            {
                new Tuple<string, AccountType>( "Quản lý", AccountType.Admin ),
                new Tuple<string, AccountType>( "Nhân viên", AccountType.Staff )
            };
            lkuAccountType.Properties.DataSource = listAccountType;
            lkuAccountType.Properties.DisplayMember = "Item1";
            lkuAccountType.Properties.ValueMember = "Item2";
            lkuAccountType.Properties.ShowFooter = false;
            lkuAccountType.Properties.ShowHeader = false;
            lkuAccountType.Properties.ShowLines = false;

            //Khởi tạo DataSource cho GridView
            dtgvData.DataSource = accountBindingSource;

            accountBindingSource.DataSource = AccountBUS.Instance.GetListAccount();

            dtgvData.Columns[0].HeaderText = "Tên đăng nhập";
            dtgvData.Columns[1].HeaderText = "Tên hiển thị";
            dtgvData.Columns[3].HeaderText = "Loại tài khoản";

            dtgvData.Columns[2].Visible = false;
            dtgvData.Columns[4].Visible = false;
            dtgvData.Columns[5].Visible = false;

            dtgvPerson.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvPerson.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgvHousehold.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvHousehold.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgvDonate.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvDonate.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgvFee.Columns[1].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvFee.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            AcceptButton = btnSearch;
        }

        void LoadBinding()
        {
            txbUsername.DataBindings.Add("Text", dtgvData.DataSource, "UserName", false, DataSourceUpdateMode.Never);
            txbDisplayName.DataBindings.Add("Text", dtgvData.DataSource, "DisplayName", false, DataSourceUpdateMode.Never);
            lkuAccountType.DataBindings.Add("EditValue", dtgvData.DataSource, "Type", false, DataSourceUpdateMode.Never);
        }

        void LoadEvent()
        {
            fInsert.GetInstance().AccountInserted += (s, e) => { btnShow.PerformClick(); };

            btnShow.Click += delegate { accountBindingSource.DataSource = AccountBUS.Instance.GetListAccount(); };

            btnInsert.Click += delegate { fInsert.GetInstance(InsertMode.Account).ShowDialog(); };

            btnDelete.Click += delegate { DeleteAccount(txbUsername.Text); };

            btnUpdate.Click += delegate { UpdateAccount(txbUsername.Text, txbDisplayName.Text); };

            btnResetPassword.Click += delegate { ResetPassword(txbUsername.Text); };

            btnSearch.Click += delegate { Search(txbSearch.Text); };

            //Hiện Description của enum thay vì giá trị
            dtgvData.CellFormatting += (s, e) =>
            {
                if (e.ColumnIndex != 3) return;

                FieldInfo info = e.Value.GetType().GetField(e.Value.ToString());
                DescriptionAttribute description = info.GetCustomAttribute<DescriptionAttribute>();
                e.Value = description.Description;
            };

            //Hiện Privilege của account được chọn trên dtgvData lên các DataGridView tương ứng
            dtgvData.CurrentCellChanged += delegate
            {
                if (dtgvData.CurrentCell == null) return;

                //Lấy ra account đang được chọn trên dtgvData
                var username = dtgvData.CurrentCell.OwningRow.Cells[0].Value.ToString();

                currentAccount = (accountBindingSource.List as List<Account>).Find(a => a.Username == username);

                currentSetting = (AppSetting)JsonConvert.DeserializeObject(currentAccount.Setting, typeof(AppSetting));

                LoadPrivilege(dtgvPerson, listPersonPrivilege, currentSetting != null ? currentSetting.PersonPrivilege : null);
                LoadPrivilege(dtgvHousehold, listHouseholdPrivilege, currentSetting != null ? currentSetting.HouseholdPrivilege : null);
                LoadPrivilege(dtgvDonate, listDonatePrivilege, currentSetting != null ? currentSetting.DonatePrivilege : null);
                LoadPrivilege(dtgvFee, listFeePrivilege, currentSetting != null ? currentSetting.FeePrivilege : null);

            };

            //Save Privilege của account được chọn trên dtgvData xuống database
            btnSavePrivilege.Click += delegate
            {
                if (currentSetting == null)
                {
                    MessageBox.Show("Tài khoản này chưa lưu cài đặt bao giờ.\n" +
                        "Hãy lưu cài đặt font của tài khoản trước.\n" +
                        "Nhấn [Xem] để tải lại danh sách tài khoản.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;
                }

                SavePrivilege(dtgvPerson, listPersonPrivilege, currentSetting.PersonPrivilege);
                SavePrivilege(dtgvHousehold, listHouseholdPrivilege, currentSetting.HouseholdPrivilege);
                SavePrivilege(dtgvDonate, listDonatePrivilege, currentSetting.DonatePrivilege);
                SavePrivilege(dtgvFee, listFeePrivilege, currentSetting.FeePrivilege);

                string setting = JsonConvert.SerializeObject(currentSetting);

                var result = AccountBUS.Instance.UpdateAccount(currentAccount.Username, null, null, null, setting);

                if (result.Item4)
                {
                    MessageBox.Show("Lưu quyền cho tài khoản thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    btnShow.PerformClick();

                    return;
                }

                MessageBox.Show("Lưu quyền cho tài khoản thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };

            //Form resize => panel resize => DataGridView resize
            panelPrivilege.SizeChanged += delegate
            {
                dtgvPerson.Width = panelPrivilege.Width / 4 - 4;

                dtgvHousehold.Width = dtgvPerson.Width;
                dtgvHousehold.Left = dtgvPerson.Left + dtgvPerson.Width + 3;

                dtgvDonate.Width = dtgvPerson.Width;
                dtgvDonate.Left = dtgvHousehold.Left + dtgvPerson.Width + 3;

                dtgvFee.Width = dtgvHousehold.Width;
                dtgvFee.Left = dtgvDonate.Left + dtgvPerson.Width + 3;
            };
        }

        /// <summary>
        /// Dựa theo 1 Dictionary&lt;string, bool&gt;  để hiển thị Enabled = true/false cho các control trong list lên DataGridView.
        /// </summary>
        /// <param name="view"></param>
        /// <param name="listControl"></param>
        /// <param name="privilege"></param>
        void LoadPrivilege(DataGridView view, List<Control> listControl, Dictionary<string, bool> privilege)
        {
            view.Rows.Clear();

            //Với mỗi control trong List<Control>, hiển thị lên DataGridView liệu account này có quyền sử dụng control này hay không
            foreach (var control in listControl)
            {
                var enable = false;

                if (privilege != null)
                {
                    if (privilege.Count > 0)
                    {
                        var key = control.Name + "@" + control.Text;

                        if (privilege.ContainsKey(key)) enable = privilege[key];

                    }
                }

                view.Rows.Add(control.Name, control.Text, enable);
            }

            view.Columns[1].ReadOnly = true;
        }

        /// <summary>
        /// Ghi vào 1 Dictionary&lt;string, bool&gt;  giá trị Enabled = true/false của các control trong list (nếu chúng được hiển thị trên DataGridView).
        /// </summary>
        /// <param name="view"></param>
        /// <param name="listControl"></param>
        /// <param name="privilege"></param>
        void SavePrivilege(DataGridView view, List<Control> listControl, Dictionary<string, bool> privilege)
        {
            privilege.Clear();

            foreach (var control in listControl)
            {
                foreach (DataGridViewRow row in view.Rows)
                {
                    if (row.Cells[0].Value.ToString().Equals(control.Name))
                    {
                        var key = control.Name + "@" + control.Text;

                        privilege[key] = (bool)row.Cells[2].Value;
                    }
                }
            }
        }

        void DeleteAccount(string username)
        {
            if (username == "admin")
            {
                MessageBox.Show("Bạn không thể xoá chính mình.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (MessageBox.Show($"Bạn thực sự muốn xoá tài khoản này?\n" +
                                $"Tên đăng nhập: {txbUsername.Text}\n" +
                                $"Tên hiển thị:      {txbDisplayName.Text}\n" +
                                $"Loại tài khoản:  {lkuAccountType.Text}", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            if (AccountBUS.Instance.DeleteAccount(username))
            {
                MessageBox.Show("Xoá tài khoản thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnShow.PerformClick();

                AccountDeleted?.Invoke(this, EventArgs.Empty);

                return;
            }

            MessageBox.Show("Xoá tài khoản thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Cập nhật displayname cho tài khoản username.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="displayname"></param>
        void UpdateAccount(string username, string displayname)
        {
            if (MessageBox.Show($"Bạn muốn cập nhật tên hiển thị cho tài khoản này?\n" +
                                $"Tên đăng nhập: {txbUsername.Text}\n" +
                                $"Tên hiển thị:      {txbDisplayName.Text}\n" +
                                $"Loại tài khoản:  {lkuAccountType.Text}", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            var match = Regex.Match(displayname, @".{5,}");

            if (match.Value.Equals(displayname) == false)
            {
                MessageBox.Show("Tên hiển thị ít nhất phải có 5 ký tự.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (AccountBUS.Instance.UpdateAccount(username, displayname, null, null, null).Item1)
            {
                MessageBox.Show("Cập nhật tên hiển thị thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnShow.PerformClick();

                return;
            }

            MessageBox.Show("Cập nhật thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void ResetPassword(string username)
        {
            if (MessageBox.Show($"Bạn muốn đặt lại mật khẩu cho tài khoản này?\n" +
                                $"Tên đăng nhập: {txbUsername.Text}\n" +
                                $"Tên hiển thị:      {txbDisplayName.Text}\n" +
                                $"Loại tài khoản:  {lkuAccountType.Text}", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            if (AccountBUS.Instance.UpdateAccount(username, null, "0", null, null).Item2)
            {
                MessageBox.Show("Đặt lại mật khẩu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            MessageBox.Show("Đặt lại mật khẩu thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void Search(string input)
        {
            //Bỏ chọn những cell đang được highlight
            dtgvData.ClearSelection();

            //Highlight những cell có chứa nội dung trong txbSearch
            var listHighlightCell = new List<DataGridViewCell>();

            input = input.ToUnsigned().ToLower();

            for (int i = 0; i < dtgvData.Rows.Count; i++)
            {
                var cell0 = dtgvData.Rows[i].Cells[0];
                if (cell0.Value.ToString().ToUnsigned().ToLower().Contains(input))
                    listHighlightCell.Add(cell0);

                var cell1 = dtgvData.Rows[i].Cells[1];
                if (cell1.Value.ToString().ToUnsigned().ToLower().Contains(input))
                    listHighlightCell.Add(cell1);
            }

            listHighlightCell.ForEach(cell => cell.Selected = true);
        }

        public void ReloadData() => btnShow.PerformClick(); 
        #endregion
    }
}
