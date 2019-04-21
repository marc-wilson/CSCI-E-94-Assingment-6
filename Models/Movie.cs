using HW6MovieSharing.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace HW6MovieSharing.Models
{
	/// <summary>
	/// Movie Model
	/// </summary>
	public class Movie
	{
		/// <summary>
		/// ID of the movie
		/// </summary>
		public int ID { get; set; }
		/// <summary>
		/// Title of the movie
		/// </summary>
		[Required]
		[StringLength(1024)]
		public string Title { get; set; }
		/// <summary>
		/// Category of the movie
		/// </summary>
		[Required]
		[StringLength(256)]
		public string Category { get; set; }
		/// <summary>
		/// First Name of the user who is barrowing the movie
		/// </summary>
		[StringLength(256)]
		public string SharedWithFirstName { get; set; }
		/// <summary>
		/// Last Name of the user who is barrowing the movie
		/// </summary>
		[StringLength(256)]
		public string SharedWithLastName { get; set; }
		/// <summary>
		/// Email Address of the user who is barrowing the movie
		/// </summary>
		[StringLength(256)]
		public string SharedWithEmailAddress { get; set; }
		/// <summary>
		/// Date that the movie was shared
		/// </summary>
		public DateTime SharedDate { get; set; }
		/// <summary>
		/// Allows the movie to be shared
		/// </summary>
		public bool Sharable { get; set; }
		/// <summary>
		/// Object Idenitifier of the movie owner
		/// </summary>
		[Required]
		public string OwnerObjectIdentifier { get; set; }
		/// <summary>
		/// Object Identifier of the user who is barrowing the movie
		/// </summary>
		public string BarrowedByObjectIdentifier { get; set; }
		/// <summary>
		/// The status of the movie
		/// </summary>
		public MovieStatuses Status { get; set; }
		/// <summary>
		/// Sets the movie as returned and clearing the appropriate values
		/// </summary>
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
