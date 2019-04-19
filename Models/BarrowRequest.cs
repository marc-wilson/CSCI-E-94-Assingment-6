using System;

namespace HW6MovieSharing.Models
{
	public class BarrowRequest
	{
		public int ID { get; set; }
		public int MovieID { get; set; }
		public string RequestedBy { get; set; }
		public DateTime DateRequested { get; set; }
	}
}
