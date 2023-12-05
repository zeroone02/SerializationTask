using SerializationTask.Common;
using System.Text.Json;

namespace SerializationTask;
public class ReaderService
{
    public int[] ReadPersonsFromJson(string filePath)
    {
        Person[] persons;
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
            options.Converters.Add(new PosixDateTimeJsonConverter());
            persons = JsonSerializer.Deserialize<Person[]>(json, options);
        }
        else
        {
            throw new FileNotFoundException("Файл Persons.json не найден.");
        }

        
        int creditCards = 0;
        int totalChildrenCount = 0;
        double sumAge = 0;
        foreach (Person person in persons)
        {
            creditCards += person.CreditCardNumbers.Length;
            foreach(var child in  person.Children)
            {
                totalChildrenCount++;
                var age = (DateTime.UtcNow - child.BirthDate).TotalDays / 365;
                sumAge += age;
            }
        }
        int totalPeople = persons.Length + totalChildrenCount;
        int averageAge = (int)sumAge / totalChildrenCount;

        int[] res = new int[3];
        res[0] = totalPeople;
        res[1] = creditCards;
        res[2] = averageAge;
        return res;
    }
}
