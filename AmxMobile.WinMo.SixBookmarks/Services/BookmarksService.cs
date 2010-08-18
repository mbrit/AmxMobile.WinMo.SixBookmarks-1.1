using System;
using System.Collections.Generic;

namespace AmxMobile.WinMo.SixBookmarks
{
    internal class BookmarksService : ODataServiceProxy
    {
        internal BookmarksService()
            : base("Bookmarks.svc/")
        {
        }
    }
}
