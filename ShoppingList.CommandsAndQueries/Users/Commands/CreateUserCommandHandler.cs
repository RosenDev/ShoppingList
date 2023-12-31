﻿using MediatR;
using ShoppingList.Common;
using ShoppingList.Model;
using ShoppingList.Services.Contracts;

namespace ShoppingList.CommandsAndQueries.Users.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ApiResponse<string>>
    {
        private readonly IUsersService usersService;

        public CreateUserCommandHandler(
            IUsersService usersService
            )
        {
            this.usersService = usersService;
        }

        public async Task<ApiResponse<string>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new CreateUserModel
            {
                Username = request.Username,
            };
            return new ApiResponse<string>(await usersService.AddAsync(user, cancellationToken));
        }
    }
}
