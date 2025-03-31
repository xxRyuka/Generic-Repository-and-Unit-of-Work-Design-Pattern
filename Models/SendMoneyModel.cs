namespace rdp.Models
{
    public class SendMoneyModel
    {
        public int SenderId { get; set; }
        public int Amount { get; set; }
        public int AccountId { get; set; }
    }
}