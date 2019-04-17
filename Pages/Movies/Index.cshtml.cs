using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HW6MovieSharing.Models;

namespace HW6MovieSharing.Pages_Movies
{
    public class IndexModel : PageModel
    {
        private readonly HW6MovieSharing.Models.MoviesDbContext _context;

        public IndexModel(HW6MovieSharing.Models.MoviesDbContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }

        public async Task OnGetAsync()
        {
            Movie = await _context.Movie.ToListAsync();
        }
    }
}
