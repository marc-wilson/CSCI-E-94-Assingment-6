using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HW6MovieSharing.Enums;
using HW6MovieSharing.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HW6MovieSharing.Pages.PublicCatalog
{
	public class IndexModel : BasePageModel
	{
		public IndexModel(MoviesDbContext context) : base(context) { }
		public IList<Movie> Movies { get; set; }
		public async Task OnGet()
		{
			Movies = await DbContext.Movie.Where(m => m.Sharable == true).ToListAsync();
		}
		public async Task OnPostAsync(int id)
		{
			var movie = await DbContext.Movie.Where(m => m.ID == id).SingleOrDefaultAsync();

			if (movie != null) {
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
				DbContext.BarrowRequest.Add(request);
				await DbContext.SaveChangesAsync();
			}
			Movies = await DbContext.Movie.Where(m => m.Sharable == true).ToListAsync();
		}
	}
}