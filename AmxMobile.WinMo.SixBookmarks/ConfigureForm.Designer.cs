namespace AmxMobile.WinMo.SixBookmarks
{
    partial class ConfigureForm
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
            this.menuAdd = new System.Windows.Forms.MenuItem();
            this.menuBack = new System.Windows.Forms.MenuItem();
            this.listBookmarks = new System.Windows.Forms.ListBox();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.menuAdd);
            this.mainMenu1.MenuItems.Add(this.menuBack);
            // 
            // menuAdd
            // 
            this.menuAdd.Text = "Add";
            this.menuAdd.Click += new System.EventHandler(this.menuAdd_Click);
            // 
            // menuBack
            // 
            this.menuBack.Text = "Back";
            this.menuBack.Click += new System.EventHandler(this.menuBack_Click);
            // 
            // listBookmarks
            // 
            this.listBookmarks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBookmarks.Location = new System.Drawing.Point(3, 3);
            this.listBookmarks.Name = "listBookmarks";
            this.listBookmarks.Size = new System.Drawing.Size(234, 198);
            this.listBookmarks.TabIndex = 0;
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(87, 207);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(72, 20);
            this.buttonEdit.TabIndex = 1;
            this.buttonEdit.Text = "Edit";
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(165, 207);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(72, 20);
            this.buttonDelete.TabIndex = 2;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // ConfigureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.listBookmarks);
            this.Menu = this.mainMenu1;
            this.Name = "ConfigureForm";
            this.Text = "Configure";
            this.Load += new System.EventHandler(this.ConfigureForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem menuAdd;
        private System.Windows.Forms.MenuItem menuBack;
        private System.Windows.Forms.ListBox listBookmarks;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonDelete;
    }
}