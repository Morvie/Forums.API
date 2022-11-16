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
        public async Task<ForumsDTO> CreateForum(ForumsDTO forum)
        {
            await _context.AddAsync(forum);
            await _context.SaveChangesAsync();

            return forum;
        }

        public Task DeleteForum(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ForumsDTO> UpdateForum(ForumsDTO forum)
        {
            throw new NotImplementedException();
        }
    }
}
