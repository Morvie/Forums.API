using ForumsService.Application.Interface;
using ForumsService.Domain.Entities;
using ForumsService.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumsService.Infrastructure.Repository
{
    public class CommandForumRepository: ICommandForumRepository
    {
        private readonly ForumDbContext _context;

        public CommandForumRepository(ForumDbContext context)
        {
            _context = context;
        }
        public async Task<ForumsDTO>CreateForum(ForumsDTO forum)
        {
            await _context.AddAsync(forum);
            await _context.SaveChangesAsync();

            return forum;
        }

        public async Task<ForumsDTO?>DeleteForum(Guid id)
        {
            var forum = await _context.Forums.FindAsync(id);
            if (forum == null) return null;
            await Task.WhenAll(_context.Forums.Where(m => m.Id == id).ExecuteDeleteAsync(), _context.SaveChangesAsync());
            return forum;
        }

        public async Task<ForumsDTO?> UpdateForum(ForumsDTO forum)
        {
            var existing = await _context.Forums.FindAsync(forum.Id);
            if (existing == null) return null;
            
            existing.Title = forum.Title;
            existing.Description = forum.Description;
            existing.Amountoflikes = forum.Amountoflikes;
            existing.MovieId = forum.MovieId;
            existing.Description = forum.Description;
            existing.Ownership = forum.Ownership;
            existing.Reported = forum.Reported;

            await _context.SaveChangesAsync();
            return existing;
        }
    }
}
