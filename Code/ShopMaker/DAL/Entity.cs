using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopMaker.DAL
{
    /// <summary>
    /// Base class for entities
    /// </summary>
    [Serializable]
    public abstract class Entity : IEntity
    {
        #region Members

        int? _requestedHashCode;
        Guid _ID;
        private bool _ignore;

        public Entity()
        {
            ID = IdentityGenerator.NewSequentialGuid();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Get or set the persisten object identifier
        /// </summary>
        public virtual Guid ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;

                OnIdChanged();
            }
        }

        #endregion

        #region Abstract Methods

        /// <summary>
        /// When POID is changed
        /// </summary>
        protected virtual void OnIdChanged()
        {

        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Check if this entity is transient, ie, without identity at this moment
        /// </summary>
        /// <returns>True if entity is transient, else false</returns>
        public bool IsTransient()
        {
            return this.ID == Guid.Empty;
        }

        public void MakeTransient()
        {
            this.ID = Guid.Empty;
        }

        public bool IsIgnored()
        {
            return _ignore;
        }

        public void SetIgnored(bool ignoreStatus)
        {
            _ignore = ignoreStatus;
        }

        #endregion

        #region Override Methods

        public override string ToString()
        {
            try
            {
                return JsonConvert.SerializeObject(this);
            }
            catch
            {
                return "Failed to serialize Entity";
            }
        }

        /// <summary>
        /// <see cref="M:System.Object.Equals"/>
        /// </summary>
        /// <param name="obj"><see cref="M:System.Object.Equals"/></param>
        /// <returns><see cref="M:System.Object.Equals"/></returns>
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Entity))
                return false;

            if (Object.ReferenceEquals(this, obj))
                return true;

            Entity item = (Entity)obj;

            if (item.IsTransient() || this.IsTransient())
                return false;
            else
                return item.ID == this.ID;
        }

        /// <summary>
        /// <see cref="M:System.Object.GetHashCode"/>
        /// </summary>
        /// <returns><see cref="M:System.Object.GetHashCode"/></returns>
        public override int GetHashCode()
        {
            if (!IsTransient())
            {
                if (!_requestedHashCode.HasValue)
                    _requestedHashCode = this.ID.GetHashCode() ^ 31;

                return _requestedHashCode.Value;
            }
            else
                return base.GetHashCode();

        }

        public static bool operator ==(Entity left, Entity right)
        {
            if (Object.Equals(left, null))
                return (Object.Equals(right, null)) ? true : false;
            else
                return left.Equals(right);
        }

        public static bool operator !=(Entity left, Entity right)
        {
            return !(left == right);
        }

        #endregion
    }
}
