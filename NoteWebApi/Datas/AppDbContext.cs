using Microsoft.EntityFrameworkCore;
using NoteWebApi.Entities;

namespace NoteWebApi.Datas
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }


        public DbSet<Note> Notes { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Note>(entity =>
            {
                entity.HasKey(q => q.Id);

                entity.Property(q => q.Title).
                       IsRequired().
                       HasMaxLength(100);


                entity.Property(q => q.Content).
                     IsRequired().
                     HasMaxLength(1000);

                entity.Property(q => q.CreatedAt).
                       IsRequired().
                       HasDefaultValueSql("getDate()");

                entity.Property(q => q.UpdatedAt).
                       IsRequired(false);

                entity.HasOne(n => n.User).
                       WithMany(n => n.Notes).
                       OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(q => q.Id);

                entity.Property(q => q.UserName).
                       IsRequired().
                       HasMaxLength(50);
                entity.Property(q => q.UserEmail).
                       IsRequired().
                       HasMaxLength(150);
                entity.Property(q => q.PasswordHash).
                       IsRequired();
                entity.Property(q => q.CreatedAt).
                       IsRequired().
                       HasDefaultValueSql("getDate()");

            });


            base.OnModelCreating(modelBuilder);
        }
    }
}
