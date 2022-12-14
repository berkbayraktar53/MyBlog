using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class DatabaseContext : IdentityDbContext<User, Role, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=MyBlogDb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .HasOne(x => x.UserReceiver)
                .WithMany(y => y.UserReceiver)
                .HasForeignKey(z => z.ReceiverId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Message>()
                .HasOne(x => x.UserSender)
                .WithMany(y => y.UserSender)
                .HasForeignKey(z => z.SenderId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogRating> BlogRatings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Newsletter> Newsletters { get; set; }
        public DbSet<Notification> Notifications { get; set; }
    }
}