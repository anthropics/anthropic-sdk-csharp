using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Organization.Invites;

namespace Anthropic.Tests.Models.Organization.Invites;

public class CannotInviteEmailsWithUnverifiedDomainsErrorDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CannotInviteEmailsWithUnverifiedDomainsErrorDetails { };

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "cannot_invite_emails_with_unverified_domains"
        );

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, model.ErrorCode));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CannotInviteEmailsWithUnverifiedDomainsErrorDetails { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CannotInviteEmailsWithUnverifiedDomainsErrorDetails>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CannotInviteEmailsWithUnverifiedDomainsErrorDetails { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<CannotInviteEmailsWithUnverifiedDomainsErrorDetails>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "cannot_invite_emails_with_unverified_domains"
        );

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, deserialized.ErrorCode));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CannotInviteEmailsWithUnverifiedDomainsErrorDetails { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CannotInviteEmailsWithUnverifiedDomainsErrorDetails { };

        CannotInviteEmailsWithUnverifiedDomainsErrorDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}
