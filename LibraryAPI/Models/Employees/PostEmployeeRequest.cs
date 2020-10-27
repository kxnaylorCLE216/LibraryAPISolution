namespace LibraryAPI.Models.Employees
{
    public class PostEmployeeRequest
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public decimal StartingSalary { get; set; }
    }
}