using Models;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace HouseholdManager.GUI
{
    public partial class fMain : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm, INotifyPropertyChanged
    {
        #region  Các page tương ứng khi click vào từng tab
        
        pagePerson pPerson;
        pageHousehold pHousehold;
        pageDonate pDonate;
        pageDonateInfo pDonateInfo;
        pageFee pFee;
        pageFeeInfo pFeeInfo;
        pageMain pMain;
        pageAccountInfo pAccountInfo;
        pageAdmin pAdmin;
        pageSetting pSetting;

        #endregion
        public fMain(fLogin fLogin , Account account) 
        {
            InitializeComponent();

            FormLogin = fLogin;

            Account = account;

            Initialize();

            LoadBinding();

            LoadEvent();                     
        
        }

        Account _account;       

        public Account Account 
        { 
            get => _account;
            set
            {
                _account = value;

                Text = $"Quản lý hộ khẩu [{_account.DisplayName}]";

                AppSetting.LoadSetting(_account.Setting);

                SetAccountPrivilege(_account.Type);

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Account"));
            }
        }

        /// <summary>
        /// Chứa form fLogin tạo ra form này.
        /// </summary>
        public fLogin FormLogin { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        void Initialize()
        {
            pMain = new pageMain(Account);
            pPerson = new pagePerson(Account);
            pHousehold = new pageHousehold(Account);
            pDonate = new pageDonate(Account);
            pDonateInfo = new pageDonateInfo();
            pFee = new pageFee(Account);
            pFeeInfo = new pageFeeInfo();
            pAccountInfo = new pageAccountInfo(Account);
            pAdmin = new pageAdmin(Account);
            pSetting = new pageSetting(Account);

            fSelect.SetPage(pHousehold); 
          
        }

        void LoadBinding()
        {
            //Binding với AppSetting để cập nhật Font và Color mỗi khi thay đổi
            pMain.DataBindings.Add("ListPerson", pPerson, "ListPerson", false, DataSourceUpdateMode.Never);
            pMain.DataBindings.Add("ListHousehold", pHousehold, "ListHousehold", false, DataSourceUpdateMode.Never);
            pMain.DataBindings.Add("ListDonateInfo2", pDonate, "ListDonateInfo2", false, DataSourceUpdateMode.Never);
            pMain.DataBindings.Add("ListFeeInfo2", pFee, "ListFeeInfo2", false, DataSourceUpdateMode.Never);
            pMain.DataBindings.Add("LabelFont", AppSetting.Instance, "LabelFont", false, DataSourceUpdateMode.Never);
            pMain.DataBindings.Add("TextColor", AppSetting.Instance, "TextColor", false, DataSourceUpdateMode.Never);

            pPerson.DataBindings.Add("SelectedHouseholdID", pHousehold, "SelectedID", false, DataSourceUpdateMode.Never);
            pPerson.DataBindings.Add("ListHousehold", pHousehold, "ListHousehold", false, DataSourceUpdateMode.OnPropertyChanged);
            pPerson.DataBindings.Add("HeaderFont", AppSetting.Instance, "HeaderFont", false, DataSourceUpdateMode.Never);
            pPerson.DataBindings.Add("RowFont", AppSetting.Instance, "RowFont", false, DataSourceUpdateMode.Never);
            pPerson.DataBindings.Add("ButtonFont", AppSetting.Instance, "ButtonFont", false, DataSourceUpdateMode.Never);
            pPerson.DataBindings.Add("LabelFont", AppSetting.Instance, "LabelFont", false, DataSourceUpdateMode.Never);
            pPerson.DataBindings.Add("TextColor", AppSetting.Instance, "TextColor", false, DataSourceUpdateMode.Never);

            pHousehold.DataBindings.Add("ListPerson", pPerson, "ListPerson", false, DataSourceUpdateMode.Never);
            pHousehold.DataBindings.Add("HeaderFont", AppSetting.Instance, "HeaderFont", false, DataSourceUpdateMode.Never);
            pHousehold.DataBindings.Add("RowFont", AppSetting.Instance, "RowFont", false, DataSourceUpdateMode.Never);
            pHousehold.DataBindings.Add("ButtonFont", AppSetting.Instance, "ButtonFont", false, DataSourceUpdateMode.Never);
            pHousehold.DataBindings.Add("LabelFont", AppSetting.Instance, "LabelFont", false, DataSourceUpdateMode.Never);
            pHousehold.DataBindings.Add("TextColor", AppSetting.Instance, "TextColor", false, DataSourceUpdateMode.Never);

            pDonate.DataBindings.Add("SelectedHouseholdID", pHousehold, "SelectedID", false, DataSourceUpdateMode.Never);
            pDonate.DataBindings.Add("HeaderFont", AppSetting.Instance, "HeaderFont", false, DataSourceUpdateMode.Never);
            pDonate.DataBindings.Add("RowFont", AppSetting.Instance, "RowFont", false, DataSourceUpdateMode.Never);
            pDonate.DataBindings.Add("ButtonFont", AppSetting.Instance, "ButtonFont", false, DataSourceUpdateMode.Never);
            pDonate.DataBindings.Add("LabelFont", AppSetting.Instance, "LabelFont", false, DataSourceUpdateMode.Never);
            pDonate.DataBindings.Add("TextColor", AppSetting.Instance, "TextColor", false, DataSourceUpdateMode.Never);

            pFee.DataBindings.Add("SelectedHouseholdID", pHousehold, "SelectedID", false, DataSourceUpdateMode.Never);
            pFee.DataBindings.Add("HeaderFont", AppSetting.Instance, "HeaderFont", false, DataSourceUpdateMode.Never);
            pFee.DataBindings.Add("RowFont", AppSetting.Instance, "RowFont", false, DataSourceUpdateMode.Never);
            pFee.DataBindings.Add("ButtonFont", AppSetting.Instance, "ButtonFont", false, DataSourceUpdateMode.Never);
            pFee.DataBindings.Add("LabelFont", AppSetting.Instance, "LabelFont", false, DataSourceUpdateMode.Never);
            pFee.DataBindings.Add("TextColor", AppSetting.Instance, "TextColor", false, DataSourceUpdateMode.Never);

            pDonateInfo.DataBindings.Add("ListDonateInfo2", pDonate, "ListDonateInfo2", false, DataSourceUpdateMode.Never);
            pDonateInfo.DataBindings.Add("HeaderFont", AppSetting.Instance, "HeaderFont", false, DataSourceUpdateMode.Never);
            pDonateInfo.DataBindings.Add("RowFont", AppSetting.Instance, "RowFont", false, DataSourceUpdateMode.Never);
            pDonateInfo.DataBindings.Add("ButtonFont", AppSetting.Instance, "ButtonFont", false, DataSourceUpdateMode.Never);
            pDonateInfo.DataBindings.Add("LabelFont", AppSetting.Instance, "LabelFont", false, DataSourceUpdateMode.Never);
            pDonateInfo.DataBindings.Add("TextColor", AppSetting.Instance, "TextColor", false, DataSourceUpdateMode.Never);

            pFeeInfo.DataBindings.Add("ListFeeInfo2", pFee, "ListFeeInfo2", false, DataSourceUpdateMode.Never);
            pFeeInfo.DataBindings.Add("HeaderFont", AppSetting.Instance, "HeaderFont", false, DataSourceUpdateMode.Never);
            pFeeInfo.DataBindings.Add("RowFont", AppSetting.Instance, "RowFont", false, DataSourceUpdateMode.Never);
            pFeeInfo.DataBindings.Add("ButtonFont", AppSetting.Instance, "ButtonFont", false, DataSourceUpdateMode.Never);
            pFeeInfo.DataBindings.Add("LabelFont", AppSetting.Instance, "LabelFont", false, DataSourceUpdateMode.Never);
            pFeeInfo.DataBindings.Add("TextColor", AppSetting.Instance, "TextColor", false, DataSourceUpdateMode.Never);

            pSetting.DataBindings.Add("HeaderFont", AppSetting.Instance, "HeaderFont", false, DataSourceUpdateMode.Never);
            pSetting.DataBindings.Add("RowFont", AppSetting.Instance, "RowFont", false, DataSourceUpdateMode.Never);
            pSetting.DataBindings.Add("ButtonFont", AppSetting.Instance, "ButtonFont", false, DataSourceUpdateMode.Never);
            pSetting.DataBindings.Add("LabelFont", AppSetting.Instance, "LabelFont", false, DataSourceUpdateMode.Never);
            pSetting.DataBindings.Add("TextColor", AppSetting.Instance, "TextColor", false, DataSourceUpdateMode.Never);

            pAccountInfo.DataBindings.Add("ButtonFont", AppSetting.Instance, "ButtonFont", false, DataSourceUpdateMode.Never);
            pAccountInfo.DataBindings.Add("TextColor", AppSetting.Instance, "TextColor", false, DataSourceUpdateMode.Never);

            //Các page truyền list control cho pageAdmin để nó cài đặt quyền cho từng control
            pAdmin.DataBindings.Add("listPersonPrivilege", pPerson, "listPrivilege", false, DataSourceUpdateMode.Never);
            pAdmin.DataBindings.Add("listHouseholdPrivilege", pHousehold, "listPrivilege", false, DataSourceUpdateMode.Never);
            pAdmin.DataBindings.Add("listDonatePrivilege", pDonate, "listPrivilege", false, DataSourceUpdateMode.Never);
            pAdmin.DataBindings.Add("listFeePrivilege", pFee, "listPrivilege", false, DataSourceUpdateMode.Never);
            pAdmin.DataBindings.Add("HeaderFont", AppSetting.Instance, "HeaderFont", false, DataSourceUpdateMode.Never);
            pAdmin.DataBindings.Add("RowFont", AppSetting.Instance, "RowFont", false, DataSourceUpdateMode.Never);
            pAdmin.DataBindings.Add("ButtonFont", AppSetting.Instance, "ButtonFont", false, DataSourceUpdateMode.Never);
            pAdmin.DataBindings.Add("TextColor", AppSetting.Instance, "TextColor", false, DataSourceUpdateMode.Never);

            //Thay đổi account khi click vào tabSwitchUser => binding account mới đến các page
            pMain.DataBindings.Add("Account", this, "Account", false, DataSourceUpdateMode.Never);
            pPerson.DataBindings.Add("Account", this, "Account", false, DataSourceUpdateMode.Never);
            pHousehold.DataBindings.Add("Account", this, "Account", false, DataSourceUpdateMode.Never);
            pDonate.DataBindings.Add("Account", this, "Account", false, DataSourceUpdateMode.Never);
            pFee.DataBindings.Add("Account", this, "Account", false, DataSourceUpdateMode.Never);
            pAccountInfo.DataBindings.Add("Account", this, "Account", false, DataSourceUpdateMode.Never);
            pAdmin.DataBindings.Add("Account", this, "Account", false, DataSourceUpdateMode.Never);
            pSetting.DataBindings.Add("Account", this, "Account", false, DataSourceUpdateMode.Never);

        }

        void LoadEvent()
        {
            //Khi click vào mỗi tab sẽ xoá page cũ đang hiện trên pageContainer
            foreach (var element in tabContainer.Elements)
            {
                element.Click += delegate { pageContainer.Controls.Clear(); };

                foreach (var e in element.Elements)
                {
                    if (e.Text != "Đăng nhập") e.Click += delegate { pageContainer.Controls.Clear(); };
                }               
            }

            //Đồng thời khi click vào mỗi tab cũng hiện 1 page tương ứng
            //Khi 1 page vừa được add vào Controls, các binding của nó cũng chạy theo
            tabMainPage.Click +=    delegate { pageContainer.Controls.Add(pMain);       AcceptButton = null; };
            tabPerson.Click +=      delegate { pageContainer.Controls.Add(pPerson);     AcceptButton = pPerson.AcceptButton; };
            tabHousehold.Click +=   delegate { pageContainer.Controls.Add(pHousehold);  AcceptButton = pHousehold.AcceptButton; };
            tabDonate.Click +=      delegate { pageContainer.Controls.Add(pDonate);     AcceptButton = pDonate.AcceptButton; };
            tabFee.Click +=         delegate { pageContainer.Controls.Add(pFee);        AcceptButton = pFee.AcceptButton; };
            tabDonateFee.Click +=   delegate { pageContainer.Controls.Add(pDonateInfo); AcceptButton = pDonateInfo.AcceptButton; };
            tabDonateInfo.Click +=  delegate { pageContainer.Controls.Add(pDonateInfo); AcceptButton = pDonateInfo.AcceptButton; };
            tabFeeInfo.Click +=     delegate { pageContainer.Controls.Add(pFeeInfo);    AcceptButton = pFeeInfo.AcceptButton; };
            tabAccount.Click +=     delegate { pageContainer.Controls.Add(pAccountInfo);AcceptButton = pAccountInfo.AcceptButton; };
            tabAccountInfo.Click += delegate { pageContainer.Controls.Add(pAccountInfo);AcceptButton = pAccountInfo.AcceptButton; };
            tabAdmin.Click +=       delegate { pageContainer.Controls.Add(pAdmin);      AcceptButton = pAdmin.AcceptButton; };
            tabSetting.Click +=     delegate { pageContainer.Controls.Add(pSetting);    AcceptButton = null; };
            tabSwitchUser.Click +=  delegate { Enabled = false; FormLogin.Show(); };

            //Đặt lại size và vị trí cho page mỗi khi nó được add vào pageContainer
            pageContainer.ControlAdded += (s, e) => 
            { 
                e.Control.Left = 1; 
                e.Control.Top = 1;
                e.Control.Size = new Size(pageContainer.Width - 2, pageContainer.Height - 2);
            };

            //Form resize => container resize => page resize
            pageContainer.SizeChanged += delegate { if (pageContainer.Controls.Count > 0) pageContainer.Controls[0].Size = new Size(pageContainer.Width - 2, pageContainer.Height - 2); };

            //Hiện sẵn trang chủ khi form mới load
            Load += delegate { pageContainer.Controls.Add(pMain); };

            //Bật lại form login khi tắt form này
            FormClosing += delegate { FormLogin.Show(); FormLogin.FormMain = null; };

            //Load lại list UserName của fLogin khi có 1 account bị xoá
            pAdmin.AccountDeleted += delegate { FormLogin.ReloadListUser(); };

            //Load lại danh sách tài khoản khi người dùng thay đổi thông tin tài khoản
            pAccountInfo.AccountChanged += (s, e) => 
            { 
                pAdmin.ReloadData();
                Text = $"Quản lý hộ khẩu [{(s as pageAccountInfo).Account.DisplayName}]";
            };

            //Save thông tin của tài khoản hiện tại khi đăng nhập tài khoản khác
            FormLogin.AccountLogin += delegate { pAccountInfo.SaveNote(); };
            
        }

        void SetAccountPrivilege(AccountType type) => tabAdmin.Visible = type == AccountType.Admin;

    }

    
}
