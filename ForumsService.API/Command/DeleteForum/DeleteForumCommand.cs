using ForumsService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumsService.Application.Command.DeleteForum
{
    public class DeleteForumCommand: IRequest<ForumsDTO>
    { 
        public Guid Id { get; set; }

        public DeleteForumCommand(Guid id)
        {
            Id = id;
        }
    }
}
