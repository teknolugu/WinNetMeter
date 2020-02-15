using Newtonsoft.Json;

namespace WinNetMeter.Core.Helper
{
    public static class TextHelper
    {
        public static string ToJson(this object dataTable, bool indented = false)
        {
            var serializerSetting = new JsonSerializerSettings();

            serializerSetting.Formatting = indented ? Formatting.Indented : Formatting.None;

            return JsonConvert.SerializeObject(dataTable, serializerSetting);
        }

        public static T MapObject<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
