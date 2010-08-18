using System;

namespace AmxMobile.WinMo.SixBookmarks
{
    public class EntityField : EntityItem
    {
        public DataType Type { get; private set; }
        public int Size { get; private set; }
        public int Ordinal { get; private set; }
        public bool IsKey { get; set; }
        public bool IsOnServer { get; set; }

        internal EntityField(string name, string nativeName, DataType type, int size, int ordinal)
            : base(name, nativeName)
        {
            this.Type = type;
            this.Size = size;
            this.Ordinal = ordinal;
        }
    }
}
