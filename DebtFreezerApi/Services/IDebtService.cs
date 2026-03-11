using DebtFreezerApi.Dtos;

namespace DebtFreezerApi.Services
{
    public interface IDebtService
    {
        Task<List<DebtDto>> GetAllAsync();

        Task<DebtDto> GetByIdAsync(int id);

        Task<DebtDto> CreateAsync(CreateDebtDto dto);

        Task<bool> UpdateAsync(int id, UpdateDebtDto dto);

        Task<bool> DeleteAsync(int id);
    }
}
