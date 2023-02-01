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

			services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<JsonInBase64LeftCommandValidator>());

			services.AddEndpointsApiExplorer();
			services.AddSwaggerGen(sw =>
			{
				sw.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
				{
					Title = "CompareJson Api",
					Version = "v1",
					Description = "API responsible for comparing two documents in Json base64 format and returning their similarities, differences and difference sizes",
					License = new Microsoft.OpenApi.Models.OpenApiLicense() { Name = "Licensed by xpto documentation api" }
				});
			});
		}

		public void Configure(WebApplication app, IWebHostEnvironment environment)
		{
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI(sw =>
				{
					sw.SwaggerEndpoint("/swagger/v1/swagger.json", "CompareJson.Api v1");

				});
			}

			app.UseHttpsRedirection();

			app.UseMiddleware<GlobalExceptionHandlingMiddleware>();

			app.UseAuthorization();

			app.MapControllers();
		}
	}
}