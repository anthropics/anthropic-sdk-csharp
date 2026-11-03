using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Organization.Users;

namespace Anthropic.Tests.Models.Organization.Users;

public class CannotRemoveLastMemberErrorDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CannotRemoveLastMemberErrorDetails { };

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "cannot_remove_last_member"
        );

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, model.ErrorCode));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CannotRemoveLastMemberErrorDetails { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CannotRemoveLastMemberErrorDetails>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CannotRemoveLastMemberErrorDetails { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CannotRemoveLastMemberErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "cannot_remove_last_member"
        );

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, deserialized.ErrorCode));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CannotRemoveLastMemberErrorDetails { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CannotRemoveLastMemberErrorDetails { };

        CannotRemoveLastMemberErrorDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}
