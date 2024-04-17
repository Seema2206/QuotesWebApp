using System;
using System.ComponentModel.DataAnnotations;

namespace WarpDrivePractical.Models
{
	public class Quotes
	{
		[Key]
		public int Id { get; set; }
		public string Author { get; set; }
		public string Tags { get; set; }
		public string Quote { get; set; }
	}
}

