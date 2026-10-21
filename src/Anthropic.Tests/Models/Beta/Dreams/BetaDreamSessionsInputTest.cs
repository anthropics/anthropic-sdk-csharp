using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Dreams;

namespace Anthropic.Tests.Models.Beta.Dreams;

public class BetaDreamSessionsInputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaDreamSessionsInput { SessionIds = ["string"] };

        List<string> expectedSessionIds = ["string"];
        JsonElement expectedType = JsonSerializer.SerializeToElement("sessions");

        Assert.Equal(expectedSessionIds.Count, model.SessionIds.Count);
        for (int i = 0; i < expectedSessionIds.Count; i++)
        {
            Assert.Equal(expectedSessionIds[i], model.SessionIds[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaDreamSessionsInput { SessionIds = ["string"] };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaDreamSessionsInput>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaDreamSessionsInput { SessionIds = ["string"] };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaDreamSessionsInput>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedSessionIds = ["string"];
        JsonElement expectedType = JsonSerializer.SerializeToElement("sessions");

        Assert.Equal(expectedSessionIds.Count, deserialized.SessionIds.Count);
        for (int i = 0; i < expectedSessionIds.Count; i++)
        {
            Assert.Equal(expectedSessionIds[i], deserialized.SessionIds[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaDreamSessionsInput { SessionIds = ["string"] };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaDreamSessionsInput { SessionIds = ["string"] };

        BetaDreamSessionsInput copied = new(model);

        Assert.Equal(model, copied);
    }
}
