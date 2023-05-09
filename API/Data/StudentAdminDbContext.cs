using API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class StudentAdminDbContext : DbContext 
    {
        public StudentAdminDbContext(DbContextOptions<StudentAdminDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Gender> Genders { get; set; }  
    }
}
