using BackendAssignment.Data;
using Microsoft.EntityFrameworkCore;

namespace BackendAssignment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            // Add OpenAPI support
            builder.Services.AddOpenApi();

            // Add CORS policy to allow any origin, any method, any header
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder => builder
                        .AllowAnyOrigin()      // Allow any origin for now (to test)
                        .AllowAnyHeader()      // Allow all headers
                        .AllowAnyMethod());    // Allow all methods (GET, POST, etc.)
            });

            // Configure DB context
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi(); // OpenAPI setup for development
            }

            // Apply the CORS policy globally
            app.UseCors("AllowAllOrigins");

            // Use HTTPS redirection (though you're using HTTP now, this is fine)
            app.UseHttpsRedirection();

            // Apply authorization middleware (if needed)
            app.UseAuthorization();

            // Map controllers (API endpoints)
            app.MapControllers();

            // Start the application
            app.Run();
        }
    }
}
