using DebtFreezerApi.Data;
using DebtFreezerApi.Dtos;
using DebtFreezerApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Validation;

namespace DebtFreezerApi.Repositories
{
    public class UserRepository : IUSerRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var user = await _context.Utilisateurs.FindAsync(id);
            return user;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Utilisateurs.ToListAsync();
        }

        public async Task<User> CreateAsync(RegisterDto dto)
        {
            var user = new User
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Password = dto.Password,
                TotalDebt = 0,
                Challenges = new List<Challenge>()
            };
            _context.Utilisateurs.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return  await _context.Utilisateurs.AnyAsync(u => u.Id == id);
        }
    }
}
