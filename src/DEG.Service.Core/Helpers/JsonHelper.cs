using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace DEG.Service.Core.Helpers
{
    public class JsonHelper
    {
        public static string Stringify(object toSerialize)
        {
            var serializer = new DataContractJsonSerializer(toSerialize.GetType());
            string output;
            using (var ms = new MemoryStream())
            {
                serializer.WriteObject(ms, toSerialize);
                output = Encoding.UTF8.GetString(ms.ToArray());
            }
            return output;
        }

        public static T Parse<T>(string toParse) where T : class
        {
            var serializer = new DataContractJsonSerializer(typeof (T));
            T result;
            using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(toParse)))
            {
                result = serializer.ReadObject(ms) as T;
            }
            return result;
        }
    }
}
