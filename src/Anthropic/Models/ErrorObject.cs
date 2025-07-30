using System.Text.Json.Serialization;
using ErrorObjectVariants = Anthropic.Models.ErrorObjectVariants;

namespace Anthropic.Models;

[JsonConverter(typeof(UnionConverter<ErrorObject>))]
public abstract record class ErrorObject
{
    internal ErrorObject() { }

    public static implicit operator ErrorObject(InvalidRequestError value) =>
        new ErrorObjectVariants::InvalidRequestErrorVariant(value);

    public static implicit operator ErrorObject(AuthenticationError value) =>
        new ErrorObjectVariants::AuthenticationErrorVariant(value);

    public static implicit operator ErrorObject(BillingError value) =>
        new ErrorObjectVariants::BillingErrorVariant(value);

    public static implicit operator ErrorObject(PermissionError value) =>
        new ErrorObjectVariants::PermissionErrorVariant(value);

    public static implicit operator ErrorObject(NotFoundError value) =>
        new ErrorObjectVariants::NotFoundErrorVariant(value);

    public static implicit operator ErrorObject(RateLimitError value) =>
        new ErrorObjectVariants::RateLimitErrorVariant(value);

    public static implicit operator ErrorObject(GatewayTimeoutError value) =>
        new ErrorObjectVariants::GatewayTimeoutErrorVariant(value);

    public static implicit operator ErrorObject(APIErrorObject value) =>
        new ErrorObjectVariants::APIErrorObjectVariant(value);

    public static implicit operator ErrorObject(OverloadedError value) =>
        new ErrorObjectVariants::OverloadedErrorVariant(value);

    public abstract void Validate();
}
