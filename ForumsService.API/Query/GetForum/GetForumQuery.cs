using ForumsService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumsService.Application.Query.GetForum
{
    public class GetForumQuery : IRequest<ForumsDTO>
    {
        public Guid Id { get; }

        public GetForumQuery(Guid id)
        {
            Id = id;
        }
    }
}
