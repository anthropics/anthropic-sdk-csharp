using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ClaudeTag;

namespace Anthropic.Tests.Models.Beta.Organization.ClaudeTag;

public class BetaBundleOnCallErrorDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaBundleOnCallErrorDetails { };

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement("bundle_on_call");

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, model.ErrorCode));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaBundleOnCallErrorDetails { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBundleOnCallErrorDetails>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaBundleOnCallErrorDetails { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBundleOnCallErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement("bundle_on_call");

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, deserialized.ErrorCode));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaBundleOnCallErrorDetails { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaBundleOnCallErrorDetails { };

        BetaBundleOnCallErrorDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}
