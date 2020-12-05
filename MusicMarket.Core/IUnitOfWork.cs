using MusicMarket.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MusicMarket.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IBooksRepository Book{ get; }
        IWritersRepository Writer{ get; }
        Task<int> CommitAsync();
    }
}
