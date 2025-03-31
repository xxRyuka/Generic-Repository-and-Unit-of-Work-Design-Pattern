using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rdp.Data.Entities;
using rdp.Models;

namespace rdp.Data.Mapping.Abstract
{
    public interface IAccountMapper
    {
        Account MapToAccount(AccountViewModel accountViewModel);
    }
}