using DevExpress.Skins.XtraForm;
using DevExpress.XtraEditors;
using HouseholdManager.BUS;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace HouseholdManager.GUI
{
    public partial class fInsert : DevExpress.XtraEditors.XtraForm
    {
        private static readonly fInsert _instance = new fInsert();
        public static fInsert GetInstance() => _instance;
        public static fInsert GetInstance(InsertMode mode)
        {
            _instance.Mode = mode;

            return _instance;
        }
        private fInsert()
        {
            InitializeComponent();

            LoadEvent();

            Initialize();
        }


        /// <summary>
        /// Xảy ra khi 1 Person mới được thêm vào cơ sở dữ liệu.
        /// </summary>
        public event EventHandler PersonInserted;

        /// <summary>
        /// Xảy ra khi 1 Household mới được thêm vào cơ sở dữ liệu.
        /// </summary>
        public event EventHandler HouseholdInserted;

        public event EventHandler AccountInserted;

        public event EventHandler DonateInserted;

        public event EventHandler FeeInserted;

        InsertMode _mode;
        /// <summary>
        /// Báo cho form fInsert biết nó được gọi ra để insert cái gì.
        /// </summary>
        public InsertMode Mode 
        {
            get => _mode;
            set
            {
                _mode = value;

                ChangeMode(_mode);
            }
        }

        void ChangeMode(InsertMode mode)
        {
            //Làm trống form
            panelPerson.Visible = false;
            panelPerson.Left = 450;

            panelHousehold.Visible = false;
            panelHousehold.Left = 450;

            panelAccount.Visible = false;
            panelAccount.Left = 450;

            panelDonate.Visible = false;
            panelDonate.Left = 450;

            panelFee.Visible = false;
            panelFee.Left = 450;


            //Xoá hết các event trong btnInsert.Click
            FieldInfo EventClickInfo = typeof(Control).GetField("EventClick", BindingFlags.Static | BindingFlags.NonPublic);
            object key = EventClickInfo.GetValue(btnInsert);

            PropertyInfo EventsInfo = typeof(Control).GetProperty("Events", BindingFlags.Instance | BindingFlags.NonPublic);
            EventHandlerList Events = (EventHandlerList)EventsInfo.GetValue(btnInsert);

            Events.RemoveHandler(key, Events[key]);

            //Tuỳ theo mode, hiện ra panel và đặt event tương ứng
            if (mode == InsertMode.Person)
            {
                Text = "Thêm nhân khẩu";
                panelPerson.Visible = true;
                panelPerson.Left = 8;
                btnInsert.Click += (s, e) => InsertPerson();
                txbNamePerson.Select();
            }

            if(mode == InsertMode.Household)
            {
                Text = "Thêm hộ khẩu";
                panelHousehold.Visible = true;
                panelHousehold.Left = 8;
                btnInsert.Click += (s, e) => InsertHousehold();
                txbOwner.Select();
            }

            if(mode == InsertMode.Account)
            {
                Text = "Thêm tài khoản";
                panelAccount.Visible = true;
                panelAccount.Left = 8;
                btnInsert.Click += (s, e) => InsertAccount();
                txbUserName.Select();
            }

            if (mode == InsertMode.Donate)
            {
                Text = "Thêm đóng góp";
                panelDonate.Visible = true;
                panelDonate.Left = 8;
                panelDonate.Top = 12;
                btnInsert.Click += (s, e) => InsertDonate();
                txbNameDonate.Select();
            }

            if (mode == InsertMode.Fee)
            {
                Text = "Thêm thu phí";
                panelFee.Visible = true;
                panelFee.Left = 8;
                panelFee.Top = 12;
                btnInsert.Click += (s, e) => InsertFee();
                txbNameFee.Select();
            }
        }

        void Initialize()
        {
            //Khởi tạo DataSource cho các ComboBox
            var listGender = new List<Tuple<string, PersonGender>>()
            {
                new Tuple<string, PersonGender>( "Nam", PersonGender.Male ),
                new Tuple<string, PersonGender>( "Nữ", PersonGender.Female )
            };
            lkuGender.Properties.DataSource = listGender;
            lkuGender.Properties.DisplayMember = "Item1";
            lkuGender.Properties.ValueMember = "Item2";
            lkuGender.Properties.ShowFooter = false;
            lkuGender.Properties.ShowHeader = false;
            lkuGender.Properties.ShowLines = false;

            var listRelation = new List<Tuple<string, HouseholdRelation>>()
            {
               new Tuple<string, HouseholdRelation>( "Chủ hộ", HouseholdRelation.Owner ),
               new Tuple<string, HouseholdRelation>( "Vợ", HouseholdRelation.Wife ),
               new Tuple<string, HouseholdRelation>( "Chồng", HouseholdRelation.Husband ),
               new Tuple<string, HouseholdRelation>( "Con trai", HouseholdRelation.Son ),
               new Tuple<string, HouseholdRelation>( "Con gái", HouseholdRelation.Daughter ),
               new Tuple<string, HouseholdRelation>( "Cha", HouseholdRelation.Father ),
               new Tuple<string, HouseholdRelation>( "Mẹ", HouseholdRelation.Mother ),
               new Tuple<string, HouseholdRelation>( "Ông", HouseholdRelation.Grandfather ),
               new Tuple<string, HouseholdRelation>( "Bà", HouseholdRelation.Grandmother ),
               new Tuple<string, HouseholdRelation>( "Cháu trai", HouseholdRelation.Grandson ),
               new Tuple<string, HouseholdRelation>( "Cháu gái", HouseholdRelation.Granddaughter ),
               //new Tuple<string, HouseholdRelation>( "Đối tượng tạm trú", HouseholdRelation.TemporaryResidence ),
            };
            lkuRelation.Properties.DataSource = listRelation;
            lkuRelation.Properties.DisplayMember = "Item1";
            lkuRelation.Properties.ValueMember = "Item2";
            lkuRelation.Properties.ShowFooter = false;
            lkuRelation.Properties.ShowHeader = false;
            lkuRelation.Properties.ShowLines = false;

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

            Size = new Size(427, 427);

            
            Mode = InsertMode.Person;
        }

        void LoadEvent()
        {
            ckbRegisterTemp.CheckedChanged += delegate { nmHouseholdID.Enabled = lkuRelation.Enabled = !ckbRegisterTemp.Checked; };

            btnCancel.Click += delegate { Close(); };

            btnReset.Click += delegate { ResetText(Mode); };

        }

        void ResetText(InsertMode mode)
        {
            var panel = new Panel();

            if (mode == InsertMode.Person) panel = panelPerson;
            if (mode == InsertMode.Household) panel = panelHousehold;
            if (mode == InsertMode.Account) panel = panelAccount;
            if (mode == InsertMode.Donate) panel = panelDonate;
            if (mode == InsertMode.Fee) panel = panelFee;

            foreach (Control control in panel.Controls)
            {
                if (!(control is Label) && !(control is CheckEdit)) control.ResetText();
            }
        }

        void InsertPerson()
        {
            if (string.IsNullOrEmpty(txbNamePerson.Text) || string.IsNullOrEmpty(lkuGender.Text) || string.IsNullOrEmpty(dtDateOfBirth.Text) || string.IsNullOrEmpty(txbCmnd.Text) || string.IsNullOrEmpty(txbAddressPerson.Text))
            {
                MessageBox.Show("Không được để trống bất cứ mục nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(lkuRelation.Text) && ckbRegisterTemp.Checked == false)
            {
                MessageBox.Show("Không được để trống bất cứ mục nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Thêm người địa phương
            if (ckbRegisterTemp.Checked == false)
            {
                var person = PersonBUS.Instance.InsertPerson(txbNamePerson.Text, Convert.ToInt32(lkuGender.EditValue), dtDateOfBirth.Text, txbCmnd.Text, txbAddressPerson.Text, (int)nmHouseholdID.Value, Convert.ToInt32(lkuRelation.EditValue));
                if (person != null)
                {
                    MessageBox.Show("Thêm nhân khẩu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    PersonInserted?.Invoke(this, new InsertedEventArgs(person));

                    ResetText(InsertMode.Person);

                    return;
                }
            }
            else
            {
                //Tạm trú
                var person = PersonBUS.Instance.InsertPerson(txbNamePerson.Text, Convert.ToInt32(lkuGender.EditValue), dtDateOfBirth.Text, txbCmnd.Text, txbAddressPerson.Text, 1, 12);
                if (person != null)
                {
                    MessageBox.Show("Thêm nhân khẩu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    PersonInserted?.Invoke(this, new InsertedEventArgs(person));

                    ResetText(InsertMode.Person);

                    return;
                }
            }          

            MessageBox.Show("Thêm nhân khẩu thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);

        }

        void InsertHousehold()
        {
            if (string.IsNullOrEmpty(txbOwner.Text) || string.IsNullOrEmpty(txbAddressHousehold.Text))
            {
                MessageBox.Show("Không được để trống bất cứ mục nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var household = HouseholdBUS.Instance.InsertHousehold(txbOwner.Text, txbAddressHousehold.Text);
            if (household != null)
            {
                MessageBox.Show("Thêm hộ khẩu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                HouseholdInserted?.Invoke(this, new InsertedEventArgs(household));

                ResetText(InsertMode.Household);

                return;
            }

            MessageBox.Show("Thêm hộ khẩu thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);

        }

        void InsertAccount()
        {
            if (string.IsNullOrEmpty(txbUserName.Text))
            {
                MessageBox.Show("Không được để trống bất cứ mục nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var account = AccountBUS.Instance.InsertAccount(txbUserName.Text);
            if (account != null)
            {
                MessageBox.Show("Thêm tài khoản thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                AccountInserted?.Invoke(this, new InsertedEventArgs(account));

                ResetText(InsertMode.Account);

                return;
            }

            MessageBox.Show("Thêm tài khoản thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);

        }

        void InsertDonate()
        {
            if (string.IsNullOrEmpty(txbNameDonate.Text) || string.IsNullOrEmpty(dtDateAriseDonate.Text) || string.IsNullOrEmpty(nmMinValue.Text))
            {
                MessageBox.Show("Không được để trống bất cứ mục nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var donate = DonateBUS.Instance.InsertDonate(txbNameDonate.Text, dtDateAriseDonate.Text, (double)nmMinValue.Value);
            if (donate != null)
            {
                MessageBox.Show("Thêm đóng góp thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DonateInserted?.Invoke(this, new InsertedEventArgs(donate));

                ResetText(InsertMode.Donate);

                return;
            }

            MessageBox.Show("Thêm đóng góp thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);

        }

        void InsertFee()
        {
            if (string.IsNullOrEmpty(txbNameFee.Text) || string.IsNullOrEmpty(dtDateAriseFee.Text) || string.IsNullOrEmpty(nmValue.Text) || string.IsNullOrEmpty(lkuFactor.Text))
            {
                MessageBox.Show("Không được để trống bất cứ mục nào.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var fee = FeeBUS.Instance.InsertFee(txbNameFee.Text, dtDateAriseFee.Text, (double)nmValue.Value, Convert.ToInt32(lkuFactor.EditValue));
            if (fee != null)
            {
                MessageBox.Show("Thêm thu phí thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                FeeInserted?.Invoke(this, new InsertedEventArgs(fee));

                ResetText(InsertMode.Fee);

                return;
            }

            MessageBox.Show("Thêm thu phí thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        protected override FormPainter CreateFormBorderPainter()
        {
            return new MyFormPainter(this, DevExpress.LookAndFeel.UserLookAndFeel.Default.ActiveLookAndFeel);
        }
    }

    /// <summary>
    /// Báo cho form fInsert biết nó được gọi ra để insert cái gì.
    /// </summary>
    public enum InsertMode
    {
        Person = 1,
        Household = 2,
        Donate = 3,
        Fee = 4,
        Account = 5
    }

    /// <summary>
    /// Thông tin về item vừa được insert xuống database.
    /// </summary>
    public class InsertedEventArgs : EventArgs
    {
        public InsertedEventArgs(object inserted)
        {
            Inserted = inserted;
        }

        /// <summary>
        /// Trả về đối tượng được insert thành công.
        /// </summary>
        public object Inserted { get; set; }
    }
}