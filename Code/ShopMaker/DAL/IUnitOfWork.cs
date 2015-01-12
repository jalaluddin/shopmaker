using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopMaker.DAL
{
    public interface IUnitOfWork
    {
        void MarkDirty(IEntity item);
        bool IsDirty(IEntity item);
        void MarkDeleted(IEntity item);
        bool IsDeleted(IEntity item);
        void MarkClean(IEntity item);
        bool IsClean(IEntity item);
        void MarkNew(IEntity item);
        bool IsNew(IEntity item);
        void Commit();
        void Rollback();
    }
}
