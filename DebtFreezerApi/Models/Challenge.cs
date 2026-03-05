using System.ComponentModel.DataAnnotations;

namespace DebtFreezerApi.Models
{
    public class Challenge
    {
        public int Id { get; set; }

        [Required]
        public decimal TargetAmount { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        public List<User> Users { get; }
    }
}
