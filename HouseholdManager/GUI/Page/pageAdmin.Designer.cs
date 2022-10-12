namespace HouseholdManager.GUI
{
    partial class pageAdmin
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pageAdmin));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelAllPage = new System.Windows.Forms.Panel();
            this.panelCRUD = new System.Windows.Forms.Panel();
            this.btnShow = new DevExpress.XtraEditors.SimpleButton();
            this.btnInsert = new DevExpress.XtraEditors.SimpleButton();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.btnSavePrivilege = new DevExpress.XtraEditors.SimpleButton();
            this.btnResetPassword = new DevExpress.XtraEditors.SimpleButton();
            this.txbDisplayName = new DevExpress.XtraEditors.TextEdit();
            this.txbUsername = new DevExpress.XtraEditors.TextEdit();
            this.lkuAccountType = new DevExpress.XtraEditors.LookUpEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelGridView = new System.Windows.Forms.Panel();
            this.dtgvData = new System.Windows.Forms.DataGridView();
            this.panelPrivilege = new System.Windows.Forms.Panel();
            this.dtgvFee = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dtgvDonate = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dtgvHousehold = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dtgvPerson = new System.Windows.Forms.DataGridView();
            this.ControlName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ControlText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ControlEnabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.separatorControl2 = new DevExpress.XtraEditors.SeparatorControl();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.txbSearch = new DevExpress.XtraEditors.TextEdit();
            this.separatorControl1 = new DevExpress.XtraEditors.SeparatorControl();
            this.panelAllPage.SuspendLayout();
            this.panelCRUD.SuspendLayout();
            this.panelInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txbDisplayName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbUsername.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkuAccountType.Properties)).BeginInit();
            this.panelGridView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvData)).BeginInit();
            this.panelPrivilege.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvFee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDonate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvHousehold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvPerson)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl2)).BeginInit();
            this.panelSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txbSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelAllPage
            // 
            this.panelAllPage.BackColor = System.Drawing.Color.LightCyan;
            this.panelAllPage.Controls.Add(this.panelCRUD);
            this.panelAllPage.Controls.Add(this.panelInfo);
            this.panelAllPage.Controls.Add(this.panelGridView);
            this.panelAllPage.Controls.Add(this.panelPrivilege);
            this.panelAllPage.Controls.Add(this.separatorControl2);
            this.panelAllPage.Controls.Add(this.panelSearch);
            this.panelAllPage.Controls.Add(this.separatorControl1);
            this.panelAllPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAllPage.Location = new System.Drawing.Point(0, 0);
            this.panelAllPage.Name = "panelAllPage";
            this.panelAllPage.Size = new System.Drawing.Size(1200, 700);
            this.panelAllPage.TabIndex = 1;
            // 
            // panelCRUD
            // 
            this.panelCRUD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCRUD.BackColor = System.Drawing.Color.LightCyan;
            this.panelCRUD.Controls.Add(this.btnShow);
            this.panelCRUD.Controls.Add(this.btnInsert);
            this.panelCRUD.Controls.Add(this.btnUpdate);
            this.panelCRUD.Controls.Add(this.btnDelete);
            this.panelCRUD.Location = new System.Drawing.Point(810, 3);
            this.panelCRUD.Name = "panelCRUD";
            this.panelCRUD.Size = new System.Drawing.Size(388, 36);
            this.panelCRUD.TabIndex = 25;
            // 
            // btnShow
            // 
            this.btnShow.Location = new System.Drawing.Point(5, 3);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(90, 30);
            this.btnShow.TabIndex = 0;
            this.btnShow.Text = "Xem";
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(101, 3);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(90, 30);
            this.btnInsert.TabIndex = 4;
            this.btnInsert.Text = "Thêm";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(197, 3);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(90, 30);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "Sửa";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(293, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(90, 30);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Xoá";
            // 
            // panelInfo
            // 
            this.panelInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelInfo.BackColor = System.Drawing.Color.LightCyan;
            this.panelInfo.Controls.Add(this.btnSavePrivilege);
            this.panelInfo.Controls.Add(this.btnResetPassword);
            this.panelInfo.Controls.Add(this.txbDisplayName);
            this.panelInfo.Controls.Add(this.txbUsername);
            this.panelInfo.Controls.Add(this.lkuAccountType);
            this.panelInfo.Controls.Add(this.label8);
            this.panelInfo.Controls.Add(this.label2);
            this.panelInfo.Controls.Add(this.label1);
            this.panelInfo.Location = new System.Drawing.Point(809, 45);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(388, 266);
            this.panelInfo.TabIndex = 9;
            // 
            // btnSavePrivilege
            // 
            this.btnSavePrivilege.Location = new System.Drawing.Point(7, 233);
            this.btnSavePrivilege.Name = "btnSavePrivilege";
            this.btnSavePrivilege.Size = new System.Drawing.Size(376, 30);
            this.btnSavePrivilege.TabIndex = 34;
            this.btnSavePrivilege.Text = "Lưu quyền tài khoản";
            // 
            // btnResetPassword
            // 
            this.btnResetPassword.Location = new System.Drawing.Point(7, 181);
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.Size = new System.Drawing.Size(376, 30);
            this.btnResetPassword.TabIndex = 33;
            this.btnResetPassword.Text = "Đặt lại mật khẩu";
            // 
            // txbDisplayName
            // 
            this.txbDisplayName.Location = new System.Drawing.Point(7, 79);
            this.txbDisplayName.Name = "txbDisplayName";
            this.txbDisplayName.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txbDisplayName.Properties.Appearance.Options.UseFont = true;
            this.txbDisplayName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txbDisplayName.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txbDisplayName.Properties.ContextImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("txbDisplayName.Properties.ContextImageOptions.Image")));
            this.txbDisplayName.Size = new System.Drawing.Size(376, 26);
            this.txbDisplayName.TabIndex = 30;
            // 
            // txbUsername
            // 
            this.txbUsername.Enabled = false;
            this.txbUsername.Location = new System.Drawing.Point(7, 28);
            this.txbUsername.Name = "txbUsername";
            this.txbUsername.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txbUsername.Properties.Appearance.Options.UseFont = true;
            this.txbUsername.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txbUsername.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far;
            this.txbUsername.Properties.ContextImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("txbUsername.Properties.ContextImageOptions.Image")));
            this.txbUsername.Size = new System.Drawing.Size(376, 26);
            this.txbUsername.TabIndex = 27;
            // 
            // lkuAccountType
            // 
            this.lkuAccountType.Enabled = false;
            this.lkuAccountType.Location = new System.Drawing.Point(7, 130);
            this.lkuAccountType.Name = "lkuAccountType";
            this.lkuAccountType.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lkuAccountType.Properties.Appearance.Options.UseFont = true;
            this.lkuAccountType.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lkuAccountType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)});
            this.lkuAccountType.Properties.DropDownRows = 2;
            this.lkuAccountType.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoSuggest;
            this.lkuAccountType.Size = new System.Drawing.Size(376, 26);
            this.lkuAccountType.TabIndex = 22;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(3, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(131, 19);
            this.label8.TabIndex = 18;
            this.label8.Text = "Loại tài khoản:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(3, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 19);
            this.label2.TabIndex = 9;
            this.label2.Text = "Tên hiển thị:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(1, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 19);
            this.label1.TabIndex = 8;
            this.label1.Text = "Tên đăng nhập:";
            // 
            // panelGridView
            // 
            this.panelGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelGridView.BackColor = System.Drawing.Color.LightCyan;
            this.panelGridView.Controls.Add(this.dtgvData);
            this.panelGridView.Location = new System.Drawing.Point(3, 45);
            this.panelGridView.Name = "panelGridView";
            this.panelGridView.Size = new System.Drawing.Size(801, 266);
            this.panelGridView.TabIndex = 10;
            // 
            // dtgvData
            // 
            this.dtgvData.AllowUserToAddRows = false;
            this.dtgvData.AllowUserToDeleteRows = false;
            this.dtgvData.AllowUserToResizeRows = false;
            this.dtgvData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvData.BackgroundColor = System.Drawing.Color.LightCyan;
            this.dtgvData.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvData.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dtgvData.Location = new System.Drawing.Point(3, 3);
            this.dtgvData.Name = "dtgvData";
            this.dtgvData.RowHeadersVisible = false;
            this.dtgvData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dtgvData.Size = new System.Drawing.Size(795, 260);
            this.dtgvData.TabIndex = 5;
            // 
            // panelPrivilege
            // 
            this.panelPrivilege.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPrivilege.BackColor = System.Drawing.Color.LightCyan;
            this.panelPrivilege.Controls.Add(this.dtgvFee);
            this.panelPrivilege.Controls.Add(this.dtgvDonate);
            this.panelPrivilege.Controls.Add(this.dtgvHousehold);
            this.panelPrivilege.Controls.Add(this.dtgvPerson);
            this.panelPrivilege.Location = new System.Drawing.Point(3, 317);
            this.panelPrivilege.Name = "panelPrivilege";
            this.panelPrivilege.Size = new System.Drawing.Size(1194, 380);
            this.panelPrivilege.TabIndex = 19;
            // 
            // dtgvFee
            // 
            this.dtgvFee.AllowUserToAddRows = false;
            this.dtgvFee.AllowUserToDeleteRows = false;
            this.dtgvFee.AllowUserToResizeRows = false;
            this.dtgvFee.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtgvFee.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvFee.BackgroundColor = System.Drawing.Color.LightCyan;
            this.dtgvFee.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtgvFee.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvFee.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewCheckBoxColumn3});
            this.dtgvFee.Location = new System.Drawing.Point(894, 3);
            this.dtgvFee.Name = "dtgvFee";
            this.dtgvFee.RowHeadersVisible = false;
            this.dtgvFee.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvFee.Size = new System.Drawing.Size(294, 374);
            this.dtgvFee.TabIndex = 8;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Tên";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn6.HeaderText = "Thu phí";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewCheckBoxColumn3
            // 
            this.dataGridViewCheckBoxColumn3.HeaderText = "Hiện";
            this.dataGridViewCheckBoxColumn3.Name = "dataGridViewCheckBoxColumn3";
            this.dataGridViewCheckBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dtgvDonate
            // 
            this.dtgvDonate.AllowUserToAddRows = false;
            this.dtgvDonate.AllowUserToDeleteRows = false;
            this.dtgvDonate.AllowUserToResizeRows = false;
            this.dtgvDonate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dtgvDonate.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvDonate.BackgroundColor = System.Drawing.Color.LightCyan;
            this.dtgvDonate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtgvDonate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvDonate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewCheckBoxColumn2});
            this.dtgvDonate.Location = new System.Drawing.Point(597, 3);
            this.dtgvDonate.Name = "dtgvDonate";
            this.dtgvDonate.RowHeadersVisible = false;
            this.dtgvDonate.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvDonate.Size = new System.Drawing.Size(294, 374);
            this.dtgvDonate.TabIndex = 7;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Tên";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn4.HeaderText = "Đóng góp";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewCheckBoxColumn2
            // 
            this.dataGridViewCheckBoxColumn2.HeaderText = "Hiện";
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            this.dataGridViewCheckBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dtgvHousehold
            // 
            this.dtgvHousehold.AllowUserToAddRows = false;
            this.dtgvHousehold.AllowUserToDeleteRows = false;
            this.dtgvHousehold.AllowUserToResizeRows = false;
            this.dtgvHousehold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dtgvHousehold.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvHousehold.BackgroundColor = System.Drawing.Color.LightCyan;
            this.dtgvHousehold.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtgvHousehold.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvHousehold.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewCheckBoxColumn1});
            this.dtgvHousehold.Location = new System.Drawing.Point(300, 3);
            this.dtgvHousehold.Name = "dtgvHousehold";
            this.dtgvHousehold.RowHeadersVisible = false;
            this.dtgvHousehold.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvHousehold.Size = new System.Drawing.Size(294, 374);
            this.dtgvHousehold.TabIndex = 6;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Tên";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn2.HeaderText = "Hộ khẩu";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.HeaderText = "Hiện";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dtgvPerson
            // 
            this.dtgvPerson.AllowUserToAddRows = false;
            this.dtgvPerson.AllowUserToDeleteRows = false;
            this.dtgvPerson.AllowUserToResizeRows = false;
            this.dtgvPerson.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dtgvPerson.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvPerson.BackgroundColor = System.Drawing.Color.LightCyan;
            this.dtgvPerson.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtgvPerson.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvPerson.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ControlName,
            this.ControlText,
            this.ControlEnabled});
            this.dtgvPerson.Location = new System.Drawing.Point(3, 3);
            this.dtgvPerson.Name = "dtgvPerson";
            this.dtgvPerson.RowHeadersVisible = false;
            this.dtgvPerson.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvPerson.Size = new System.Drawing.Size(294, 374);
            this.dtgvPerson.TabIndex = 5;
            // 
            // ControlName
            // 
            this.ControlName.HeaderText = "Tên";
            this.ControlName.Name = "ControlName";
            this.ControlName.Visible = false;
            // 
            // ControlText
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ControlText.DefaultCellStyle = dataGridViewCellStyle4;
            this.ControlText.HeaderText = "Nhân khẩu";
            this.ControlText.Name = "ControlText";
            // 
            // ControlEnabled
            // 
            this.ControlEnabled.HeaderText = "Hiện";
            this.ControlEnabled.Name = "ControlEnabled";
            this.ControlEnabled.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ControlEnabled.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // separatorControl2
            // 
            this.separatorControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.separatorControl2.BackColor = System.Drawing.Color.Transparent;
            this.separatorControl2.LineColor = System.Drawing.Color.DarkViolet;
            this.separatorControl2.LineThickness = 1;
            this.separatorControl2.Location = new System.Drawing.Point(3, 302);
            this.separatorControl2.Name = "separatorControl2";
            this.separatorControl2.Size = new System.Drawing.Size(1194, 23);
            this.separatorControl2.TabIndex = 20;
            // 
            // panelSearch
            // 
            this.panelSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSearch.BackColor = System.Drawing.Color.LightCyan;
            this.panelSearch.Controls.Add(this.btnSearch);
            this.panelSearch.Controls.Add(this.txbSearch);
            this.panelSearch.Location = new System.Drawing.Point(3, 3);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(801, 36);
            this.panelSearch.TabIndex = 10;
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(708, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(90, 30);
            this.btnSearch.TabIndex = 36;
            this.btnSearch.Text = "Tìm";
            // 
            // txbSearch
            // 
            this.txbSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txbSearch.Location = new System.Drawing.Point(3, 3);
            this.txbSearch.Name = "txbSearch";
            this.txbSearch.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txbSearch.Properties.Appearance.Options.UseFont = true;
            this.txbSearch.Properties.AutoHeight = false;
            this.txbSearch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.txbSearch.Properties.ContextImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("txbSearch.Properties.ContextImageOptions.Image")));
            this.txbSearch.Properties.NullText = "Quản lý tài khoản";
            this.txbSearch.Properties.NullValuePrompt = "Quản lý tài khoản";
            this.txbSearch.Size = new System.Drawing.Size(699, 30);
            this.txbSearch.TabIndex = 31;
            // 
            // separatorControl1
            // 
            this.separatorControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.separatorControl1.BackColor = System.Drawing.Color.Transparent;
            this.separatorControl1.LineColor = System.Drawing.Color.DarkViolet;
            this.separatorControl1.LineThickness = 1;
            this.separatorControl1.Location = new System.Drawing.Point(3, 30);
            this.separatorControl1.Name = "separatorControl1";
            this.separatorControl1.Size = new System.Drawing.Size(1194, 23);
            this.separatorControl1.TabIndex = 18;
            // 
            // pageAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelAllPage);
            this.Name = "pageAdmin";
            this.Size = new System.Drawing.Size(1200, 700);
            this.panelAllPage.ResumeLayout(false);
            this.panelCRUD.ResumeLayout(false);
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txbDisplayName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txbUsername.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lkuAccountType.Properties)).EndInit();
            this.panelGridView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvData)).EndInit();
            this.panelPrivilege.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgvFee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvDonate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvHousehold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvPerson)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl2)).EndInit();
            this.panelSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txbSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.separatorControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelAllPage;
        private System.Windows.Forms.Panel panelSearch;
        private DevExpress.XtraEditors.TextEdit txbSearch;
        private System.Windows.Forms.Panel panelGridView;
        private System.Windows.Forms.DataGridView dtgvData;
        private System.Windows.Forms.Panel panelInfo;
        private DevExpress.XtraEditors.TextEdit txbDisplayName;
        private DevExpress.XtraEditors.TextEdit txbUsername;
        private DevExpress.XtraEditors.LookUpEdit lkuAccountType;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SeparatorControl separatorControl1;
        private DevExpress.XtraEditors.SimpleButton btnResetPassword;
        private System.Windows.Forms.Panel panelPrivilege;
        private System.Windows.Forms.DataGridView dtgvPerson;
        private DevExpress.XtraEditors.SimpleButton btnSavePrivilege;
        private System.Windows.Forms.DataGridViewTextBoxColumn ControlName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ControlText;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ControlEnabled;
        private DevExpress.XtraEditors.SeparatorControl separatorControl2;
        private System.Windows.Forms.DataGridView dtgvFee;
        private System.Windows.Forms.DataGridView dtgvDonate;
        private System.Windows.Forms.DataGridView dtgvHousehold;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private System.Windows.Forms.Panel panelCRUD;
        private DevExpress.XtraEditors.SimpleButton btnShow;
        private DevExpress.XtraEditors.SimpleButton btnInsert;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
    }
}
