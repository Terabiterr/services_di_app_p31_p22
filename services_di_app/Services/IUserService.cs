using services_di_app.Models;

namespace services_di_app.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User?>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<User?> CreateAsync(User? model);
        Task<User?> UpdateAsync(int id, User? model);
        Task<bool> DeleteAsync(int id);
    }
}
