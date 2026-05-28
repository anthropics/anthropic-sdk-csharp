using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaAdvisorResultBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAdvisorResultBlockParam { Text = "text", StopReason = "stop_reason" };

        string expectedText = "text";
        JsonElement expectedType = JsonSerializer.SerializeToElement("advisor_result");
        string expectedStopReason = "stop_reason";

        Assert.Equal(expectedText, model.Text);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedStopReason, model.StopReason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAdvisorResultBlockParam { Text = "text", StopReason = "stop_reason" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAdvisorResultBlockParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAdvisorResultBlockParam { Text = "text", StopReason = "stop_reason" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAdvisorResultBlockParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedText = "text";
        JsonElement expectedType = JsonSerializer.SerializeToElement("advisor_result");
        string expectedStopReason = "stop_reason";

        Assert.Equal(expectedText, deserialized.Text);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedStopReason, deserialized.StopReason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAdvisorResultBlockParam { Text = "text", StopReason = "stop_reason" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaAdvisorResultBlockParam { Text = "text" };

        Assert.Null(model.StopReason);
        Assert.False(model.RawData.ContainsKey("stop_reason"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaAdvisorResultBlockParam { Text = "text" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaAdvisorResultBlockParam
        {
            Text = "text",

            StopReason = null,
        };

        Assert.Null(model.StopReason);
        Assert.True(model.RawData.ContainsKey("stop_reason"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaAdvisorResultBlockParam
        {
            Text = "text",

            StopReason = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAdvisorResultBlockParam { Text = "text", StopReason = "stop_reason" };

        BetaAdvisorResultBlockParam copied = new(model);

        Assert.Equal(model, copied);
    }
}
