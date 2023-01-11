using DB.Core;
using DB.Core.Contracts;
using DB.Repositories.Contracts;
using DB.Repositories;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Models
{
    public class DatabaseWorker : IDatabaseWorker
    {
        private readonly SGContext _context;

        private void loadRepositories()
        {
            Clientes = new ClienteRepository(_context);
        }

        public DatabaseWorker(SGContext context)
        {
            _context = context;

            this.loadRepositories();
        }
        public DatabaseWorker()
        {
            _context = DatabaseHelper.GetDefaultContext();

            this.loadRepositories();
        }

        public IClienteRepository Clientes { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
