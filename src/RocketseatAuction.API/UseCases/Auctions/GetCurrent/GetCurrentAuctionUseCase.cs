using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Repositories.Interfaces;

namespace RocketseatAuction.API.UseCases.Auctions.GetCurrent;

public class GetCurrentAuctionUseCase
{

    private readonly IAuctionRepository _repository;

    public GetCurrentAuctionUseCase(IAuctionRepository repository)
    {
        _repository = repository;
    }
    
    public Task<Auction?> Execute(int id)
    {
        return _repository.Get(id);
    }
}