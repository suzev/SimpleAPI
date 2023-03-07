using Microsoft.EntityFrameworkCore;
using SimpleAPI.Controllers;
using SimpleAPI.Models;

namespace SimpleAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
