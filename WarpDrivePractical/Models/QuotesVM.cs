using System;
namespace WarpDrivePractical.Models
{
	public class QuotesVM
	{
        public int id { get; set; }
        public string Author { get; set; }
        public string[] Tags { get; set; }
        public string Quote { get; set; }
    }
}

