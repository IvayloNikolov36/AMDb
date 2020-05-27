namespace AMDb.Web.Infrastructure.JsonConverters
{
    using AMDb.DataModels.Enums;
    using Newtonsoft.Json;
    using System;

    public class EnumGenreConvertor : JsonConverter<Genre>
    {
        public override Genre ReadJson(JsonReader reader, Type objectType, Genre existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return Enum.Parse<Genre>(reader.Value.ToString(), ignoreCase: true);
        }

        public override void WriteJson(JsonWriter writer, Genre value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }
    }
}
