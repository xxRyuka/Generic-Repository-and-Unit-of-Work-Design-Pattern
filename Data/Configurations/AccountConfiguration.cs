using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using rdp.Data.Entities;

namespace rdp.Data.Configurations
{
	public class AccountConfiguration : IEntityTypeConfiguration<Account>
	{
		public void Configure(EntityTypeBuilder<Account> builder)
		{
			builder.Property(x => x.Balance)
				.IsRequired()
				.HasColumnType("decimal(18,4)");

			builder.Property(x => x.AccountNumber).IsRequired();	
		}
	}
}
