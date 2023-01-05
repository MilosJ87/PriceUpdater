using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

using PriceUpdater.DbContexts;
using PriceUpdater.Entities;
using PriceUpdater.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var dbConnectionString = builder.Configuration.GetConnectionString("PriceUpdaterConnectionString");
builder.Services.AddDbContext<PriceUpdaterContext>(options => options.UseSqlServer(dbConnectionString));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IZlatneKovaniceRepo, ZlatneKovaniceRepo>();


builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: "CorsPolicy", builder =>
    {
        builder.WithOrigins("http://localhost:4200/")
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
