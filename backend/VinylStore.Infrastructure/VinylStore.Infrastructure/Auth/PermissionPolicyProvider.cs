using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using VinylStore.Core.Enums;

namespace VinylStore.Infrastructure.Auth;

public class PermissionPolicyProvider(IOptions<AuthorizationOptions> options) : IAuthorizationPolicyProvider
{
    private const string PolicyPrefix = "Permissions:";
    private readonly DefaultAuthorizationPolicyProvider _fallbackProvider = new(options);

    public async Task<AuthorizationPolicy> GetDefaultPolicyAsync()
        => await _fallbackProvider.GetDefaultPolicyAsync();

    public async Task<AuthorizationPolicy?> GetFallbackPolicyAsync()
        => await _fallbackProvider.GetFallbackPolicyAsync();

    public async Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
    {
        if (!policyName.StartsWith(PolicyPrefix, StringComparison.OrdinalIgnoreCase))
            return await _fallbackProvider.GetPolicyAsync(policyName);

        var permissions = policyName[PolicyPrefix.Length..]
            .Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Select(p => Enum.Parse<Permissions>(p.Trim()))
            .ToArray();

        var policy = new AuthorizationPolicyBuilder();
        policy.RequireAuthenticatedUser();
        policy.AddRequirements(new PermissionRequirements(permissions));

        return policy.Build();
    }
}