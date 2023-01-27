using CompareJson.Api.Domain.Commands.JsonInBase64Left;
using CompareJson.Api.Domain.Commands.JsonInBase64Right;
using CompareJson.Api.Domain.Interfaces.Configurations;
using CompareJson.Api.Domain.Interfaces.Repository.Mongo;
using CompareJson.Api.Domain.Query.JsonCompare;
using CompareJson.Api.Infrastructure.Data.Configurations;
using CompareJson.Api.Infrastructure.Data.Repositories.Mongo;
using MediatR;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace CompareJson.Api
{
	public class Startup
	{
		public IConfiguration Configuration { get; }
		public Startup(IConfiguration configuration) 
		{
			Configuration = configuration;
		}

		public void ConfigureServices(IServiceCollection services)
		{

			services.Configure<DatabaseConfig>(Configuration.GetSection(nameof(DatabaseConfig)));	
			services.AddSingleton<IDatabaseConfig>(sp => sp.GetRequiredService<IOptions<DatabaseConfig>>().Value);
			services.AddMediatR(Assembly.GetExecutingAssembly());
			
			services.AddAutoMapper(typeof(JsonInBase64LeftCommandProfile));
			services.AddAutoMapper(typeof(JsonInBase64RightCommandProfile));
			services.AddAutoMapper(typeof(JsonCompareQueryProfile));

			services.AddSingleton<IJsonInBase64MongoRepository, JsonMongoRepository>();
	
			
			services.AddControllers();
			services.AddEndpointsApiExplorer();
			services.AddSwaggerGen();

		}

		public void Configure(WebApplication app, IWebHostEnvironment environment)
		{
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();

			app.MapControllers();

		}
	}
}