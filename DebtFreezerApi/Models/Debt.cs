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

    public class Debt
    {
        public int Id { get; set; }

        public string Creditor { get; set; }

        public decimal OriginalAmount { get; set; }

        public decimal RemainingAmount { get; set; }

        public float InterestRate { get; set; }

        public DateTime DueDate { get; set; }

        public DebtType Type { get; set; }

        public DebtStatus Status { get; set; } = DebtStatus.ACTIVE;

        public int UserId { get; }
        public User User { get; }
    }
}
