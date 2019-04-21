using System.Threading.Tasks;
using HW6MovieSharing.Enums;
using HW6MovieSharing.Models;
using Microsoft.AspNetCore.Mvc;

namespace HW6MovieSharing.Pages.UserCatalog
{
	/// <summary>
	/// Add Movie model
	/// </summary>
	public class AddMovieModel : BasePageModel
	{
		/// <summary>
		/// Initializer
		/// </summary>
		/// <param name="context"></param>
		public AddMovieModel(MoviesDbContext context) : base(context) { }
		/// <summary>
		/// Movie to add
		/// </summary>
		[BindProperty]
		public Movie Movie { get; set; }

		/// <summary>
		/// Adds a movie
		/// </summary>
		/// <returns></returns>
		public async Task<IActionResult> OnPostAsync()
		{
			// Get the authenticated user info
			Movie.OwnerObjectIdentifier = AuthenticatedUserInfo.ObjectIdentifier;
			// Set the movie as available
			Movie.Status = MovieStatuses.Available;
			// Add the movie to the db
			DbContext.Movie.Add(Movie);
			// Save the db changes
			await DbContext.SaveChangesAsync();
			// Redirect back to the catalog
			return RedirectToPage("./Index");
		}
	}
}