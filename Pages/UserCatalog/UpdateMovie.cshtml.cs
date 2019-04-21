using System.Threading.Tasks;
using HW6MovieSharing.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HW6MovieSharing.Pages.UserCatalog
{
	/// <summary>
	/// Update movie model
	/// </summary>
	public class UpdateMovieModel : BasePageModel
	{
		/// <summary>
		/// Initializer
		/// </summary>
		/// <param name="context"></param>
		public UpdateMovieModel(MoviesDbContext context) : base(context) { }
		/// <summary>
		/// The movie to update
		/// </summary>
		[BindProperty]
		public Movie Movie { get; set; }
		/// <summary>
		/// Gets the movie
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<IActionResult> OnGetAsync(int? id)
		{
			// Check if the id is valid
			if (id == null) return NotFound();
			// Get the movie
			Movie = await DbContext.Movie.SingleOrDefaultAsync<Movie>(m => m.ID == id);
			// Check if the movie exists
			if (Movie == null) return NotFound();
			// Return the page
			return Page();
		}
		/// <summary>
		/// Updates the movie
		/// </summary>
		/// <returns></returns>
		public async Task<IActionResult> OnPostAsync()
		{
			// Update the state of the movie
			DbContext.Attach(Movie).State = EntityState.Modified;
			// Save the changes to the db
			await DbContext.SaveChangesAsync();
			// Redirect the main page
			return RedirectToPage("./Index");
		}
	}
}