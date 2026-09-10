using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsAgentAutoEvaluatedPermissionTest : TestBase
{
    [Fact]
    public void AllowValidationWorks()
    {
        BetaManagedAgentsAgentAutoEvaluatedPermission value =
            new BetaManagedAgentsAgentAutoEvaluatedPermissionAllow();
        value.Validate();
    }

    [Fact]
    public void AskValidationWorks()
    {
        BetaManagedAgentsAgentAutoEvaluatedPermission value =
            new BetaManagedAgentsAgentAutoEvaluatedPermissionAsk("reason_code");
        value.Validate();
    }

    [Fact]
    public void DenyValidationWorks()
    {
        BetaManagedAgentsAgentAutoEvaluatedPermission value =
            new BetaManagedAgentsAgentAutoEvaluatedPermissionDeny("reason_code");
        value.Validate();
    }

    [Fact]
    public void AllowSerializationRoundtripWorks()
    {
        BetaManagedAgentsAgentAutoEvaluatedPermission value =
            new BetaManagedAgentsAgentAutoEvaluatedPermissionAllow();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsAgentAutoEvaluatedPermission>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AskSerializationRoundtripWorks()
    {
        BetaManagedAgentsAgentAutoEvaluatedPermission value =
            new BetaManagedAgentsAgentAutoEvaluatedPermissionAsk("reason_code");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsAgentAutoEvaluatedPermission>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DenySerializationRoundtripWorks()
    {
        BetaManagedAgentsAgentAutoEvaluatedPermission value =
            new BetaManagedAgentsAgentAutoEvaluatedPermissionDeny("reason_code");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsAgentAutoEvaluatedPermission>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsAgentAutoEvaluatedPermission value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "allow",
                  "reason_code": "reason_code"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        JsonElement expectedType = JsonSerializer.SerializeToElement("allow");
        string expectedReasonCode = "reason_code";

        Assert.True(JsonElement.DeepEquals(expectedType, value.Type));
        Assert.Equal(expectedReasonCode, value.ReasonCode);

        BetaManagedAgentsAgentAutoEvaluatedPermission emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.ReasonCode);

        BetaManagedAgentsAgentAutoEvaluatedPermission mismatchedValue = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "reason_code": [
                    "invalid"
                  ]
                }
                """
            )
        );

        Assert.Null(mismatchedValue.ReasonCode);
    }
}
