using ForumsService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumsService.Application.Command.UpdateForum
{
    public class UpdateForumCommand : IRequest<ForumsDTO>
    {
        public ForumsDTO ExistingForum { get; }

        public UpdateForumCommand(ForumsDTO existingMovie)
        {
            ExistingForum = existingMovie;
        }
    }
}
