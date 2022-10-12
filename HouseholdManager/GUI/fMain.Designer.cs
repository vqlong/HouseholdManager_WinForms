namespace HouseholdManager.GUI
{
    partial class fMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMain));
            this.tabContainer = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.tabMainPage = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.tabPerson = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.tabHousehold = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.tabDonate = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.tabFee = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.tabDonateFee = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.tabDonateInfo = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.tabFeeInfo = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.tabAccount = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.tabAccountInfo = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.tabAdmin = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.tabSwitchUser = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.tabSetting = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.barEditItem1 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.barEditItem2 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barEditItem3 = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemFontEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemFontEdit();
            this.defaultManager = new DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager(this.components);
            this.pageContainer = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.tabContainer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemFontEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.defaultManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pageContainer)).BeginInit();
            this.SuspendLayout();
            // 
            // tabContainer
            // 
            this.tabContainer.Dock = System.Windows.Forms.DockStyle.Left;
            this.tabContainer.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.tabMainPage,
            this.tabDonateFee,
            this.tabAccount,
            this.tabSetting});
            this.tabContainer.Location = new System.Drawing.Point(0, 31);
            this.tabContainer.Name = "tabContainer";
            this.tabContainer.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            this.tabContainer.Size = new System.Drawing.Size(260, 702);
            this.tabContainer.TabIndex = 1;
            this.tabContainer.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // tabMainPage
            // 
            this.tabMainPage.Appearance.Default.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.tabMainPage.Appearance.Default.Options.UseFont = true;
            this.tabMainPage.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.tabPerson,
            this.tabHousehold,
            this.tabDonate,
            this.tabFee});
            this.tabMainPage.Expanded = true;
            this.tabMainPage.Name = "tabMainPage";
            this.tabMainPage.Text = "Trang chủ";
            // 
            // tabPerson
            // 
            this.tabPerson.Appearance.Default.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPerson.Appearance.Default.ForeColor = System.Drawing.Color.Gainsboro;
            this.tabPerson.Appearance.Default.Options.UseFont = true;
            this.tabPerson.Appearance.Default.Options.UseForeColor = true;
            this.tabPerson.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("tabPerson.ImageOptions.Image")));
            this.tabPerson.Name = "tabPerson";
            this.tabPerson.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.tabPerson.Text = "Nhân khẩu";
            // 
            // tabHousehold
            // 
            this.tabHousehold.Appearance.Default.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tabHousehold.Appearance.Default.ForeColor = System.Drawing.Color.Gainsboro;
            this.tabHousehold.Appearance.Default.Options.UseFont = true;
            this.tabHousehold.Appearance.Default.Options.UseForeColor = true;
            this.tabHousehold.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("tabHousehold.ImageOptions.Image")));
            this.tabHousehold.Name = "tabHousehold";
            this.tabHousehold.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.tabHousehold.Text = "Hộ khẩu";
            // 
            // tabDonate
            // 
            this.tabDonate.Appearance.Default.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tabDonate.Appearance.Default.ForeColor = System.Drawing.Color.Gainsboro;
            this.tabDonate.Appearance.Default.Options.UseFont = true;
            this.tabDonate.Appearance.Default.Options.UseForeColor = true;
            this.tabDonate.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("tabDonate.ImageOptions.Image")));
            this.tabDonate.Name = "tabDonate";
            this.tabDonate.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.tabDonate.Text = "Đóng góp";
            // 
            // tabFee
            // 
            this.tabFee.Appearance.Default.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tabFee.Appearance.Default.ForeColor = System.Drawing.Color.Gainsboro;
            this.tabFee.Appearance.Default.Options.UseFont = true;
            this.tabFee.Appearance.Default.Options.UseForeColor = true;
            this.tabFee.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("tabFee.ImageOptions.Image")));
            this.tabFee.Name = "tabFee";
            this.tabFee.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.tabFee.Text = "Thu phí";
            // 
            // tabDonateFee
            // 
            this.tabDonateFee.Appearance.Default.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.tabDonateFee.Appearance.Default.Options.UseFont = true;
            this.tabDonateFee.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.tabDonateInfo,
            this.tabFeeInfo});
            this.tabDonateFee.Expanded = true;
            this.tabDonateFee.HeaderTemplate.AddRange(new DevExpress.XtraBars.Navigation.HeaderElementInfo[] {
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Text),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Image),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.HeaderControl),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.ContextButtons)});
            this.tabDonateFee.Name = "tabDonateFee";
            this.tabDonateFee.Text = "Thống kê";
            // 
            // tabDonateInfo
            // 
            this.tabDonateInfo.Appearance.Default.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tabDonateInfo.Appearance.Default.ForeColor = System.Drawing.Color.Gainsboro;
            this.tabDonateInfo.Appearance.Default.Options.UseFont = true;
            this.tabDonateInfo.Appearance.Default.Options.UseForeColor = true;
            this.tabDonateInfo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("tabDonateInfo.ImageOptions.Image")));
            this.tabDonateInfo.Name = "tabDonateInfo";
            this.tabDonateInfo.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.tabDonateInfo.Text = "Dữ liệu đóng góp";
            // 
            // tabFeeInfo
            // 
            this.tabFeeInfo.Appearance.Default.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tabFeeInfo.Appearance.Default.ForeColor = System.Drawing.Color.Gainsboro;
            this.tabFeeInfo.Appearance.Default.Options.UseFont = true;
            this.tabFeeInfo.Appearance.Default.Options.UseForeColor = true;
            this.tabFeeInfo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("tabFeeInfo.ImageOptions.Image")));
            this.tabFeeInfo.Name = "tabFeeInfo";
            this.tabFeeInfo.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.tabFeeInfo.Text = "Dữ liệu thu phí";
            // 
            // tabAccount
            // 
            this.tabAccount.Appearance.Default.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.tabAccount.Appearance.Default.Options.UseFont = true;
            this.tabAccount.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.tabAccountInfo,
            this.tabAdmin,
            this.tabSwitchUser});
            this.tabAccount.Expanded = true;
            this.tabAccount.Name = "tabAccount";
            this.tabAccount.Text = "Tài khoản";
            // 
            // tabAccountInfo
            // 
            this.tabAccountInfo.Appearance.Default.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tabAccountInfo.Appearance.Default.ForeColor = System.Drawing.Color.Gainsboro;
            this.tabAccountInfo.Appearance.Default.Options.UseFont = true;
            this.tabAccountInfo.Appearance.Default.Options.UseForeColor = true;
            this.tabAccountInfo.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("tabAccountInfo.ImageOptions.Image")));
            this.tabAccountInfo.Name = "tabAccountInfo";
            this.tabAccountInfo.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.tabAccountInfo.Text = "Cá nhân";
            // 
            // tabAdmin
            // 
            this.tabAdmin.Appearance.Default.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tabAdmin.Appearance.Default.ForeColor = System.Drawing.Color.Gainsboro;
            this.tabAdmin.Appearance.Default.Options.UseFont = true;
            this.tabAdmin.Appearance.Default.Options.UseForeColor = true;
            this.tabAdmin.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("tabAdmin.ImageOptions.Image")));
            this.tabAdmin.Name = "tabAdmin";
            this.tabAdmin.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.tabAdmin.Text = "Quản lý";
            // 
            // tabSwitchUser
            // 
            this.tabSwitchUser.Appearance.Default.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tabSwitchUser.Appearance.Default.ForeColor = System.Drawing.Color.Gainsboro;
            this.tabSwitchUser.Appearance.Default.Options.UseFont = true;
            this.tabSwitchUser.Appearance.Default.Options.UseForeColor = true;
            this.tabSwitchUser.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("tabSwitchUser.ImageOptions.Image")));
            this.tabSwitchUser.Name = "tabSwitchUser";
            this.tabSwitchUser.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.tabSwitchUser.Text = "Đăng nhập";
            // 
            // tabSetting
            // 
            this.tabSetting.Appearance.Default.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold);
            this.tabSetting.Appearance.Default.Options.UseFont = true;
            this.tabSetting.Name = "tabSetting";
            this.tabSetting.Text = "Cài đặt";
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barEditItem1,
            this.barEditItem2,
            this.barButtonItem1,
            this.barEditItem3});
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Manager = this.defaultManager;
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemTextEdit2,
            this.repositoryItemFontEdit1});
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(1462, 31);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            // 
            // barEditItem1
            // 
            this.barEditItem1.Caption = "barEditItem1";
            this.barEditItem1.Edit = this.repositoryItemTextEdit1;
            this.barEditItem1.Id = 0;
            this.barEditItem1.Name = "barEditItem1";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // barEditItem2
            // 
            this.barEditItem2.Caption = "barEditItem2";
            this.barEditItem2.Edit = this.repositoryItemTextEdit2;
            this.barEditItem2.Id = 1;
            this.barEditItem2.Name = "barEditItem2";
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 2;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barEditItem3
            // 
            this.barEditItem3.Caption = "barEditItem3";
            this.barEditItem3.Edit = this.repositoryItemFontEdit1;
            this.barEditItem3.Id = 3;
            this.barEditItem3.Name = "barEditItem3";
            // 
            // repositoryItemFontEdit1
            // 
            this.repositoryItemFontEdit1.AutoHeight = false;
            this.repositoryItemFontEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemFontEdit1.Name = "repositoryItemFontEdit1";
            // 
            // defaultManager
            // 
            this.defaultManager.Form = this;
            this.defaultManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barEditItem1,
            this.barEditItem2,
            this.barButtonItem1,
            this.barEditItem3});
            this.defaultManager.MaxItemId = 4;
            this.defaultManager.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemTextEdit2,
            this.repositoryItemFontEdit1});
            this.defaultManager.ShowCloseButton = true;
            this.defaultManager.ShowFullMenus = true;
            // 
            // pageContainer
            // 
            this.pageContainer.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.pageContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageContainer.Location = new System.Drawing.Point(260, 31);
            this.pageContainer.Name = "pageContainer";
            this.pageContainer.Size = new System.Drawing.Size(1202, 702);
            this.pageContainer.TabIndex = 3;
            // 
            // fMain
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1462, 733);
            this.Controls.Add(this.pageContainer);
            this.Controls.Add(this.tabContainer);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Name = "fMain";
            this.NavigationControl = this.tabContainer;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý hộ khẩu";
            ((System.ComponentModel.ISupportInitialize)(this.tabContainer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemFontEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.defaultManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pageContainer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.Navigation.AccordionControl tabContainer;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement tabMainPage;
        private DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager defaultManager;
        private DevExpress.XtraBars.Navigation.AccordionControlElement tabPerson;
        private DevExpress.XtraBars.Navigation.AccordionControlElement tabHousehold;
        private DevExpress.XtraBars.Navigation.AccordionControlElement tabDonate;
        private DevExpress.XtraBars.Navigation.AccordionControlElement tabFee;
        private DevExpress.XtraBars.Navigation.AccordionControlElement tabAccount;
        private DevExpress.XtraBars.Navigation.AccordionControlElement tabAccountInfo;
        private DevExpress.XtraBars.Navigation.AccordionControlElement tabAdmin;
        private DevExpress.XtraBars.BarEditItem barEditItem1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraBars.BarEditItem barEditItem2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraEditors.PanelControl pageContainer;
        private DevExpress.XtraBars.Navigation.AccordionControlElement tabSwitchUser;
        private DevExpress.XtraBars.Navigation.AccordionControlElement tabDonateFee;
        private DevExpress.XtraBars.Navigation.AccordionControlElement tabDonateInfo;
        private DevExpress.XtraBars.Navigation.AccordionControlElement tabFeeInfo;
        private DevExpress.XtraBars.Navigation.AccordionControlElement tabSetting;
        private DevExpress.XtraBars.BarEditItem barEditItem3;
        private DevExpress.XtraEditors.Repository.RepositoryItemFontEdit repositoryItemFontEdit1;
    }
}