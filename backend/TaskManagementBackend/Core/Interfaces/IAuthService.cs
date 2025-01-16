namespace TaskManagementBackend.Core.Interfaces
{
    public interface IAuthService
    {
        string GenerateJwtToken(int userId, string username);
        bool VerifyPassword(string password, string hashedPassword);
        string HashPassword(string password);
    }
}
