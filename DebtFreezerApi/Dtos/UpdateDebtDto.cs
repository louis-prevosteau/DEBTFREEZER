using DebtFreezerApi.Models;

namespace DebtFreezerApi.Dtos
{
    public class UpdateDebtDto
    {
        public string Creditor { get; set; }

        public decimal OriginalAmount { get; set; }

        public decimal RemainingAmount { get; set; }

        public float InterestRate { get; set; }

        public DateTime DueDate { get; set; }

        public DebtType Type { get; set; }

        public int UserId { get; set; }
    }
}
