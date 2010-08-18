using System;

namespace AmxMobile.WinMo.SixBookmarks
{
    public class SqlConstraint
    {
        internal EntityField Field { get; private set; }
        internal object Value { get; private set; }

        internal SqlConstraint(EntityField field, object value)
        {
            this.Field = field;
            this.Value = value;
        }
    }
}
