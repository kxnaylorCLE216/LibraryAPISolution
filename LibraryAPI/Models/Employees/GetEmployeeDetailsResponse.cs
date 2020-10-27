namespace LibraryAPI.Models.Employees
{
    public class GetEmployeeDetailsResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public decimal Salary { get; set; }
        public string Manager { get; set; }
    }
}