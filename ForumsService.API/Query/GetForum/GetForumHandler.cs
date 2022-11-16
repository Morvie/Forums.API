using ForumsService.Application.Interface;
using ForumsService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumsService.Application.Query.GetForum
{
    public class GetForumHandler : IRequestHandler<GetForumQuery, ForumsDTO?>
    {
        private readonly IQueryForumRepository _repository;

        public GetForumHandler(IQueryForumRepository repository)
        {
            _repository = repository;
        }

        public async Task<ForumsDTO?> Handle(GetForumQuery request, CancellationToken cancellationToken)
        {
            return await _repository.Get(request.Id);
        }
    }
}
