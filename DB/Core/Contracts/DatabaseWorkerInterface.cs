using System;
using DB.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Core.Contracts
{
    public interface IDatabaseWorker: IDisposable
    {
        IClienteRepository Clientes { get; }
        int Complete();
    }
}
