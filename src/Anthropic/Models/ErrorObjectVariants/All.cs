using System.Text.Json.Serialization;

namespace Anthropic.Models.ErrorObjectVariants;

[JsonConverter(typeof(VariantConverter<InvalidRequestErrorVariant, InvalidRequestError>))]
public sealed record class InvalidRequestErrorVariant(InvalidRequestError Value)
    : ErrorObject,
        IVariant<InvalidRequestErrorVariant, InvalidRequestError>
{
    public static InvalidRequestErrorVariant From(InvalidRequestError value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<AuthenticationErrorVariant, AuthenticationError>))]
public sealed record class AuthenticationErrorVariant(AuthenticationError Value)
    : ErrorObject,
        IVariant<AuthenticationErrorVariant, AuthenticationError>
{
    public static AuthenticationErrorVariant From(AuthenticationError value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<BillingErrorVariant, BillingError>))]
public sealed record class BillingErrorVariant(BillingError Value)
    : ErrorObject,
        IVariant<BillingErrorVariant, BillingError>
{
    public static BillingErrorVariant From(BillingError value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<PermissionErrorVariant, PermissionError>))]
public sealed record class PermissionErrorVariant(PermissionError Value)
    : ErrorObject,
        IVariant<PermissionErrorVariant, PermissionError>
{
    public static PermissionErrorVariant From(PermissionError value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<NotFoundErrorVariant, NotFoundError>))]
public sealed record class NotFoundErrorVariant(NotFoundError Value)
    : ErrorObject,
        IVariant<NotFoundErrorVariant, NotFoundError>
{
    public static NotFoundErrorVariant From(NotFoundError value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<RateLimitErrorVariant, RateLimitError>))]
public sealed record class RateLimitErrorVariant(RateLimitError Value)
    : ErrorObject,
        IVariant<RateLimitErrorVariant, RateLimitError>
{
    public static RateLimitErrorVariant From(RateLimitError value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<GatewayTimeoutErrorVariant, GatewayTimeoutError>))]
public sealed record class GatewayTimeoutErrorVariant(GatewayTimeoutError Value)
    : ErrorObject,
        IVariant<GatewayTimeoutErrorVariant, GatewayTimeoutError>
{
    public static GatewayTimeoutErrorVariant From(GatewayTimeoutError value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<APIErrorObjectVariant, APIErrorObject>))]
public sealed record class APIErrorObjectVariant(APIErrorObject Value)
    : ErrorObject,
        IVariant<APIErrorObjectVariant, APIErrorObject>
{
    public static APIErrorObjectVariant From(APIErrorObject value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}

[JsonConverter(typeof(VariantConverter<OverloadedErrorVariant, OverloadedError>))]
public sealed record class OverloadedErrorVariant(OverloadedError Value)
    : ErrorObject,
        IVariant<OverloadedErrorVariant, OverloadedError>
{
    public static OverloadedErrorVariant From(OverloadedError value)
    {
        return new(value);
    }

    public override void Validate()
    {
        this.Value.Validate();
    }
}
