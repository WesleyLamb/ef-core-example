using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Core
{
    public class DatabaseHelper
    {
        private static SGContext _sgContext;
        private static ConnectionParams _connectionParams;

        public static SGContext GetDefaultContext()
        {
            if (_sgContext == null)
            {
                _sgContext = new SGContext(DatabaseHelper.GetDefaultConnectionParams());
            }
            return _sgContext;
        }

        public static ConnectionParams GetDefaultConnectionParams()
        {
            if (_connectionParams == null)
            {
                _connectionParams = new ConnectionParams();
                _connectionParams.LoadFromIniFile($"{System.Environment.CurrentDirectory}\\ConfigSoftMaster.ini");
            }
            
            return _connectionParams;
        }
    }
}
