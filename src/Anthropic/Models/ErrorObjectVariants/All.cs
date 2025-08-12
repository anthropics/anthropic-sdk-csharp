using Models = Anthropic.Models;

namespace Anthropic.Models.ErrorObjectVariants;

public sealed record class InvalidRequestErrorVariant(Models::InvalidRequestError Value)
    : Models::ErrorObject,
        IVariant<InvalidRequestErrorVariant, Models::InvalidRequestError>
{
    public static InvalidRequestErrorVariant From(Models::InvalidRequestError value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class AuthenticationErrorVariant(Models::AuthenticationError Value)
    : Models::ErrorObject,
        IVariant<AuthenticationErrorVariant, Models::AuthenticationError>
{
    public static AuthenticationErrorVariant From(Models::AuthenticationError value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BillingErrorVariant(Models::BillingError Value)
    : Models::ErrorObject,
        IVariant<BillingErrorVariant, Models::BillingError>
{
    public static BillingErrorVariant From(Models::BillingError value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class PermissionErrorVariant(Models::PermissionError Value)
    : Models::ErrorObject,
        IVariant<PermissionErrorVariant, Models::PermissionError>
{
    public static PermissionErrorVariant From(Models::PermissionError value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NotFoundErrorVariant(Models::NotFoundError Value)
    : Models::ErrorObject,
        IVariant<NotFoundErrorVariant, Models::NotFoundError>
{
    public static NotFoundErrorVariant From(Models::NotFoundError value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class RateLimitErrorVariant(Models::RateLimitError Value)
    : Models::ErrorObject,
        IVariant<RateLimitErrorVariant, Models::RateLimitError>
{
    public static RateLimitErrorVariant From(Models::RateLimitError value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class GatewayTimeoutErrorVariant(Models::GatewayTimeoutError Value)
    : Models::ErrorObject,
        IVariant<GatewayTimeoutErrorVariant, Models::GatewayTimeoutError>
{
    public static GatewayTimeoutErrorVariant From(Models::GatewayTimeoutError value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class APIErrorObjectVariant(Models::APIErrorObject Value)
    : Models::ErrorObject,
        IVariant<APIErrorObjectVariant, Models::APIErrorObject>
{
    public static APIErrorObjectVariant From(Models::APIErrorObject value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class OverloadedErrorVariant(Models::OverloadedError Value)
    : Models::ErrorObject,
        IVariant<OverloadedErrorVariant, Models::OverloadedError>
{
    public static OverloadedErrorVariant From(Models::OverloadedError value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
