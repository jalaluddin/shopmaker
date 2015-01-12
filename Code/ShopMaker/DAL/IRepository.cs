using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ShopMaker.DAL
{
    public interface IRepository
    {
        void Delete(IEntity item);
        void Delete(ICollection<IEntity> items);
        void Delete(ICollection<object> itemIDs);
        void Insert(IEntity item);
        void Update(IEntity item);
        IEntity Get(object id);
        int GetTotalCount();
    }
}
