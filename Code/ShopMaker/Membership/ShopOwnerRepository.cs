using ShopMaker.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;

namespace ShopMaker.Membership
{
	public class ShopOwnerRepository : IMembershipRepository
	{
        private IDbCommandExecutionService _dbCommandExecutionService;
        private IDbCommandFactory _dbCommandFactory;

        public ShopOwnerRepository(IDbCommandExecutionService dbCommandExecutionService,
            IDbCommandFactory dbCommandFactory)
        {
            _dbCommandExecutionService = dbCommandExecutionService;
            _dbCommandFactory = dbCommandFactory;
        }

		public virtual void Add(IUserAccount user)
		{
            DbCommand command = _dbCommandFactory.CreateCommand("ShopOwnerAccount_Add",
                _dbCommandFactory.CreateParameter("AccountCreationDateTime", user.AccountCreationDateTime),
                _dbCommandFactory.CreateParameter("AccountStatus", user.AccountStatus),
                _dbCommandFactory.CreateParameter("EmailAddress", user.EmailAddress),
                _dbCommandFactory.CreateParameter("FirstName", user.FirstName),
                _dbCommandFactory.CreateParameter("IPAddress", user.IPAddress),
                _dbCommandFactory.CreateParameter("LastLoginDateTime", user.LastLoginDateTime),
                _dbCommandFactory.CreateParameter("LastName", user.LastName),
                _dbCommandFactory.CreateParameter("LastWrongPasswordAttemptDateTime", user.LastWrongPasswordAttemptDateTime),
                _dbCommandFactory.CreateParameter("MobileNumber", user.MobileNumber),
                _dbCommandFactory.CreateParameter("Password", user.EncryptedPassword),
                _dbCommandFactory.CreateParameter("WrongPasswordAttempt", user.WrongPasswordAttempt),
                _dbCommandFactory.CreateParameter("ID", user.ID));

            _dbCommandExecutionService.ExecuteCommand(command);
		}

		public virtual void Remove(string emailAddress)
		{
            DbCommand command = _dbCommandFactory.CreateCommand("ShopOwnerAccount_Remove",
                _dbCommandFactory.CreateParameter("EmailAddress", emailAddress));

            _dbCommandExecutionService.ExecuteCommand(command);
		}

		public virtual void Edit(IUserAccount user)
		{
            DbCommand command = _dbCommandFactory.CreateCommand("ShopOwnerAccount_Edit",
                _dbCommandFactory.CreateParameter("AccountCreationDateTime", user.AccountCreationDateTime),
                _dbCommandFactory.CreateParameter("AccountStatus", user.AccountStatus),
                _dbCommandFactory.CreateParameter("EmailAddress", user.EmailAddress),
                _dbCommandFactory.CreateParameter("FirstName", user.FirstName),
                _dbCommandFactory.CreateParameter("IPAddress", user.IPAddress),
                _dbCommandFactory.CreateParameter("LastLoginDateTime", user.LastLoginDateTime),
                _dbCommandFactory.CreateParameter("LastName", user.LastName),
                _dbCommandFactory.CreateParameter("LastWrongPasswordAttemptDateTime", user.LastWrongPasswordAttemptDateTime),
                _dbCommandFactory.CreateParameter("MobileNumber", user.MobileNumber),
                _dbCommandFactory.CreateParameter("Password", user.EncryptedPassword),
                _dbCommandFactory.CreateParameter("WrongPasswordAttempt", user.WrongPasswordAttempt),
                _dbCommandFactory.CreateParameter("ID", user.ID));

            _dbCommandExecutionService.ExecuteCommand(command);
		}

		public virtual IUserAccount Get(string emailAddress)
		{
            DbCommand command = _dbCommandFactory.CreateCommand("ShopOwnerAccount_Get",
                _dbCommandFactory.CreateParameter("EmailAddress", emailAddress));

            return _dbCommandExecutionService.ExecuteQuery<ShopOwner>(command).FirstOrDefault<IUserAccount>();
		}
	}
}