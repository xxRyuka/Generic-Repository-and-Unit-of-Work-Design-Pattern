using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using rdp.Data.Entities;
using rdp.Models;

namespace rdp.Data.Mapping.Abstract
{
    public interface IUserMapper
    {
        List<UserListModel> MapToUserList(List<ApplicationUser> userList);

       UserListModel MapToUserModel(ApplicationUser user, UserListModel listModel);
        

        ApplicationUser MapToUser(UserListModel user, ApplicationUser applicationUser);
    }
}