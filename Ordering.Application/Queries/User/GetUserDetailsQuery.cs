﻿using MediatR;
using Ordering.Application.Common.Interfaces;
using Ordering.Application.DTOs;

namespace Ordering.Application.Queries.User;

public class GetUserDetailsQuery : IRequest<UserDetailsResponseDTO>
{
    public string UserId { get; set; }
}

public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, UserDetailsResponseDTO>
{
    private readonly IIdentityService _identityService;

    public GetUserDetailsQueryHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }
    public async Task<UserDetailsResponseDTO> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
    {
        var (userId, fullName, userName, email, roles) = await _identityService.GetUserDetailsAsync(request.UserId);
        return new UserDetailsResponseDTO() { Id = userId, FullName = fullName, UserName = userName, Email = email, Roles = roles };
    }
}