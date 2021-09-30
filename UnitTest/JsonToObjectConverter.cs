using Newtonsoft.Json;

namespace BookAPI.UnitTest
{
    public class JsonToObjectConverter
    {
        public static string ObjectToJsonString(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
        public static T GetObject<T>(string jsonString)
        {
            return jsonString == null ? default : JsonConvert.DeserializeObject<T>(jsonString);
        }
    }
}
