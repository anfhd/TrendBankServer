﻿namespace TrendBankServer.Models.DataTransferObjects
{
    public class CardForCreationDto
    {
        public string Number { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string CVV { get; set; }
        public double Balance { get; set; }
    }
}
