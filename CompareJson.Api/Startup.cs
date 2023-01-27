using CompareJson.Api.CrossCutting.Execeptions;
using CompareJson.Api.Domain.Commands.JsonInBase64Left;
using CompareJson.Api.Domain.Commands.JsonInBase64Right;
using CompareJson.Api.Domain.Interfaces.Repository.InMemory;
using CompareJson.Api.Domain.Query.JsonCompare;
using CompareJson.Api.Infrastructure.Data.DatabaseContext;
using CompareJson.Api.Infrastructure.Data.Repositories.InMemory;
using MediatR;
using System.Reflection;
using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

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
			services.AddMediatR(Assembly.GetExecutingAssembly());

			services.AddAutoMapper(typeof(JsonInBase64LeftCommandProfile));
			services.AddAutoMapper(typeof(JsonInBase64RightCommandProfile));
			services.AddAutoMapper(typeof(JsonCompareQueryProfile));

			services.AddDbContext<JsonBase64Context>();

			services.AddTransient<IJsonBase64Repository, JsonBase64Repository>();

			services.AddValidatorsFromAssembly(typeof(JsonInBase64LeftCommandValidator).Assembly);
			services.AddControllers(x =>
				{
					x.Filters.Add<JsonIsNotBase64Exception>();
				}
			);
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