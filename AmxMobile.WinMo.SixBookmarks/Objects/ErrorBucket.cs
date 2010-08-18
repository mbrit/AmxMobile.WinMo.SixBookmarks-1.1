using System.Collections.Generic;
using System.Text;

namespace AmxMobile.WinMo.SixBookmarks
{
    public class ErrorBucket : List<string>
    {
        public ErrorBucket()
        {
        }

        public bool HasErrors
        {
            get
            {
                if (this.Count > 0)
                    return true;
                else
                    return false;
            }
        }

        public string GetAllErrorsSeparatedByCrLf()
        {
            StringBuilder builder = new StringBuilder();
            foreach (string error in this)
            {
                if (builder.Length > 0)
                    builder.Append("\r\n");
                builder.Append(error);
            }

            // return...
            return builder.ToString();
        }
    }
}
