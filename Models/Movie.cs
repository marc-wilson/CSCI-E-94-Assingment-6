using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
	}
}
