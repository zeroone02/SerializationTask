using System;

namespace SerializationTask;
public class RandomPersonGenerator
{
    private readonly string[] _firstNames = { "Artur", "Vlad", "Vanya", "Sergey", "Susan", "Richard", "Michael" };
    private readonly string[] _lastNames = { "Bukov", "Kosp", "Lisov", "Cal", "Villiam", "Ebig", "Norson" };
    public Person[] CreateRandomPeople()
    {
        var people = new Person[10000];
        for (int i = 0; i < 10000; i++)
        {
            Person person = CreateRandomPerson(i + 1);
            people[i] = person;
        }
        return people;
    }
    private Person CreateRandomPerson(int id)
    {
        Random random = new Random();
        Person person = new Person();

        person.LastName = _lastNames[random.Next(_lastNames.Length)];
        person.FirstName = _firstNames[random.Next(_firstNames.Length)];

        person.Id = id;
        person.TransportId = Guid.NewGuid();
        person.SequenceId = id + 1;
        person.Age = random.Next(16, 100);
        person.Gender = (random.Next() % 2) == 0 ? Gender.Male : Gender.Female;
        person.Salary = random.NextDouble() * 100000.0;
        person.IsMarred = (random.NextDouble() > 0.5);

        int year = DateTime.Now.Year - person.Age;
        int month = random.Next(1, 13); 
        int day = random.Next(1, DateTime.DaysInMonth(year, month));

        var dateTime = new DateTime(year, month, day);
        person.BirthDate = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day);


        person.CreditCardNumbers = new string[random.Next(1, 4)];
        for (int i = 0; i < person.CreditCardNumbers.Length; i++)
        {
            person.CreditCardNumbers[i] = 
                random.Next(1000, 5000).ToString() + " "
              + random.Next(1000, 5000).ToString()  + " "
              + random.Next(1000, 5000).ToString();
        }
        

        person.Phones = new string[random.Next(1, 4)];
        for (int i = 0; i < person.Phones.Length; i++)
        {
            person.Phones[i] = "8" + random.Next(10000000, 99000000).ToString();
                
        }

        Child[] children = new Child[random.Next(4)];
        for (int k = 0; k < children.Length; k++)
        {
            children[k] = CreateRandomChild(id + k,person.Age);
        }
        person.Children = children;

        return person;
    }
    private Child CreateRandomChild(int id, int personAge)
    {
        Child child = new Child();
        Random random = new Random();

        child.FirstName = _firstNames[random.Next(_firstNames.Length)];
        child.LastName = _lastNames[random.Next(_lastNames.Length)];

        child.Id = id;
        child.Gender = (random.Next() % 2) == 0 ? Gender.Male : Gender.Female;

        int year = random.Next(DateTime.Now.Year - personAge + 16, DateTime.Now.Year);
        int month = random.Next(1, 13);
        int day = random.Next(1, DateTime.DaysInMonth(year, month));
        child.BirthDate = new DateTime(year, month, day);

        return child;
    }
}
        

