using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ApiBase.Helpers
{
    public class XMLSerializeObject<T> where T : class
    {
        public static string Serialize(T obj)
        {
            XmlSerializer submit = new XmlSerializer(typeof(T));
            using (var fmXml = new StringWriter())
            {
                using (XmlTextWriter writter = new XmlTextWriter(fmXml){ Formatting = Formatting.Indented })
                {
                    submit.Serialize(writter, obj);
                    return fmXml.ToString();
                }
            }
        }
    }
}