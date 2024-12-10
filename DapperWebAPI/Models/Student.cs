using System.ComponentModel.DataAnnotations;

namespace DapperWebAPI.Models
{
    public class Student
    {
        [Key]
        [StringLength(50)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; }
    }
}
