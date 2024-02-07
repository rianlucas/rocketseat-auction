using RocketseatAuction.API.Communitcation.Requests;
using RocketseatAuction.API.Data;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Utils;

namespace RocketseatAuction.API.UseCases.Offers.CreateOffer;

public class CreateOfferUseCase
{
    private readonly RocketseatAuctionDbContext _repository;
    private readonly LoggedUser _loggedUser;

    public CreateOfferUseCase(RocketseatAuctionDbContext repository, LoggedUser loggedUser)
    {
        _repository = repository;
        _loggedUser = loggedUser;
    } 
    
    public async Task<Offer> Execute(RequestCreateOffer request)
    {
        
        var offer = new Offer
        {
            ItemId = request.ItemId,
            UserId = _loggedUser.User().Result.Id,
            Price = request.Price
        };

        await _repository.Offers.AddAsync(offer);
        await _repository.SaveChangesAsync();

        return offer;
    }
}