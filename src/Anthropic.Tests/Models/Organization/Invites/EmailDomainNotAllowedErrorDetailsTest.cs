using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Organization.Invites;

namespace Anthropic.Tests.Models.Organization.Invites;

public class EmailDomainNotAllowedErrorDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new EmailDomainNotAllowedErrorDetails { };

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "email_domain_not_allowed"
        );

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, model.ErrorCode));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new EmailDomainNotAllowedErrorDetails { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EmailDomainNotAllowedErrorDetails>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new EmailDomainNotAllowedErrorDetails { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<EmailDomainNotAllowedErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "email_domain_not_allowed"
        );

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, deserialized.ErrorCode));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new EmailDomainNotAllowedErrorDetails { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new EmailDomainNotAllowedErrorDetails { };

        EmailDomainNotAllowedErrorDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}
