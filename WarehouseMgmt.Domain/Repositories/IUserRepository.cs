using WarehouseMgmt.Domain.Entities;

namespace WarehouseMgmt.Domain.Repositories
{
    public interface IUserRepository : IGenericRepository<UserEntity>
    {
        UserEntity GetByUserName(string username, string password);
        bool Login(string username, string password);
    }
}
