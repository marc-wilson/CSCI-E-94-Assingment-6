using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HW6MovieSharing.Enums;
using HW6MovieSharing.Models;
using Microsoft.EntityFrameworkCore;

namespace HW6MovieSharing.Pages.PublicCatalog
{
	/// <summary>
	/// Index model for the public catalog
	/// </summary>
	public class IndexModel : BasePageModel
	{
		/// <summary>
		/// Initializer
		/// </summary>
		/// <param name="context"></param>
		public IndexModel(MoviesDbContext context) : base(context) { }
		/// <summary>
		/// Movies in the public catalog
		/// </summary>
		public IList<Movie> Movies { get; set; }
		/// <summary>
		/// On page load
		/// </summary>
		/// <returns></returns>
		public async Task OnGet()
		{
			// Get the movies from the db
			Movies = await DbContext.Movie.Where(m => m.Sharable == true).ToListAsync();
		}
		/// <summary>
		/// Requests the movie to be barrowed
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task OnPostAsync(int id)
		{
			// Get the movie from the database
			var movie = await DbContext.Movie.Where(m => m.ID == id).SingleOrDefaultAsync();
			// Check to see if the movie is null
			if (movie != null) {
				// Create a new barrow request
				var request = new BarrowRequest
				{
					DateRequested = DateTime.UtcNow,
					MovieID = movie.ID,
					MovieTitle = movie.Title,
					MovieOwner = movie.OwnerObjectIdentifier,
					RequestedByObjectIdentifier = AuthenticatedUserInfo.ObjectIdentifier,
					RequestedByFirstName = AuthenticatedUserInfo.FirstName,
					RequestedByLastName = AuthenticatedUserInfo.LastName,
					RequestedByEmailAddress = AuthenticatedUserInfo.EmailAddress,
					Status = MovieStatuses.BarrowRequested
				};
				// Add the request to the database
				DbContext.BarrowRequest.Add(request);
				// Save the database changes
				await DbContext.SaveChangesAsync();
			}
			// Fetch the updated movies set
			Movies = await DbContext.Movie.Where(m => m.Sharable == true).ToListAsync();
		}
	}
}