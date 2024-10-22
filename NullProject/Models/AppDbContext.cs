using congress.Models;
using Microsoft.EntityFrameworkCore;

namespace Session7.Models
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}
        public DbSet<Users> Users { get; set; }
       
    }
}
