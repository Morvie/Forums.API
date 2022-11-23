using ForumsService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumsService.Application.Interface
{
    public interface IQueryForumRepository
    {
        Task<IEnumerable<ForumsDTO>> GetAll();
        Task<ForumsDTO> Get(Guid id);
    }
}
