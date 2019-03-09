using Microsoft.EntityFrameworkCore;
using PhoneBook.Models;
using System;

namespace PhoneBook.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Contact> Contact { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
