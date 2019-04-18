using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HW6MovieSharing.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HW6MovieSharing.Pages.UserCatalog
{
	public class UpdateMovieModel : BasePageModel
	{
		public UpdateMovieModel(MoviesDbContext context) : base(context) { }
		public Movie Movie { get; set; }
		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null) return NotFound();
			Movie = await DbContext.Movie.SingleOrDefaultAsync<Movie>(m => m.ID == id);
			if (Movie == null) return NotFound();
			return Page();
		}
	}
}