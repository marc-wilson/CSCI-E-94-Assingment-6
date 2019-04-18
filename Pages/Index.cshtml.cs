using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HW6MovieSharing.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HW6MovieSharing.Pages
{
	public class IndexModel : BasePageModel
	{
		public IndexModel(MoviesDbContext context) : base(context) { }
		public void OnGet()
		{
			var name = AuthenticatedUserInfo.FirstName;
			if (name == null)
			{

			}
		}
	}
}
