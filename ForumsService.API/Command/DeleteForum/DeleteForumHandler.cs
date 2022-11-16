using ForumsService.Application.Interface;
using ForumsService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumsService.Application.Command.DeleteForum
{
    public class DeleteForumHandler : IRequestHandler<DeleteForumCommand, ForumsDTO?>
    {
        private readonly ICommandForumRepository _repository;

        public DeleteForumHandler(ICommandForumRepository repository)
        {
            _repository = repository;
        }
        public async Task<ForumsDTO?> Handle(DeleteForumCommand request, CancellationToken cancellationToken)
        {
            var forum = await _repository.DeleteForum(request.Id);
            return forum;
        }
    }
}
