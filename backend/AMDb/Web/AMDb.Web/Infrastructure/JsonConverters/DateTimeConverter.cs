namespace AMDb.Web.Infrastructure.JsonConverters
{
    using Newtonsoft.Json;
    using System;
    using System.Globalization;

    public class DateTimeConverter : JsonConverter<DateTime>
    {
        public override DateTime ReadJson(JsonReader reader, Type objectType, DateTime existingValue, bool hasExistingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            return DateTime.ParseExact(reader.ReadAsString(),
                    "dd.MM.yyyy", CultureInfo.InvariantCulture);
        }

        public override void WriteJson(JsonWriter writer, DateTime value, Newtonsoft.Json.JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString(
                    "dd.MM.yyyy", CultureInfo.InvariantCulture));
        }
    }
}
