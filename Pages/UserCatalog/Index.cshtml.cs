using HW6MovieSharing.Enums;
using HW6MovieSharing.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW6MovieSharing.Pages.UserCatalog
{
	/// <summary>
	/// Index Page for the user catalog
	/// </summary>
	public class IndexModel : BasePageModel
	{
		/// <summary>
		/// Initializer
		/// </summary>
		/// <param name="context"></param>
		public IndexModel(MoviesDbContext context) : base(context) {}
		/// <summary>
		/// Movies that belong to the authenticated user
		/// </summary>
		public IList<Movie> Movies { get; set; }
		/// <summary>
		/// Initial load
		/// </summary>
		/// <returns></returns>
		public async Task OnGetAsync()
		{
			// Get the movies that belong to the current authenticated user
			Movies = await DbContext.Movie.Where(m => m.OwnerObjectIdentifier == AuthenticatedUserInfo.ObjectIdentifier).ToListAsync();
		}
		/// <summary>
		/// Deletes a movie if there are not open requests
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<IActionResult> OnPostAsync(int? id)
		{
			// Make sure the idis not null
			if (id == null) return NotFound();
			// Get the movie from the db
			var movie = await DbContext.Movie.SingleOrDefaultAsync<Movie>(m => m.ID == id);
			// Make sure the movie exists
			if (movie == null) return NotFound();
			// Get any open requests for the movie
			var requests = await DbContext.BarrowRequest.Where(r => r.MovieID == movie.ID).SingleOrDefaultAsync();
			// Make sure there aren't any requests for the movie
			if (requests != null) return Page();
			// Remove the movie
			DbContext.Movie.Remove(movie);
			// Save the changes
			await DbContext.SaveChangesAsync();
			// Redirect to the catalog
			return RedirectToPage("./Index");
		}
	}
}