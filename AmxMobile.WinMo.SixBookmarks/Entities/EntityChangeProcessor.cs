using System;
using System.Text;

namespace AmxMobile.WinMo.SixBookmarks
{
    internal class EntityChangeProcessor
    {
        public EntityType EntityType { get; private set; }

        internal EntityChangeProcessor(EntityType et)
        {
            if (et == null)
                throw new ArgumentNullException("et");
            this.EntityType = et;
        }

        internal void SaveChanges(Entity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            // new?
            if (entity.IsNew)
                Insert(entity);
            else if (entity.IsModified())
                Update(entity);
            else if (entity.IsDeleted)
                Delete(entity);
        }

        internal void Delete(Entity entity)
        {
            SqlStatement sql = new SqlStatement();

            // delete...
            StringBuilder builder = new StringBuilder();
            builder.Append("delete from ");
            builder.Append(this.EntityType.NativeName);
            builder.Append(" where ");
            AppendSelectConstraint(builder, sql, entity);

            // run...
            sql.CommandText = builder.ToString();

            // run...
            SqlCeHelper db = new SqlCeHelper();
            db.EnsureTableExists(entity.EntityType);
            db.ExecuteNonQuery(sql);
        }

        internal void Update(Entity entity)
        {
            SqlStatement sql = new SqlStatement();

            // create...
            StringBuilder builder = new StringBuilder();
            builder.Append("update ");
            builder.Append(this.EntityType.NativeName);
            builder.Append(" set ");
            bool first = true;
            foreach (EntityField field in this.EntityType.Fields)
            {
                if (entity.IsModified(field))
                {
                    if (first)
                        first = false;
                    else
                        builder.Append(", ");
                    builder.Append(field.NativeName);
                    builder.Append("=@");

                    // value...
                    object value = entity.GetValue(field);
                    builder.Append(sql.AddParameter(value).Name);
                }
            }
            builder.Append(" where ");
            this.AppendSelectConstraint(builder, sql, entity);

            // run...
            sql.CommandText = builder.ToString();

            // run...
            SqlCeHelper db = new SqlCeHelper();
            db.EnsureTableExists(entity.EntityType);
            db.ExecuteNonQuery(sql);
        }

        private void AppendSelectConstraint(StringBuilder builder, SqlStatement sql, Entity entity)
        {
            if (builder == null)
                throw new ArgumentNullException("builder");
            if (sql == null)
                throw new ArgumentNullException("sql");
            if (entity == null)
                throw new ArgumentNullException("entity");

            // run...
            EntityField key = this.EntityType.GetKeyField();
            if (key == null)
                throw new InvalidOperationException("'key' is null.");
            builder.Append(key.NativeName);
            builder.Append("=@");
            builder.Append(sql.AddParameter(entity.GetValue(key)).Name);
        }

        internal void Insert(Entity entity)
        {
            SqlStatement sql = new SqlStatement();

            // create...
            StringBuilder builder = new StringBuilder();
            builder.Append("insert into ");
            builder.Append(this.EntityType.NativeName);
            builder.Append(" (");
            bool first = true;
            foreach (EntityField field in this.EntityType.Fields)
            {
                if (entity.IsModified(field))
                {
                    if (first)
                        first = false;
                    else
                        builder.Append(", ");
                    builder.Append(field.NativeName);
                }
            }
            builder.Append(") values (");
            first = true;
            foreach (EntityField field in this.EntityType.Fields)
            {
                if (entity.IsModified(field))
                {
                    if (first)
                        first = false;
                    else
                        builder.Append(", ");

                    // param...
                    object value = entity.GetValue(field);
                    SqlStatementParameter param = sql.AddParameter(value);
                    builder.Append("@");
                    builder.Append(param.Name);
                }
            }
            builder.Append(")");

            // run...
            sql.CommandText = builder.ToString();

            // run...
            SqlCeHelper db = new SqlCeHelper();
            db.EnsureTableExists(entity.EntityType);
            db.ExecuteNonQuery(sql);
        }
    }
}
