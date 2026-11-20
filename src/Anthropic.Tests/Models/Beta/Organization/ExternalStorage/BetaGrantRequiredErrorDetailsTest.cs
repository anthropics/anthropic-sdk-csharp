using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ExternalStorage;

namespace Anthropic.Tests.Models.Beta.Organization.ExternalStorage;

public class BetaGrantRequiredErrorDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaGrantRequiredErrorDetails { };

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement("grant_required");

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, model.ErrorCode));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaGrantRequiredErrorDetails { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGrantRequiredErrorDetails>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaGrantRequiredErrorDetails { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaGrantRequiredErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement("grant_required");

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, deserialized.ErrorCode));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaGrantRequiredErrorDetails { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaGrantRequiredErrorDetails { };

        BetaGrantRequiredErrorDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}
