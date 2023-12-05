namespace SerializationTask;
public class Person
{
    public int Id { get; set; }
    public Guid TransportId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int SequenceId { get; set; }
    public string[] CreditCardNumbers { get; set; }
    public int Age { get; set; }
    public string[] Phones { get; set; }
    public DateTime BirthDate { get; set; }
    public double Salary { get; set; }
    public bool IsMarred { get; set; }
    public Gender Gender { get; set; }
    public Child[] Children { get; set; }
}
