using System;

namespace ShopMaker.DAL
{
    public interface IEntity
    {
        Guid ID { get; set; }
        bool IsTransient();
        void MakeTransient();
        bool IsIgnored();
        void SetIgnored(bool ignoreStatus);
    }
}
