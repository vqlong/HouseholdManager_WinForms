using DevExpress.Skins;
using DevExpress.Skins.XtraForm;
using DevExpress.Utils;
using DevExpress.Utils.Drawing;
using HouseholdManager.BUS;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace HouseholdManager.GUI
{
    public partial class fLogin : DevExpress.XtraEditors.XtraForm
    {
        public fLogin()
        {
            InitializeComponent();

            Initialize();

            LoadEvent();

        }


        /// <summary>
        /// Chứa form fMain mà form này tạo ra.
        /// </summary>
        public fMain FormMain { get; set; }

        /// <summary>
        /// Xảy ra khi 1 tài khoản đăng nhập thành công.
        /// </summary>
        public event EventHandler AccountLogin;

        void Initialize()
        {
            ReloadListUser();

            AcceptButton = btnLogin;

            var button = new Button();
            button.Click += delegate { Close(); };
            CancelButton = button;    

        }

        void LoadEvent()
        {
            //Load lại list UserName khi có 1 account mới được insert
            fInsert.GetInstance().AccountInserted += delegate { ReloadListUser(); };

            ckbShowPass.CheckedChanged += delegate { txbPassword.Properties.UseSystemPasswordChar = !ckbShowPass.Checked; };

            btnLogin.Click += delegate { Login(lkuUsername.Text, txbPassword.Text); };

            FormClosing += (s, e) => 
            {
                //Nếu fMain != null tức là fLogin đang được gọi từ cửa sổ fMain => chỉ ẩn đi mà không thoát
                if (FormMain != null)
                {
                    e.Cancel = true;

                    Hide();

                    FormMain.Enabled = true;

                    return;
                }

                if (MessageBox.Show("Bạn muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) e.Cancel = true; 
            };
        }

        void Login(string username, string password)
        {
            var account = AccountBUS.Instance.Login(username, password);

            if (account == null)
            {
                MessageBox.Show("Đăng nhập thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            AccountLogin?.Invoke(this, EventArgs.Empty);

            Help.Log.InfoFormat($"Login Account - Username: {username}, Displayname: {account.DisplayName}, Account Type: {account.Type}");

            //Truyền fLogin vào ngay khi khởi tạo fMain để tránh null exception tại các đoạn sử dụng thuộc tính FormLogin của fMain
            if (FormMain == null) FormMain = new fMain(this, account);           

            FormMain.Account = account;

            Hide();

            FormMain.Enabled = true;

            FormMain.Show();

            txbPassword.ResetText();
        }

        public void ReloadListUser() => lkuUsername.Properties.DataSource = AccountBUS.Instance.GetListUser();

        protected override FormPainter CreateFormBorderPainter()
        {
            return new MyFormPainter(this, DevExpress.LookAndFeel.UserLookAndFeel.Default.ActiveLookAndFeel);
        }
    }

    public class MyFormPainter : FormPainter
    {
        public MyFormPainter(Control owner, ISkinProvider provider) : base(owner, provider) { }

        //Đổi màu nền title bar của form
        protected override void DrawBackground(GraphicsCache cache)
        {
            //base.DrawBackground(cache);  
            cache.FillRectangle(Color.DarkViolet, CaptionBounds);
        }

        //Đổi font chữ title bar của form
        //protected override void DrawText(DevExpress.Utils.Drawing.GraphicsCache cache)
        //{
        //    string text = Text;
        //    if (text == null || text.Length == 0 || this.TextBounds.IsEmpty) return;
        //    AppearanceObject appearance = new AppearanceObject(GetDefaultAppearance());
        //    appearance.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular);
        //    appearance.TextOptions.Trimming = Trimming.EllipsisCharacter;
        //    Rectangle r = RectangleHelper.GetCenterBounds(TextBounds, new Size(TextBounds.Width, appearance.CalcDefaultTextSize(cache.Graphics).Height));
        //    DrawTextShadow(cache, appearance, r);
        //    cache.DrawString(text, appearance.Font, appearance.GetForeBrush(cache), r, appearance.GetStringFormat());
        //}

        protected override void DrawText(DevExpress.Utils.Drawing.GraphicsCache cache)
        {
            string text = Text;
            if (text == null || text.Length == 0 || this.TextBounds.IsEmpty) return;
            AppearanceObject appearance = new AppearanceObject(GetDefaultAppearance());
            appearance.Font = new Font("Tahoma", 12, FontStyle.Bold);
            appearance.TextOptions.Trimming = Trimming.EllipsisCharacter;
            Rectangle r = RectangleHelper.GetCenterBounds(TextBounds, new Size(TextBounds.Width, appearance.CalcDefaultTextSize(cache.Graphics).Height));
            DrawTextShadow(cache, appearance, r);
            cache.DrawString(text, appearance.Font, Brushes.WhiteSmoke, r, appearance.GetStringFormat());
        }
    }
}