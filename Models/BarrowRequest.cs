using HW6MovieSharing.Enums;
using System;

namespace HW6MovieSharing.Models
{
	public class BarrowRequest
	{
		public int ID { get; set; }
		public int MovieID { get; set; }
		public string MovieTitle { get; set; }
		public string MovieOwner { get; set; }
		public string RequestedByObjectIdentifier { get; set; }
		public string RequestedByFirstName { get; set; }
		public string RequestedByLastName { get; set; }
		public string RequestedByEmailAddress { get; set; }
		public DateTime DateRequested { get; set; }
		public MovieStatuses Status { get; set; }

		public void SetAsCompleted()
		{
			Status = MovieStatuses.RequestCompleted;
		}
	}
}
