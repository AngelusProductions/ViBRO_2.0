using Microsoft.EntityFrameworkCore;
using Vibro.API.Data;
using Vibro.API.Mappings;
using Vibro.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<VibroDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("VibroConnectionString"));
});

builder.Services.AddScoped<IVibeRepository, SqlVibeRepository>();

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

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
