using ShopMaker.DAL;
using System;
using System.Collections.Generic;
using System.Data.Common;
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


            DbCommand command = _dbCommandFactory.CreateCommand("AdminAccount_Add",
                _dbCommandFactory.CreateParameter("ID", user.ID),
                _dbCommandFactory.CreateParameter("AccountCreationDateTime", user.AccountCreationDateTime),
                _dbCommandFactory.CreateParameter("AccountStatus", user.AccountStatus),
                _dbCommandFactory.CreateParameter("EmailAddress", user.EmailAddress),
                _dbCommandFactory.CreateParameter("FirstName", user.FirstName),
                _dbCommandFactory.CreateParameter("LastName", user.LastName),              
                _dbCommandFactory.CreateParameter("LastWrongPasswordAttemptDateTime", user.LastWrongPasswordAttemptDateTime),
                _dbCommandFactory.CreateParameter("MobileNumber", user.MobileNumber),
                _dbCommandFactory.CreateParameter("Password", user.EncryptedPassword),
                _dbCommandFactory.CreateParameter("WrongPasswordAttempt", user.WrongPasswordAttempt)               
                );

            _dbCommandExecutionService.ExecuteCommand(command);			
		}

		public virtual void Remove(string EmailAddress)
		{
            DbCommand command = _dbCommandFactory.CreateCommand("AdminAccount_Remove",
               _dbCommandFactory.CreateParameter("EmailAddress", EmailAddress));

            _dbCommandExecutionService.ExecuteCommand(command);
		}

		public virtual void Edit(IUserAccount user)
		{
            DbCommand command = _dbCommandFactory.CreateCommand("AdminAccount_Edit",
                _dbCommandFactory.CreateParameter("ID", user.ID),
                _dbCommandFactory.CreateParameter("AccountCreationDateTime", user.AccountCreationDateTime),
                _dbCommandFactory.CreateParameter("AccountStatus", user.AccountStatus),
                _dbCommandFactory.CreateParameter("EmailAddress", user.EmailAddress),
                _dbCommandFactory.CreateParameter("FirstName", user.FirstName),
                _dbCommandFactory.CreateParameter("LastName", user.LastName),
                _dbCommandFactory.CreateParameter("LastWrongPasswordAttemptDateTime", user.LastWrongPasswordAttemptDateTime),
                _dbCommandFactory.CreateParameter("MobileNumber", user.MobileNumber),
                _dbCommandFactory.CreateParameter("Password", user.EncryptedPassword),
                _dbCommandFactory.CreateParameter("WrongPasswordAttempt", user.WrongPasswordAttempt)
                );

            _dbCommandExecutionService.ExecuteCommand(command);
		}

		public virtual IUserAccount Get(string emailAddress)
		{
            DbCommand command = _dbCommandFactory.CreateCommand("AdminAccount_Get",
                _dbCommandFactory.CreateParameter("EmailAddress", emailAddress));

            return _dbCommandExecutionService.ExecuteQuery<Admin>(command).FirstOrDefault<IUserAccount>();

            
		}

	}
}
