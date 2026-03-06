using DebtFreezerApi.Data;
using DebtFreezerApi.Dtos;
using DebtFreezerApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Validation;

namespace DebtFreezerApi.Repositories
{
    public class UserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetById(int id)
        {
            var user = await _context.Utilisateurs.FindAsync(id);
            return user;
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.Utilisateurs.ToListAsync();
        }

        public async Task<User> Create(RegisterDto dto)
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
    }
}
