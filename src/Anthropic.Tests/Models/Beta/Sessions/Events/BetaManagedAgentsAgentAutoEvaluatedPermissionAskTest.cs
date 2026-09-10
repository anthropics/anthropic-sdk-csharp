using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsAgentAutoEvaluatedPermissionAskTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsAgentAutoEvaluatedPermissionAsk
        {
            ReasonCode = "reason_code",
        };

        string expectedReasonCode = "reason_code";
        JsonElement expectedType = JsonSerializer.SerializeToElement("ask");

        Assert.Equal(expectedReasonCode, model.ReasonCode);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsAgentAutoEvaluatedPermissionAsk
        {
            ReasonCode = "reason_code",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsAgentAutoEvaluatedPermissionAsk>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsAgentAutoEvaluatedPermissionAsk
        {
            ReasonCode = "reason_code",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsAgentAutoEvaluatedPermissionAsk>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedReasonCode = "reason_code";
        JsonElement expectedType = JsonSerializer.SerializeToElement("ask");

        Assert.Equal(expectedReasonCode, deserialized.ReasonCode);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsAgentAutoEvaluatedPermissionAsk
        {
            ReasonCode = "reason_code",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsAgentAutoEvaluatedPermissionAsk
        {
            ReasonCode = "reason_code",
        };

        BetaManagedAgentsAgentAutoEvaluatedPermissionAsk copied = new(model);

        Assert.Equal(model, copied);
    }
}
