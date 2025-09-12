using Beta = Anthropic.Client.Models.Beta;

namespace Anthropic.Client.Models.Beta.BetaErrorVariants;

public sealed record class BetaInvalidRequestError(Beta::BetaInvalidRequestError Value)
    : Beta::BetaError,
        IVariant<BetaInvalidRequestError, Beta::BetaInvalidRequestError>
{
    public static BetaInvalidRequestError From(Beta::BetaInvalidRequestError value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaAuthenticationError(Beta::BetaAuthenticationError Value)
    : Beta::BetaError,
        IVariant<BetaAuthenticationError, Beta::BetaAuthenticationError>
{
    public static BetaAuthenticationError From(Beta::BetaAuthenticationError value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaBillingError(Beta::BetaBillingError Value)
    : Beta::BetaError,
        IVariant<BetaBillingError, Beta::BetaBillingError>
{
    public static BetaBillingError From(Beta::BetaBillingError value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaPermissionError(Beta::BetaPermissionError Value)
    : Beta::BetaError,
        IVariant<BetaPermissionError, Beta::BetaPermissionError>
{
    public static BetaPermissionError From(Beta::BetaPermissionError value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaNotFoundError(Beta::BetaNotFoundError Value)
    : Beta::BetaError,
        IVariant<BetaNotFoundError, Beta::BetaNotFoundError>
{
    public static BetaNotFoundError From(Beta::BetaNotFoundError value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaRateLimitError(Beta::BetaRateLimitError Value)
    : Beta::BetaError,
        IVariant<BetaRateLimitError, Beta::BetaRateLimitError>
{
    public static BetaRateLimitError From(Beta::BetaRateLimitError value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaGatewayTimeoutError(Beta::BetaGatewayTimeoutError Value)
    : Beta::BetaError,
        IVariant<BetaGatewayTimeoutError, Beta::BetaGatewayTimeoutError>
{
    public static BetaGatewayTimeoutError From(Beta::BetaGatewayTimeoutError value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaAPIError(Beta::BetaAPIError Value)
    : Beta::BetaError,
        IVariant<BetaAPIError, Beta::BetaAPIError>
{
    public static BetaAPIError From(Beta::BetaAPIError value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BetaOverloadedError(Beta::BetaOverloadedError Value)
    : Beta::BetaError,
        IVariant<BetaOverloadedError, Beta::BetaOverloadedError>
{
    public static BetaOverloadedError From(Beta::BetaOverloadedError value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
