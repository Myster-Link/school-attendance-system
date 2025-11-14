using Microsoft.EntityFrameworkCore.Storage;
using Repository.Repository.User;

namespace Repository.UnitOfWork
{
    public interface IUnitOfWorkManager
    {
        //  EF
        IDbContextTransaction Transaction { get; }
        Task SaveChanges();
        Task BeginTransaction();
        Task Commit();
        void Rollback();

        IUserRepository UserRepository { get; }
    }
}
