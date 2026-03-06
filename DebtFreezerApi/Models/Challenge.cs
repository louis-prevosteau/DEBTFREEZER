using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DebtFreezerApi.Models
{
    [Table("challenge")]
    public class Challenge
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal TargetAmount { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        public List<User> Users { get; set; }
    }
}
