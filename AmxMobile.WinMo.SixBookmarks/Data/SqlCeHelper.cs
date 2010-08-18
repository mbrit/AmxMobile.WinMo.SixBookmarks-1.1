using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlServerCe;
using System.Data;

namespace AmxMobile.WinMo.SixBookmarks
{
    internal class SqlCeHelper
    {
        private static List<EntityType> CheckedTables { get; set; }

        internal SqlCeHelper()
        {
        }

        static SqlCeHelper()
        {
            CheckedTables = new List<EntityType>();
        }

        internal void EnsureTableExists(EntityType et)
        {
            // have we already checked it?
            if (CheckedTables.Contains(et))
                return;

            // check it...
            SqlStatement sql = new SqlStatement("select table_name from information_schema.tables where table_name=@p0", et.NativeName);
            object result = this.ExecuteScalar(sql);
            try
            {
                if(!(result is string))
                    CreateTable(et);
            }
            finally
            {
                CheckedTables.Add(et);
            }
        }

        private void CreateTable(EntityType et)
        {
            SqlStatement create = GetCreateStatement(et);
            if (create == null)
                throw new InvalidOperationException("'create' is null.");

            // run...
            ExecuteNonQuery(create);
        }

        private SqlStatement GetCreateStatement(EntityType et)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("create table ");
            builder.Append(et.NativeName);
            builder.Append(" (");
            bool first = true;
            foreach (EntityField field in et.Fields)
            {
                if (first)
                    first = false;
                else
                    builder.Append(", ");

                // append...
                AppendCreateSnippet(builder, field);
            }
            builder.Append(")");

            // return...
            return new SqlStatement(builder.ToString());
        }

        private void AppendCreateSnippet(StringBuilder builder, EntityField field)
        {
            if (builder == null)
                throw new ArgumentNullException("builder");
            if (field == null)
                throw new ArgumentNullException("field");

            // add...
            builder.Append(field.NativeName);
            builder.Append(" ");
            if (field.Type == DataType.String)
            {
                builder.Append("nvarchar(");
                builder.Append(field.Size);
                builder.Append(")");
            }
            else if (field.Type == DataType.Int32)
            {
                builder.Append("int");

                // autonumber?
                if (field.IsKey)
                    builder.Append(" identity not null primary key");
            }
            else if (field.Type == DataType.Boolean)
                builder.Append("bit");
            else
                throw new NotSupportedException(string.Format("Cannot handle '{0}'.", field.Type));

        }

        internal void ExecuteNonQuery(ISqlStatementSource sql)
        {
            using (SqlCeConnection conn = CreateConnection())
            {
                SqlCeCommand command = CreateCommand(conn, sql);
                if (command == null)
                    throw new InvalidOperationException("'command' is null.");

                // execute...
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw HandleException(command, ex);
                }
            }
        }

        internal object ExecuteScalar(ISqlStatementSource sql)
        {
            using (SqlCeConnection conn = CreateConnection())
            {
                SqlCeCommand command = CreateCommand(conn, sql);
                if (command == null)
                    throw new InvalidOperationException("'command' is null.");

                // execute...
                try
                {
                    return command.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw HandleException(command, ex);
                }
            }
        }

        private SqlCeCommand CreateCommand(SqlCeConnection conn, ISqlStatementSource sql)
        {
            if (conn == null)
                throw new ArgumentNullException("conn");
            if (sql == null)
                throw new ArgumentNullException("sql");

            // get...
            SqlStatement real = sql.GetStatement();
            if (real == null)
                throw new InvalidOperationException("'real' is null.");

            // create...
            SqlCeCommand command = conn.CreateCommand();
            command.CommandText = real.CommandText;

            // params...
            foreach (SqlStatementParameter param in real.Parameters)
                command.Parameters.Add(param.Name, param.Value);

            // open...
            if (conn.State != System.Data.ConnectionState.Open)
                conn.Open();

            // return...
            return command;
        }

        private SqlCeConnection CreateConnection()
        {
            // conn string...
            string filePath = Path.Combine(SixBookmarksRuntime.Current.ApplicationFolderPath, SixBookmarksRuntime.Current.DatabaseFilename);
            string connString = string.Format("Data Source={0};Persist Security Info=False", filePath);

            // if the files does not exist, create it...
            if (!(File.Exists(filePath)))
            {
                SqlCeEngine engine = new SqlCeEngine(connString);
                engine.CreateDatabase();
            }

            // return...
            return new SqlCeConnection(connString);
        }

        internal List<T> ExecuteEntityCollection<T>(ISqlStatementSource sql)
            where T : Entity
        {
            using (SqlCeConnection conn = CreateConnection())
            {
                SqlStatement real = sql.GetStatement();
                if (real == null)
                    throw new InvalidOperationException("'real' is null.");

                // get...
                EntityType et = EntityType.GetEntityType(typeof(T));
                if (et == null)
                    throw new InvalidOperationException("'et' is null.");

                // command...
                SqlCeCommand command = CreateCommand(conn, real);
                if (command == null)
                    throw new InvalidOperationException("'command' is null.");

                try
                {
                    // walk the reader...
                    SqlCeDataReader reader = command.ExecuteReader();
                    if (reader == null)
                        throw new InvalidOperationException("'reader' is null.");
                    using (reader)
                    {
                        // create...
                        List<T> results = et.CreateCollectionInstance<T>();
                        while (reader.Read())
                        {
                            // create...
                            T item = (T)et.CreateInstance();

                            // walk...
                            for (int index = 0; index < et.Fields.Count; index++)
                            {
                                EntityField field = et.Fields[index];

                                // value...
                                object value = reader.GetValue(index);
                                item.SetValue(field, value, SetReason.Load);
                            }

                            // add...
                            results.Add(item);
                        }

                        // return...
                        return results;
                    }
                }
                catch (Exception ex)
                {
                    throw HandleException(command, ex);
                }
            }
        }

        private Exception HandleException(SqlCeCommand command, Exception ex)
        {
            return new InvalidOperationException(string.Format("SQL statement execution failed.  SQL: {0}", command.CommandText), ex);
        }
    }
}
