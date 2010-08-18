using System;
using System.IO;

namespace AmxMobile.WinMo.SixBookmarks
{
    public class SixBookmarksRuntime
    {
        /// <summary>
		/// Private field to hold singleton instance.
		/// </summary>
		private static SixBookmarksRuntime _current = new SixBookmarksRuntime();
		
        public SimpleXmlPropertyBag Settings { get; private set; }
        public string Username { get; private set; }

		/// <summary>
		/// Private constructor.
		/// </summary>
		private SixBookmarksRuntime()
		{
            // register the entity type...
            EntityType bookmark = new EntityType(typeof(Bookmark), "Bookmark");
            bookmark.AddField(Bookmark.BookmarkIdKey, Bookmark.BookmarkIdKey, DataType.Int32, -1).IsKey = true;
            bookmark.AddField(Bookmark.NameKey, Bookmark.NameKey, DataType.String, 128).IsOnServer = true;
            bookmark.AddField(Bookmark.UrlKey, Bookmark.UrlKey, DataType.String, 128).IsOnServer = true;
            bookmark.AddField(Bookmark.OrdinalKey, Bookmark.OrdinalKey, DataType.Int32, -1).IsOnServer = true;
            bookmark.AddField(Bookmark.IsLocalModifiedKey, Bookmark.IsLocalModifiedKey, DataType.Boolean, -1);
            bookmark.AddField(Bookmark.IsLocalDeletedKey, Bookmark.IsLocalDeletedKey, DataType.Boolean, -1);
            EntityType.RegisterEntityType(bookmark);

            // ensure...
            string appDataPath = this.ApplicationFolderPath;
            if (!(Directory.Exists(appDataPath)))
                Directory.CreateDirectory(appDataPath);

            // settings...
            this.Settings = SimpleXmlPropertyBag.Load(Path.Combine(appDataPath, "Settings.xml"), false);
        }
						
		/// <summary>
		/// Gets the singleton instance of <see cref="SixBookmarksRuntime">SixBookmarksRuntime</see>.
		/// </summary>
		internal static SixBookmarksRuntime Current
		{
			get
			{
				if(_current == null)
					throw new ObjectDisposedException("SixBookmarksRuntime");
				return _current;
			}
		}

        public string ApplicationFolderPath
        {
            get
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Six Bookmarks");
            }
        }

        public void Logon(string username)
        {
            this.Username = username;
        }

        internal string DatabaseFilename
        {
            get
            {
                if (Username == null)
                    throw new InvalidOperationException("'Username' is null.");
                if (Username.Length == 0)
                    throw new InvalidOperationException("'Username' is zero-length.");

                // return...
                return string.Format("SixBookmarks-{0}.sdf", this.Username);
            }
        }
    }
}
