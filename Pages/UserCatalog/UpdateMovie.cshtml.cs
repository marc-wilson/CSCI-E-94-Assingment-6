using System.Threading.Tasks;
using HW6MovieSharing.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HW6MovieSharing.Pages.UserCatalog
{
	public class UpdateMovieModel : BasePageModel
	{
		public UpdateMovieModel(MoviesDbContext context) : base(context) { }

		[BindProperty]
		public Movie Movie { get; set; }

		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null) return NotFound();
			Movie = await DbContext.Movie.SingleOrDefaultAsync<Movie>(m => m.ID == id);
			if (Movie == null) return NotFound();
			return Page();
		}
		public async Task<IActionResult> OnPostAsync()
		{
			DbContext.Attach(Movie).State = EntityState.Modified;
			await DbContext.SaveChangesAsync();
			return RedirectToPage("./Index");
		}
	}
}