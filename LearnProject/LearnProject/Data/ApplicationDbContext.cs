using LearnProject.Data.BlogData;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LearnProject.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        public DbSet<ArticleHeader> ArticleHeaders { get; set; }
        public DbSet<ArticleBody> ArticleBodies { get; set; }
    }
}
