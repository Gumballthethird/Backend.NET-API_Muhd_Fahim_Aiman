using FreelancerApp.Infrastructure.Data;
using FreelancerApp.Application.Interfaces;
using FreelancerApp.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register DbContext
builder.Services.AddDbContext<FreelancerDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"),
    x => x.MigrationsAssembly("FreelancerApp.Infrastructure")));

// Register Application Services
builder.Services.AddScoped<IFreelancerService, FreelancerService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
