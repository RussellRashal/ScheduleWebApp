using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ScheduleWebApp.Models;

namespace ScheduleWebApp.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Staff> staff { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Note> Note { get; set; }
        public DbSet<ScheduleDateAndTime> ScheduleDateAndTime { get; set; }
        public DbSet<Routes> Routes { get; set; }

        public DbSet<Driver> Drivers { get; set; }

        public DbSet<Test> Test { get; set; }
        
        public DbSet<Schedules> Schedules { get; set; }

        /*protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Student>()
                .HasMany(a => a.ScheduleDateAndTime)
                .WithRequired(c => c.Student)
                .HasForeignKey(c => c.StudentId);

            base.OnModelCreating(modelBuilder);
        }*/
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }           

    
}