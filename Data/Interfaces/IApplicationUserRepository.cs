using rdp.Data.Entities;

namespace rdp.Data.Interfaces
{
    public interface IApplicationUserRepository
    {
        List<ApplicationUser> GetAll();
        ApplicationUser? GetById(int? id);
           
    }
}