using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ShopMaker.DAL
{
    public interface IDbCommandFactory
    {
        DbCommand CreateCommand(string commandText, params object[] parameters);
        DbParameter CreateParameter(string name, object value);
        DbParameter CreateOutputParameter(string name, DbType dbType);
    }
}
