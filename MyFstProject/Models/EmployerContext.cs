using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace MyFstProject.Models
{
    public class EmployerContext : DbContext
    {
        public DbSet<Employer> Employers { get; set; }
        public EmployerContext(DbContextOptions<EmployerContext> options)
            : base(options)
        {
        }
    }
}
