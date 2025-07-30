using System.Text.Json.Serialization;

namespace Anthropic.Models.Beta.BetaErrorVariants;

[JsonConverter(typeof(VariantConverter<BetaInvalidRequestErrorVariant, BetaInvalidRequestError>))]
public sealed record class BetaInvalidRequestErrorVariant(BetaInvalidRequestError Value)
    : BetaError,
        IVariant<BetaInvalidRequestErrorVariant, BetaInvalidRequestError>
{
    public static BetaInvalidRequestErrorVariant From(BetaInvalidRequestError value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<BetaAuthenticationErrorVariant, BetaAuthenticationError>))]
public sealed record class BetaAuthenticationErrorVariant(BetaAuthenticationError Value)
    : BetaError,
        IVariant<BetaAuthenticationErrorVariant, BetaAuthenticationError>
{
    public static BetaAuthenticationErrorVariant From(BetaAuthenticationError value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<BetaBillingErrorVariant, BetaBillingError>))]
public sealed record class BetaBillingErrorVariant(BetaBillingError Value)
    : BetaError,
        IVariant<BetaBillingErrorVariant, BetaBillingError>
{
    public static BetaBillingErrorVariant From(BetaBillingError value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<BetaPermissionErrorVariant, BetaPermissionError>))]
public sealed record class BetaPermissionErrorVariant(BetaPermissionError Value)
    : BetaError,
        IVariant<BetaPermissionErrorVariant, BetaPermissionError>
{
    public static BetaPermissionErrorVariant From(BetaPermissionError value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<BetaNotFoundErrorVariant, BetaNotFoundError>))]
public sealed record class BetaNotFoundErrorVariant(BetaNotFoundError Value)
    : BetaError,
        IVariant<BetaNotFoundErrorVariant, BetaNotFoundError>
{
    public static BetaNotFoundErrorVariant From(BetaNotFoundError value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<BetaRateLimitErrorVariant, BetaRateLimitError>))]
public sealed record class BetaRateLimitErrorVariant(BetaRateLimitError Value)
    : BetaError,
        IVariant<BetaRateLimitErrorVariant, BetaRateLimitError>
{
    public static BetaRateLimitErrorVariant From(BetaRateLimitError value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<BetaGatewayTimeoutErrorVariant, BetaGatewayTimeoutError>))]
public sealed record class BetaGatewayTimeoutErrorVariant(BetaGatewayTimeoutError Value)
    : BetaError,
        IVariant<BetaGatewayTimeoutErrorVariant, BetaGatewayTimeoutError>
{
    public static BetaGatewayTimeoutErrorVariant From(BetaGatewayTimeoutError value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<BetaAPIErrorVariant, BetaAPIError>))]
public sealed record class BetaAPIErrorVariant(BetaAPIError Value)
    : BetaError,
        IVariant<BetaAPIErrorVariant, BetaAPIError>
{
    public static BetaAPIErrorVariant From(BetaAPIError value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<BetaOverloadedErrorVariant, BetaOverloadedError>))]
public sealed record class BetaOverloadedErrorVariant(BetaOverloadedError Value)
    : BetaError,
        IVariant<BetaOverloadedErrorVariant, BetaOverloadedError>
{
    public static BetaOverloadedErrorVariant From(BetaOverloadedError value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
