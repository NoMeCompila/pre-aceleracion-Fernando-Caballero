using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using proyectoAlkemy.Models;
using Microsoft.EntityFrameworkCore;

namespace proyectoAlkemy.Contexts
{
    public class UserContext : IdentityDbContext<User>
    {
        private const string Schema = "Users";
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema(Schema);
        }

    }
}
