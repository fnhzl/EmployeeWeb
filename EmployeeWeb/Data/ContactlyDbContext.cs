using EmployeeWeb.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;

namespace EmployeeWeb.Data
{
    public class ContactlyDbContext: DbContext
    {
        public ContactlyDbContext(DbContextOptions<ContactlyDbContext> options) : base(options) 
        { 
        }

        public DbSet<Contact> Contacts { get; set; }

    }
}
