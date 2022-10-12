namespace HouseholdManager.GUI
{
    partial class fDialogBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fDialogBox));
            this.panelText = new System.Windows.Forms.Panel();
            this.lbText = new DevExpress.XtraEditors.LabelControl();
            this.panelButton = new System.Windows.Forms.Panel();
            this.Button1 = new DevExpress.XtraEditors.SimpleButton();
            this.Button2 = new DevExpress.XtraEditors.SimpleButton();
            this.Button3 = new DevExpress.XtraEditors.SimpleButton();
            this.panelBug = new DevExpress.XtraEditors.PanelControl();
            this.panelBottom = new DevExpress.XtraEditors.PanelControl();
            this.panelText.SuspendLayout();
            this.panelButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelBug)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).BeginInit();
            this.panelBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelText
            // 
            this.panelText.Controls.Add(this.lbText);
            this.panelText.Location = new System.Drawing.Point(71, 12);
            this.panelText.Name = "panelText";
            this.panelText.Size = new System.Drawing.Size(395, 119);
            this.panelText.TabIndex = 0;
            // 
            // lbText
            // 
            this.lbText.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lbText.Appearance.Options.UseFont = true;
            this.lbText.Appearance.Options.UseTextOptions = true;
            this.lbText.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lbText.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lbText.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lbText.Location = new System.Drawing.Point(3, 43);
            this.lbText.Name = "lbText";
            this.lbText.Size = new System.Drawing.Size(389, 19);
            this.lbText.TabIndex = 11;
            this.lbText.Text = "Text";
            // 
            // panelButton
            // 
            this.panelButton.Controls.Add(this.Button1);
            this.panelButton.Controls.Add(this.Button2);
            this.panelButton.Controls.Add(this.Button3);
            this.panelButton.Location = new System.Drawing.Point(12, 11);
            this.panelButton.Name = "panelButton";
            this.panelButton.Size = new System.Drawing.Size(454, 36);
            this.panelButton.TabIndex = 9;
            // 
            // Button1
            // 
            this.Button1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.Button1.Appearance.ForeColor = System.Drawing.Color.DarkViolet;
            this.Button1.Appearance.Options.UseBorderColor = true;
            this.Button1.Appearance.Options.UseFont = true;
            this.Button1.Appearance.Options.UseForeColor = true;
            this.Button1.Location = new System.Drawing.Point(3, 3);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(140, 30);
            this.Button1.TabIndex = 0;
            this.Button1.Text = "Yes";
            // 
            // Button2
            // 
            this.Button2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.Button2.Appearance.ForeColor = System.Drawing.Color.DarkViolet;
            this.Button2.Appearance.Options.UseBorderColor = true;
            this.Button2.Appearance.Options.UseFont = true;
            this.Button2.Appearance.Options.UseForeColor = true;
            this.Button2.Location = new System.Drawing.Point(157, 3);
            this.Button2.Name = "Button2";
            this.Button2.Size = new System.Drawing.Size(140, 30);
            this.Button2.TabIndex = 4;
            this.Button2.Text = "No";
            // 
            // Button3
            // 
            this.Button3.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.Button3.Appearance.ForeColor = System.Drawing.Color.DarkViolet;
            this.Button3.Appearance.Options.UseBorderColor = true;
            this.Button3.Appearance.Options.UseFont = true;
            this.Button3.Appearance.Options.UseForeColor = true;
            this.Button3.Location = new System.Drawing.Point(311, 3);
            this.Button3.Name = "Button3";
            this.Button3.Size = new System.Drawing.Size(140, 30);
            this.Button3.TabIndex = 3;
            this.Button3.Text = "Cancel";
            // 
            // panelBug
            // 
            this.panelBug.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelBug.ContentImage = ((System.Drawing.Image)(resources.GetObject("panelBug.ContentImage")));
            this.panelBug.Location = new System.Drawing.Point(12, 12);
            this.panelBug.Name = "panelBug";
            this.panelBug.Size = new System.Drawing.Size(53, 119);
            this.panelBug.TabIndex = 10;
            // 
            // panelBottom
            // 
            this.panelBottom.Controls.Add(this.panelButton);
            this.panelBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottom.Location = new System.Drawing.Point(0, 137);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new System.Drawing.Size(478, 55);
            this.panelBottom.TabIndex = 11;
            // 
            // fDialogBox
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 192);
            this.Controls.Add(this.panelBottom);
            this.Controls.Add(this.panelBug);
            this.Controls.Add(this.panelText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "fDialogBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fDialogBox";
            this.panelText.ResumeLayout(false);
            this.panelButton.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelBug)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelBottom)).EndInit();
            this.panelBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelText;
        private System.Windows.Forms.Panel panelButton;
        private DevExpress.XtraEditors.SimpleButton Button1;
        private DevExpress.XtraEditors.SimpleButton Button2;
        private DevExpress.XtraEditors.SimpleButton Button3;
        private DevExpress.XtraEditors.PanelControl panelBug;
        private DevExpress.XtraEditors.LabelControl lbText;
        private DevExpress.XtraEditors.PanelControl panelBottom;
    }
}