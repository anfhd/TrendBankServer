namespace TrendBankServer.Models.DataTransferObjects
{
    public class TransactionForCreationDto
    {
        public Guid? CardToId { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
