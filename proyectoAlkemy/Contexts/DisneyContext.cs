using Microsoft.EntityFrameworkCore;
using proyectoAlkemy.Models;
namespace proyectoAlkemy.Contexts
{
    public class DisneyContext: DbContext
    {
        private const string Schema = "disney";
        public DisneyContext(DbContextOptions<DisneyContext> options) : base(options) { 
            
        }

        /*
        // uso de fluent API para definir la relaciones mucho a muchos
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema(Schema);
            modelBuilder.Entity<CharactersMS>()
                .HasOne(c => c.Character)
                .WithMany(ms => ms.Characters_MovieSeries)
                .HasForeignKey(ci => ci.CharactersID);

            modelBuilder.Entity<CharactersMS>()
                .HasOne(c => c.MovieSerie)
                .WithMany(ms => ms.Characters_MovieSeries)
                .HasForeignKey(ci => ci.Movie_SerieID);

        }*/

        public DbSet<Characters> Characters { get; set; } = null!;
        public DbSet<MovieSerie> MovieSeries{ get; set; } = null!;
        public DbSet<Genres> Genres { get; set; } = null!;
        //public DbSet<CharactersMS> CharactersMs { get; set; } = null!;
    }
}
