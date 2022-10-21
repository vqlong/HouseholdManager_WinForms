using DevExpress.XtraEditors;
using HouseholdManager.BUS;
using HouseholdManager.DTO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HouseholdManager.GUI
{
    public partial class pageHousehold : DevExpress.XtraEditors.XtraUserControl, INotifyPropertyChanged, IMode
    {
        public pageHousehold(Account account)
        {
            InitializeComponent();
            
            Initialize();

            LoadBinding();

            LoadEvent();

            Account = account;
        }

        #region Property

        Account _account;
        public Account Account
        {
            get => _account;
            set
            {
                _account = value;

                Help.SetPrivilege(AppSetting.Instance.HouseholdPrivilege, listPrivilege);
            }
        }

        BindingSource householdBindingSource = new BindingSource();

        BindingSource personBindingSource = new BindingSource();

        /// <summary>
        /// Danh sách các control binding cho pageAdmin để có thể cài đặt Enabled = true/false bởi admin.
        /// </summary>
        public List<Control> listPrivilege { get; set; }

        public IButtonControl AcceptButton { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        List<Person> _listPerson;
        /// <summary>
        /// 1 List&lt;Person&gt; dùng để binding với ListPerson của pPerson.
        /// </summary>
        public List<Person> ListPerson
        {
            get => _listPerson;
            set
            {
                _listPerson = value;

                personBindingSource.DataSource = _listPerson;
            }
        }

        List<Household> _listHousehold;
        /// <summary>
        /// 1 List&lt;Household&gt; dùng để binding với ListHousehold của pMain và pPerson.
        /// </summary>
        public List<Household> ListHousehold
        {
            get => _listHousehold;
            set
            {
                _listHousehold = value;

                householdBindingSource.DataSource = _listHousehold;
                householdBindingSource.ResetBindings(false);
            }
        }

        int _selectedID;
        /// <summary>
        /// Dùng để truyền ID vừa lựa chọn bằng nút btnSelect cho các page binding đến page này.
        /// </summary>
        public int SelectedID
        {
            get => _selectedID;
            set
            {
                _selectedID = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedID"));
            }
        }

        DisplayMode _mode;
        /// <summary>
        /// Thiết lập chế độ hiển thị cho pageHousehold.
        /// </summary>
        public DisplayMode Mode
        {
            get => _mode;
            set
            {
                _mode = value;
                ChangeDisplayMode(_mode);
            }
        }

        private Font _fontHeader;
        public Font HeaderFont
        {
            get => _fontHeader;
            set
            {
                _fontHeader = value;
                Help.SetHeaderFont(new List<DataGridView> { dtgvData, dtgvPerson }, _fontHeader);
            }
        }

        private Font _rowFont;
        public Font RowFont
        {
            get => _rowFont;
            set
            {
                _rowFont = value;
                Help.SetRowFont(new List<DataGridView> { dtgvData, dtgvPerson }, _rowFont);
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
                        btnSelect,
                        btnCancel
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
                        btnCancel,
                        labelStatistic
                    },
                    _textColor);
            }
        }

        #endregion
        public void ChangeDisplayMode(DisplayMode mode)
        {
            if(mode == DisplayMode.Normal)
            {
                panelSelect.Visible = false;

                btnInsert.Enabled = true;
                Help.SetPrivilege(AppSetting.Instance.HouseholdPrivilege, listPrivilege);
                panelLabel.Visible = true;
                panelStatistic.Visible = true;
                txbSearch.Properties.NullText = "Quản lý hộ khẩu";
                txbSearch.Properties.NullValuePrompt = "Quản lý hộ khẩu";
                return;
            }

            btnInsert.Enabled = false;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            panelLabel.Visible = false;
            panelStatistic.Visible = false;

            panelSelect.Top = 170;
            panelSelect.Visible = true;

            txbSearch.Properties.NullText = "Lựa chọn 1 hộ khẩu trong danh sách dưới đây";
            txbSearch.Properties.NullValuePrompt = "Lựa chọn 1 hộ khẩu trong danh sách dưới đây";

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
                btnSelect,
                btnCancel
            };

            dtgvData.DataSource = householdBindingSource;
            dtgvPerson.DataSource = personBindingSource;

            ListHousehold = HouseholdBUS.Instance.GetListHousehold();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ListHousehold"));

            FormatHousehold();

            //Khi mới khởi tạo pageHousehold hiển thị các chức năng CRUD bình thường
            Mode = DisplayMode.Normal;

            //Kết quả form trả về khi các nút này được click (trong DisplayMode.Select)
            btnCancel.DialogResult = DialogResult.Cancel;
            btnSelect.DialogResult = DialogResult.OK;

            AcceptButton = btnSearch;
        }

        void LoadBinding()
        {
            nmID.DataBindings.Add("Value", dtgvData.DataSource, "ID", false, DataSourceUpdateMode.Never);
            txbOwner.DataBindings.Add("Text", dtgvData.DataSource, "Owner", false, DataSourceUpdateMode.Never);
            txbAddress.DataBindings.Add("Text", dtgvData.DataSource, "Address", false, DataSourceUpdateMode.Never);
            nmMemberCount.DataBindings.Add("Value", dtgvData.DataSource, "MemberCount", false, DataSourceUpdateMode.Never);
        }

        void LoadEvent()
        {
            fInsert.GetInstance().HouseholdInserted += (s, e) =>
            {
                var household = (Household)(e as InsertedEventArgs).Inserted;
                //Thêm vào householdBindingSource để hiển thị lên dtgvData hiện tại (có thể đang hiện kết quả search)
                householdBindingSource.Add(household);
                //Thêm vào ListHousehold
                ListHousehold.Add(household);

                //Bôi đen hàng vừa thêm vào
                dtgvData.CurrentCell = dtgvData.Rows[dtgvData.RowCount - 1].Cells[1];

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ListHousehold"));
                ////LoadData(); 
            };

            btnShow.Click += delegate { ListHousehold = HouseholdBUS.Instance.GetListHousehold(); };

            btnInsert.Click += delegate { fInsert.GetInstance(InsertMode.Household).ShowDialog(); };

            btnDelete.Click += delegate { DeleteHousehold((int)nmID.Value); };

            btnUpdate.Click += delegate { UpdateHousehold((int)nmID.Value, txbOwner.Text, txbAddress.Text); };

            btnSearch.Click += delegate { SearchHousehold(txbSearch.Text); };

            //Khi nhận data lần đầu tiên
            //dtgvData.BindingContextChanged += delegate { FormatHousehold(); };

            //Click vào cell ID để chọn toàn bộ GridView
            dtgvData.CellClick += (s, e) => { if (e.ColumnIndex == 0 && e.RowIndex == -1) dtgvData.SelectAll(); };

            //Hiện thống kê về các hàng được chọn
            dtgvData.SelectionChanged += delegate { LoadStatistic(); };

            //Nhấn btnSelect (trong insert mode) sẽ gán giá trị cho SelectedID và thoát form
            btnSelect.Click += delegate { SelectedID = (int)nmID.Value; (Parent.Parent as Form).Close(); };

            //Nhấn btnCancel => thoát
            btnCancel.Click += delegate { (Parent.Parent as Form).Close(); };

            //Hiện các thành viên khi có hộ khẩu được chọn trên dtgvData
            dtgvData.CurrentCellChanged += delegate 
            {
                //Khi chưa click vào tabHousehold => chưa xảy ra binding => ListPerson chưa nhận giá trị
                if (ListPerson == null) return;

                var list = ListPerson.FindAll(person => person.HouseholdID == nmID.Value);

                personBindingSource.DataSource = list;

                dtgvPerson.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";

                dtgvPerson.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dtgvPerson.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dtgvPerson.Columns[0].HeaderText = "ID";
                dtgvPerson.Columns[1].HeaderText = "Họ tên";
                dtgvPerson.Columns[2].HeaderText = "Giới tính";
                dtgvPerson.Columns[3].HeaderText = "Ngày sinh";
                dtgvPerson.Columns[4].HeaderText = "CMND";
                dtgvPerson.Columns[5].HeaderText = "Quê quán";
                dtgvPerson.Columns[6].HeaderText = "ID Hộ";
                dtgvPerson.Columns[7].HeaderText = "Quan hệ";

                dtgvPerson.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dtgvPerson.Columns[0].Width = 40;
                dtgvPerson.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
                dtgvPerson.Columns[6].Width = 80;
            };
        }

        void LoadStatistic() => nmTotalHousehold.Value = dtgvData.SelectedRows.Count;

        void DeleteHousehold(int id)
        {
            if (MessageBox.Show($"Bạn thực sự muốn xoá hộ khẩu này?\n" +
                                $"ID:          {nmID.Text}\n" +
                                $"Chủ hộ: {txbOwner.Text}\n" +
                                $"Địa chỉ:  {txbAddress.Text}\n" +
                                $"Xoá hộ khẩu này sẽ xoá tất cả danh sách đóng góp và nộp tiền của nó.", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            if (HouseholdBUS.Instance.DeleteHousehold(id))
            {
                MessageBox.Show("Xoá hộ khẩu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Xoá trên GridView và notify thay đổi
                ListHousehold.RemoveAll(household => household.ID == id);

                householdBindingSource.RemoveCurrent();
                householdBindingSource.ResetBindings(false);

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ListHousehold"));

                //Xoá hộ khẩu sẽ không tự cập nhật lại thông tin trên DonateInfo và FeeInfo

                ////LoadData();

                return;
            }

            MessageBox.Show("Xoá hộ khẩu thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void UpdateHousehold(int id, string owner, string address)
        {
            if (MessageBox.Show($"Bạn muốn cập nhật hộ khẩu này?\n" +
                                $"ID:           {nmID.Text}\n" +
                                $"Chủ hộ:  {txbOwner.Text}\n" +
                                $"Địa chỉ:   {txbAddress.Text}", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            if (HouseholdBUS.Instance.UpdateHousehold(id, owner, address))
            {
                MessageBox.Show("Cập nhật nhân khẩu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //update lại hộ khẩu trên GridView
                var household = ListHousehold.Find(h => h.ID == id);
                household.Owner = owner;
                household.Address = address;
                householdBindingSource.ResetCurrentItem();
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ListHousehold"));

                ////LoadData();

                return;
            }

            MessageBox.Show("Cập nhật nhân khẩu thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        void SearchHousehold(string input) => householdBindingSource.DataSource = Help.Search(ListHousehold, input);
        //{
        //    //var list = new List<Household>(ListHousehold);

        //    //input = input.ToLower().ToUnsigned();

        //    //list.RemoveAll(household => household.Owner.ToUnsigned().ToLower().Contains(input) == false);

        //    dtgvData.DataSource = list;

        //    LoadBinding();
        //}

        void FormatHousehold()
        {
            dtgvData.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvData.Columns[3].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgvData.Columns[0].HeaderText = "ID";
            dtgvData.Columns[1].HeaderText = "Chủ hộ";
            dtgvData.Columns[2].HeaderText = "Địa chỉ";
            dtgvData.Columns[3].HeaderText = "Số thành viên";

            dtgvData.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dtgvData.Columns[0].Width = 40;
        }


    }

    
}
