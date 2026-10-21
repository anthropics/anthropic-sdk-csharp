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
    public void AllowTypeWorks()
    {
        BetaManagedAgentsAgentAutoEvaluatedPermission value =
            new BetaManagedAgentsAgentAutoEvaluatedPermissionAllow();
        Assert.Equal(BetaManagedAgentsAgentAutoEvaluatedPermissionType.Allow, value.Type.Value());
    }

    [Fact]
    public void AskTypeWorks()
    {
        BetaManagedAgentsAgentAutoEvaluatedPermission value =
            new BetaManagedAgentsAgentAutoEvaluatedPermissionAsk("reason_code");
        Assert.Equal(BetaManagedAgentsAgentAutoEvaluatedPermissionType.Ask, value.Type.Value());
    }

    [Fact]
    public void DenyTypeWorks()
    {
        BetaManagedAgentsAgentAutoEvaluatedPermission value =
            new BetaManagedAgentsAgentAutoEvaluatedPermissionDeny("reason_code");
        Assert.Equal(BetaManagedAgentsAgentAutoEvaluatedPermissionType.Deny, value.Type.Value());
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

        ApiEnum<string, BetaManagedAgentsAgentAutoEvaluatedPermissionType> expectedType =
            BetaManagedAgentsAgentAutoEvaluatedPermissionType.Allow;
        string expectedReasonCode = "reason_code";

        Assert.Equal(expectedType, value.Type);
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

public class BetaManagedAgentsAgentAutoEvaluatedPermissionTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsAgentAutoEvaluatedPermissionType.Allow)]
    [InlineData(BetaManagedAgentsAgentAutoEvaluatedPermissionType.Ask)]
    [InlineData(BetaManagedAgentsAgentAutoEvaluatedPermissionType.Deny)]
    public void Validation_Works(BetaManagedAgentsAgentAutoEvaluatedPermissionType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsAgentAutoEvaluatedPermissionType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentAutoEvaluatedPermissionType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsAgentAutoEvaluatedPermissionType.Allow)]
    [InlineData(BetaManagedAgentsAgentAutoEvaluatedPermissionType.Ask)]
    [InlineData(BetaManagedAgentsAgentAutoEvaluatedPermissionType.Deny)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsAgentAutoEvaluatedPermissionType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsAgentAutoEvaluatedPermissionType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentAutoEvaluatedPermissionType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentAutoEvaluatedPermissionType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentAutoEvaluatedPermissionType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
