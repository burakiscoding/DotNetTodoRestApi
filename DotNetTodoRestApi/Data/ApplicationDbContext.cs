using DotNetTodoRestApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DotNetTodoRestApi.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Todo> Todos { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<LikedTodo> LikedTodos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                },
            };
            builder.Entity<IdentityRole>().HasData(roles);

            builder.Entity<LikedTodo>(x => x.HasKey(p => new { p.AppUserId, p.TodoId }));

            builder.Entity<LikedTodo>()
                .HasOne(u => u.AppUser)
                .WithMany(u => u.LikedTodos)
                .HasForeignKey(p => p.AppUserId);

            builder.Entity<LikedTodo>()
                .HasOne(u => u.Todo)
                .WithMany(u => u.LikedTodos)
                .HasForeignKey(p => p.TodoId);
        }
    }
}
