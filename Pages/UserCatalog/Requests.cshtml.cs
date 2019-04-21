using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HW6MovieSharing.Enums;
using HW6MovieSharing.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HW6MovieSharing.Pages.UserCatalog
{
	/// <summary>
	/// Requests Model
	/// </summary>
	public class RequestsModel : BasePageModel
	{
		/// <summary>
		/// Initializer
		/// </summary>
		/// <param name="context"></param>
		public RequestsModel(MoviesDbContext context) : base(context) {}
		/// <summary>
		/// Current users requests or pending items
		/// </summary>
		[BindProperty]
		public IList<BarrowRequest> Requests { get; set; }
		/// <summary>
		/// Initial page load
		/// </summary>
		/// <returns></returns>
        public async Task OnGet()
        {
			// Get requests or pending items for the current authenticated user
			Requests = await DbContext.BarrowRequest.Where(r => r.MovieOwner == AuthenticatedUserInfo.ObjectIdentifier).ToListAsync();
        }
		/// <summary>
		/// Mark the Return Request as returned
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<IActionResult> OnPostMarkAsReturnedAsync(int? id)
		{
			// Make sure the id is valid
			if (id <= 0) return NotFound();
			// Get the request
			var request = await DbContext.BarrowRequest.Where(r => r.ID == id).SingleOrDefaultAsync();
			// Make sure the request exists
			if (request == null) return NotFound();
			// Set the request status
			request.Status = MovieStatuses.RequestCompleted;
			// Get the movie
			var movie = await DbContext.Movie.Where(m => m.ID == request.MovieID).SingleOrDefaultAsync();
			// Update the movie satus
			movie.SetMovieAsReturned();
			// Update the request
			DbContext.BarrowRequest.Update(request);
			DbContext.Movie.Update(movie);
			// Save the changes
			await DbContext.SaveChangesAsync();
			// Update the request list
			Requests = await DbContext.BarrowRequest.Where(r => r.MovieOwner == AuthenticatedUserInfo.ObjectIdentifier).ToListAsync();
			// Return the page
			return Page();
		}
		/// <summary>
		/// Delete a completed request
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<IActionResult> OnPostDeleteRequestAsync(int? id)
		{
			// Check if the id is valid
			if (id <= 0) return NotFound();
			// Get the request
			var request = await DbContext.BarrowRequest.Where(r => r.ID == id).SingleOrDefaultAsync();
			// Check is the request is null
			if (request == null) return NotFound();
			// Remove the request
			DbContext.BarrowRequest.Remove(request);
			// Save the changes
			await DbContext.SaveChangesAsync();
			// Get the updated list of requests
			Requests = await DbContext.BarrowRequest.Where(r => r.MovieOwner == AuthenticatedUserInfo.ObjectIdentifier).ToListAsync();
			// Return the page
			return Page();
		}
		/// <summary>
		/// Approved a barrow request
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<IActionResult> OnPostApproveRequestAsync(int? id)
		{
			// Make sure the id is valid
			if (id <= 0) return NotFound();
			// Get the request
			var request = await DbContext.BarrowRequest.Where(r => r.ID == id).SingleOrDefaultAsync();
			// Check is the request exists
			if (request == null) return NotFound();
			// Set the request as completed
			request.SetAsCompleted();
			// Update the request
			DbContext.BarrowRequest.Update(request);
			// Get the movie
			var movie = await DbContext.Movie.Where(m => m.ID == request.MovieID).SingleOrDefaultAsync();
			// Update the movie properites
			movie.BarrowedByObjectIdentifier = request.RequestedByObjectIdentifier;
			movie.SharedWithFirstName = request.RequestedByFirstName;
			movie.SharedWithLastName = request.RequestedByLastName;
			movie.SharedWithEmailAddress = request.RequestedByEmailAddress;
			movie.Status = MovieStatuses.Barrowed;
			movie.SharedDate = DateTime.UtcNow;
			// Update the movie
			DbContext.Movie.Update(movie);
			// Save the db changes
			await DbContext.SaveChangesAsync();
			// Get the updated list of requests
			Requests = await DbContext.BarrowRequest.Where(r => r.MovieOwner == AuthenticatedUserInfo.ObjectIdentifier).ToListAsync();
			// Return the page
			return Page();
		}
		/// <summary>
		/// Reject a barrow request
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public async Task<IActionResult> OnPostRejectRequestAsync(int? id)
		{
			// Check if the id is valid
			if (id <= 0) return NotFound();
			// Get the request
			var request = await DbContext.BarrowRequest.Where(r => r.ID == id).SingleOrDefaultAsync();
			// Check if the requets exists
			if (request == null) return NotFound();
			// Update the request status
			request.Status = MovieStatuses.BarrowRejected;
			// Update the request
			DbContext.BarrowRequest.Update(request);
			// Save the changes
			await DbContext.SaveChangesAsync();
			// Get the updated requests
			Requests = await DbContext.BarrowRequest.Where(r => r.MovieOwner == AuthenticatedUserInfo.ObjectIdentifier).ToListAsync();
			// Return the page
			return Page();
		}
    }
}