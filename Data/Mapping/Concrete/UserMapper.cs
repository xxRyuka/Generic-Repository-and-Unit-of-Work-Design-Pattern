using rdp.Data.Context;
using rdp.Data.Entities;
using rdp.Data.Mapping.Abstract;
using rdp.Data.Repositories;
using rdp.Models;

namespace rdp.Data.Mapping.Concrete
{
    public class UserMapper : IUserMapper
    {
        // dısardan liste vereceğiz
        public List<UserListModel> MapToUserList(List<ApplicationUser> userList)
        {
            var list = userList.Select(x => new UserListModel
            {
                Id = x.Id,
                Name = x.Name,
                SurName = x.SurName

            }).ToList();

            return list;
        }

        // dısarıdan bir user vereceğiz
        public UserListModel MapToUserModel(ApplicationUser user, UserListModel listModel)
        {
            listModel.Id = user.Id;
                listModel.Name = user.Name;
                listModel.SurName = user.SurName;

            return listModel;
        }

        public ApplicationUser MapToUser(UserListModel user, ApplicationUser applicationUser)
        {

            applicationUser.Id = user.Id;
            applicationUser.Name = user.Name;
            applicationUser.SurName = user.SurName;
            return applicationUser;

        }
    }
}