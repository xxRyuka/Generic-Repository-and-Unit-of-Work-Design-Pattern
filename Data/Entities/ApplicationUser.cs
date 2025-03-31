namespace rdp.Data.Entities
{
	public class ApplicationUser
	{
		public int Id{ get; set; }

		public string? Name { get; set; }
		public string? SurName { get; set; }

		public List<Account>? Accounts { get; set; } = new List<Account>();

	}
}
