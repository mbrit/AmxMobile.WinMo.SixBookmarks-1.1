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
    public partial class NavigatorForm : Form
    {
        private List<Bookmark> _bookmarks;

        public NavigatorForm()
        {
            InitializeComponent();
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            Navigate("http://www.multimobiledevelopment.com/");   
        }

        private void NavigatorForm_Load(object sender, EventArgs e)
        {
            this.RefreshView(false);
        }

        private List<Bookmark> Bookmarks
        {
            get
            {
                if (_bookmarks == null)
                {
                    _bookmarks = Bookmark.GetBookmarksForDisplay();
                    if (_bookmarks == null)
                        throw new InvalidOperationException("'_bookmarks' is null.");
                }
                return _bookmarks;
            }
            set
            {
                _bookmarks = value;
            }
        }

        private void RefreshView(bool reset)
        {
            // reset?
            if (reset)
                _bookmarks = null;

            // reset buttons
            for (int index = 0; index < 6; index++)
                ResetButton(index);

            // walk...
            if (Bookmarks == null)
                throw new InvalidOperationException("'Bookmarks' is null.");
            foreach (Bookmark bookmark in this.Bookmarks)
                ConfigureBookmark(bookmark);
        }

        private void ConfigureBookmark(Bookmark bookmark)
        {
            if (bookmark == null)
                throw new ArgumentNullException("bookmark");

            // button...
            Button button = GetButton(bookmark.Ordinal);
            if (button == null)
                throw new InvalidOperationException("'button' is null.");

            // set...
            button.Text = bookmark.Name;
        }

        private void ResetButton(int index)
        {
            Button button = GetButton(index);
            if (button == null)
                throw new InvalidOperationException("'button' is null.");

            // set...
            button.Text = "...";
        }

        private Button GetButton(int index)
        {
            if (index == 0)
                return this.buttonNavigate1;
            else if (index == 1)
                return this.buttonNavigate2;
            else if (index == 2)
                return this.buttonNavigate3;
            else if (index == 3)
                return this.buttonNavigate4;
            else if (index == 4)
                return this.buttonNavigate5;
            else if (index == 5)
                return this.buttonNavigate6;
            else
                throw new InvalidOperationException(string.Format("Button '{0}' not found.", index));
        }

        private void buttonNavigate1_Click(object sender, EventArgs e)
        {
            HandleNavigate(0);
        }

        private void buttonNavigate2_Click(object sender, EventArgs e)
        {
            HandleNavigate(1);
        }

        private void buttonNavigate3_Click(object sender, EventArgs e)
        {
            HandleNavigate(2);
        }

        private void buttonNavigate4_Click(object sender, EventArgs e)
        {
            HandleNavigate(3);
        }

        private void buttonNavigate5_Click(object sender, EventArgs e)
        {
            HandleNavigate(4);
        }

        private void buttonNavigate6_Click(object sender, EventArgs e)
        {
            HandleNavigate(5);
        }

        private void HandleNavigate(int ordinal)
        {
            Bookmark bookmark = GetBookmarkByOrdinal(ordinal);
            if (bookmark != null)
                Navigate(bookmark.Url);
            else
                HandleConfigure();
        }

        private Bookmark GetBookmarkByOrdinal(int ordinal)
        {
            foreach (Bookmark bookmark in this.Bookmarks)
            {
                if (bookmark.Ordinal == ordinal)
                    return bookmark;
            }

            // nope...
            return null;
        }

        private void Navigate(string url)
        {
            System.Diagnostics.Process.Start(url, string.Empty);
        }

        private void buttonConfigure_Click(object sender, EventArgs e)
        {
            HandleConfigure();
        }

        private void HandleConfigure()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(this.HandleConfigure));
                return;
            }

            // show...
            using (ConfigureForm dialog = new ConfigureForm())
                dialog.ShowDialog();

            // update...
            this.RefreshView(true);
        }

        private void buttonLogoff_Click(object sender, EventArgs e)
        {
            Alert.Show("TBD.");
        }
    }
}