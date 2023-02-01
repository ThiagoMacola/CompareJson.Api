using CompareJson.Api.Middlewares;
using CompareJson.Domain.Commands.JsonInBase64Left;
using CompareJson.Domain.Commands.JsonInBase64Right;
using CompareJson.Domain.DomainService;
using CompareJson.Domain.Interfaces.DomainService;
using CompareJson.Domain.Interfaces.Repository.InMemory;
using CompareJson.Domain.Querys.JsonCompare;
using CompareJson.Infrastructure.Data.DatabaseContext;
using CompareJson.Infrastructure.Data.Repositories.InMemory;
using FluentValidation.AspNetCore;
using MediatR;
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
			services.AddMediatR(typeof(Startup));
			services.AddMediatR(typeof(JsonInBase64RightCommand).GetTypeInfo().Assembly);
			services.AddMediatR(typeof(JsonInBase64LeftCommand).GetTypeInfo().Assembly);
			services.AddMediatR(typeof(JsonCompareQuery).GetTypeInfo().Assembly);
			services.AddAutoMapper(typeof(JsonInBase64RightCommandProfile));
			services.AddAutoMapper(typeof(JsonCompareQueryProfile));
			services.AddTransient<GlobalExceptionHandlingMiddleware>();
			services.AddDbContext<JsonBase64Context>();

			services.AddSingleton<IJsonInBase64CompareDomainService, JsonInBase64CompareDomainService>();
			services.AddScoped<IJsonBase64Repository, JsonBase64Repository>();

			services.AddControllers()
				.AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<Startup>());

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

			app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

			app.UseAuthorization();

			app.MapControllers();
		}
	}
}