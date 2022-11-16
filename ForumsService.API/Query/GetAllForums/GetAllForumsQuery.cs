using ForumsService.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumsService.Application.Query.GetAllForums
{
    public class GetAllForumsQuery : IRequest<IEnumerable<ForumsDTO>>
    {
    }
}
