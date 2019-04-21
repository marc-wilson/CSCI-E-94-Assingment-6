using HW6MovieSharing.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW6MovieSharing.Pages
{
	/// <summary>
	/// Base page model that derives from page model
	/// </summary>
	public class BasePageModel : PageModel
	{
		/// <summary>
		/// DB Context
		/// </summary>
		protected MoviesDbContext DbContext { get; }
		/// <summary>
		/// Decoded Claims
		/// </summary>
		private DecodedClaims _decodedClaims = null;
		/// <summary>
		/// Authenticated User Info
		/// </summary>
		public DecodedClaims AuthenticatedUserInfo
		{
			get
			{
				if (_decodedClaims == null)
				{
					_decodedClaims = new DecodedClaims(this.User);
				}
				return _decodedClaims;
			}
		}
		/// <summary>
		/// Initializer
		/// </summary>
		/// <param name="context"></param>
		public BasePageModel(MoviesDbContext context)
		{
			DbContext = context;
		}
	}
}
