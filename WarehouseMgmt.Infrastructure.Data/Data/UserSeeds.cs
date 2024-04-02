using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WarehouseMgmt.Domain.Entities;
using BCrypt.Net;

namespace WarehouseMgmt.Infrastructure.Data.Data
{
    public class UserSeeds : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {

            builder.HasData(
                new UserEntity { Id = 1, UserName = "Juan.Cuesta", Name = "Juan", Lastname = "Cuesta", Email = "juan.cuesta@prueba.com", Password = "Quefollon@2024", Role = "Administrador" },
                new UserEntity { Id = 2, UserName = "Isabel.Ruiz", Name = "Isabel", Lastname = "Ruiz", Email = "lahierbas@prueba.com", Password = "hierbas@2024", Role = "Operador" }
            );
        }

        public static class PasswordHelper
        {
            public static string HashPassword(string password)
            {
                return BCrypt.Net.BCrypt.HashPassword(password);
            }
        }
    }
}
