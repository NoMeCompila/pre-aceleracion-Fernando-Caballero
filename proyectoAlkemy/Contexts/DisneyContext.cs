using Microsoft.EntityFrameworkCore;
using proyectoAlkemy.Models;
namespace proyectoAlkemy.Contexts
{
    public class DisneyContext: DbContext
    {
        private const string Schema = "disney";
        public DisneyContext(DbContextOptions<DisneyContext> options) : base(options) { 
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema(Schema);
            modelBuilder.Entity<CharactersMS>()
                .HasOne(c => c.character)
                .WithMany(ms => ms.Characters_MovieSeries)
                .HasForeignKey(ci => ci.charactersID);

            modelBuilder.Entity<CharactersMS>()
                .HasOne(c => c.movieSerie)
                .WithMany(ms => ms.Characters_MovieSeries)
                .HasForeignKey(ci => ci.movie_serieID);

        }

        public DbSet<Characters> Characters { get; set; } = null!;
        public DbSet<MovieSerie> MovieSeries{ get; set; } = null!;
        public DbSet<Genres> Genres { get; set; } = null!;
        public DbSet<CharactersMS> CharactersMs { get; set; } = null!;
    }
}
