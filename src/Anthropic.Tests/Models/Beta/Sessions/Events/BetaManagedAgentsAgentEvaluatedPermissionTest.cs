using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsAgentEvaluatedPermissionTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsAgentEvaluatedPermission.Allow)]
    [InlineData(BetaManagedAgentsAgentEvaluatedPermission.Ask)]
    [InlineData(BetaManagedAgentsAgentEvaluatedPermission.Deny)]
    public void Validation_Works(BetaManagedAgentsAgentEvaluatedPermission rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsAgentEvaluatedPermission> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentEvaluatedPermission>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsAgentEvaluatedPermission.Allow, 0, "allow")]
    [InlineData(BetaManagedAgentsAgentEvaluatedPermission.Ask, 1, "ask")]
    [InlineData(BetaManagedAgentsAgentEvaluatedPermission.Deny, 2, "deny")]
    public void EnumMemberSerializationRoundtrip_Works(
        BetaManagedAgentsAgentEvaluatedPermission rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsAgentEvaluatedPermission> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentEvaluatedPermission>
        >(apiJson, ModelBase.SerializerOptions);

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentEvaluatedPermission>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentEvaluatedPermission>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
