using Microsoft.EntityFrameworkCore;
using services_di_app.Data;
using services_di_app.Models;

namespace services_di_app.Services
{
    public class UserService : ICRUDService
    {
        private readonly AppDbContext _context;
        public UserService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Model?> CreateAsync(Model? model)
        {
            if (model is not User newUser)
                throw new Exception("Error model ...");

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Model?>> GetAllAsync()
            => await _context.Users.ToArrayAsync();

        public async Task<Model?> GetByIdAsync(int id)
            => await _context.Users.FindAsync(id);

        public async Task<Model?> UpdateAsync(int id, Model? model)
        {
            if (model is not User user)
                throw new Exception("Error model ...");
            if(await _context.Users.FindAsync(id) == null)
                throw new Exception("Not found model ...");
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
