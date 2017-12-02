using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DotVVM.SampleWeb.Model
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<ForumThread> ForumThreads { get; set; }

        public virtual DbSet<ForumPost> ForumPosts { get; set; }
    }
}