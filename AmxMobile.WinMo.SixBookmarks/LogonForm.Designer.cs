namespace AmxMobile.WinMo.SixBookmarks
{
    partial class LogonForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.label1 = new System.Windows.Forms.Label();
            this.textUsername = new System.Windows.Forms.TextBox();
            this.textPassword = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.checkRememberMe = new System.Windows.Forms.CheckBox();
            this.menuLogon = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuLogon);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 16);
            this.label1.Text = "Username";
            // 
            // textUsername
            // 
            this.textUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textUsername.Location = new System.Drawing.Point(3, 29);
            this.textUsername.Name = "textUsername";
            this.textUsername.Size = new System.Drawing.Size(234, 21);
            this.textUsername.TabIndex = 1;
            // 
            // textPassword
            // 
            this.textPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textPassword.Location = new System.Drawing.Point(3, 72);
            this.textPassword.Name = "textPassword";
            this.textPassword.PasswordChar = '*';
            this.textPassword.Size = new System.Drawing.Size(234, 21);
            this.textPassword.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(3, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(234, 16);
            this.label2.Text = "Password";
            // 
            // checkRememberMe
            // 
            this.checkRememberMe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.checkRememberMe.Checked = true;
            this.checkRememberMe.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkRememberMe.Location = new System.Drawing.Point(3, 99);
            this.checkRememberMe.Name = "checkRememberMe";
            this.checkRememberMe.Size = new System.Drawing.Size(234, 20);
            this.checkRememberMe.TabIndex = 5;
            this.checkRememberMe.Text = "Remember me";
            // 
            // menuLogon
            // 
            this.menuLogon.Text = "Logon";
            this.menuLogon.Click += new System.EventHandler(this.menuLogon_Click);
            // 
            // LogonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.checkRememberMe);
            this.Controls.Add(this.textPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textUsername);
            this.Controls.Add(this.label1);
            this.Menu = this.mainMenu1;
            this.Name = "LogonForm";
            this.Text = "Logon";
            this.Load += new System.EventHandler(this.LogonForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem menuLogon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textUsername;
        private System.Windows.Forms.TextBox textPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkRememberMe;
    }
}