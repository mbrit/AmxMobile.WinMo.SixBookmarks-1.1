using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace AmxMobile.WinMo.SixBookmarks
{
    public class SqlStatementParameter
    {
        public string Name { get; private set; }
        public object Value { get; private set; }

        public SqlStatementParameter(string name, object value)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            if (name.Length == 0)
                throw new ArgumentException("'name' is zero-length.");
            if (value == null)
                throw new ArgumentNullException("value");

            // set...
            this.Name = name;
            this.Value = value;
        }
    }
}
