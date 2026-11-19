using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ClaudeCode.ManagedSettings;

namespace Anthropic.Tests.Models.Beta.Organization.ClaudeCode.ManagedSettings;

public class BetaCmekFeatureUnsupportedErrorDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaCmekFeatureUnsupportedErrorDetails { };

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "cmek_feature_unsupported"
        );

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, model.ErrorCode));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaCmekFeatureUnsupportedErrorDetails { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaCmekFeatureUnsupportedErrorDetails>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaCmekFeatureUnsupportedErrorDetails { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaCmekFeatureUnsupportedErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "cmek_feature_unsupported"
        );

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, deserialized.ErrorCode));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaCmekFeatureUnsupportedErrorDetails { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaCmekFeatureUnsupportedErrorDetails { };

        BetaCmekFeatureUnsupportedErrorDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}
