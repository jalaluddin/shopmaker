using Ninject;
using Proggasoft.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ShopMaker.DAL
{
    public class DbCommandExecutionService : IDbCommandExecutionService
    {
        private IReflectionHelper _reflectionHelper;

        public DbCommandExecutionService(IReflectionHelper reflectionHelper)
        {
            _reflectionHelper = reflectionHelper;
        }

        #region Execution Related Helper Methods

        public virtual int ExecuteCommand(DbCommand command)
        {
            int result = 0;
            try
            {
                command = ConvertNullToDbNull(command);

                if (command.Connection.State != System.Data.ConnectionState.Open)
                    command.Connection.Open();
                command.ExecuteNonQuery();
            }
            catch
            {
                result = -1;
                throw;
            }
            finally
            {
                // Releasing connection resource
                DisposeCommand(command);
            }

            return result;
        }

        public virtual int ExecuteCommand(Queue<DbCommand> commands)
        {
            while (commands.Count > 0)
            {
                DbCommand command = commands.Dequeue();
                ExecuteCommand(command);
            }
            return 0;
        }

        public virtual IEnumerable<T> ExecuteQuery<T>(DbCommand command) where T : IEntity
        {
            ICollection<T> result = null;

            DbDataReader reader = null;
            try
            {
                if (command.Connection.State != System.Data.ConnectionState.Open)
                    command.Connection.Open();
                reader = command.ExecuteReader();
                result = new List<T>();
                do
                {
                    DataTranslationItem item = new DataTranslationItem(reader.FieldCount);
                    for (var i = 0; i < reader.FieldCount; i++)
                    {
                        item.DataTypeNames[i] = reader.GetDataTypeName(i);
                        item.Types[i] = reader.GetFieldType(i);
                        item.ColumnNames[i] = reader.GetName(i);
                    }

                    while (reader.Read())
                    {
                        for (var i = 0; i < reader.FieldCount; i++)
                        {
                            item.ResultSet[i] = reader.GetValue(i);
                        }
                        result.Add(InternalTranslate<T>(item));
                    }
                }
                while (reader.NextResult());

                int _recordsAffected = reader.RecordsAffected;
            }
            catch
            {
                throw;
            }
            finally
            {
                if(reader != null)
                    reader.Dispose();
                if (command.Connection != null && command.Connection.State != System.Data.ConnectionState.Closed)
                    command.Connection.Close();
                if(command.Connection != null)
                    command.Connection.Dispose();
                if(command != null)
                    command.Dispose();
            }

            return result;
        }

        public virtual T ExecuteScalar<T>(DbCommand command)
        {
            try
            {
                command = ConvertNullToDbNull(command);

                if (command.Connection.State != System.Data.ConnectionState.Open)
                    command.Connection.Open();
                object result = command.ExecuteScalar();

                if (result == DBNull.Value)
                    return default(T);
                else
                    return (T)result;
            }
            catch
            {
                throw;
            }
            finally
            {
                // Releasing connection resource
                DisposeCommand(command);
            }
        }

        public virtual IEnumerable ExecuteQuery(Type type, DbCommand command)
        {
            ArrayList result = null;

            DbDataReader reader = null;
            try
            {
                if (command.Connection.State != System.Data.ConnectionState.Open)
                    command.Connection.Open();
                reader = command.ExecuteReader();
                result = new ArrayList();
                do
                {
                    DataTranslationItem item = new DataTranslationItem(reader.FieldCount);
                    for (var i = 0; i < reader.FieldCount; i++)
                    {
                        item.DataTypeNames[i] = reader.GetDataTypeName(i);
                        item.Types[i] = reader.GetFieldType(i);
                        item.ColumnNames[i] = reader.GetName(i);
                    }

                    while (reader.Read())
                    {
                        for (var i = 0; i < reader.FieldCount; i++)
                        {
                            item.ResultSet[i] = reader.GetValue(i);
                        }
                        result.Add(InternalTranslate(type, item));
                    }
                }
                while (reader.NextResult());

                int _recordsAffected = reader.RecordsAffected;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (reader != null)
                    reader.Dispose();
                // Releasing connection resource
                DisposeCommand(command);
            }

            return result;
        }

        public virtual IEnumerable<IEntity> ExecuteQuery(IEntity dataContainer, DbCommand command)
        {
            ICollection<IEntity> result = null;

            DbDataReader reader = null;
            try
            {
                if (command.Connection.State != System.Data.ConnectionState.Open)
                    command.Connection.Open();
                reader = command.ExecuteReader();
                result = new List<IEntity>();
                do
                {
                    DataTranslationItem item = new DataTranslationItem(reader.FieldCount);
                    for (var i = 0; i < reader.FieldCount; i++)
                    {
                        item.DataTypeNames[i] = reader.GetDataTypeName(i);
                        item.Types[i] = reader.GetFieldType(i);
                        item.ColumnNames[i] = reader.GetName(i);
                    }

                    while (reader.Read())
                    {
                        for (var i = 0; i < reader.FieldCount; i++)
                        {
                            item.ResultSet[i] = reader.GetValue(i);
                        }
                        result.Add(InternalTranslate(dataContainer, item));
                    }
                }
                while (reader.NextResult());

                int _recordsAffected = reader.RecordsAffected;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (reader != null)
                    reader.Dispose();
                // Releasing connection resource
                DisposeCommand(command);
            }

            return result;
        }

        #endregion

        #region Private Methods

        private DbCommand ConvertNullToDbNull(DbCommand command)
        {
            for (int i = 0; i < command.Parameters.Count; i++)
            {
                if (command.Parameters[i].Value == null)
                    command.Parameters[i].Value = DBNull.Value;
            }
            return command;
        }

        private T InternalTranslate<T>(DataTranslationItem item) where T : IEntity
        {
            Type type = typeof(T);
            return (T)InternalTranslate(type, item);
        }

        private object InternalTranslate(Type type, DataTranslationItem item)
        {
            ConstructorInfo constructor = type.GetConstructor(new Type[0]);
            var target = (IEntity)constructor.Invoke(new object[0]);
            return InternalTranslate(target, item);
        }

        private IEntity InternalTranslate(IEntity target, DataTranslationItem item)
        {
            Type type = target.GetType();
            
            for (int j = 0; j < item.Size; j++)
            {
                object value = item.ResultSet[j];
                if (value is DBNull)
                    value = null;
                string name = item.ColumnNames[j];

                bool isForeignKey = false;
                var property = type.GetProperty(name, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

                if (property == null && name != "ID" && name.Contains("ID"))
                {
                    name = name.Replace("ID", "");
                    isForeignKey = true;
                    property = type.GetProperty(name, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
                }
                
                if (property != null && property.CanWrite)
                {
                    if (isForeignKey)
                    {
                        var propertyValue = property.GetValue(target);
                        if (propertyValue != null && typeof(Entity).IsAssignableFrom(propertyValue.GetType()))
                        {
                            IEntity complexField = (IEntity)propertyValue;
                            if (value != null)
                                complexField.ID = (Guid)value;
                            else
                                complexField = null;

                            property.SetValue(target, complexField);
                        }
                        else if (property.PropertyType.IsInterface && typeof(IEntity).IsAssignableFrom(property.PropertyType))
                        {
                            // Removing I from interface name
                            string strongTypeName = property.PropertyType.AssemblyQualifiedName;
                            string[] parts = strongTypeName.Split(',');
                            int index = parts[0].LastIndexOf('.');
                            parts[0] = parts[0].Remove(index + 1, 1);
                            strongTypeName = String.Join(",", parts);
                            // Creating instance of the concrete type
                            Type concreteType = Type.GetType(strongTypeName);
                            ConstructorInfo constructor = concreteType.GetConstructor(new Type[0]);
                            var strongTypeValue = (IEntity)constructor.Invoke(new object[0]);

                            if (strongTypeValue != null)
                            {
                                IEntity complexField = (IEntity)strongTypeValue;
                                if (value != null)
                                {
                                    complexField.ID = (Guid)value;
                                    // if the property was null then it was not intended to pull the entire 
                                    // object for this property, rather we should only fetch ID
                                    complexField.SetIgnored(true);
                                }
                                else
                                    complexField = null;

                                property.SetValue(target, complexField);
                            }
                            else
                                property.SetValue(target, null);
                        }
                        else
                            property.SetValue(target, null);
                    }
                    else if (property.PropertyType == typeof(Double))
                        property.SetValue(target, Convert.ToDouble(value));
                    else
                        SetValueWithNullableEnumCheck(property, target, value);
                }
            }

            return (IEntity)target;
        }

        private void SetValueWithNullableEnumCheck(PropertyInfo property, IEntity target, object value)
        {
            Type propType = property.PropertyType;

            if (propType.IsGenericType &&
                  propType.GetGenericTypeDefinition() ==
                  typeof(Nullable<>) && value != null)
            {
                Type[] typeCol = propType.GetGenericArguments();
                Type nullableType;
                if (typeCol.Length > 0)
                {
                    nullableType = typeCol[0];
                    if (nullableType.BaseType == typeof(Enum))
                    {
                        object o = Enum.Parse(nullableType, value.ToString());
                        property.SetValue(target, o, null);
                    }
                    else
                        property.SetValue(target, value);
                }
            }
            else if (propType.IsEnum)
            {
                object o = Enum.Parse(propType, value.ToString());
                property.SetValue(target, o, null);
            }
            else
                property.SetValue(target, value);
        }

        private void DisposeCommand(DbCommand command)
        {
            if (command != null)
            {
                if (command.Connection != null)
                {
                    if (command.Connection.State != System.Data.ConnectionState.Closed)
                        command.Connection.Close();
                    command.Connection.Dispose();
                }
                command.Dispose();
            }
        }

        #endregion
    }
}
