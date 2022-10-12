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
    public partial class fDialogBox : DevExpress.XtraEditors.XtraForm
    {
        public fDialogBox(string text, string caption, string text3 = "Huỷ", string text2 = null, string text1 = null)
        {
            InitializeComponent();

            lbText.Text = text;
            lbText.Top = (panelText.Height - lbText.Height) / 2;
            Text = caption;

            //Form trả về kết quả DialogResult theo Button được click
            Button3.DialogResult = DialogResult.Cancel;
            Button3.Text = text3;
            Button3.Click += delegate { Close(); };
            AcceptButton = Button3;

            //Không click Button nào sẽ trả về mặc định
            DialogResult = DialogResult.Cancel;

            Button2.DialogResult = DialogResult.No;
            if (text2 == null) Button2.Visible = false;
            Button2.Text = text2;
            Button2.Click += delegate { Close(); };

            Button1.DialogResult = DialogResult.Yes;
            if (text1 == null) Button1.Visible = false;
            Button1.Text = text1;
            Button1.Click += delegate { Close(); };

        }

        protected override FormPainter CreateFormBorderPainter()
        {
            return new MyFormPainter(this, DevExpress.LookAndFeel.UserLookAndFeel.Default.ActiveLookAndFeel);
        }
    }
}