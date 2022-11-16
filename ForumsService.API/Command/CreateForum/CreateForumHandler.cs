using ForumsService.Application.Interface;
using ForumsService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumsService.Application.Command.CreateForum
{
    public class CreateForumHandler : IRequestHandler<CreateForumCommand, ForumsDTO>
    {
        private readonly ICommandForumRepository _repository;
        public CreateForumHandler(ICommandForumRepository repository)
        {
            _repository = repository;
        }
        public async Task<ForumsDTO> Handle(CreateForumCommand request, CancellationToken cancellationToken)
        {
            var forum = new ForumsDTO(Guid.NewGuid(),request.Title, request.Description,request.Ownership,request.DateOfAdded,request.Reported,request.Amountoflikes,request.MovieId);
            var result = await _repository.CreateForum(forum);
            return result;
        }
    }
}
