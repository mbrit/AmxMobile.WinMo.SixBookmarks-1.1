using System;
using System.Collections.Generic;

namespace AmxMobile.WinMo.SixBookmarks
{
    internal class RestRequestArgs : Dictionary<string, string>
    {
        internal RestRequestArgs(string operation)
        {
            this["operation"] = operation;
        }
    }
}
