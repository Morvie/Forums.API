using ForumsService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumsService.Infrastructure.Context
{
    public class ForumDbContext:DbContext
    {
        public ForumDbContext(DbContextOptions<ForumDbContext> options) : base(options)
        {
        }
        public DbSet<ForumsDTO> Forums { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ForumsDTO>().HasData(
                new ForumsDTO() { Id = new Guid("1c565daf-3eaa-4b60-bc11-d0a96fce249e"), Title = "Is the Star-Wars - Rise of Empire movie good?", Description = "I don't think this is a good movie at all! It contains a lot of bad filming.", Amountoflikes = 4, DateOfAdded = DateTime.Now, MovieId = 42543, Ownership = new Guid("1c565daf-3eaa-4b60-bc11-d0a96fce249e"), Reported = false },
                new ForumsDTO() { Id = new Guid("208e2274-db97-4ac4-b17c-27d10abca7a8"), Title = "Harry Potter & The Deathly Hallows Part 1 - Hagrid?!", Description = "Just Hagrid in the movie?!.", Amountoflikes = 245, DateOfAdded = DateTime.Now, MovieId = 5345, Ownership = new Guid("48aff7a7-702c-40d7-bbb0-417c0d775c08"), Reported = false }
            );
        }
    }
}
