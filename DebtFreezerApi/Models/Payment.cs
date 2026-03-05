using System.ComponentModel.DataAnnotations;

namespace DebtFreezerApi.Models
{
    public class Payment
    {
        public int Id { get; set; }

        [Required]
        public decimal Amount { get; set; }

        public string Notes { get; set; }

        public DateTime PaymentDate { get; set; }

        [Required]
        public int UserId { get; set; }

        public User User { get; set; }

        [Required]
        public int DebtId { get; set; }

        public Debt Debt { get; set; }
    }
}
