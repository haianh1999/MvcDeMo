using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCDEMO.Models;
namespace MVCDEMO.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext (DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }

        public DbSet<MVCDEMO.Models.Person> Person { get; set; }

        public DbSet<MVCDEMO.Models.Student> Student { get; set; }

        public DbSet<MVCDEMO.Models.Product> Product { get; set; }

        public DbSet<MVCDEMO.Models.Employee> Employee { get; set; }
    }
}
