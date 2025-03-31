using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rdp.Models
{
    public class AccountListModel
    {
        public int Id { get; set; }
        public int ApplicationUserId { get; set; }
        public int Balance { get; set; }
        public int AccountNumber { get; set; }

        public string selectListInfo { get; set; }
    }
}