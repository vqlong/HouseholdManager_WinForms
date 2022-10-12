using DevExpress.Skins.XtraForm;
using DevExpress.XtraEditors;
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
    /// <summary>
    /// Form chứa 1 đối tượng pageHousehold hoặc pagePerson, dùng để lựa chọn 1 hộ khẩu hoặc nhân khẩu.
    /// <br>ID của hộ khẩu hoặc nhân khẩu được lựa chọn nằm trong thuộc tính SelectedID.</br>
    /// <br>Được khởi tạo 1 lần ở fMain, các page dùng chung.</br>
    /// </summary>
    public partial class fSelect : DevExpress.XtraEditors.XtraForm
    {
        private static readonly fSelect _instance = new fSelect();
        public static fSelect Instance => _instance;

        /// <summary>
        /// Khởi tạo thuộc tính Page cho form để nó có cái mà hiển thị.
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public static fSelect SetPage(IMode page)
        {
            _instance.Page = page;

            return _instance;
        }
        private fSelect()
        {
            InitializeComponent();

            Initialize();

            LoadEvent();
        }

        /// <summary>
        /// Chứa 1 đối tượng IMode được hiển thị trên form này. 
        /// </summary>
        public IMode Page { get; set; }

        void Initialize()
        {
            //Tạo nút thoát form khi nhấn ESC
            var button = new SimpleButton();
            button.Click += delegate { Close(); };
            CancelButton = button;

            //Mặc định form trả về Cancel (khi nhấn X)
            DialogResult = DialogResult.Cancel;
        }

        void LoadEvent()
        {
            Load += delegate
            {
                var page = Page as Control;
                pageContainer.Controls.Add(page);
                AcceptButton = Page.AcceptButton;
                page.Size = new Size(1200, 700);
                page.Left = 1;
                page.Top = 1;
                Page.Mode = DisplayMode.Select;
            };

            FormClosing += delegate 
            { 
                Page.Mode = DisplayMode.Normal;

                //Controls.Add(Page): Mỗi control chỉ add được 1 lần vào Controls (nếu có sẵn rồi sẽ không add)
                //trừ khi Page được gán lại
                //=> Clear cho chắc
                pageContainer.Controls.Clear();
            };
        }
        protected override FormPainter CreateFormBorderPainter()
        {
            return new MyFormPainter(this, DevExpress.LookAndFeel.UserLookAndFeel.Default.ActiveLookAndFeel);
        }
    }
}