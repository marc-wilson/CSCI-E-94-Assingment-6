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
    public class RequestsModel : BasePageModel
    {
		public RequestsModel(MoviesDbContext context) : base(context) {}
		[BindProperty]
		public IList<BarrowRequest> Requests { get; set; }
        public async Task OnGet()
        {
			Requests = await DbContext.BarrowRequest.Where(r => r.MovieOwner == AuthenticatedUserInfo.ObjectIdentifier).ToListAsync();
        }
		public async Task<IActionResult> OnPostMarkAsReturnedAsync(int? id)
		{
			if (id <= 0) return NotFound();
			var request = await DbContext.BarrowRequest.Where(r => r.ID == id).SingleOrDefaultAsync();
			if (request == null) return NotFound();
			request.Status = MovieStatuses.RequestCompleted;
			var movie = await DbContext.Movie.Where(m => m.ID == request.MovieID).SingleOrDefaultAsync();
			movie.SetMovieAsReturned();

			DbContext.BarrowRequest.Update(request);
			await DbContext.SaveChangesAsync();
			Requests = await DbContext.BarrowRequest.Where(r => r.MovieOwner == AuthenticatedUserInfo.ObjectIdentifier).ToListAsync();
			return Page();
		}
		public async Task<IActionResult> OnPostDeleteRequestAsync(int? id)
		{
			if (id <= 0) return NotFound();
			var request = await DbContext.BarrowRequest.Where(r => r.ID == id).SingleOrDefaultAsync();
			if (request == null) return NotFound();
			DbContext.BarrowRequest.Remove(request);
			await DbContext.SaveChangesAsync();
			Requests = await DbContext.BarrowRequest.Where(r => r.MovieOwner == AuthenticatedUserInfo.ObjectIdentifier).ToListAsync();
			return Page();
		}
		public async Task<IActionResult> OnPostApproveRequestAsync(int? id)
		{
			if (id <= 0) return NotFound();
			var request = await DbContext.BarrowRequest.Where(r => r.ID == id).SingleOrDefaultAsync();
			if (request == null) return NotFound();
			request.SetAsCompleted();
			DbContext.BarrowRequest.Update(request);
			var movie = await DbContext.Movie.Where(m => m.ID == request.MovieID).SingleOrDefaultAsync();
			movie.BarrowedByObjectIdentifier = request.RequestedByObjectIdentifier;
			movie.SharedWithFirstName = request.RequestedByFirstName;
			movie.SharedWithLastName = request.RequestedByLastName;
			movie.SharedWithEmailAddress = request.RequestedByEmailAddress;
			movie.Status = MovieStatuses.Barrowed;
			DbContext.Movie.Update(movie);
			await DbContext.SaveChangesAsync();
			Requests = await DbContext.BarrowRequest.Where(r => r.MovieOwner == AuthenticatedUserInfo.ObjectIdentifier).ToListAsync();
			return Page();
		}
		public async Task<IActionResult> OnPostRejectRequestAsync(int? id)
		{
			if (id <= 0) return NotFound();
			var request = await DbContext.BarrowRequest.Where(r => r.ID == id).SingleOrDefaultAsync();
			if (request == null) return NotFound();
			request.Status = MovieStatuses.BarrowRejected;
			DbContext.BarrowRequest.Update(request);
			await DbContext.SaveChangesAsync();
			Requests = await DbContext.BarrowRequest.Where(r => r.MovieOwner == AuthenticatedUserInfo.ObjectIdentifier).ToListAsync();
			return Page();
		}
    }
}