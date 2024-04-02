using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace www.Boss.org.az.Models.JsonMethods
{
    static class FileProcessJson
    {
        public static void JsonFileWriteAllText<T>(string path, T item)
        {
            var options = new JsonSerializerOptions();
            options.WriteIndented = true;
            options.Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping;

            var textJson = JsonSerializer.Serialize(item, options);
            File.WriteAllText(path, textJson);
        }
    }
}
