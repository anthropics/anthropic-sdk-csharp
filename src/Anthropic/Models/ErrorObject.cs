using Anthropic = Anthropic;
using ErrorObjectVariants = Anthropic.Models.ErrorObjectVariants;
using Serialization = System.Text.Json.Serialization;

namespace Anthropic.Models;

[Serialization::JsonConverter(typeof(Anthropic::UnionConverter<ErrorObject>))]
public abstract record class ErrorObject
{
    internal ErrorObject() { }

    public static implicit operator ErrorObject(InvalidRequestError value) =>
        new ErrorObjectVariants::InvalidRequestError(value);

    public static implicit operator ErrorObject(AuthenticationError value) =>
        new ErrorObjectVariants::AuthenticationError(value);

    public static implicit operator ErrorObject(BillingError value) =>
        new ErrorObjectVariants::BillingError(value);

    public static implicit operator ErrorObject(PermissionError value) =>
        new ErrorObjectVariants::PermissionError(value);

    public static implicit operator ErrorObject(NotFoundError value) =>
        new ErrorObjectVariants::NotFoundError(value);

    public static implicit operator ErrorObject(RateLimitError value) =>
        new ErrorObjectVariants::RateLimitError(value);

    public static implicit operator ErrorObject(GatewayTimeoutError value) =>
        new ErrorObjectVariants::GatewayTimeoutError(value);

    public static implicit operator ErrorObject(APIErrorObject value) =>
        new ErrorObjectVariants::APIErrorObject(value);

    public static implicit operator ErrorObject(OverloadedError value) =>
        new ErrorObjectVariants::OverloadedError(value);

    public abstract void Validate();
}
