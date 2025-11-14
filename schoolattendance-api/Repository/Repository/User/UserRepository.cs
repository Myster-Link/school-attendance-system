using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Repository.Models;

namespace Repository.Repository.User
{
    public class UserRepository : IUserRepository
    {

        private readonly SchoolAttendanceDatabaseContext _context;

        public UserRepository(SchoolAttendanceDatabaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MasterUser>> Get()
            => await _context.MasterUsers.AsNoTracking()
                                         .Include(u => u.Role)
                                         .ToListAsync();

        public async Task<MasterUser> GetById(string userId)
            => await _context.MasterUsers.AsNoTracking().Include(u => u.Role).FirstOrDefaultAsync(u => u.UserId == userId);

        public async Task<MasterUser?> GetByIdentification(string identification)
            => await _context.MasterUsers.AsNoTracking().Include(u => u.Role).FirstOrDefaultAsync(u => u.Identification == identification);

        public async Task<MasterUser?> GetByEmail(string email)
            => await _context.MasterUsers.AsNoTracking().Include(u => u.Role).FirstOrDefaultAsync(u => u.Email == email);

        public async Task Add(MasterUser masterUser)
            => await _context.MasterUsers.AddAsync(masterUser);

        public async Task Update(MasterUser masterUser)
        {
            _context.MasterUsers.Attach(masterUser);
            _context.Entry(masterUser).State = EntityState.Modified;
        }

        public async Task Delete(string id)
        {
            var data = await _context.MasterUsers.FindAsync(id);
            _context.MasterUsers.Remove(data);
        }
    }
}