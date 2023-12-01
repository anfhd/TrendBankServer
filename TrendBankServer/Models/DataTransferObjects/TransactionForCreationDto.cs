using System.ComponentModel.DataAnnotations;

namespace TrendBankServer.Models.DataTransferObjects
{
    public class TransactionForCreationDto
    {
        public Guid? CardToId { get; set; }

        [Required(ErrorMessage = "Amount is a required field.")]
        public double Amount { get; set; }

        [Required(ErrorMessage = "Date is a required field.")]
        public DateTime Date { get; set; }
    }
}
