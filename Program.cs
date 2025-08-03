using Microsoft.EntityFrameworkCore;
using StockWebApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();


//���Ucontext
builder.Services.AddDbContext<UserContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("WebDatabase")));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
