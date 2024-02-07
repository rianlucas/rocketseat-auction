using Microsoft.AspNetCore.Mvc;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.UseCases.Auctions.GetCurrent;

namespace RocketseatAuction.API.Controllers;

public class AuctionController : RocketseatAuctionBaseController
{
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(Auction), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> Get(
        int id,
        [FromServices] GetCurrentAuctionUseCase useCase
        )
    {
        var auction = await useCase.Execute(id);

        if (auction is null)
        {
            return NoContent();
        }

        return Ok(auction);
    }
}