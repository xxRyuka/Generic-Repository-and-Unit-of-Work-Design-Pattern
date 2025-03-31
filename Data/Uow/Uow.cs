using rdp.Data.Context;
using rdp.Data.Interfaces;
using rdp.Data.Repositories;

namespace rdp.Data.Uow
{
    public class Uow : IUow
    {
        private readonly BankContext _context;
        public Uow(BankContext context)
        {
            _context = context;
        }

        public IGenericRepository<T> GetRepository<T>() where T : class,new()
        {
            return new GenericRepository<T>(context:_context);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }

}