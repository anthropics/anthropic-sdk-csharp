using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaThreadContinueParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaThreadContinueParams { PreviousMessageID = "previous_message_id" };

        string expectedPreviousMessageID = "previous_message_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("continue");

        Assert.Equal(expectedPreviousMessageID, model.PreviousMessageID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaThreadContinueParams { PreviousMessageID = "previous_message_id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaThreadContinueParams>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaThreadContinueParams { PreviousMessageID = "previous_message_id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaThreadContinueParams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedPreviousMessageID = "previous_message_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("continue");

        Assert.Equal(expectedPreviousMessageID, deserialized.PreviousMessageID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaThreadContinueParams { PreviousMessageID = "previous_message_id" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaThreadContinueParams { PreviousMessageID = "previous_message_id" };

        BetaThreadContinueParams copied = new(model);

        Assert.Equal(model, copied);
    }
}
