using MusicMarket.Core;
using MusicMarket.Core.Repositories;
using MusicMarket.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MusicMarket.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BooksMarketDbContext _context;
        private BookRepository _bookRepository;
        private WriterRepository _writerRepository;

        public UnitOfWork(BooksMarketDbContext context)
        {
            this._context = context;
        }

        public IBooksRepository Book=> _bookRepository = _bookRepository ?? new BookRepository(_context);

        public IWritersRepository Artists => _writerRepository = _writerRepository ?? new WriterRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
