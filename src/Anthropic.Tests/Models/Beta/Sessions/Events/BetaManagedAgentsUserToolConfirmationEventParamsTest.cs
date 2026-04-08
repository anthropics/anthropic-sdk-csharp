using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsUserToolConfirmationEventParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsUserToolConfirmationEventParams
        {
            Result = BetaManagedAgentsUserToolConfirmationEventParamsResult.Allow,
            ToolUseID = "x",
            Type = BetaManagedAgentsUserToolConfirmationEventParamsType.UserToolConfirmation,
            DenyMessage = "deny_message",
        };

        ApiEnum<string, BetaManagedAgentsUserToolConfirmationEventParamsResult> expectedResult =
            BetaManagedAgentsUserToolConfirmationEventParamsResult.Allow;
        string expectedToolUseID = "x";
        ApiEnum<string, BetaManagedAgentsUserToolConfirmationEventParamsType> expectedType =
            BetaManagedAgentsUserToolConfirmationEventParamsType.UserToolConfirmation;
        string expectedDenyMessage = "deny_message";

        Assert.Equal(expectedResult, model.Result);
        Assert.Equal(expectedToolUseID, model.ToolUseID);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedDenyMessage, model.DenyMessage);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsUserToolConfirmationEventParams
        {
            Result = BetaManagedAgentsUserToolConfirmationEventParamsResult.Allow,
            ToolUseID = "x",
            Type = BetaManagedAgentsUserToolConfirmationEventParamsType.UserToolConfirmation,
            DenyMessage = "deny_message",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsUserToolConfirmationEventParams>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsUserToolConfirmationEventParams
        {
            Result = BetaManagedAgentsUserToolConfirmationEventParamsResult.Allow,
            ToolUseID = "x",
            Type = BetaManagedAgentsUserToolConfirmationEventParamsType.UserToolConfirmation,
            DenyMessage = "deny_message",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsUserToolConfirmationEventParams>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<string, BetaManagedAgentsUserToolConfirmationEventParamsResult> expectedResult =
            BetaManagedAgentsUserToolConfirmationEventParamsResult.Allow;
        string expectedToolUseID = "x";
        ApiEnum<string, BetaManagedAgentsUserToolConfirmationEventParamsType> expectedType =
            BetaManagedAgentsUserToolConfirmationEventParamsType.UserToolConfirmation;
        string expectedDenyMessage = "deny_message";

        Assert.Equal(expectedResult, deserialized.Result);
        Assert.Equal(expectedToolUseID, deserialized.ToolUseID);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedDenyMessage, deserialized.DenyMessage);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsUserToolConfirmationEventParams
        {
            Result = BetaManagedAgentsUserToolConfirmationEventParamsResult.Allow,
            ToolUseID = "x",
            Type = BetaManagedAgentsUserToolConfirmationEventParamsType.UserToolConfirmation,
            DenyMessage = "deny_message",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsUserToolConfirmationEventParams
        {
            Result = BetaManagedAgentsUserToolConfirmationEventParamsResult.Allow,
            ToolUseID = "x",
            Type = BetaManagedAgentsUserToolConfirmationEventParamsType.UserToolConfirmation,
        };

        Assert.Null(model.DenyMessage);
        Assert.False(model.RawData.ContainsKey("deny_message"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsUserToolConfirmationEventParams
        {
            Result = BetaManagedAgentsUserToolConfirmationEventParamsResult.Allow,
            ToolUseID = "x",
            Type = BetaManagedAgentsUserToolConfirmationEventParamsType.UserToolConfirmation,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaManagedAgentsUserToolConfirmationEventParams
        {
            Result = BetaManagedAgentsUserToolConfirmationEventParamsResult.Allow,
            ToolUseID = "x",
            Type = BetaManagedAgentsUserToolConfirmationEventParamsType.UserToolConfirmation,

            DenyMessage = null,
        };

        Assert.Null(model.DenyMessage);
        Assert.True(model.RawData.ContainsKey("deny_message"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsUserToolConfirmationEventParams
        {
            Result = BetaManagedAgentsUserToolConfirmationEventParamsResult.Allow,
            ToolUseID = "x",
            Type = BetaManagedAgentsUserToolConfirmationEventParamsType.UserToolConfirmation,

            DenyMessage = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsUserToolConfirmationEventParams
        {
            Result = BetaManagedAgentsUserToolConfirmationEventParamsResult.Allow,
            ToolUseID = "x",
            Type = BetaManagedAgentsUserToolConfirmationEventParamsType.UserToolConfirmation,
            DenyMessage = "deny_message",
        };

        BetaManagedAgentsUserToolConfirmationEventParams copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsUserToolConfirmationEventParamsResultTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsUserToolConfirmationEventParamsResult.Allow)]
    [InlineData(BetaManagedAgentsUserToolConfirmationEventParamsResult.Deny)]
    public void Validation_Works(BetaManagedAgentsUserToolConfirmationEventParamsResult rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsUserToolConfirmationEventParamsResult> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUserToolConfirmationEventParamsResult>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsUserToolConfirmationEventParamsResult.Allow)]
    [InlineData(BetaManagedAgentsUserToolConfirmationEventParamsResult.Deny)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsUserToolConfirmationEventParamsResult rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsUserToolConfirmationEventParamsResult> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUserToolConfirmationEventParamsResult>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUserToolConfirmationEventParamsResult>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUserToolConfirmationEventParamsResult>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class BetaManagedAgentsUserToolConfirmationEventParamsTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsUserToolConfirmationEventParamsType.UserToolConfirmation)]
    public void Validation_Works(BetaManagedAgentsUserToolConfirmationEventParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsUserToolConfirmationEventParamsType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUserToolConfirmationEventParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsUserToolConfirmationEventParamsType.UserToolConfirmation)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsUserToolConfirmationEventParamsType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsUserToolConfirmationEventParamsType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUserToolConfirmationEventParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUserToolConfirmationEventParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsUserToolConfirmationEventParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
