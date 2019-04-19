using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HW6MovieSharing.Models;
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
			
			// TODO: Add entry to barrow requests
			if (movie != null) {
				var request = new BarrowRequest
				{
					DateRequested = DateTime.UtcNow,
					MovieID = movie.ID,
					RequestedBy = AuthenticatedUserInfo.ObjectIdentifier
				};
				DbContext.BarrowRequest.Add(request);
				await DbContext.SaveChangesAsync();
				if (request != null)
				{

				}
			}
		}
	}
}