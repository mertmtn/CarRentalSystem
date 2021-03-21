﻿using Entities.Concrete;
using Microsoft.EntityFrameworkCore; 

namespace DataAccess.Concrete.EntityFramework
{
    public class CarRentalDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=TOSH\SQLEXPRESS;Database=CARRENTALDB;Trusted_Connection=true");
        }

        public DbSet<Car> Car { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Color> Color { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Company> Company { get; set; }
        public DbSet<Rental> Rental { get; set; }
    }
}
