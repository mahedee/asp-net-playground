
using DemoApp.Filters;

namespace DemoApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            // Here services is the IServiceCollection object

            // Add the filter to the global filter collection
            builder.Services.AddControllers(options =>
            {
                options.Filters.Add(new CustomHeaderFilter("X-DevelopedBy", "Mahedee"));
            });
            
            // Add Custom Authorization Filter to the global filter collection using IServiceCollection object
            builder.Services.AddControllers(options =>
            {
                options.Filters.Add(new CustomAuthorizationFilter());
            });


            // Add policy based authorization
            builder.Services.AddAuthorization(options =>
            {
                // Here Admin is the policy name and Role is the claim type
                options.AddPolicy("Admin", policy => policy.RequireClaim("Role", "Admin"));

                // Here User is the policy name and Role is the claim type
                options.AddPolicy("User", policy => policy.RequireRole("Role", "User"));
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}