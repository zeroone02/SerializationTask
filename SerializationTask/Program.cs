namespace SerializationTask;
public class Program
{
    public static int Main(string[] args)
    {
        try
        {
            Console.Write("Введите путь до Persons.json:");
            var filePath = Console.ReadLine();

            RandomPersonGenerator generator = new RandomPersonGenerator();
            ImportService importService = new ImportService();
            ReaderService readerService = new ReaderService();

            var people = generator.CreateRandomPeople();
            importService.ImportPersonsToJson(people, filePath);
            var res = readerService.ReadPersonsFromJson(filePath);

            Console.WriteLine($"Всего людей: {res[0]}");
            Console.WriteLine($"Количество кредитных карточек людей {res[1]}");
            Console.WriteLine($"Cреднее значение возраста ребенка {res[2]}");

            return 1;
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
            return 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return 0;
        }
    }

}
