using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TrendBankServer.Models.DataTransferObjects
{
    public class CardDto
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string CVV { get; set; }
        public double Balance { get; set; }
    }
}
