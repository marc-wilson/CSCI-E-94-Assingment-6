using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HW6MovieSharing.Enums;
using HW6MovieSharing.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HW6MovieSharing.Pages.UserCatalog
{
    public class BarrowedMoviesModel : BasePageModel
    {
		public BarrowedMoviesModel(MoviesDbContext context) : base(context) { }
		[BindProperty]
		public IList<Movie> Movies { get; set; }
        public async Task OnGetAsync()
        {
			Movies = await DbContext.Movie.Where(m => m.BarrowedByObjectIdentifier == AuthenticatedUserInfo.ObjectIdentifier).ToListAsync();
        }
		public async Task<IActionResult> OnPostAsync(int? id)
		{
			if (id <= 0) return NotFound();
			var movie = await DbContext.Movie.Where(m => m.ID == id).SingleOrDefaultAsync();
			if (movie == null) return NotFound();
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
			movie.Status = MovieStatuses.ReturnRequested;
			DbContext.Movie.Update(movie);
			DbContext.BarrowRequest.Add(request);
			await DbContext.SaveChangesAsync();
			Movies = await DbContext.Movie.Where(m => m.BarrowedByObjectIdentifier == AuthenticatedUserInfo.ObjectIdentifier).ToListAsync();
			return Page();
		}
    }
}