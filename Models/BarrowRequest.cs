using HW6MovieSharing.Enums;
using System;

namespace HW6MovieSharing.Models
{
	/// <summary>
	/// A Barrow Request / Return Request
	/// </summary>
	public class BarrowRequest
	{
		/// <summary>
		/// Id of the request
		/// </summary>
		public int ID { get; set; }
		/// <summary>
		/// Id of the movie
		/// </summary>
		public int MovieID { get; set; }
		/// <summary>
		/// Title of the movie
		/// </summary>
		public string MovieTitle { get; set; }
		/// <summary>
		/// Owner of the movie
		/// </summary>
		public string MovieOwner { get; set; }
		/// <summary>
		/// Request author id
		/// </summary>
		public string RequestedByObjectIdentifier { get; set; }
		/// <summary>
		/// Request author first name
		/// </summary>
		public string RequestedByFirstName { get; set; }
		/// <summary>
		/// Request author Last Name
		/// </summary>
		public string RequestedByLastName { get; set; }
		/// <summary>
		/// Request author email address
		/// </summary>
		public string RequestedByEmailAddress { get; set; }
		/// <summary>
		/// Date of the request
		/// </summary>
		public DateTime DateRequested { get; set; }
		/// <summary>
		/// Status of the request
		/// </summary>
		public MovieStatuses Status { get; set; }

		/// <summary>
		/// Set Request as completed
		/// </summary>
		public void SetAsCompleted()
		{
			Status = MovieStatuses.RequestCompleted;
		}
	}
}
