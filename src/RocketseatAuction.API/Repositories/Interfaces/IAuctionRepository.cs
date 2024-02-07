using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Repositories.Interfaces;

public interface IAuctionRepository
{
    public Task<Auction?>? Get(int id);
}