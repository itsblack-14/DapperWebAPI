using DapperWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DapperWebAPI.Context
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Student> Students { get; set; }
    }
}
