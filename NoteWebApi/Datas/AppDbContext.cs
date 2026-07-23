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
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
