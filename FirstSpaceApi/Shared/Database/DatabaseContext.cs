using FirstSpaceApi.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstSpaceApi.Shared.Database
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {

        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public virtual DbSet<User>? User { get; set; }

        // Configure entity and relationship
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                //entity.HasNoKey();
                entity.ToTable("User");
                entity.Property(e => e.UserId).HasColumnName("UserId");
                entity.Property(e => e.FirstName).HasMaxLength(60).IsUnicode(false);
                entity.Property(e => e.MiddleName).HasMaxLength(60).IsUnicode(false);
                entity.Property(e => e.LastName).HasMaxLength(60).IsUnicode(false);
                entity.Property(e => e.UserName).HasMaxLength(30).IsUnicode(false);
                entity.Property(e => e.Email).HasMaxLength(50).IsUnicode(false);
                entity.Property(e => e.Password).HasMaxLength(20).IsUnicode(false);
                entity.Property(e => e.CreatedDate).IsUnicode(false);
            });


            // Define relationship between entity
            //modelBuilder.Entity<User>()
            //.HasMany(a => a.PropertyName)
            //.WithOne(b => b.PropertyName)
            //.HasForeignKey(b => b.PropertyName);

            // Call the partial method to continue configuration in another file
            OnModelCreatingPartial(modelBuilder);

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

}
