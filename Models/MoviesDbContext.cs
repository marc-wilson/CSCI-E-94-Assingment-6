using Microsoft.EntityFrameworkCore;

namespace HW6MovieSharing.Models
{
	/// <summary>
	/// DB Context for hthe MovieDb
	/// </summary>
	public class MoviesDbContext : DbContext
	{
		/// <summary>
		/// Initializer
		/// </summary>
		/// <param name="options"></param>
		public MoviesDbContext(DbContextOptions<MoviesDbContext> options) : base(options) { }
		/// <summary>
		/// Movie DB Set
		/// </summary>
		public DbSet<Movie> Movie { get; set; }
		/// <summary>
		/// Barrow Request DB Set
		/// </summary>
		public DbSet<BarrowRequest> BarrowRequest { get; set; }
	}
}
