using DebtFreezerApi.Repositories;
using DebtFreezerApi.Models;

namespace DebtFreezerApi.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<User>> GetAll()
        {
            return await _userRepository.GetAll();
        }
    }
}
