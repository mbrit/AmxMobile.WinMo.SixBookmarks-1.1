using System;
using System.Collections.Generic;

namespace AmxMobile.WinMo.SixBookmarks
{
    public class Bookmark : Entity
    {
        public const String BookmarkIdKey = "BookmarkId";
        public const String OrdinalKey = "Ordinal";
        public const String NameKey = "Name";
        public const String UrlKey = "Url";
        public const String IsLocalModifiedKey = "IsLocalModified";
        public const String IsLocalDeletedKey = "IsLocalDeleted";

        public Bookmark()
        {
        }

        public int BookmarkId
        {
            get
            {
                return this.GetInt32Value(BookmarkIdKey);
            }
            set
            {
                this.SetValue(BookmarkIdKey, value, SetReason.UserSet);
            }
        }

        public string Name
        {
            get
            {
                return this.GetStringValue(NameKey);
            }
            set
            {
                this.SetValue(NameKey, value, SetReason.UserSet);
            }
        }

        public string Url
        {
            get
            {
                return this.GetStringValue(UrlKey);
            }
            set
            {
                this.SetValue(UrlKey, value, SetReason.UserSet);
            }
        }

        public int Ordinal
        {
            get
            {
                return this.GetInt32Value(OrdinalKey);
            }
            set
            {
                this.SetValue(OrdinalKey, value, SetReason.UserSet);
            }
        }

        public bool IsLocalModified
        {
            get
            {
                return this.GetBooleanValue(IsLocalModifiedKey);
            }
            set
            {
                this.SetValue(IsLocalModifiedKey, value, SetReason.UserSet);
            }
        }

        public bool IsLocalDeleted
        {
            get
            {
                return this.GetBooleanValue(IsLocalDeletedKey);
            }
            set
            {
                this.SetValue(IsLocalDeletedKey, value, SetReason.UserSet);
            }
        }

        internal static List<Bookmark> GetBookmarksForDisplay()
        {
            SqlFilter filter = new SqlFilter(typeof(Bookmark));
            filter.AddConstraint("islocaldeleted", false);

            // return...
            return filter.ExecuteEntityCollection<Bookmark>();
        }

        public override string ToString()
        {
            return this.Name;
        }

        internal static void DeleteAll()
        {
            SqlCeHelper db = new SqlCeHelper();

            // ensure...
            EntityType et = EntityType.GetEntityType(typeof(Bookmark));
            db.EnsureTableExists(et);

            // delete...
            db.ExecuteNonQuery(new SqlStatement("delete from " + et.NativeName));
        }

        internal static Bookmark GetByOrdinal(int ordinal)
        {
            SqlFilter filter = new SqlFilter(typeof(Bookmark));
            filter.AddConstraint("ordinal", ordinal);
            filter.AddConstraint("islocaldeleted", false);

            // return...
            return filter.ExecuteEntity<Bookmark>();
        }

        internal static List<Bookmark> GetBookmarksForServerUpdate()
        {
            SqlFilter filter = new SqlFilter(typeof(Bookmark));
            filter.AddConstraint("islocalmodified", true);
            filter.AddConstraint("islocaldeleted", false);

            // return...
            return filter.ExecuteEntityCollection<Bookmark>();
        }

        internal static List<Bookmark> GetBookmarksForServerDelete()
        {
            SqlFilter filter = new SqlFilter(typeof(Bookmark));
            filter.AddConstraint("islocaldeleted", true);

            // return...
            return filter.ExecuteEntityCollection<Bookmark>();
        }
    }
}
