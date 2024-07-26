using DotNetTodoRestApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetTodoRestApi.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Todo> Todos { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
