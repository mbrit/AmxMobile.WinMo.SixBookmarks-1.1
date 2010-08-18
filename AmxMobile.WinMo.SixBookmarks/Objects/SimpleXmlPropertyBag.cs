using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace AmxMobile.WinMo.SixBookmarks
{
    public class SimpleXmlPropertyBag : Dictionary<string, string>
    {
        private string Path { get; set; }

        internal SimpleXmlPropertyBag(string path)
        {
            if (path == null)
                throw new ArgumentNullException("path");
            if (path.Length == 0)
                throw new ArgumentException("'path' is zero-length.");

            // set...
            this.Path = path;
        }

        public void Save()
        {
            // get a document...
            XDocument doc = this.ToXmlDocument();
            if (doc == null)
                throw new InvalidOperationException("'doc' is null.");

            // open a stream and recreate the file...
            doc.Save(this.Path);
        }

        private XDocument ToXmlDocument()
        {
            XDocument doc = new XDocument();

            // root...
            XElement root = new XElement("Root");
            doc.Add(root);

            // items...
            foreach (string key in this.Keys)
            {   
                // create a child element...
                XElement element = new XElement(key);
                root.Add(element);

                // set...
                element.SetValue(this[key]);
            }

            // return...
            return doc;
        }

        internal static SimpleXmlPropertyBag Load(string path, bool throwIfNotFound)
        {
            // folder...
            string folder = System.IO.Path.GetDirectoryName(path);
            if (!(System.IO.Directory.Exists(folder)))
                System.IO.Directory.CreateDirectory(folder);

            // does the file exist?
            if (File.Exists(path))
            {
                // load it...
                XDocument doc = null;
                using (Stream stream = File.Open(path, FileMode.Open, FileAccess.Read))
                {
                    StreamReader reader = new StreamReader(stream);
                    doc = XDocument.Load(reader);
                }

                // find the root...
                XElement root = doc.Element("Root");
                if (root == null)
                    throw new InvalidOperationException("'root' is null.");

                // load...
                SimpleXmlPropertyBag bag = new SimpleXmlPropertyBag(path);
                foreach (XElement element in root.Elements())
                    bag[element.Name.LocalName] = element.Value;

                // return...
                return bag;
            }
            else
            {
                if (throwIfNotFound)
                    throw new InvalidOperationException(string.Format("A file at '{0}' was not found.", path));
                else
                {
                    // return a new one...
                    return new SimpleXmlPropertyBag(path);
                }
            }
        }
    }
}
