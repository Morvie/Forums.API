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
    public class QueryForumRepository : IQueryForumRepository
    {
        private readonly ForumDbContext _context;

        public QueryForumRepository(ForumDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ForumsDTO>> GetAll()
        {
            return await _context.Forums.ToListAsync();
        }

        public async Task<ForumsDTO?> Get(Guid id)
        {
            return await _context.Forums.FindAsync(id);
        }
    }
}
