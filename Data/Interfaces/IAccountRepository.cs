using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rdp.Data.Interfaces
{
    public interface IAccountRepository
    {
        List<rdp.Data.Entities.Account> GetAll();

        rdp.Data.Entities.Account? GetById(int? id);
        void Create(rdp.Data.Entities.Account account);
        
    }
}