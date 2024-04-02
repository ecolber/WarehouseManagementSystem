namespace WarehouseMgmt.Application.Services.Interfaces
{
    public interface IJWTService
    {
        string GenerateToken(string UserName, string password);
    }
}
