using DebtFreezerApi.Models;

namespace DebtFreezerApi.Dtos
{
    public class UserDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public float TotalDebt { get; set; }
        public List<ChallengeDto> Challenges { get; set; }
    }
}
