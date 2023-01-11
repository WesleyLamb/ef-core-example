using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using DB.Core;
using DB.Models;
using DB.Repositories.Contracts ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DB.Repositories
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(SGContext context) : base(context) 
        { 
        
        }
        public IEnumerable<Cliente> GetTopSellingClients(int count)
        {
            throw new NotImplementedException();

            //return SGContext.Clientes.OrderByDescending(char => char.FullPrice).Take(count).ToList();
        }

        public IEnumerable<Cliente> GetClientsWithPurchases(int pageIndex, int pageSize = 100) 
        { 
            throw new NotImplementedException();

            //return PlutoContext.Courses
            //    .Include(c => c.Cliente)
            //    .OrderBy(c => c.Cliente)
            //    .Skip((pageIndex - 1) * pageSize)
            //    .Take(pageSize)
            //    .ToList();
        }

        public SGContext SGContext
        {
            get { return Context as SGContext; }
        }
    }
}
