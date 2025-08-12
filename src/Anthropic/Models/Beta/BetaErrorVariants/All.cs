using Beta = Anthropic.Models.Beta;

namespace Anthropic.Models.Beta.BetaErrorVariants;

public sealed record class BetaInvalidRequestErrorVariant(Beta::BetaInvalidRequestError Value)
    : Beta::BetaError,
        IVariant<BetaInvalidRequestErrorVariant, Beta::BetaInvalidRequestError>
{
    public static BetaInvalidRequestErrorVariant From(Beta::BetaInvalidRequestError value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaAuthenticationErrorVariant(Beta::BetaAuthenticationError Value)
    : Beta::BetaError,
        IVariant<BetaAuthenticationErrorVariant, Beta::BetaAuthenticationError>
{
    public static BetaAuthenticationErrorVariant From(Beta::BetaAuthenticationError value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaBillingErrorVariant(Beta::BetaBillingError Value)
    : Beta::BetaError,
        IVariant<BetaBillingErrorVariant, Beta::BetaBillingError>
{
    public static BetaBillingErrorVariant From(Beta::BetaBillingError value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaPermissionErrorVariant(Beta::BetaPermissionError Value)
    : Beta::BetaError,
        IVariant<BetaPermissionErrorVariant, Beta::BetaPermissionError>
{
    public static BetaPermissionErrorVariant From(Beta::BetaPermissionError value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaNotFoundErrorVariant(Beta::BetaNotFoundError Value)
    : Beta::BetaError,
        IVariant<BetaNotFoundErrorVariant, Beta::BetaNotFoundError>
{
    public static BetaNotFoundErrorVariant From(Beta::BetaNotFoundError value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaRateLimitErrorVariant(Beta::BetaRateLimitError Value)
    : Beta::BetaError,
        IVariant<BetaRateLimitErrorVariant, Beta::BetaRateLimitError>
{
    public static BetaRateLimitErrorVariant From(Beta::BetaRateLimitError value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaGatewayTimeoutErrorVariant(Beta::BetaGatewayTimeoutError Value)
    : Beta::BetaError,
        IVariant<BetaGatewayTimeoutErrorVariant, Beta::BetaGatewayTimeoutError>
{
    public static BetaGatewayTimeoutErrorVariant From(Beta::BetaGatewayTimeoutError value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaAPIErrorVariant(Beta::BetaAPIError Value)
    : Beta::BetaError,
        IVariant<BetaAPIErrorVariant, Beta::BetaAPIError>
{
    public static BetaAPIErrorVariant From(Beta::BetaAPIError value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaOverloadedErrorVariant(Beta::BetaOverloadedError Value)
    : Beta::BetaError,
        IVariant<BetaOverloadedErrorVariant, Beta::BetaOverloadedError>
{
    public static BetaOverloadedErrorVariant From(Beta::BetaOverloadedError value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
