using rdp.Data.Interfaces;

namespace rdp.Data.Uow
{
    public interface IUow
    {
        public IGenericRepository<T> GetRepository<T>() where T : class, new();

        public void SaveChanges();


    }
}