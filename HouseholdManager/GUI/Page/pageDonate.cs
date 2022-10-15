using DevExpress.XtraEditors;
using HouseholdManager.BUS;
using HouseholdManager.DTO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HouseholdManager.GUI
{
    public partial class pageDonate : DevExpress.XtraEditors.XtraUserControl, INotifyPropertyChanged
    {
        public pageDonate(Account account)
        {
            InitializeComponent();

            Initialize();

            LoadData();

            LoadEvent();

            Account = account;
        }

        Account _account;
        public Account Account
        {
            get => _account;
            set
            {
                _account = value;

                Help.SetPrivilege(AppSetting.Instance.DonatePrivilege, listPrivilege);
            }
        }

        /// <summary>
        /// Danh sách các control binding cho pageAdmin để có thể cài đặt Enabled = true/false bởi admin.
        /// </summary>
        public List<Control> listPrivilege { get; set; }

        BindingSource donateBindingSource = new BindingSource();

        public event PropertyChangedEventHandler PropertyChanged;

        public List<Donate> ListDonate { get; set; }

        /// <summary>
        /// Dùng để binding cho pDonateInfo.
        /// </summary>
        public List<DonateInfo2> ListDonateInfo2 { get; set; }

        public SimpleButton AcceptButton { get; private set; }

        /// <summary>
        /// Dùng để binding với SelectedID của pHousehold.
        /// </summary>
        public int SelectedHouseholdID { get; set; }

        private Font _fontHeader;
        public Font HeaderFont
        {
            get => _fontHeader;
            set
            {
                _fontHeader = value;
                Help.SetHeaderFont(new List<DataGridView> { dtgvData }, _fontHeader);
            }
        }

        private Font _rowFont;
        public Font RowFont
        {
            get => _rowFont;
            set
            {
                _rowFont = value;
                Help.SetRowFont(new List<DataGridView> { dtgvData }, _rowFont);
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
                        btnSelect
                    },
                    _buttonFont);
            }
        }

        private Font _labelFont;
        public Font LabelFont
        {
            get => _labelFont;
            set
            {
                _labelFont = value;

                Help.SetLabelFont(new List<Label> { labelStatistic }, _labelFont);
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
                        btnSelect,
                        labelStatistic
                    },
                    _textColor);
            }
        }

        void Initialize()
        {
            listPrivilege = new List<Control>
            {
                btnSearch,
                btnShow,
                btnInsert,
                btnUpdate,
                btnDelete,
                btnSelect
            };

            //Chỉ cần load 1 lần ở đây để binding cho bên pageDonateInfo là đủ
            ListDonateInfo2 = DonateBUS.Instance.GetListDonateInfo();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ListDonateInfo2"));

            AcceptButton = btnSearch;
        }

        void LoadData()
        {
            dtgvData.DataSource = donateBindingSource;

            ListDonate = DonateBUS.Instance.GetListDonate();
            donateBindingSource.DataSource = ListDonate;

            dtgvData.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy";
            dtgvData.Columns[3].DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("vi-vn");
            dtgvData.Columns[3].DefaultCellStyle.Format = "c0";

            dtgvData.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvData.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvData.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvData.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgvData.Columns[0].HeaderText = "ID";
            dtgvData.Columns[1].HeaderText = "Khoản đóng góp";
            dtgvData.Columns[2].HeaderText = "Ngày kêu gọi";
            dtgvData.Columns[3].HeaderText = "Số tiền thấp nhất";

            dtgvData.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dtgvData.Columns[0].Width = 40;

            LoadBinding();
        }

        void LoadBinding()
        {
            foreach (Control control in panelInfo.Controls)
            {
                if (!(control is Label) && !(control is SimpleButton)) control.DataBindings.Clear();
            }

            nmID.DataBindings.Add("Value", dtgvData.DataSource, "ID", false, DataSourceUpdateMode.Never);
            txbName.DataBindings.Add("Text", dtgvData.DataSource, "Name", false, DataSourceUpdateMode.Never);
            dtDateArise.DataBindings.Add("EditValue", dtgvData.DataSource, "DateArise", false, DataSourceUpdateMode.Never);
            nmMinValue.DataBindings.Add("Value", dtgvData.DataSource, "MinValue", false, DataSourceUpdateMode.Never);

        }

        void LoadEvent()
        {
            fInsert.GetInstance().DonateInserted += (s, e) =>
            {
                donateBindingSource.Add((Donate)(e as InsertedEventArgs).Inserted);

                //Nếu dtgvData.DataSource đang là donateBindSource thì mới bôi đen hàng vừa thêm vào
                //Ngược lại (dtgvData.DataSource đang gán bởi hàm SearchFee) thì thôi
                if (dtgvData.DataSource.Equals(donateBindingSource)) dtgvData.CurrentCell = dtgvData.Rows[dtgvData.RowCount - 1].Cells[1];

            };

            btnShow.Click += delegate { LoadData(); };

            btnInsert.Click += delegate { fInsert.GetInstance(InsertMode.Donate).ShowDialog(); };

            btnDelete.Click += delegate { DeleteDonate((int)nmID.Value); };

            btnUpdate.Click += delegate { UpdateDonate((int)nmID.Value, txbName.Text, dtDateArise.Text, (double)nmMinValue.Value); };

            btnSearch.Click += delegate { SearchDonate(txbSearch.Text); };

            //Click vào cell ID để chọn toàn bộ GridView
            dtgvData.CellClick += (s, e) => { if (e.ColumnIndex == 0 && e.RowIndex == -1) dtgvData.SelectAll(); };

            //Hiện thống kê về các hàng được chọn
            dtgvData.SelectionChanged += delegate { LoadStatistic(); };

            btnSelect.Click += delegate { DonateByHousehold(); };
        }

        void LoadStatistic() => nmTotalDonate.Value = dtgvData.SelectedRows.Count;

        void DeleteDonate(int id)
        {
            if (MessageBox.Show($"Bạn thực sự muốn xoá khoản đóng góp này?\n" +
                                $"ID:       {nmID.Text}\n" +
                                $"Tên:    {txbName.Text}\n" +
                                $"Ngày: {dtDateArise.Text}\n" +
                                $"Xoá khoản đóng góp này sẽ xoá tất cả danh sách đóng tiền của nó.", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            if (DonateBUS.Instance.DeleteDonate(id))
            {
                MessageBox.Show("Xoá đóng góp thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData();

                ListDonateInfo2.RemoveAll(info => info.DonateID == id);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ListDonateInfo2"));

                return;
            }

            MessageBox.Show("Xoá đóng góp thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void UpdateDonate(int id, string name, string dateArise, double minValue)
        {
            if (MessageBox.Show($"Bạn muốn cập nhật khoản đóng góp này?\n" +
                                $"ID:       {nmID.Text}\n" +
                                $"Tên:    {txbName.Text}\n" +
                                $"Ngày: {dtDateArise.Text}", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            if (DonateBUS.Instance.UpdateDonate(id, name, dateArise, minValue))
            {
                MessageBox.Show("Cập nhật đóng góp thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData();

                //Khi thay đổi name của 1 Donate => thay đổi name trong các DonateInfo liên quan đến nó
                var list = ListDonateInfo2.FindAll(info => info.DonateID == id);
                list.ForEach(info => info.Name = name);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ListDonateInfo2"));

                return;
            }

            MessageBox.Show("Cập nhật nhân khẩu thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void SearchDonate(string input)
        {
            var list = new List<Donate>(ListDonate);

            input = input.ToLower().ToUnsigned();

            list.RemoveAll(donate => donate.Name.ToUnsigned().ToLower().Contains(input) == false
                                  && donate.DateArise.ToString("dd/MM/yyyy").ToUnsigned().ToLower().Contains(input) == false);

            dtgvData.DataSource = list;

            LoadBinding();
        }

        void DonateByHousehold()
        {
            //Nếu chọn huỷ trong form lựa chọn hộ khẩu => thoát
            if (fSelect.Instance.ShowDialog() == DialogResult.Cancel) return;

            //Tìm kiếm khoản đóng góp gần đây nhất cho quỹ này của hộ khẩu đã chọn
            var info2 = ListDonateInfo2.FindLast(info => info.HouseholdID == SelectedHouseholdID && info.DonateID == nmID.Value);

            if (info2 != null)
            {   
                var result = Help.DialogBox($"Nhà ông (bà) {info2.Owner} đã đóng {info2.Value:0,0} vnđ cho {info2.Name} ngày {info2.DateContribute:dd/MM/yyyy}.\n\n" +
                                            $"Tiếp tục đóng góp?", "Thông báo", "Thôi", "Đóng tiếp");

                if (result == 3) return;
            }

            var household = HouseholdBUS.Instance.GetHouseholdByID(SelectedHouseholdID);

            var donate = DonateBUS.Instance.GetDonateByID((int)nmID.Value);

            var fInsertMoney = new fInsertMoney(household, donate);

            //Insert thành công sẽ thêm mới vào GridView đang hiển thị và notify
            fInsertMoney.DonateInfoInserted += (s, e) => 
            {
                var newInfo = (DonateInfo)(e as InsertedEventArgs).Inserted;
                var newInfo2 = new DonateInfo2(newInfo.ID, newInfo.HouseholdID, newInfo.DonateID, household.Owner, donate.Name, newInfo.DateContribute, newInfo.Value);
                ListDonateInfo2.Add(newInfo2);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ListDonateInfo2"));
            };

            fInsertMoney.ShowDialog();
        }
    }
}
