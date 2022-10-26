using DevExpress.XtraEditors;
using Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HouseholdManager.GUI
{
    public partial class pageDonateInfo : DevExpress.XtraEditors.XtraUserControl
    {
        public pageDonateInfo()
        {
            InitializeComponent();

            Initialize();

            LoadBinding();

            LoadEvent();
        }

        #region Property

        BindingSource donateInfoBindingSource = new BindingSource();

        public SimpleButton AcceptButton { get; private set; }

        List<DonateInfo2> _listDonateInfo2;
        public List<DonateInfo2> ListDonateInfo2
        {
            get => _listDonateInfo2;
            set
            {
                _listDonateInfo2 = value;

                donateInfoBindingSource.DataSource = _listDonateInfo2;
                donateInfoBindingSource.ResetBindings(false);
                FormatDonateInfo();
            }
        }

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
                        btnDelete
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
                        labelStatistic
                    },
                    _textColor);
            }
        } 

        #endregion

        void Initialize()
        {
            dtgvData.DataSource = donateInfoBindingSource;

            AcceptButton = btnSearch;
        }

        void LoadBinding()
        {
            nmID.DataBindings.Add("Value", dtgvData.DataSource, "ID", false, DataSourceUpdateMode.Never);
            txbHousehold.DataBindings.Add("Text", dtgvData.DataSource, "Owner", false, DataSourceUpdateMode.Never);
            txbDonate.DataBindings.Add("Text", dtgvData.DataSource, "Name", false, DataSourceUpdateMode.Never);
            dtDate.DataBindings.Add("EditValue", dtgvData.DataSource, "DateContribute", false, DataSourceUpdateMode.Never);
            nmValue.DataBindings.Add("Value", dtgvData.DataSource, "Value", false, DataSourceUpdateMode.Never);

        }

        void LoadEvent()
        {
            btnShow.Click += delegate { donateInfoBindingSource.DataSource = ListDonateInfo2; };

            btnSearch.Click += delegate { SearchDonateInfo(txbSearch.Text); };

            //Click vào cell ID để chọn toàn bộ GridView
            dtgvData.CellMouseClick += (s, e) => { if (e.ColumnIndex == 0 && e.RowIndex == -1) dtgvData.SelectAll(); };

            //Hiện thống kê về các hàng được chọn
            dtgvData.SelectionChanged += delegate { LoadStatistic(); };
        }

        void FormatDonateInfo()
        {
            dtgvData.Columns[5].DefaultCellStyle.Format = "dd/MM/yyyy";
            dtgvData.Columns[6].DefaultCellStyle.FormatProvider = new System.Globalization.CultureInfo("vi-vn");
            dtgvData.Columns[6].DefaultCellStyle.Format = "c0";

            dtgvData.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvData.Columns[5].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvData.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtgvData.Columns[6].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dtgvData.Columns[0].HeaderText = "ID";
            dtgvData.Columns[1].Visible = false;
            dtgvData.Columns[2].Visible = false;
            dtgvData.Columns[3].HeaderText = "Hộ gia đình";
            dtgvData.Columns[4].HeaderText = "Khoản đóng góp";
            dtgvData.Columns[5].HeaderText = "Ngày đóng";
            dtgvData.Columns[6].HeaderText = "Số tiền";

            dtgvData.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dtgvData.Columns[0].Width = 40;
        }

        void LoadStatistic()
        {
            //Tạo list chứa những hàng được chọn trên GridView
            var list = new List<DonateInfo2>();
            foreach (DataGridViewRow row in dtgvData.SelectedRows)
            {
                list.Add(new DonateInfo2((int)row.Cells[0].Value,
                                         (int)row.Cells[1].Value,
                                         (int)row.Cells[2].Value,
                                              row.Cells[3].Value.ToString(),
                                              row.Cells[4].Value.ToString(),
                                    (DateTime)row.Cells[5].Value,
                                      (double)row.Cells[6].Value));
            }

            nmTotalValue.Value = (decimal)list.Sum(info => info.Value);
        }

        void SearchDonateInfo(string input) => donateInfoBindingSource.DataSource = Help.Search(ListDonateInfo2, input);

    }
}
