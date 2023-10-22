using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace Common.Utils
{
    public static class Base64Utils
    {
        public static string FromObject(object obj)
        {
            string json = JsonSerializer.Serialize(obj);
            string base64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(json));
            return base64;
        }

        public static T? ToObject<T>(string base64)
        {
            string json = Encoding.UTF8.GetString(Convert.FromBase64String(base64));
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}
