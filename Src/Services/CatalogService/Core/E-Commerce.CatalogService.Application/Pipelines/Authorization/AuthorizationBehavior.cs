using E_Commerce.CatalogService.Application.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace E_Commerce.CatalogService.Application.Pipelines.Authorization;

public class AuthorizationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>, ISecuredRequest
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthorizationBehavior(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        List<string>? roleClaims = (_httpContextAccessor.HttpContext?.User?.Claims.Where(c => c.Type == ClaimTypes.Role).Select(x => x.Value).ToList()) ?? throw new AuthorizationException("Claims not found.");
        bool isNotMatchedARoleClaimWithRequestRoles = roleClaims.Where(roleClaim => request.Roles.Any(role => role == roleClaim)).Any();
        if (!isNotMatchedARoleClaimWithRequestRoles) throw new AuthorizationException("You are not authorized.");
        TResponse response = await next();
        return response;
    }
}