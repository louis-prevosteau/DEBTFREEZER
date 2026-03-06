using DebtFreezerApi.Models;

namespace DebtFreezerApi.Dtos
{
    public class DebtDto
    {
        public int Id { get; set; }

        public string Creditor { get; set; }

        public decimal OriginalAmount { get; set; }

        public decimal RemainingAmount { get; set; }

        public float InterestRate { get; set; }

        public DateTime DueDate { get; set; }

        public DebtType Type { get; set; }

        public DebtStatus Status { get; set; }

        public User User { get; }
    }
}
