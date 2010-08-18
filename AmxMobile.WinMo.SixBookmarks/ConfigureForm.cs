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
    public partial class ConfigureForm : Form
    {
        public ConfigureForm()
        {
            InitializeComponent();
        }

        private void menuBack_Click(object sender, EventArgs e)
        {
            // sync...
            Sync sync = new Sync();
            sync.DoSync((Action)delegate()
            {
                    
            }, Alert.GetFailedHandler());
        }

        private void ConfigureForm_Load(object sender, EventArgs e)
        {
            RefreshView();
        }

        private void RefreshView()
        {
            this.listBookmarks.Items.Clear();

            // get...
            List<Bookmark> bookmarks = Bookmark.GetBookmarksForDisplay();
            bookmarks.Sort(new OrdinalComparer());
            foreach (Bookmark bookmark in bookmarks)
                this.listBookmarks.Items.Add(bookmark);
        }

        private class OrdinalComparer : IComparer<Bookmark>
        {
            public int Compare(Bookmark x, Bookmark y)
            {
                if (x.Ordinal < y.Ordinal)
                    return -1;
                else if (x.Ordinal > y.Ordinal)
                    return 1;
                else
                    return 0;
            }
        }

        private void menuAdd_Click(object sender, EventArgs e)
        {
            // get the next ordinal...
            bool[] taken = new bool[6];
            foreach (Bookmark bookmark in this.listBookmarks.Items)
                taken[bookmark.Ordinal] = true;

            // walk...
            for (int index = 0; index < taken.Length; index++)
            {
                if (!(taken[index]))
                {
                    ConfigureBookmark(index);
                    return;
                }
            }

            // show...
            MessageBox.Show("There are no more slots available.");
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            Bookmark selected = (Bookmark)this.listBookmarks.SelectedItem;
            if (selected != null)
                ConfigureBookmark(selected.Ordinal);
        }

        private void ConfigureBookmark(int ordinal)
        {
            using (ConfigureSingletonForm dialog = new ConfigureSingletonForm())
            {
                dialog.Ordinal = ordinal;
                dialog.ShowDialog();

                // refresh...
                this.RefreshView();
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            Bookmark bookmark = (Bookmark)this.listBookmarks.SelectedItem;
            if (bookmark != null)
            {
                bookmark.IsLocalDeleted = true;
                bookmark.SaveChanges();

                // refresh...
                this.RefreshView();
            }
        }
    }
}