using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using rdp.Data.Context;
using rdp.Data.Entities;
using rdp.Data.Interfaces;

namespace rdp.Data.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly BankContext _context;

     

        public AccountRepository(BankContext context)
        {
            _context=context;
        }

        public List<Account> GetAll()
        {
            return _context.Accounts.ToList(); 
        }

        public Account? GetById(int? id)
        {
            return _context.Accounts.SingleOrDefault(x=>x.Id == id);
        }

        public void Create(Account account){
            _context.Accounts.Add(account);
        }

        public Account? GetByIdWithUser(int id)
        {
            return _context.Accounts.Include(x=>x.ApplicationUser).SingleOrDefault(x=>x.Id == id);
        }
    }
}