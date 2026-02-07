var builder = WebApplication.CreateBuilder(args);

// Add controller support to the service container
builder.Services.AddControllers();

// Configure CORS to allow requests from the Angular development server
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularDev", policy =>
    {
        policy
            .WithOrigins("http://localhost:4200") // Allow requests only from Angular dev server
            .AllowAnyHeader()                     // Allow any HTTP headers
            .AllowAnyMethod()                     // Allow GET, POST, PUT, DELETE, etc.
            .SetIsOriginAllowedToAllowWildcardSubdomains(); // Optional: allow subdomains of localhost
    });
});

var app = builder.Build();

// Enable the configured CORS policy
app.UseCors("AllowAngularDev");

// Enable authorization middleware (if needed for future endpoints)
app.UseAuthorization();

// Map controller routes (attribute routing)
app.MapControllers();

// Run the application
app.Run();
