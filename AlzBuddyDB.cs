using AlzBuddy.Models;
using Microsoft.EntityFrameworkCore;

namespace AlzBuddy
{
    public class AlzBuddyDB : DbContext
    {
        public DbSet<AccountUser> AccountUsers { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Medication> Medication { get; set; }
        public DbSet<UsersPacients> UsersPacients { get; set; }
        public DbSet<Pacient> Pacients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Initial Catalog=AlzBuddy;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Encrypt=False;TrustServerCertificate=True;Connection Timeout=30");
            }
        }
    }
}
