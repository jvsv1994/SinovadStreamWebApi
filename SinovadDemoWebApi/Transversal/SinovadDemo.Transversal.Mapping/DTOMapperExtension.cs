using System.Text.Json;

namespace SinovadDemo.Transversal.Mapping
{
    public static class DTOMapperExtension
    {
        public static T MapTo<T>(this object value)
        {
            var serialized = JsonSerializer.Serialize(value);
            return JsonSerializer.Deserialize<T>(serialized);
        }

    }
}
