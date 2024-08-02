using Microsoft.EntityFrameworkCore;
using EmployeeAdminWebApi.Models.Entities;

namespace EmployeeAdminWebApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) :base(options)
        {
            
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
