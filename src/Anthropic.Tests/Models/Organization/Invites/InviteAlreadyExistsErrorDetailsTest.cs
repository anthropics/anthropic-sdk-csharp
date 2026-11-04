using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Organization.Invites;

namespace Anthropic.Tests.Models.Organization.Invites;

public class InviteAlreadyExistsErrorDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new InviteAlreadyExistsErrorDetails { };

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement("invite_already_exists");

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, model.ErrorCode));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new InviteAlreadyExistsErrorDetails { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InviteAlreadyExistsErrorDetails>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new InviteAlreadyExistsErrorDetails { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<InviteAlreadyExistsErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement("invite_already_exists");

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, deserialized.ErrorCode));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new InviteAlreadyExistsErrorDetails { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new InviteAlreadyExistsErrorDetails { };

        InviteAlreadyExistsErrorDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}
