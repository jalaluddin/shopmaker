using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ShopMaker.DAL
{
    public class SqlCommandFactory : IDbCommandFactory
    {
        private string _connectionString;

        public SqlCommandFactory(string connectionString)
        {
            this._connectionString = connectionString;
        }
        
        public virtual DbCommand CreateCommand(string commandText, params object[] parameters)
        {
            DbCommand command = new SqlCommand(commandText, new SqlConnection(this._connectionString));
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandTimeout = 18000;

            var dbParameters = new DbParameter[parameters.Length];
            if (parameters.All(p => p is DbParameter))
            {
                for (var i = 0; i < parameters.Length; i++)
                {
                    dbParameters[i] = (DbParameter)parameters[i];
                    if (((DbParameter)parameters[i]).Value == null)
                        dbParameters[i].Value = DBNull.Value;
                }
            }
            else if (!parameters.Any(p => p is DbParameter))
            {
                var parameterNames = new string[parameters.Length];
                var parameterSql = new string[parameters.Length];
                for (var i = 0; i < parameters.Length; i++)
                {
                    parameterNames[i] = string.Format(CultureInfo.InvariantCulture, "p{0}", i);
                    dbParameters[i] = command.CreateParameter();
                    dbParameters[i].ParameterName = parameterNames[i];
                    dbParameters[i].Value = parameters[i] ?? DBNull.Value;
                    parameterSql[i] = "@" + parameterNames[i];
                }
                command.CommandText = string.Format(CultureInfo.InvariantCulture, command.CommandText, parameterSql);
            }
            else
            {
                throw new InvalidOperationException("Mixed DB parameters are not allowed.");
            }

            foreach (var dbParameter in dbParameters)
            {
                if (!command.Parameters.Contains(dbParameter.ParameterName))
                    command.Parameters.Add(dbParameter);
            }
            return command;
        }

        public virtual DbParameter CreateParameter(string name, object value)
        {
            return new SqlParameter(name, CorrectSqlDateTime(value));
        }

        public virtual DbParameter CreateOutputParameter(string name, DbType dbType)
        {
            SqlParameter outParam = new SqlParameter(name, CorrectSqlDateTime(dbType));
            outParam.Direction = ParameterDirection.Output;
            return outParam;
        }

        protected object CorrectSqlDateTime(object parameterValue)
        {
            if (parameterValue != null && parameterValue.GetType().Name == "DateTime")
            {
                if (Convert.ToDateTime(parameterValue) < SqlDateTime.MinValue.Value)
                    return SqlDateTime.MinValue.Value;
                else
                    return parameterValue;
            }
            else
                return parameterValue;
        }
    }
}
