using HW6MovieSharing.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HW6MovieSharing.Pages
{
	public class BasePageModel : PageModel
	{
		protected MoviesDbContext DbContext { get; }
		private DecodedClaims _decodedClaims = null;

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
		public BasePageModel(MoviesDbContext context)
		{
			DbContext = context;
		}
	}
}
