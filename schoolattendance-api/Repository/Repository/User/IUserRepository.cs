using Repository.Models;

namespace Repository.Repository.User
{
    public interface IUserRepository
    {
        Task<IEnumerable<MasterUser>> Get();
        Task<MasterUser> GetById(string id);
        Task<MasterUser> GetByIdentification(string identification);
        Task<MasterUser> GetByEmail(string email);
        Task Add(MasterUser entity);
        Task Update(MasterUser entity);
        Task Delete(string id);
    }
}
