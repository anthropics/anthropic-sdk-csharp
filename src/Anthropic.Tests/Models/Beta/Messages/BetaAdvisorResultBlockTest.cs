using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaAdvisorResultBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAdvisorResultBlock { StopReason = "stop_reason", Text = "text" };

        string expectedStopReason = "stop_reason";
        string expectedText = "text";
        JsonElement expectedType = JsonSerializer.SerializeToElement("advisor_result");

        Assert.Equal(expectedStopReason, model.StopReason);
        Assert.Equal(expectedText, model.Text);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAdvisorResultBlock { StopReason = "stop_reason", Text = "text" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAdvisorResultBlock>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAdvisorResultBlock { StopReason = "stop_reason", Text = "text" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAdvisorResultBlock>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedStopReason = "stop_reason";
        string expectedText = "text";
        JsonElement expectedType = JsonSerializer.SerializeToElement("advisor_result");

        Assert.Equal(expectedStopReason, deserialized.StopReason);
        Assert.Equal(expectedText, deserialized.Text);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAdvisorResultBlock { StopReason = "stop_reason", Text = "text" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAdvisorResultBlock { StopReason = "stop_reason", Text = "text" };

        BetaAdvisorResultBlock copied = new(model);

        Assert.Equal(model, copied);
    }
}
