// 代码生成时间: 2025-09-07 06:36:16
// JsonDataConverter.cs
// 这个类是一个JSON数据格式转换器，它可以将JSON字符串转换成C#对象
// 并且可以将C#对象转换成JSON字符串。
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace JsonDataConverterApp
{
    public class JsonDataConverter
    {
        private readonly JsonSerializerOptions _serializerOptions = new JsonSerializerOptions
        {
            WriteIndented = true,
            PropertyNameCaseInsensitive = true
        };

        // 将JSON字符串转换为C#对象
        public T ConvertFromJson<T>(string json)
        {
            try
            {
                return JsonSerializer.Deserialize<T>(json, _serializerOptions);
            }
            catch (JsonException ex)
            {
                throw new ArgumentException("Invalid JSON string.", ex);
            }
        }

        // 将C#对象转换为JSON字符串
        public string ConvertToJson<T>(T obj)
        {
            try
            {
                return JsonSerializer.Serialize(obj, _serializerOptions);
            }
            catch (JsonException ex)
            {
                throw new InvalidOperationException("Object is not serializable.", ex);
            }
        }
    }
}
