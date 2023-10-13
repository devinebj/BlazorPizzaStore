using Microsoft.EntityFrameworkCore;
using StoreDatabase.Data;

namespace PizzaStoreWebApi {
	public class Program {
		public static void Main(string[] args) {
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddDbContext<StoreContext>(optionsBuilder => {
				optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("StoreDB"));
			});

			builder.Services.AddDbContext<StoreContext>();

			builder.Services.AddControllers();

			builder.Services.AddCors(options => {
				options.AddPolicy("CorsAllowAll",
					policy => {
						policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
					});
			});

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			app.UseCors("CorsAllowAll");
			app.UseHttpsRedirection();

			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}