using DebtFreezerApi.Models;

namespace DebtFreezerApi.Dtos
{
    public class ChallengeDto
    {
        public string Name { get; set; }

        public decimal TargetAmount { get; set; }

        public DateTime DueDate { get; set; }

        public List<UserDto> Users { get; set; }
    }
}
