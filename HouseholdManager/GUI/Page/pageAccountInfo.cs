using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit.API.Native;
using DevExpress.XtraRichEdit.API.Native.Implementation;
using HouseholdManager.BUS;
using HouseholdManager.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HouseholdManager.GUI
{
    public partial class pageAccountInfo : DevExpress.XtraEditors.XtraUserControl
    {
        public pageAccountInfo(Account account)
        {
            InitializeComponent();

            Initialize();

            LoadEvent();

            Account = account;
        }

        public event EventHandler AccountChanged;

        Account _account;
        public Account Account
        {
            get => _account;
            set
            {
                _account = value;

                ShowAccountInfo(_account);
            }
        }

        public SimpleButton AcceptButton { get; set; }

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
                        btnPrintDialog,
                        btnPrintPreview,
                        btnPrint,
                        btnExportToPdf,
                        btnSaveChange
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
                        btnPrintDialog,
                        btnPrintPreview,
                        btnPrint,
                        btnExportToPdf,
                        btnSaveChange
                    },
                    _textColor);
            }
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

            AcceptButton = btnSearch;
        }

        void ShowAccountInfo(Account account)
        {
            if(account.Username != txbUsername.Text)
            {
                txbUsername.Text = account.Username;
                txbDisplayName.Text = account.DisplayName;
                lkuAccountType.EditValue = account.Type;
                richNote.Text = account.Note;
                txbPassword.ResetText();
                txbNewPassword.ResetText();
                txbConfirmPassword.ResetText();
                ckbShowPass.Checked = false;
            }           
        }

        void LoadEvent()
        {
            btnSearch.Click += delegate { Search(txbSearch.Text); };

            ckbShowPass.CheckedChanged += delegate 
            { 
                txbPassword.Properties.UseSystemPasswordChar = 
                txbNewPassword.Properties.UseSystemPasswordChar = 
                txbConfirmPassword.Properties.UseSystemPasswordChar = !ckbShowPass.Checked; 
            };

            btnSaveChange.Click += delegate { SaveChange(txbUsername.Text, txbPassword.Text, txbDisplayName.Text, txbNewPassword.Text, richNote.Text); };

            btnPrintDialog.Click += delegate
            {
                if (richNote.IsPrintingAvailable)
                {
                    richNote.ShowPrintDialog();
                    return;
                }

                MessageBox.Show("Lỗi.\n[XtraPrinting Library is not available]", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };

            btnPrintPreview.Click += delegate { richNote.ShowPrintPreview(); };

            btnPrint.Click += delegate { richNote.Print(); };

            btnExportToPdf.Click += delegate
            {
                var dialog = new SaveFileDialog();

                dialog.DefaultExt = ".pdf";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    richNote.ExportToPdf(dialog.FileName);
                }
            };

            //Xoá bôi đen kết quả tìm kiếm
            richNote.Click += delegate
            {
                if (range != null)
                {
                    var section = richNote.Document.BeginUpdateCharacters(range);
                    section.ForeColor = SystemColors.WindowText;
                    section.BackColor = SystemColors.Window;
                    richNote.Document.EndUpdateCharacters(section);

                    //Xoá xong, gán lại null để lần tìm kiếm tiếp theo bắt đầu từ đầu
                    findText = "";
                    this.result = null;
                    range = null;
                }
            };
        }

        void SaveChange(string username, string password, string displayname, string newpassword, string note)
        {
            if (MessageBox.Show($"Bạn muốn lưu lại thay đổi cho tài khoản này?\n" +
                                $"Tên đăng nhập: {txbUsername.Text}\n" +
                                $"Tên hiển thị:      {txbDisplayName.Text}\n" +
                                $"Loại tài khoản:  {lkuAccountType.Text}", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            //Kiểm tra ô mật khẩu
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Nhập vào mật khẩu hiện tại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Kiểm tra displayname
            var match = Regex.Match(displayname, @".{5,}");
            if (match.Value.Equals(displayname) == false)
            {
                MessageBox.Show("Tên hiển thị ít nhất phải có 5 ký tự.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Nếu nhập vào newpassword thì kiểm tra newpassword
            if (!string.IsNullOrEmpty(newpassword))
            {
                match = Regex.Match(newpassword, @"^[a-zA-Z][a-zA-Z0-9]{4,}");
                if (match.Value.Equals(newpassword) == false)
                {
                    MessageBox.Show("Mật khẩu ít nhất phải có 5 ký tự a - z, A - Z, 0 - 9.\n" +
                                    "Ký tự đầu tiên không được là chữ số.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (newpassword.Equals(txbConfirmPassword.Text) == false)
                {
                    MessageBox.Show("Xác nhận lại mật khẩu mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            //Kiểm tra tài khoản
            if(AccountBUS.Instance.Login(username, password) == null)
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Luôn cập nhật Note khi ấn btnSaveChange
            var result = AccountBUS.Instance.UpdateAccount(username, displayname, newpassword, note, null);

            if (result.Item1 && !result.Item2)
            {
                MessageBox.Show("Cập nhật tên hiển thị thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Account.DisplayName = displayname;
                AccountChanged?.Invoke(this, EventArgs.Empty);
            }

            if (result.Item2 && result.Item1)
            {
                MessageBox.Show("Cập nhật tên hiển thị và mật khẩu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Account.DisplayName = displayname;
                AccountChanged?.Invoke(this, EventArgs.Empty);
            }


            if (!result.Item1 && !result.Item2 && !result.Item3) MessageBox.Show("Cập nhật thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        public void SaveNote() => AccountBUS.Instance.UpdateAccount(txbUsername.Text, null, null, richNote.Text, null);


        #region txbSearch

        //Chứa kết quả (kiểu ISearchResult) của lần tìm kiếm gần nhất
        NativeSearchResultBase result;
        //Chứa thuộc tính FindText của result
        string findText = "";
        //1 kiểu DocumentRange chứa CurrentResult của result
        DocumentRange range;
        void Search(string input)
        {
            //Xoá bôi đen kết quả trước
            if (range != null)
            {
                var section = richNote.Document.BeginUpdateCharacters(range);
                section.ForeColor = SystemColors.WindowText;
                section.BackColor = SystemColors.Window;
                richNote.Document.EndUpdateCharacters(section);
            }

            //Lấy ra thuộc tính FindText của result
            NativeSearchResultBase result = (NativeSearchResultBase)richNote.Document.StartSearch(input);
            var infoFindText = typeof(NativeSearchResultBase).GetProperty("FindText", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            string text = infoFindText.GetValue(result).ToString();

            //Kiểm tra nếu FindText khác nhau thì gán lại
            //bằng nhau thì bỏ qua và tìm kiếm kết quả tiếp theo
            if (findText.Equals(text) == false)
            {
                findText = text;
                this.result = result;
            }

            //Tìm và bôi đen kết quả tiếp theo
            if (this.result.FindNext())
            {
                range = this.result.CurrentResult;
                var section = richNote.Document.BeginUpdateCharacters(range);
                section.ForeColor = SystemColors.HighlightText;
                section.BackColor = SystemColors.Highlight;
                richNote.Document.EndUpdateCharacters(section);
            }
            else
            {
                //Nếu không tìm thấy, gán lại null để lần tìm kiếm tiếp theo bắt đầu từ đầu
                findText = "";
                this.result = null;
                range = null;
            }
        } 

        #endregion
    }
}
