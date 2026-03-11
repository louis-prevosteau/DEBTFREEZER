using DebtFreezerApi.Dtos;
using DebtFreezerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DebtFreezerApi.Repositories
{
    public interface IUSerRepository


    {
        
        Task<User> GetByIdAsync(int id);

        Task<List<User>> GetAllAsync();


        Task<User> CreateAsync(RegisterDto dto);


        Task<bool> ExistsAsync(int id);

    }
}
