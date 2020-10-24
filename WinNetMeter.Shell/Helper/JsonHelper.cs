using Newtonsoft.Json;

namespace WinNetMeter.Shell.Helper
{
    public static class JsonHelper
    {
        public static string ToJson(this object dataTable, bool indented = false)
        {
            var serializerSetting = new JsonSerializerSettings
            {
                Formatting = indented ? Formatting.Indented : Formatting.None,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            return JsonConvert.SerializeObject(dataTable, serializerSetting);
        }

        public static T MapObject<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}