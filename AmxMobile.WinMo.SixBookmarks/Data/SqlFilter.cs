using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlServerCe;

namespace AmxMobile.WinMo.SixBookmarks
{
    public class SqlFilter : ISqlStatementSource
    {
        public EntityType EntityType { get; private set; }
        private List<SqlConstraint> Constraints { get; set; }

        public SqlFilter(Type type)
            : this(EntityType.GetEntityType(type))
        {
        }

        public SqlFilter(EntityType et)
        {
            if (et == null)
                throw new ArgumentNullException("et");

            this.EntityType = et;
            this.Constraints = new List<SqlConstraint>();
        }

        public SqlStatement GetStatement()
        {
            // check that we have a table...
            SqlCeHelper helper = new SqlCeHelper();
            helper.EnsureTableExists(this.EntityType);

            // build it...
            SqlStatement sql = new SqlStatement();
            StringBuilder builder = new StringBuilder();
            builder.Append("select ");
            bool first = true;
            foreach (EntityField field in this.EntityType.Fields)
            {
                if (first)
                    first = false;
                else
                    builder.Append(", ");
                builder.Append(field.NativeName);
            }
            builder.Append(" from ");
            builder.Append(this.EntityType.NativeName);

            // consrtaints...
            if (Constraints.Count > 0)
            {
                builder.Append(" where ");

                // walk...
                first = true;
                foreach (SqlConstraint constraint in this.Constraints)
                {
                    if (first)
                        first = false;
                    else
                        builder.Append(" and ");

                    // add...
                    builder.Append(constraint.Field.NativeName);
                    builder.Append("=@");
                    builder.Append(sql.AddParameter(constraint.Value).Name);
                }
            }

            // return...
            sql.CommandText = builder.ToString();
            return sql;
        }

        internal void AddConstraint(string name, object value)
        {
            EntityField field = this.EntityType.GetField(name, true);
            if (field == null)
                throw new InvalidOperationException("'field' is null.");

            // defer...
            AddConstraint(field, value);
        }

        internal void AddConstraint(EntityField field, object value)
        {
            if (field == null)
                throw new ArgumentNullException("field");

            // add...
            this.Constraints.Add(new SqlConstraint(field, value));
        }

        internal List<T> ExecuteEntityCollection<T>()
            where T : Entity
        {
            SqlCeHelper db = new SqlCeHelper();
            return db.ExecuteEntityCollection<T>(this);
        }

        internal T ExecuteEntity<T>()
            where T : Entity
        {
            List<T> items = ExecuteEntityCollection<T>();
            if (items == null)
                throw new InvalidOperationException("'items' is null.");
            if (items.Count > 0)
                return items[0];
            else
                return null;
        }
    }
}
