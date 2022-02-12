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
        }

        public DbSet<Characters> Characters { get; set; } = null!;
        public DbSet<MovieSerie> MovieSeries{ get; set; } = null!;
        public DbSet<Genres> Genres { get; set; } = null!;
        public DbSet<CharactersMS> CharactersMs { get; set; } = null!;
    }
}
