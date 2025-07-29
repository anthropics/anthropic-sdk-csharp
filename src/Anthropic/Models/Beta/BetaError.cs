using Anthropic = Anthropic;
using BetaErrorVariants = Anthropic.Models.Beta.BetaErrorVariants;
using Serialization = System.Text.Json.Serialization;

namespace Anthropic.Models.Beta;

[Serialization::JsonConverter(typeof(Anthropic::UnionConverter<BetaError>))]
public abstract record class BetaError
{
    internal BetaError() { }

    public static implicit operator BetaError(BetaInvalidRequestError value) =>
        new BetaErrorVariants::BetaInvalidRequestError(value);

    public static implicit operator BetaError(BetaAuthenticationError value) =>
        new BetaErrorVariants::BetaAuthenticationError(value);

    public static implicit operator BetaError(BetaBillingError value) =>
        new BetaErrorVariants::BetaBillingError(value);

    public static implicit operator BetaError(BetaPermissionError value) =>
        new BetaErrorVariants::BetaPermissionError(value);

    public static implicit operator BetaError(BetaNotFoundError value) =>
        new BetaErrorVariants::BetaNotFoundError(value);

    public static implicit operator BetaError(BetaRateLimitError value) =>
        new BetaErrorVariants::BetaRateLimitError(value);

    public static implicit operator BetaError(BetaGatewayTimeoutError value) =>
        new BetaErrorVariants::BetaGatewayTimeoutError(value);

    public static implicit operator BetaError(BetaAPIError value) =>
        new BetaErrorVariants::BetaAPIError(value);

    public static implicit operator BetaError(BetaOverloadedError value) =>
        new BetaErrorVariants::BetaOverloadedError(value);

    public abstract void Validate();
}
