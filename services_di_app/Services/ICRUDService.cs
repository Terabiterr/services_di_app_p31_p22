using services_di_app.Models;

namespace services_di_app.Services
{
    public interface ICRUDService
    {
        Task<IEnumerable<Model?>> GetAllAsync();
        Task<Model?> GetByIdAsync(int id);
        Task<Model?> CreateAsync(Model? model);
        Task<Model?> UpdateAsync(int id, Model? model);
        Task<bool> DeleteAsync(int id);
    }
}
