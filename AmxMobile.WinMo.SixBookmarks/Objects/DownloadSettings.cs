using System.Collections.Generic;

namespace AmxMobile.WinMo.SixBookmarks
{
    public class DownloadSettings
    {
        public Dictionary<string, string> ExtraHeaders { get; private set; }

        public DownloadSettings()
        {
            this.ExtraHeaders = new Dictionary<string, string>();
        }
    }
}
