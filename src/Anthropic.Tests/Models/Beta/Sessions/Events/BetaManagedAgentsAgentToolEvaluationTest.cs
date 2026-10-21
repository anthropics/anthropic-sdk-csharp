using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsAgentToolEvaluationTest : TestBase
{
    [Fact]
    public void AlwaysAllowValidationWorks()
    {
        BetaManagedAgentsAgentToolEvaluation value =
            new BetaManagedAgentsAgentToolEvaluationAlwaysAllow();
        value.Validate();
    }

    [Fact]
    public void AlwaysAskValidationWorks()
    {
        BetaManagedAgentsAgentToolEvaluation value =
            new BetaManagedAgentsAgentToolEvaluationAlwaysAsk();
        value.Validate();
    }

    [Fact]
    public void AutoValidationWorks()
    {
        BetaManagedAgentsAgentToolEvaluation value = new BetaManagedAgentsAgentToolEvaluationAuto(
            new BetaManagedAgentsAgentAutoEvaluatedPermissionAllow()
        );
        value.Validate();
    }

    [Fact]
    public void AlwaysAllowSerializationRoundtripWorks()
    {
        BetaManagedAgentsAgentToolEvaluation value =
            new BetaManagedAgentsAgentToolEvaluationAlwaysAllow();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentToolEvaluation>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AlwaysAskSerializationRoundtripWorks()
    {
        BetaManagedAgentsAgentToolEvaluation value =
            new BetaManagedAgentsAgentToolEvaluationAlwaysAsk();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentToolEvaluation>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AutoSerializationRoundtripWorks()
    {
        BetaManagedAgentsAgentToolEvaluation value = new BetaManagedAgentsAgentToolEvaluationAuto(
            new BetaManagedAgentsAgentAutoEvaluatedPermissionAllow()
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsAgentToolEvaluation>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AlwaysAllowTypeWorks()
    {
        BetaManagedAgentsAgentToolEvaluation value =
            new BetaManagedAgentsAgentToolEvaluationAlwaysAllow();
        Assert.Equal(BetaManagedAgentsAgentToolEvaluationType.AlwaysAllow, value.Type.Value());
    }

    [Fact]
    public void AlwaysAskTypeWorks()
    {
        BetaManagedAgentsAgentToolEvaluation value =
            new BetaManagedAgentsAgentToolEvaluationAlwaysAsk();
        Assert.Equal(BetaManagedAgentsAgentToolEvaluationType.AlwaysAsk, value.Type.Value());
    }

    [Fact]
    public void AutoTypeWorks()
    {
        BetaManagedAgentsAgentToolEvaluation value = new BetaManagedAgentsAgentToolEvaluationAuto(
            new BetaManagedAgentsAgentAutoEvaluatedPermissionAllow()
        );
        Assert.Equal(BetaManagedAgentsAgentToolEvaluationType.Auto, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsAgentToolEvaluation value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "always_allow"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaManagedAgentsAgentToolEvaluationType> expectedType =
            BetaManagedAgentsAgentToolEvaluationType.AlwaysAllow;

        Assert.Equal(expectedType, value.Type);

        BetaManagedAgentsAgentToolEvaluation emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaManagedAgentsAgentToolEvaluationTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsAgentToolEvaluationType.AlwaysAllow)]
    [InlineData(BetaManagedAgentsAgentToolEvaluationType.AlwaysAsk)]
    [InlineData(BetaManagedAgentsAgentToolEvaluationType.Auto)]
    public void Validation_Works(BetaManagedAgentsAgentToolEvaluationType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsAgentToolEvaluationType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentToolEvaluationType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsAgentToolEvaluationType.AlwaysAllow)]
    [InlineData(BetaManagedAgentsAgentToolEvaluationType.AlwaysAsk)]
    [InlineData(BetaManagedAgentsAgentToolEvaluationType.Auto)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsAgentToolEvaluationType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsAgentToolEvaluationType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentToolEvaluationType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentToolEvaluationType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsAgentToolEvaluationType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
