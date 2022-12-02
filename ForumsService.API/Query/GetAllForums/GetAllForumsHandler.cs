using ForumsService.Application.Interface;
using ForumsService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumsService.Application.Query.GetAllForums
{
    public class CreateForumHandler : IRequestHandler<GetAllForumsQuery, IEnumerable<ForumsDTO>>
    {
        private readonly IQueryForumRepository _repository;
        public CreateForumHandler(IQueryForumRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<ForumsDTO>> Handle(GetAllForumsQuery request, CancellationToken cancellation)
        {
            var forumlist = await _repository.GetAll();
            return forumlist;
        }
    }
}
