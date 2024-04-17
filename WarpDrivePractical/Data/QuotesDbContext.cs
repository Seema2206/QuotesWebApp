using System;
using Microsoft.EntityFrameworkCore;
using WarpDrivePractical.Models;

namespace WarpDrivePractical.Data
{
	public class QuotesDbContext:DbContext
	{
		public DbSet<Quotes> Quotes { get; set; }
		public QuotesDbContext(DbContextOptions<QuotesDbContext> options):base(options)
		{

		}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			modelBuilder.Entity<Quotes>(entity =>
			{
				entity.HasKey(e => e.Id);
				entity.Property(e => e.Id);
                entity.Property(e => e.Author);
                entity.Property(e => e.Tags);
                entity.Property(e => e.Quote);
            }
			); 
        }
    }
}

