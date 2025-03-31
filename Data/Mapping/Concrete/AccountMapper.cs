using rdp.Data.Entities;
using rdp.Data.Mapping.Abstract;
using rdp.Models;

namespace rdp.Data.Mapping.Concrete
{
    public class AccountMapper : IAccountMapper
    {
        public Account MapToAccount(AccountViewModel accountViewModel)
        {
            return new Account{
                AccountNumber = accountViewModel.AccountNumber,
                Balance = accountViewModel.Balance,
                ApplicationUserId = accountViewModel.ApplicationUserId
            };
        }    
    }    
}
