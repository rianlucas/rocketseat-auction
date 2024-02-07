using Microsoft.EntityFrameworkCore;
using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Data;

public class RocketseatAuctionDbContext : DbContext
{
    
    public RocketseatAuctionDbContext(DbContextOptions<RocketseatAuctionDbContext> options) : base(options)
    {
    }

    public DbSet<Auction> Auctions { get; set; }
}