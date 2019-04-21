using HW6MovieSharing.Models;

namespace HW6MovieSharing.Pages
{
	public class IndexModel : BasePageModel
	{
		public IndexModel(MoviesDbContext context) : base(context) { }
		public void OnGet()
		{
		}
	}
}
