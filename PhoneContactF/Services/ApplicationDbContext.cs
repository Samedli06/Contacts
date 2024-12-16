using Microsoft.EntityFrameworkCore;
using PhoneContactF.Models;

namespace PhoneContactF.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Contact> contacts { get; set; }

    }

    
}
