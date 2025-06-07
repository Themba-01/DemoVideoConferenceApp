using DemoVideoConference.Server.Models;
using DemoVideoConference.Shared.Authentication.Responses;
using DemoVideoConferenceApp.Server.Features.Authentication.CreateUserAccount.Command;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace DemoVideoConferenceApp.Server.Features.Authentication.CreateUserAccount.Handler
{
    public class CreateUserHandler(UserManager<AppUser> userManager) : IRequestHandler<CreateUserCommand, CreateUserResponse>
    {
        public async Task<CreateUserResponse> Handle(CreateUserCommand request, CancellationToken token)
        {
            //check if user model is not null
            ArgumentNullException.ThrowIfNull(request.User);

            // create App User instance
            var user = new AppUser
            {
                Name = request.User.Name,
                UserName = request.User.Name,
                Email = request.User.Email,
                PasswordHash = request.User.Password
            };

            //check for email duplication
            if (await userManager.FindByEmailAsync(user.Email) != null) return new() {IsSuccess = false, Message = "User already exists"};

            //create and save new user

            await userManager.CreateAsync(user, user.PasswordHash);

            return new() {IsSuccess = true, Message ="New user created"};
        }
    }
}