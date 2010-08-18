namespace AmxMobile.WinMo.SixBookmarks
{
    partial class ConfigureSingletonForm
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
            this.textUrl = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.textName = new System.Windows.Forms.TextBox();
            this.labelUrl = new System.Windows.Forms.Label();
            this.menuSave = new System.Windows.Forms.MenuItem();
            this.menuCancel = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuSave);
            this.mainMenu1.MenuItems.Add(this.menuCancel);
            // 
            // textUrl
            // 
            this.textUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textUrl.Location = new System.Drawing.Point(3, 71);
            this.textUrl.Name = "textUrl";
            this.textUrl.Size = new System.Drawing.Size(234, 21);
            this.textUrl.TabIndex = 3;
            // 
            // labelName
            // 
            this.labelName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelName.Location = new System.Drawing.Point(3, 9);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(234, 16);
            this.labelName.Text = "Name";
            // 
            // textName
            // 
            this.textName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textName.Location = new System.Drawing.Point(3, 28);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(234, 21);
            this.textName.TabIndex = 6;
            // 
            // labelUrl
            // 
            this.labelUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelUrl.Location = new System.Drawing.Point(3, 52);
            this.labelUrl.Name = "labelUrl";
            this.labelUrl.Size = new System.Drawing.Size(234, 16);
            this.labelUrl.Text = "URL";
            // 
            // menuSave
            // 
            this.menuSave.Text = "Save";
            this.menuSave.Click += new System.EventHandler(this.menuSave_Click);
            // 
            // menuCancel
            // 
            this.menuCancel.Text = "Cancel";
            this.menuCancel.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // ConfigureSingletonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.textName);
            this.Controls.Add(this.labelUrl);
            this.Controls.Add(this.textUrl);
            this.Controls.Add(this.labelName);
            this.Menu = this.mainMenu1;
            this.Name = "ConfigureSingletonForm";
            this.Text = "Configure";
            this.Load += new System.EventHandler(this.ConfigureSingletonForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textUrl;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.MenuItem menuSave;
        private System.Windows.Forms.MenuItem menuCancel;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Label labelUrl;
    }
}