namespace EmployeeApi.DAL

{
    public class Employee
    {
        public int Id { get; set; } // Auto-increment by default in EF
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Position { get; set; }
    }
}
