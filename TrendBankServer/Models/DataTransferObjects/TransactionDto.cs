using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TrendBankServer.Models.DataTransferObjects
{
    public class TransactionDto
    {
        public Guid Id { get; set; }
        public Guid CardFromId { get; set; }
        public Guid? CardToId { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
