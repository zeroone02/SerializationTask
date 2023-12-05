using SerializationTask.Common;
using System.Text.Json;

namespace SerializationTask;
public class ImportService
{
    public void ImportPersonsToJson(Person[] persons, string filePath)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };
        options.Converters.Add(new PosixDateTimeJsonConverter());
        var json = JsonSerializer.Serialize(persons, options);
        File.WriteAllText(filePath, json);
    }
}