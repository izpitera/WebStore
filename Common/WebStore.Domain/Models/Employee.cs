namespace WebStore.Domain.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public int Salary { get; set; }
        public string Citizenship { get; set; }
        public override string ToString() => $"{FirstName} {Patronymic} {LastName}";
    }
}
