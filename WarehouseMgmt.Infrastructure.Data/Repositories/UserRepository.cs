using WarehouseMgmt.Domain.Entities;
using WarehouseMgmt.Domain.Repositories;
using WarehouseMgmt.Infrastructure.Data.Data;

namespace WarehouseMgmt.Infrastructure.Data.Repositories
{
    public class UserRepository : GenericRepository<UserEntity>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {
        }

        public UserEntity GetByUserName(string username, string password)
        {
            return this._context.Users.FirstOrDefault(x => x.UserName.Equals(username) && x.Password.Equals(password) );
        }


        public bool Login(string username, string password)
        {
            UserEntity user = GetByUserName(username, password) ?? throw new Exception("El usuario no existe");

            if (!user.Password.Equals(password))
            {
                throw new Exception("Contraseña incorrecta");
            }
            return true;
        }
    }
}
