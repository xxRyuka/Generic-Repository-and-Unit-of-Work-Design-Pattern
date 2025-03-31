namespace rdp.Data.Entities
{
	public class Account
	{
		public int Id { get; set; }
		public int Balance { get; set; }
		public int AccountNumber { get; set; }

		public ApplicationUser? ApplicationUser { get; set; }
		public int ApplicationUserId { get; set; }
	}
}
