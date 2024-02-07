using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RocketseatAuction.API.Data;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Filters;

namespace RocketseatAuction.API.Utils;

public class LoggedUser
{

    private readonly RocketseatAuctionDbContext _repository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    
    public LoggedUser(RocketseatAuctionDbContext repository,  IHttpContextAccessor httpContextAccessor)
    {
        _repository = repository;
        _httpContextAccessor = httpContextAccessor;
    } 
    
    
    public Task<User> User()
    {
            var token = TokenFromRequest();
            var email = FromBase64(token);
            
            var user = _repository.Users.FirstOrDefaultAsync(x => x.Email.Equals(email));

            return user;
    }
    
    private string TokenFromRequest()
    {
        var token = _httpContextAccessor.HttpContext?.Request.Headers.Authorization.ToString();

        if (string.IsNullOrEmpty(token))
        {
            throw new ArgumentNullException(token);
        }

        return token["Bearer ".Length..];
    }
    
    private string FromBase64(string base64)
    {
        var data = Convert.FromBase64String(base64);
        return System.Text.Encoding.UTF8.GetString(data);
    }
}