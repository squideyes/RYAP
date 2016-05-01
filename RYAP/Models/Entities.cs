using System.Data.Entity;

namespace RYAP.Website.Models
{
    public class Entities : DbContext
    {
        public Entities() 
            : base("name=RYAP")
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Joke> Jokes { get; set; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<Author>()
                .Property(e => e.Name)
                .IsUnicode(false);

            builder.Entity<Author>()
                .Property(e => e.Email)
                .IsUnicode(false);

            builder.Entity<Author>()
                .Property(e => e.Location)
                .IsUnicode(false);

            builder.Entity<Author>()
                .HasMany(e => e.Jokes)
                .WithRequired(e => e.Author)
                .WillCascadeOnDelete(false);

            builder.Entity<Joke>()
                .Property(e => e.Question)
                .IsUnicode(false);

            builder.Entity<Joke>()
                .Property(e => e.Answer)
                .IsUnicode(false);
        }
    }
}