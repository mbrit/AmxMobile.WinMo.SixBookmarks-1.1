using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AmxMobile.WinMo.SixBookmarks
{
    public partial class ConfigureSingletonForm : Form
    {
        public int Ordinal { get; set; }
        private Bookmark _bookmark;

        public ConfigureSingletonForm()
        {
            InitializeComponent();
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void menuSave_Click(object sender, EventArgs e)
        {
            ErrorBucket errors = new ErrorBucket();
            string name = this.textName.Text.Trim();
            if (string.IsNullOrEmpty(name))
                errors.Add("Name is required.");
            string url = this.textUrl.Text.Trim();
            if (string.IsNullOrEmpty(url))
                errors.Add("URL is required.");

            // ok...
            if (!(errors.HasErrors))
            {
                // set...
                this.Bookmark.Name = name;
                this.Bookmark.Url = url;
                this.Bookmark.IsLocalModified = true;
                this.Bookmark.IsLocalDeleted = false;

                // save...
                this.Bookmark.SaveChanges();

                // finish...
                this.DialogResult = DialogResult.OK;
            }

            // show...
            if (errors.HasErrors)
                Alert.Show(errors.GetAllErrorsSeparatedByCrLf());
        }

        private void ConfigureSingletonForm_Load(object sender, EventArgs e)
        {
            if (Bookmark == null)
                throw new InvalidOperationException("'Bookmark' is null.");

            // set...
            this.textName.Text = this.Bookmark.Name;
            this.textUrl.Text = this.Bookmark.Url;
        }

        private Bookmark Bookmark
        {
            get
            {
                if (_bookmark == null)
                {
                    _bookmark = Bookmark.GetByOrdinal(this.Ordinal);
                    if (_bookmark == null)
                    {
                        Bookmark newBookmark = new Bookmark();
                        newBookmark.Ordinal = this.Ordinal;
                        newBookmark.IsLocalModified = false;
                        newBookmark.IsLocalDeleted = false;

                        // set...
                        _bookmark = newBookmark;
                    }
                }
                return _bookmark;
            }
        }
    }
}