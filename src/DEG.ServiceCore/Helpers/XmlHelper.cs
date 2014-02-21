using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using System.Text;

namespace DEG.ServiceCore.Helpers
{
    public class XmlHelper
    {
        public static string Stringify(object toSerialize)
        {
            var serializer = new  XmlSerializer(toSerialize.GetType());
            string output;
            using (var ms = new MemoryStream())
            {
                serializer.Serialize(ms, toSerialize);
                output = Encoding.UTF8.GetString(ms.ToArray());
            }
            return output;
        }

        public static T Parse<T>(string toParse) where T : class
        {
            var serializer = new XmlSerializer(typeof(T));
            T result;
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(toParse)))
            {
                result = serializer.Deserialize(ms) as T;
            }
            return result;
        }

        public static bool TryParse<T>(string toParse, out T result) where T : class
        {
            try
            {
                result = Parse<T>(toParse);
                return true;
            }
            catch { }

            result = default(T);
            return false;
        }
    }
}
