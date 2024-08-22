using Newtonsoft.Json;

namespace CustomerApi.Data
{
    public class JsonHelper
    {
        public static List<T> ReadFromJsonFile<T>()
        {
            using (StreamReader r = new StreamReader("./Data/data.json"))
            {
                string json = r.ReadToEnd();
                List<T> items = JsonConvert.DeserializeObject<List<T>>(json);
                return items;
            }
        }
        public static void WriteToJsonFile<T>(List<T> data)
        {
            using (StreamWriter w = new StreamWriter("./Data/data.json"))
            {
                string jsonString = JsonConvert.SerializeObject(data);
                w.Write(jsonString);
            }
        }
    }
}
