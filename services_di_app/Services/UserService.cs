using Microsoft.EntityFrameworkCore;
using services_di_app.Data;
using services_di_app.Models;

namespace services_di_app.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        public UserService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<User?> CreateAsync(User? user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<User?>> GetAllAsync()
            => await _context.Users.ToListAsync();

        public async Task<User?> GetByIdAsync(int id)
            => await _context.Users.FindAsync(id);

        public async Task<User?> UpdateAsync(int id, User? user)
        {
            if (!_context.Users.Any(u => u.Id == id))
                return null;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
