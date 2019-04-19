using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HW6MovieSharing.Models;
using HW6MovieSharing.Pages;

namespace HW6MovieSharing.Pages_Movies
{
    public class CreateModel : BasePageModel
    {
        private readonly MoviesDbContext _context;

        public CreateModel(MoviesDbContext context) : base(context) { }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Movie Movie { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
			var shit = AuthenticatedUserInfo.ObjectIdentifier;
            _context.Movie.Add(Movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}