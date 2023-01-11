using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB.Core.Contracts;
using DB.Models;

namespace DB.Repositories.Contracts
{
    public interface IClienteRepository: IRepository<Cliente>
    {
        IEnumerable<Cliente> GetTopSellingClients(int count);
    }
}
