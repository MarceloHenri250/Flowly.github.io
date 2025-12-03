using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Flowly.Api.Data;

var builder = WebApplication.CreateBuilder(args);

// Configuration
var configuration = builder.Configuration;

// Services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// EF Core - using MySQL (configured via `appsettings.json` ConnectionStrings:DefaultConnection)
builder.Services.AddDbContext<FlowlyDbContext>(options =>
{
    var conn = configuration.GetConnectionString("DefaultConnection") ?? "Server=localhost;Port=3306;Database=flowly;User=root;Password=your_password;";
    // Specify a server version to avoid design-time connection attempts by EF tools
    var serverVersion = new MySqlServerVersion(new Version(8, 0, 33));
    options.UseMySql(conn, serverVersion);
});

// Authentication - JWT
var jwtKey = configuration["Jwt:Key"] ?? "please-change-this-secret";
var keyBytes = Encoding.UTF8.GetBytes(jwtKey);
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(keyBytes)
    };
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", () => Results.Ok("Flowly API running"));
app.MapControllers();

// Ensure DB created (for dev)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<FlowlyDbContext>();
    db.Database.Migrate();
}

app.Run();
