namespace DebtFreezerApi.Dtos
{
    public class PaymentDto
    {
        public decimal Amount { get; set; }

        public string Notes { get; set; }

        public DateTime PaymentDate { get; set; }

        public UserDto User;

        public DebtDto Debt;
    }
}
