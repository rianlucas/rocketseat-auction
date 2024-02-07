using Microsoft.AspNetCore.Mvc;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.UseCases.Auctions.GetCurrent;

namespace RocketseatAuction.API.Controllers;

[Route("/api[controller]")]
[ApiController]
public class AuctionController : ControllerBase
{
    private readonly GetCurrentAuctionUseCase _useCase;
    
    public AuctionController(GetCurrentAuctionUseCase useCase)
    {
        _useCase = useCase;
    }
    
    
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(Auction),StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Get(int id)
    {
        var auction = _useCase.Execute(id);

        if (auction is null)
        {
            return NoContent();
        }
        
        return Ok(auction);
    }
}