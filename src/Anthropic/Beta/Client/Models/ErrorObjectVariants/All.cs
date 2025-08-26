using Models = Anthropic.Beta.Client.Models;

namespace Anthropic.Beta.Client.Models.ErrorObjectVariants;

public sealed record class InvalidRequestError(Models::InvalidRequestError Value)
    : Models::ErrorObject,
        IVariant<InvalidRequestError, Models::InvalidRequestError>
{
    public static InvalidRequestError From(Models::InvalidRequestError value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class AuthenticationError(Models::AuthenticationError Value)
    : Models::ErrorObject,
        IVariant<AuthenticationError, Models::AuthenticationError>
{
    public static AuthenticationError From(Models::AuthenticationError value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class BillingError(Models::BillingError Value)
    : Models::ErrorObject,
        IVariant<BillingError, Models::BillingError>
{
    public static BillingError From(Models::BillingError value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class PermissionError(Models::PermissionError Value)
    : Models::ErrorObject,
        IVariant<PermissionError, Models::PermissionError>
{
    public static PermissionError From(Models::PermissionError value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class NotFoundError(Models::NotFoundError Value)
    : Models::ErrorObject,
        IVariant<NotFoundError, Models::NotFoundError>
{
    public static NotFoundError From(Models::NotFoundError value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class RateLimitError(Models::RateLimitError Value)
    : Models::ErrorObject,
        IVariant<RateLimitError, Models::RateLimitError>
{
    public static RateLimitError From(Models::RateLimitError value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class GatewayTimeoutError(Models::GatewayTimeoutError Value)
    : Models::ErrorObject,
        IVariant<GatewayTimeoutError, Models::GatewayTimeoutError>
{
    public static GatewayTimeoutError From(Models::GatewayTimeoutError value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class APIErrorObject(Models::APIErrorObject Value)
    : Models::ErrorObject,
        IVariant<APIErrorObject, Models::APIErrorObject>
{
    public static APIErrorObject From(Models::APIErrorObject value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

public sealed record class OverloadedError(Models::OverloadedError Value)
    : Models::ErrorObject,
        IVariant<OverloadedError, Models::OverloadedError>
{
    public static OverloadedError From(Models::OverloadedError value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
