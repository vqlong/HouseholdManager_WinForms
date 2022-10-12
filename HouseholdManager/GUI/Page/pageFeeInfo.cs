using DevExpress.XtraEditors;
using HouseholdManager.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HouseholdManager.GUI
{
    public partial class pageFeeInfo : DevExpress.XtraEditors.XtraUserControl
    {
        public pageFeeInfo()
        {
            InitializeComponent();

            Initialize();

            LoadData();

            LoadEvent();
        }

        BindingSource feeInfoBindingSource = new BindingSource();

        public SimpleButton AcceptButton { get; private set; }

        List<FeeInfo2> _listFeeInfo2;     
        public List<FeeInfo2> ListFeeInfo2
        {
            get => _listFeeInfo2;
            set
            {
                _listFeeInfo2 = value;

                feeInfoBindingSource.DataSource = _listFeeInfo2;
                feeInfoBindingSource.ResetBindings(false);
                FormatFeeInfo();
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
                Help.SetButtonFont(
                    new List<SimpleButton>
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

        void Initialize()
        {
            AcceptButton = btnSearch;
        }

        void LoadData()
        {
            dtgvData.DataSource = feeInfoBindingSource;        

            LoadBinding();
        }

        void LoadBinding()
        {
            foreach (Control control in panelInfo.Controls)
            {
                if (!(control is Label) && !(control is SimpleButton)) control.DataBindings.Clear();
            }

            nmID.DataBindings.Add("Value", dtgvData.DataSource, "ID", false, DataSourceUpdateMode.Never);
            txbHousehold.DataBindings.Add("Text", dtgvData.DataSource, "Owner", false, DataSourceUpdateMode.Never);
            txbFee.DataBindings.Add("Text", dtgvData.DataSource, "Name", false, DataSourceUpdateMode.Never);
            dtDate.DataBindings.Add("EditValue", dtgvData.DataSource, "DatePay", false, DataSourceUpdateMode.Never);
            nmValue.DataBindings.Add("Value", dtgvData.DataSource, "Value", false, DataSourceUpdateMode.Never);

        }

        void LoadEvent()
        {
            btnShow.Click += delegate { LoadData(); };

            btnSearch.Click += delegate { SearchDonateInfo(txbSearch.Text); };

            //Click vào cell ID để chọn toàn bộ GridView
            dtgvData.CellMouseClick += (s, e) => { if (e.ColumnIndex == 0 && e.RowIndex == -1) dtgvData.SelectAll(); };

            //Hiện thống kê về các hàng được chọn
            dtgvData.SelectionChanged += delegate { LoadStatistic(); };
        }

        void FormatFeeInfo()
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
            dtgvData.Columns[4].HeaderText = "Khoản thu phí";
            dtgvData.Columns[5].HeaderText = "Ngày nộp tiền";
            dtgvData.Columns[6].HeaderText = "Số tiền";

            dtgvData.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dtgvData.Columns[0].Width = 40;
        }

        void LoadStatistic()
        {
            //Tạo list chứa những hàng được chọn trên GridView
            var list = new List<FeeInfo2>();
            foreach (DataGridViewRow row in dtgvData.SelectedRows)
            {
                list.Add(new FeeInfo2((int)row.Cells[0].Value,
                                      (int)row.Cells[1].Value,
                                      (int)row.Cells[2].Value,
                                           row.Cells[3].Value.ToString(),
                                           row.Cells[4].Value.ToString(),
                                 (DateTime)row.Cells[5].Value,
                                   (double)row.Cells[6].Value));
            }

            nmTotalValue.Value = (decimal)list.Sum(info => info.Value);
        }

        void SearchDonateInfo(string input)
        {
            var list = new List<FeeInfo2>(ListFeeInfo2);

            input = input.ToLower().ToUnsigned();

            list.RemoveAll(info => info.Name.ToUnsigned().ToLower().Contains(input) == false
                                && info.Owner.ToUnsigned().ToLower().Contains(input) == false
                                && info.DatePay.ToString("dd/MM/yyyy").ToUnsigned().ToLower().Contains(input) == false);

            dtgvData.DataSource = list;

            LoadBinding();
        }
    }
}
