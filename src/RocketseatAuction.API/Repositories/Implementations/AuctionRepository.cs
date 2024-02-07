using Microsoft.EntityFrameworkCore;
using RocketseatAuction.API.Data;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Repositories.Interfaces;

namespace RocketseatAuction.API.Repositories.Implementations;

public class AuctionRepository : IAuctionRepository
{
    private readonly RocketseatAuctionDbContext _context;
    
    public AuctionRepository(RocketseatAuctionDbContext context)
    {
        _context = context;
    } 
    
    public Task<Auction?> Get(int id)
    {
        var auction = _context.Auctions
            .AsNoTracking()
            .Include(auction => auction.Items)
            .FirstOrDefaultAsync(x => x.Id == id);

        return auction.Result is null ? null : auction;
    }
}