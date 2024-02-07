using Microsoft.EntityFrameworkCore;
using RocketseatAuction.API.Data;
using RocketseatAuction.API.Repositories.Implementations;
using RocketseatAuction.API.Repositories.Interfaces;
using RocketseatAuction.API.UseCases.Auctions.GetCurrent;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RocketseatAuctionDbContext>(options => 
    options.UseSqlite(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IAuctionRepository, AuctionRepository>();
builder.Services.AddScoped<GetCurrentAuctionUseCase>();

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