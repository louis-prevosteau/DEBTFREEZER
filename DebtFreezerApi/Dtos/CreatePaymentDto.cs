namespace DebtFreezerApi.Dtos
{
    public class CreatePaymentDto
    {
        public decimal Amount { get; set; }

        public string Notes { get; set; }

        public DateTime PaymentDate { get; set; }

        public int UserId { get; set; }

        public int DebtId { get; set; }
    }
}
