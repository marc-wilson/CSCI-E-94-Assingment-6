using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HW6MovieSharing.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HW6MovieSharing.Pages.UserCatalog
{
    public class AddMovieModel : BasePageModel
    {
		public AddMovieModel(MoviesDbContext context) : base(context) { }
		[BindProperty]
		public Movie Movie { get; set; }
        public void OnGet()
        {

        }

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			DbContext.Movie.Add(Movie);
			await DbContext.SaveChangesAsync();
			return RedirectToPage("./Index");
		}
    }
}