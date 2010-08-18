using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace AmxMobile.WinMo.SixBookmarks
{
    public static class Alert
    {
        private const string Caption = "Six Bookmarks";

        internal static void Show(Exception ex)
        {
            if (ex == null)
                throw new ArgumentNullException("ex");

            // defer...
            Show("An error occurred.", ex);
        }

        internal static void Show(string message)
        {
            // defer...
            Show(message, null);
        }

        internal static void Show(string message, Exception ex)
        {
            string toShow = message;
            if (ex != null)
            {
                Debug.WriteLine(ex);
                toShow = string.Concat(message, "\r\n", ex.ToString());
            }

            // show it, and hope we're on the right thread!
            MessageBox.Show(message, "Six Bookmarks");
        }

        internal static Failed GetFailedHandler()
        {
            // return...
            FailedHandler handler = new FailedHandler();
            return new Failed(handler.Failed);
        }

        private class FailedHandler
        {
            internal FailedHandler()
            {
            }

            internal void Failed(Exception ex)
            {
                Alert.Show(ex);
            }
        }
    }
}
