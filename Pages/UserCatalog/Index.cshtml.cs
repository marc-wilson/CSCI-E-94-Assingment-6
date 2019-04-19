using HW6MovieSharing.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW6MovieSharing.Pages.UserCatalog
{
	public class IndexModel : BasePageModel
	{
		public IndexModel(MoviesDbContext context) : base(context) {}
		public IList<Movie> Movies { get; set; }
		public async Task OnGetAsync()
		{
			var currenObjectIdentifier = AuthenticatedUserInfo.ObjectIdentifier;
			Movies = await DbContext.Movie.Where(m => m.OwnerObjectIdentifier == currenObjectIdentifier).ToListAsync();
		}
		public async Task<IActionResult> OnPostAsync(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var movie = await DbContext.Movie.SingleOrDefaultAsync<Movie>(m => m.ID == id);
			// TODO: Make sure the movie is owned by the current logged in user
			if (movie == null)
			{
				return NotFound();
			}
			DbContext.Movie.Remove(movie);
			await DbContext.SaveChangesAsync();
			return RedirectToPage("./Index");
		}
	}
}