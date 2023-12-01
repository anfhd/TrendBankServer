namespace TrendBankServer.Models.DataTransferObjects
{
    public class UserForUpdateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string PostalCode { get; set; }
        public string Password { get; set; }
    }
}
