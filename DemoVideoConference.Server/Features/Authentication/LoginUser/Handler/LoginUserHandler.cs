using System.Security.Claims;
using DemoVideoConference.Server.Models;
using DemoVideoConference.Shared.Authentication.Responses;
using DemoVideoConferenceApp.Server.Features.Authentication.LoginUser.Command;
using DemoVideoConferenceApp.Server.Helpers;
using DemoVideoConferenceApp.Server.Infrastructure.Data;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace DemoVideoConferenceApp.Server.Features.Authentication.LoginUser.Handler
{
    public record LoginUserHandler(UserManager<AppUser> userManager, AppDbContext context, ITokenGenerator tokenGenerator) : IRequestHandler<LoginUserCommand, LoginUserResponse>
    {
        public async Task<LoginUserResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            //check if id model is null
            ArgumentNullException.ThrowIfNull(request.Login);

            var user = await userManager.FindByEmailAsync(request.Login.Email);
            if (user == null) return new(null!) {IsSuccess = false, Message = "Invalid Credentials provided"};

            if (!await userManager.CheckPasswordAsync(user, request.Login.Password)) return new(null!) {IsSuccess = false, Message="Invalid Credentials provided"};

            var userClaims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Email, user.Email!)
            };

            string token = tokenGenerator.GenerateToken(userClaims);
            return new(token) {IsSuccess = true, Message = "Login made successfully"};
        }
    }

}
