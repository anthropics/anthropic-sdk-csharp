using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Analytics;

namespace Anthropic.Tests.Models.Beta.Organization.Analytics;

public class BetaAnalyticsServerToolUseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAnalyticsServerToolUse { WebSearchRequests = 10 };

        long expectedWebSearchRequests = 10;

        Assert.Equal(expectedWebSearchRequests, model.WebSearchRequests);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAnalyticsServerToolUse { WebSearchRequests = 10 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsServerToolUse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAnalyticsServerToolUse { WebSearchRequests = 10 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAnalyticsServerToolUse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedWebSearchRequests = 10;

        Assert.Equal(expectedWebSearchRequests, deserialized.WebSearchRequests);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAnalyticsServerToolUse { WebSearchRequests = 10 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAnalyticsServerToolUse { WebSearchRequests = 10 };

        BetaAnalyticsServerToolUse copied = new(model);

        Assert.Equal(model, copied);
    }
}
