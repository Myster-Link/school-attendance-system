using Microsoft.EntityFrameworkCore.Storage;
using Repository.Models;
using Repository.Repository.User;

namespace Repository.UnitOfWork
{
    public class UnitOfWorkManager : IUnitOfWorkManager
    {
        //  EF
        protected SchoolAttendanceDatabaseContext _context;
        protected IDbContextTransaction _transaction;

        //  Repositories
        private IUserRepository _userRepository;

        public UnitOfWorkManager(SchoolAttendanceDatabaseContext context)
        {
            _context = context;
        }

        //EF
        public SchoolAttendanceDatabaseContext Context => _context;
        public IDbContextTransaction Transaction => _transaction;

        public async Task SaveChanges()
            => await _context.SaveChangesAsync();

        public async Task BeginTransaction()
        {
            if (_context.Database.CurrentTransaction == null)
                _transaction = await _context.Database.BeginTransactionAsync();
            else
                _transaction = _context.Database.CurrentTransaction;
        }

        public async Task Commit()
        {
            try
            {
                await SaveChanges();
                _transaction.Commit();
            }
            catch (Exception)
            {
                Rollback();
                throw;
            }
            finally
            {
                Dispose();
            }
        }

        public void Rollback()
        {
            _transaction?.Rollback();
            Dispose();
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _transaction = null;
        }

        public IUserRepository UserRepository
        {
            get
            {
                return _userRepository == null ?
                       _userRepository = new UserRepository(_context) :
                       _userRepository;
            }
        }
    }
}