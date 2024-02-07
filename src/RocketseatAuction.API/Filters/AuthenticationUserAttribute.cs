using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RocketseatAuction.API.Data;

namespace RocketseatAuction.API.Filters;

public class AuthenticationUserAttribute : AuthorizeAttribute, IAuthorizationFilter
{

    private readonly RocketseatAuctionDbContext _repository;

    public AuthenticationUserAttribute(RocketseatAuctionDbContext repository) => _repository = repository;
    
    
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        try
        {

            var token = TokenFromRequest(context.HttpContext);
            var email = FromBase64(token);

            var user = _repository.Users.Any(x => x.Email.Equals(email));

            if (!user)
            {
                context.Result = new UnauthorizedObjectResult("User not found");
            }
        }
        catch (Exception ex)
        {
            context.Result = new UnauthorizedObjectResult(ex.Message);
        }

    }

    private string TokenFromRequest(HttpContext context)
    {
        var token = context.Request.Headers.Authorization.ToString();

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