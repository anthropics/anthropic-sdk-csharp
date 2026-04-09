using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaAdvisorResultBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAdvisorResultBlockParam { Text = "text" };

        string expectedText = "text";
        JsonElement expectedType = JsonSerializer.SerializeToElement("advisor_result");

        Assert.Equal(expectedText, model.Text);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAdvisorResultBlockParam { Text = "text" };

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
        var model = new BetaAdvisorResultBlockParam { Text = "text" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAdvisorResultBlockParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedText = "text";
        JsonElement expectedType = JsonSerializer.SerializeToElement("advisor_result");

        Assert.Equal(expectedText, deserialized.Text);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAdvisorResultBlockParam { Text = "text" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAdvisorResultBlockParam { Text = "text" };

        BetaAdvisorResultBlockParam copied = new(model);

        Assert.Equal(model, copied);
    }
}
