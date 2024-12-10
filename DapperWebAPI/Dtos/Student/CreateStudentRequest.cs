namespace DapperWebAPI.Dtos.Student
{
    public class CreateStudentRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
    }
}
