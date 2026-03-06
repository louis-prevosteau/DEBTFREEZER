using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DebtFreezerApi.Models
{
    [Table("utilisateurs")]
    public class User
    {
        [Key]
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
