using CompareJson.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CompareJson.Api.Infrastructure.Data.DatabaseContext
{
	public class JsonBase64Context : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseInMemoryDatabase(databaseName: "JsonBase64");
		}
		public DbSet<JsonInBase64> JsonInBase64 { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<JsonInBase64>().HasKey(table => new { table.Id, table.Position });
		}
	}
}
