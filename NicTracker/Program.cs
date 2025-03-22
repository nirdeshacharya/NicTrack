using Microsoft.EntityFrameworkCore;
using NicTrackerData.Models;
using NicTrackerService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register services
builder.Services.AddScoped<IIntakeService, IntakeService>();
builder.Services.AddScoped<ICravingsService, CravingsService>();
builder.Services.AddScoped<ILastSmokedService, LastSmokedService>();

//DBConn
var connectionString = builder.Configuration.GetConnectionString("AppDb");
builder.Services.AddDbContext<NicTracContext>(x => x.UseSqlServer(connectionString));
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
