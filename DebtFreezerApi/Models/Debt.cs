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

        public string Creditor { get; set; }

        public decimal OriginalAmount { get; set; }

        public decimal RemainingAmount { get; set; }

        public float InterestRate { get; set; }

        public DateTime DueDate { get; set; }

        public DebtType Type { get; set; }

        public DebtStatus Status { get; set; } = DebtStatus.ACTIVE;

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
