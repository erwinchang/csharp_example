using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CH6_4_Boostrap.Models;

namespace CH6_4_Boostrap.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext (DbContextOptions<EmployeeContext> options)
            : base(options)
        {
        }

        public DbSet<CH6_4_Boostrap.Models.Employee> Employee { get; set; }
    }
}
