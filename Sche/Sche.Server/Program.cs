var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var allowedOrigin = builder.Configuration["AllowedOrigin"] ?? "https://termoinf.pl/";

builder.Services.AddCors(options =>
{
    options
    .AddPolicy(name: "CORSPolicy",
    policy =>
    {
        policy
            .WithOrigins(allowedOrigin)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    });
});

builder.Services.AddControllers();

var app = builder.Build();

app.UseDefaultFiles();
app.MapStaticAssets();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseCors("CORSPolicy");

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
