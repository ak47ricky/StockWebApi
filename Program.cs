using Microsoft.EntityFrameworkCore;
using StockWebApi.Models.Context;
using StockWebApi.Repository;
using StockWebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();


//µù¥Ucontext
builder.Services.AddDbContext<UserContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("WebDatabase")));

builder.Services.AddScoped<UserRepository>();

builder.Services.AddScoped<UserService>();

builder.Services.AddHttpContextAccessor();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
