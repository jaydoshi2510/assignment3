using Microsoft.EntityFrameworkCore;
using jayassignment3.Models;

namespace jayassignment3.Data
{
    public class Jayassignment3DbContext : DbContext
    {
        public Jayassignment3DbContext(DbContextOptions<Jayassignment3DbContext> options)
            : base(options)
        {
        }

        public DbSet<CartViewModel> Carts { get; set; }
        public DbSet<CommentViewModel> Comments { get; set; }
        public DbSet<OrderViewModel> Orders { get; set; }
        public DbSet<ProductViewModel> Products { get; set; }
        public DbSet<UserViewModel> Users { get; set; }
    }
}