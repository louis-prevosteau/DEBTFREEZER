using System.ComponentModel.DataAnnotations;

namespace DebtFreezerApi.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public float TotalDebt { get; set; }

        public List<Challenge> Challenges { get; set; }
    }
}
