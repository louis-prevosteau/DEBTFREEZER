using DebtFreezerApi.Data;
using DebtFreezerApi.Dtos;
using DebtFreezerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DebtFreezerApi.Services
{
    public class AuthService
    {
        private readonly ApplicationDbContext _context;

        public AuthService(ApplicationDbContext context)
        {
            _context = context;
        }

        public User Register(RegisterDto dto)
        {
            // Optional: check if email is already registered
            if (_context.Utilisateurs.Any(u => u.Email == dto.Email))
                throw new Exception("Email already in use.");

            var user = new User
            {
                FullName = dto.FullName,
                Email = dto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                TotalDebt = 0,
                Challenges = new List<Challenge>()
            };

            _context.Utilisateurs.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User Login(LoginDto dto)
        {
            var user = _context.Utilisateurs
                .FirstOrDefault(u => u.Email == dto.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
                return null;

            return user;
        }
    }
}