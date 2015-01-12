using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopMaker.DAL
{
    public interface IDbCommandExecutionService
    {
        int ExecuteCommand(DbCommand command);
        int ExecuteCommand(Queue<DbCommand> commands);
        IEnumerable<T> ExecuteQuery<T>(DbCommand command) where T : IEntity;
        IEnumerable ExecuteQuery(Type type, DbCommand command);
        IEnumerable<IEntity> ExecuteQuery(IEntity dataContainer, DbCommand command);
        T ExecuteScalar<T>(DbCommand command);
    }
}
