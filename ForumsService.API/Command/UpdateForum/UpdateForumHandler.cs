using ForumsService.Application.Interface;
using ForumsService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumsService.Application.Command.UpdateForum
{
    public class UpdateForumHandler : IRequestHandler<UpdateForumCommand, ForumsDTO?>
    {
        private readonly ICommandForumRepository _repository;

        public UpdateForumHandler(ICommandForumRepository repository)
        {
            _repository = repository;
        }

        public async Task<ForumsDTO?> Handle(UpdateForumCommand command, CancellationToken cancellationToken)
        {
            return await _repository.UpdateForum(command.ExistingForum);
        }
    }
}
