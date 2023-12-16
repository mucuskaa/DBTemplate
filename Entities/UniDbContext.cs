using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DBTemplate.Entities
{
    internal class UniDbContext : DbContext
    {
        public UniDbContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Chair> Chairs { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=UniDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().UseTpcMappingStrategy();

            var employee1 = new Employee
            {
                Id= 1,
                FirstName="Tom",
                LastName="White",
                Email="whitetpm@gmail.com",
                Phone="380508854711"
            };

            modelBuilder.Entity<Employee>().HasData(employee1);
        }
    }
}
