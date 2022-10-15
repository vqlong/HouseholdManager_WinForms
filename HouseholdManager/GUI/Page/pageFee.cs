using DevExpress.XtraEditors;
using HouseholdManager.BUS;
using HouseholdManager.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HouseholdManager.GUI
{
    public partial class pageFee : DevExpress.XtraEditors.XtraUserControl, INotifyPropertyChanged
    {
        public pageFee(Account account)
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

                Help.SetPrivilege(AppSetting.Instance.FeePrivilege, listPrivilege);
            }
        }

        /// <summary>
        /// Danh sách các control binding cho pageAdmin để có thể cài đặt Enabled = true/false bởi admin.
        /// </summary>
        public List<Control> listPrivilege { get; set; }

        BindingSource FeeBindingSource = new BindingSource();

        public event PropertyChangedEventHandler PropertyChanged;

        public List<Fee> ListFee { get; set; }

        /// <summary>
        /// Dùng để binding cho pFeeInfo.
        /// </summary>
        public List<FeeInfo2> ListFeeInfo2 { get; set; }

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

            var listFactor = new List<Tuple<string, FeeFactor>>()
            {
                new Tuple<string, FeeFactor>( "Tính theo số người mỗi hộ", FeeFactor.ByPerson ),
                new Tuple<string, FeeFactor>( "Tính theo hộ", FeeFactor.ByHousehold )
            };
            lkuFactor.Properties.DataSource = listFactor;
            lkuFactor.Properties.DisplayMember = "Item1";
            lkuFactor.Properties.ValueMember = "Item2";
            lkuFactor.Properties.ShowFooter = false;
            lkuFactor.Properties.ShowHeader = false;
            lkuFactor.Properties.ShowLines = false;

            //Chỉ cần load 1 lần ở đây để binding cho bên pageFeeInfo là đủ
            ListFeeInfo2 = FeeBUS.Instance.GetListFeeInfo();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ListFeeInfo2"));

            AcceptButton = btnSearch;
        }

        void LoadData()
        {
            dtgvData.DataSource = FeeBindingSource;

            ListFee = FeeBUS.Instance.GetListFee();
            FeeBindingSource.DataSource = ListFee;

            dtgvData.RowsDefaultCellStyle.Font = new Font("Tahoma", 10, FontStyle.Regular);
            dtgvData.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy";
            dtgvData.Columns[3].DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("vi-vn");
            dtgvData.Columns[3].DefaultCellStyle.Format = "c0";

            dtgvData.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvData.Columns[2].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvData.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvData.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgvData.Columns[0].HeaderText = "ID";
            dtgvData.Columns[1].HeaderText = "Khoản thu phí";
            dtgvData.Columns[2].HeaderText = "Ngày phát sinh";
            dtgvData.Columns[3].HeaderText = "Số tiền phải nộp";
            dtgvData.Columns[4].HeaderText = "Hệ số";

            dtgvData.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dtgvData.Columns[0].Width = 40;

            var font = new Font("Tahoma", 10, FontStyle.Bold);
            dtgvData.Columns[0].HeaderCell.Style.Font = font;
            dtgvData.Columns[1].HeaderCell.Style.Font = font;
            dtgvData.Columns[2].HeaderCell.Style.Font = font;
            dtgvData.Columns[3].HeaderCell.Style.Font = font;
            dtgvData.Columns[4].HeaderCell.Style.Font = font;

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
            nmValue.DataBindings.Add("Value", dtgvData.DataSource, "Value", false, DataSourceUpdateMode.Never);
            lkuFactor.DataBindings.Add("EditValue", dtgvData.DataSource, "Factor", false, DataSourceUpdateMode.Never);
        }

        void LoadEvent()
        {
            fInsert.GetInstance().FeeInserted += (s, e) =>
            {
                FeeBindingSource.Add((Fee)(e as InsertedEventArgs).Inserted);

                //Nếu dtgvData.DataSource đang là feeBindSource thì mới bôi đen hàng vừa thêm vào
                //Ngược lại (dtgvData.DataSource đang gán bởi hàm SearchFee) thì thôi
                if (dtgvData.DataSource.Equals(FeeBindingSource)) dtgvData.CurrentCell = dtgvData.Rows[dtgvData.RowCount - 1].Cells[1];

            };

            btnShow.Click += delegate { LoadData(); };

            btnInsert.Click += delegate { fInsert.GetInstance(InsertMode.Fee).ShowDialog(); };

            btnDelete.Click += delegate { DeleteFee((int)nmID.Value); };

            btnUpdate.Click += delegate { UpdateFee((int)nmID.Value, txbName.Text, dtDateArise.Text, (double)nmValue.Value, (int)lkuFactor.EditValue); };

            btnSearch.Click += delegate { SearchFee(txbSearch.Text); };

            //Click vào cell ID để chọn toàn bộ GridView
            dtgvData.CellClick += (s, e) => { if (e.ColumnIndex == 0 && e.RowIndex == -1) dtgvData.SelectAll(); };

            //Hiện thống kê về các hàng được chọn
            dtgvData.SelectionChanged += delegate { LoadStatistic(); };

            btnSelect.Click += delegate { PayByHousehold(); };
        }

        void LoadStatistic() => nmTotalFee.Value = dtgvData.SelectedRows.Count;

        void DeleteFee(int id)
        {
            if (MessageBox.Show($"Bạn thực sự muốn xoá khoản thu phí này?\n" +
                                $"ID:       {nmID.Text}\n" +
                                $"Tên:    {txbName.Text}\n" +
                                $"Ngày: {dtDateArise.Text}\n" +
                                $"Xoá khoản phí này sẽ xoá tất cả danh sách nộp tiền của nó.", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            if (FeeBUS.Instance.DeleteFee(id))
            {
                MessageBox.Show("Xoá thu phí thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData();

                ListFeeInfo2.RemoveAll(info => info.FeeID == id);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ListFeeInfo2"));

                return;
            }

            MessageBox.Show("Xoá thu phí thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void UpdateFee(int id, string name, string dateArise, double minValue, int factor)
        {
            if (MessageBox.Show($"Bạn muốn cập nhật khoản thu phí này?\n" +
                                $"ID:       {nmID.Text}\n" +
                                $"Tên:    {txbName.Text}\n" +
                                $"Ngày: {dtDateArise.Text}", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            if (FeeBUS.Instance.UpdateFee(id, name, dateArise, minValue, factor))
            {
                MessageBox.Show("Cập nhật thu phí thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData();

                //Khi thay đổi name của 1 Fee => thay đổi name trong các FeeInfo liên quan đến nó
                var list = ListFeeInfo2.FindAll(info => info.FeeID == id);
                list.ForEach(info => info.Name = name);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ListFeeInfo2"));

                return;
            }

            MessageBox.Show("Cập nhật thu phí thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void SearchFee(string input)
        {
            var list = new List<Fee>(ListFee);

            input = input.ToLower().ToUnsigned();

            list.RemoveAll(fee => fee.Name.ToUnsigned().ToLower().Contains(input) == false
                                  && fee.DateArise.ToString("dd/MM/yyyy").ToUnsigned().ToLower().Contains(input) == false);

            dtgvData.DataSource = list;

            LoadBinding();
        }

        void PayByHousehold()
        {
            if (fSelect.Instance.ShowDialog() == DialogResult.Cancel) return;

            var info2 = ListFeeInfo2.FindLast(info => info.HouseholdID == SelectedHouseholdID && info.FeeID == nmID.Value);

            if (info2 != null)
            {
                var result = Help.DialogBox($"Nhà ông (bà) {info2.Owner} đã nộp {info2.Value:0,0} vnđ cho {info2.Name} ngày {info2.DatePay:dd/MM/yyyy}.\n\n" +
                                            $"Tiếp tục nộp tiền?", "Thông báo", "Thôi", "Nộp tiếp");

                if (result == 3) return;
            }

            var household = HouseholdBUS.Instance.GetHouseholdByID(SelectedHouseholdID);

            var fee = FeeBUS.Instance.GetFeeByID((int)nmID.Value);

            var fInsertMoney = new fInsertMoney(household, fee);

            fInsertMoney.FeeInfoInserted += (s, e) =>
            {
                var newInfo = (FeeInfo)(e as InsertedEventArgs).Inserted;
                var newInfo2 = new FeeInfo2(newInfo.ID, newInfo.HouseholdID, newInfo.FeeID, household.Owner, fee.Name, newInfo.DatePay, newInfo.Value);
                ListFeeInfo2.Add(newInfo2);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ListFeeInfo2"));
            };

            fInsertMoney.ShowDialog();
        }
    }
}
