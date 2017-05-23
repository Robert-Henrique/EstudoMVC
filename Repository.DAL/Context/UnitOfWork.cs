using System.Data.Entity;

namespace Repository.DAL.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly DbContext _dbContext;

        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DbContext Context
        {
            get { return _dbContext; }
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
