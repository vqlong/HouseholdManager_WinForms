using Models;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace HouseholdManager.GUI
{
    public partial class pageSetting : DevExpress.XtraEditors.XtraUserControl
    {
        /// <summary>
        /// Chỉnh sửa Font và Color => gán lại cho AppSetting => binding đến các page.
        /// </summary>
        /// <param name="account"></param>
        public pageSetting(Account account)
        {
            InitializeComponent();

            Account = account;            
            
            LoadEvent();
        }

        public Account Account { get; set; }

        private Font _headerFont;
        public Font HeaderFont
        {
            get => _headerFont;
            set
            {
                _headerFont = value;

                LoadHeaderFont(_headerFont);
            }
        }

        private Font _rowFont;
        public Font RowFont
        {
            get => _rowFont;
            set
            {
                _rowFont = value;

                LoadRowFont(_rowFont);
            }
        }

        private Font _buttonFont;
        public Font ButtonFont 
        {
            get => _buttonFont;
            set
            {
                _buttonFont = value;

                LoadButtonFont(_buttonFont);

                Help.SetControlFont(
                    new List<Control> 
                    { 
                        btnButtonFont, 
                        btnHeaderFont, 
                        btnLabelFont, 
                        btnRowFont, 
                        btnTextColor,
                        btnSave,
                        btnDefault
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

                LoadLabelFont(_labelFont);
            }
        }

        private Color _textColor;
        public Color TextColor
        {
            get => _textColor;
            set
            {
                _textColor = value;

                LoadTextColor(_textColor);

                Help.SetTextColor(
                    new List<object>
                    {
                        btnButtonFont,
                        btnHeaderFont,
                        btnLabelFont,
                        btnRowFont,
                        btnTextColor,
                        btnDefault,
                        btnSave
                    }, 
                    _textColor);
            }
        }

        /// <summary>
        /// Hiển thị Font được chọn lên txbHeaderFont.
        /// </summary>
        /// <param name="font"></param>
        void LoadHeaderFont(Font font)
        {
            txbHeaderFont.Text = $"{font.Name}, {font.Size.ToString()}, {font.Style.ToString()}";
            txbHeaderFont.Font = font;
        }

        void LoadRowFont(Font font)
        {
            txbRowFont.Text = $"{font.Name}, {font.Size.ToString()}, {font.Style.ToString()}";
            txbRowFont.Font = font;
        }

        void LoadButtonFont(Font font)
        {
            txbButtonFont.Text = $"{font.Name}, {font.Size.ToString()}, {font.Style.ToString()}";
            txbButtonFont.Font = font;
            txbButtonFont.ForeColor = txbTextColor.ForeColor;
        }

        void LoadLabelFont(Font font)
        {
            txbLabelFont.Text = $"{font.Name}, {font.Size.ToString()}, {font.Style.ToString()}";
            txbLabelFont.Font = font;
            txbLabelFont.ForeColor = txbTextColor.ForeColor;
        }

        void LoadTextColor(Color color)
        {
            txbTextColor.Text = $"Màu chữ: {color.Name}";
            txbTextColor.Font = txbButtonFont.Font;
            txbTextColor.ForeColor = color;
        }

        void LoadEvent()
        {
            btnHeaderFont.Click += delegate
            {
                FontDialog fontDialog = new FontDialog();
                if(fontDialog.ShowDialog() == DialogResult.OK)
                {
                    AppSetting.Instance.HeaderFont = fontDialog.Font;
                }
            };

            btnRowFont.Click += delegate
            {
                FontDialog fontDialog = new FontDialog();
                if (fontDialog.ShowDialog() == DialogResult.OK)
                {
                    AppSetting.Instance.RowFont = fontDialog.Font;
                }
            };

            btnButtonFont.Click += delegate
            {
                FontDialog fontDialog = new FontDialog();
                if (fontDialog.ShowDialog() == DialogResult.OK)
                {
                    AppSetting.Instance.ButtonFont = fontDialog.Font;
                }
            };

            btnLabelFont.Click += delegate
            {
                FontDialog fontDialog = new FontDialog();
                if (fontDialog.ShowDialog() == DialogResult.OK)
                {
                    AppSetting.Instance.LabelFont = fontDialog.Font;
                }
            };

            btnTextColor.Click += delegate
            {
                ColorDialog colorDialog = new ColorDialog();
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    AppSetting.Instance.TextColor = colorDialog.Color;
                }
            };

            btnSave.Click += delegate 
            { 
                var result = AppSetting.SaveSetting(Account.Username);

                if (result)
                {
                    MessageBox.Show("Lưu cài đặt thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return;
                }

                MessageBox.Show("Lưu cài đặt thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };

            btnDefault.Click += delegate { AppSetting.LoadDefault(); };
      
        }
    }
}
