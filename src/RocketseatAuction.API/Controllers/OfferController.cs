
using Microsoft.AspNetCore.Mvc;
using RocketseatAuction.API.Communitcation.Requests;
using RocketseatAuction.API.Filters;
using RocketseatAuction.API.UseCases.Offers.CreateOffer;

namespace RocketseatAuction.API.Controllers;

public class OfferController : RocketseatAuctionBaseController
{
    [HttpPost]
    [Route("{id:int}")]
    [ServiceFilter(typeof(AuthenticationUserAttribute))]
    public async Task<IActionResult> CreateOffer(
        int id, 
        [FromBody] RequestCreateOffer request,
        [FromServices] CreateOfferUseCase useCase
        )
    {
        var offer = await useCase.Execute(request);
        return Created(String.Empty, offer);
    }
}

