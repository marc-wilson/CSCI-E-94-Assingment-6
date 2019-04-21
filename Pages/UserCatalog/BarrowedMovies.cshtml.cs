using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HW6MovieSharing.Enums;
using HW6MovieSharing.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HW6MovieSharing.Pages.UserCatalog
{
	/// <summary>
	/// Barrowed Movie model
	/// </summary>
	public class BarrowedMoviesModel : BasePageModel
    {
		/// <summary>
		/// Initalizer
		/// </summary>
		/// <param name="context"></param>
		public BarrowedMoviesModel(MoviesDbContext context) : base(context) { }
		/// <summary>
		/// Current movies that are barrowed
		/// </summary>
		[BindProperty]
		public IList<Movie> Movies { get; set; }
		/// <summary>
		/// On initial load
		/// </summary>
		/// <returns></returns>
        public async Task OnGetAsync()
        {
			// Get movies that are currently being  barrowed form the authenicated user
			Movies = await DbContext.Movie.Where(m => m.BarrowedByObjectIdentifier == AuthenticatedUserInfo.ObjectIdentifier).ToListAsync();
        }
		/// <summary>
		/// Request to return the movie back to the user
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<IActionResult> OnPostAsync(int? id)
		{
			// Make sure an id is present
			if (id <= 0) return NotFound();
			// Get the movie from the db
			var movie = await DbContext.Movie.Where(m => m.ID == id).SingleOrDefaultAsync();
			// Make sure the movie isn't null
			if (movie == null) return NotFound();
			// Create a new return request
			var request = new BarrowRequest
			{
				MovieID = movie.ID,
				MovieOwner = movie.OwnerObjectIdentifier,
				MovieTitle = movie.Title,
				RequestedByFirstName = AuthenticatedUserInfo.FirstName,
				RequestedByLastName = AuthenticatedUserInfo.LastName,
				RequestedByEmailAddress = AuthenticatedUserInfo.EmailAddress,
				RequestedByObjectIdentifier = AuthenticatedUserInfo.ObjectIdentifier,
				DateRequested = DateTime.UtcNow,
				Status = MovieStatuses.ReturnRequested
			};
			// Update the status of the movie
			movie.Status = MovieStatuses.ReturnRequested;
			// Update the movie
			DbContext.Movie.Update(movie);
			// Add the request
			DbContext.BarrowRequest.Add(request);
			// Save the db changes
			await DbContext.SaveChangesAsync();
			// Get the updated list of barrowed movies
			Movies = await DbContext.Movie.Where(m => m.BarrowedByObjectIdentifier == AuthenticatedUserInfo.ObjectIdentifier).ToListAsync();
			// Return the page
			return Page();
		}
    }
}