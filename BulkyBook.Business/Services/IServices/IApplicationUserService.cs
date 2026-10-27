using BulkyBook.Models;

namespace BulkyBook.Business;

public interface IApplicationUserService
{
    Task<ApplicationUser?> GetUserByIdAsync(string userId);
    Task<IEnumerable<ApplicationUser>> GetAllUsersAsync();
}
