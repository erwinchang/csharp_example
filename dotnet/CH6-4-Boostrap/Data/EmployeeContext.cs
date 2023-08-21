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

        //建立種子資料
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee { Id = 1, Name = "Mary", Email = "mary@gmailcom", Mobile = "0922-111222", Department ="總經理室", Title="CEO" },
                new Employee { Id = 2, Name = "David", Email = "david@gmailcom", Mobile = "0933-111222",Department = "人事部", Title ="管理師" },
                new Employee { Id = 3, Name = "Rose", Email = "rose@gmailcom", Mobile = "0944-111222" ,Department ="財務部",Title ="經理"},
                new Employee { Id = 4, Name = "Mary2", Email = "mary@gmailcom", Mobile = "0922-111222", Department = "總經理室2", Title = "CEO2" },
                new Employee { Id = 5, Name = "David2", Email = "david@gmailcom", Mobile = "0933-111222", Department = "人事部2", Title = "管理師2" },
                new Employee { Id = 6, Name = "Rose2", Email = "rose@gmailcom", Mobile = "0944-111222", Department = "財務部2", Title = "經理2" }
            );
        }
    }
}
