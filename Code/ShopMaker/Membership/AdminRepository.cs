using ShopMaker.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopMaker.Membership
{
	public class AdminRepository : IMembershipRepository
	{
        private IDbCommandExecutionService _dbCommandExecutionService;
        private IDbCommandFactory _dbCommandFactory;

        public AdminRepository(IDbCommandExecutionService dbCommandExecutionService,
            IDbCommandFactory dbCommandFactory)
        {
            _dbCommandExecutionService = dbCommandExecutionService;
            _dbCommandFactory = dbCommandFactory;
        }

		public virtual void Add(IUserAccount user)
		{
			throw new System.NotImplementedException();
		}

		public virtual void Remove(string EmailAddress)
		{
			throw new System.NotImplementedException();
		}

		public virtual void Edit(IUserAccount user)
		{
			throw new System.NotImplementedException();
		}

		public virtual IUserAccount Get(string emailAddress)
		{
			throw new System.NotImplementedException();
		}

	}
}

