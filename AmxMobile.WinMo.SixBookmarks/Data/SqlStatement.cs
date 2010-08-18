using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace AmxMobile.WinMo.SixBookmarks
{
    public class SqlStatement : ISqlStatementSource
    {
        public string CommandText { get; set; }
        public List<SqlStatementParameter> Parameters {get; private set; }

        public SqlStatement()
        {
            this.Parameters = new List<SqlStatementParameter>();
        }

        public SqlStatement(string commandText)
            : this()
        {
            if (commandText == null)
                throw new ArgumentNullException("commandText");
            if (commandText.Length == 0)
                throw new ArgumentException("'commandText' is zero-length.");

            // set...
            this.CommandText = commandText;
        }

        public SqlStatement(string commandText, params object[] paramValues)
            : this(commandText)
        {
            for (int index = 0; index < paramValues.Length; index++)
                this.AddParameter("p" + index.ToString(), paramValues[index]);
        }

        public SqlStatement GetStatement()
        {
            return this;
        }

        internal SqlStatementParameter AddParameter(object value)
        {
            return AddParameter(GetNextUniqueName(), value);
        }

        private string GetNextUniqueName()
        {
            int index = 0;
            while (true)
            {
                // check...
                string name = "z" + index.ToString();
                SqlStatementParameter existing = GetParameter(name);
                if (existing == null)
                    return name;

                // next...
                index++;
            }
        }

        private SqlStatementParameter GetParameter(string name)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            if (name.Length == 0)
                throw new ArgumentException("'name' is zero-length.");

            // walk...
            foreach (SqlStatementParameter param in this.Parameters)
            {
                if (string.Compare(param.Name, name, true) == 0)
                    return param;
            }

            // nope...
            return null;
        }

        internal SqlStatementParameter AddParameter(string name, object value)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            if (name.Length == 0)
                throw new ArgumentException("'name' is zero-length.");

            // add...
            SqlStatementParameter param = new SqlStatementParameter(name, value);
            this.Parameters.Add(param);

            // return...
            return param;
        }
    }
}
