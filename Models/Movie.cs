using HW6MovieSharing.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace HW6MovieSharing.Models
{
	public class Movie
	{
		public int ID { get; set; }
		[Required]
		[StringLength(1024)]
		public string Title { get; set; }
		[Required]
		[StringLength(256)]
		public string Category { get; set; }
		[StringLength(256)]
		public string SharedWithFirstName { get; set; }
		[StringLength(256)]
		public string SharedWithLastName { get; set; }
		[StringLength(256)]
		public string SharedWithEmailAddress { get; set; }
		public DateTime SharedDate { get; set; }
		public bool Sharable { get; set; }
		[Required]
		public string OwnerObjectIdentifier { get; set; }
		public string BarrowedByObjectIdentifier { get; set; }
		public MovieStatuses Status { get; set; }

		public void SetMovieAsReturned()
		{
			BarrowedByObjectIdentifier = null;
			SharedWithFirstName = null;
			SharedWithLastName = null;
			SharedWithEmailAddress = null;
			Status = MovieStatuses.Available;
		}
	}

	
}
