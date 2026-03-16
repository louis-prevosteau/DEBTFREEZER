using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DebtFreezerApi.Models
{
    public enum DebtType
    {
        CREDIT_CARD,
        PERSONAL_LOAN,
        MORTGAGE,
        STUDENT_LOAN,
        OTHER
    }

    public enum DebtStatus
    {
        ACTIVE,
        PAID_OFF
    }
    [Table("dettes")]
    public class Debt
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Creditor is required.")]
        public string Creditor { get; set; }


        [Range(0, double.MaxValue, ErrorMessage = "Le montant doit être supérieur à 0")]
        public decimal OriginalAmount { get; set; }

        public decimal RemainingAmount { get; set; }

        [Range(1, 100, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public float InterestRate { get; set; }

        
        public DateTime DueDate { get; set; }

        public DebtType Type { get; set; }

        public DebtStatus Status { get; set; } = DebtStatus.ACTIVE;

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
