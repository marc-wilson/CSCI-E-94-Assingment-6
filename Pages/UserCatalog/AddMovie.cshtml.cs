using System.Threading.Tasks;
using HW6MovieSharing.Models;
using Microsoft.AspNetCore.Mvc;

namespace HW6MovieSharing.Pages.UserCatalog
{
	public class AddMovieModel : BasePageModel
	{
		public AddMovieModel(MoviesDbContext context) : base(context) { }
		[BindProperty]
		public Movie Movie { get; set; }
		public async Task OnGetAsync() { }

		public async Task<IActionResult> OnPostAsync()
		{
			Movie.OwnerObjectIdentifier = AuthenticatedUserInfo.ObjectIdentifier;
			// TODO: Validate Model
			DbContext.Movie.Add(Movie);
			await DbContext.SaveChangesAsync();
			return RedirectToPage("./Index");
		}
	}
}