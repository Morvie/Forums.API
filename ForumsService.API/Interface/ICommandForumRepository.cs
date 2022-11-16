using ForumsService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumsService.Application.Interface
{
    public interface ICommandForumRepository
    {
        Task<ForumsDTO> CreateForum(ForumsDTO forum);
        Task<ForumsDTO> UpdateForum(ForumsDTO forum);
        Task DeleteForum(Guid id);
    }
}
