using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumsService.Application.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        ICommandForumRepository CommandForumRepository{ get; }
        IQueryForumRepository QueryForumRepository { get; }
        Task Save();
    }
}
