using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsWebFetchUrlSourceUserInputTest : TestBase
{
    [Fact]
    public void AllValidationWorks()
    {
        BetaManagedAgentsWebFetchUrlSourceUserInput value =
            new BetaManagedAgentsWebFetchUrlSourceAll();
        value.Validate();
    }

    [Fact]
    public void NoneValidationWorks()
    {
        BetaManagedAgentsWebFetchUrlSourceUserInput value =
            new BetaManagedAgentsWebFetchUrlSourceNone();
        value.Validate();
    }

    [Fact]
    public void AllSerializationRoundtripWorks()
    {
        BetaManagedAgentsWebFetchUrlSourceUserInput value =
            new BetaManagedAgentsWebFetchUrlSourceAll();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsWebFetchUrlSourceUserInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void NoneSerializationRoundtripWorks()
    {
        BetaManagedAgentsWebFetchUrlSourceUserInput value =
            new BetaManagedAgentsWebFetchUrlSourceNone();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsWebFetchUrlSourceUserInput>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void AllTypeWorks()
    {
        BetaManagedAgentsWebFetchUrlSourceUserInput value =
            new BetaManagedAgentsWebFetchUrlSourceAll();
        Assert.Equal(BetaManagedAgentsWebFetchUrlSourceUserInputType.All, value.Type.Value());
    }

    [Fact]
    public void NoneTypeWorks()
    {
        BetaManagedAgentsWebFetchUrlSourceUserInput value =
            new BetaManagedAgentsWebFetchUrlSourceNone();
        Assert.Equal(BetaManagedAgentsWebFetchUrlSourceUserInputType.None, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaManagedAgentsWebFetchUrlSourceUserInput value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "all"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaManagedAgentsWebFetchUrlSourceUserInputType> expectedType =
            BetaManagedAgentsWebFetchUrlSourceUserInputType.All;

        Assert.Equal(expectedType, value.Type);

        BetaManagedAgentsWebFetchUrlSourceUserInput emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaManagedAgentsWebFetchUrlSourceUserInputTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsWebFetchUrlSourceUserInputType.All)]
    [InlineData(BetaManagedAgentsWebFetchUrlSourceUserInputType.None)]
    public void Validation_Works(BetaManagedAgentsWebFetchUrlSourceUserInputType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsWebFetchUrlSourceUserInputType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsWebFetchUrlSourceUserInputType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsWebFetchUrlSourceUserInputType.All)]
    [InlineData(BetaManagedAgentsWebFetchUrlSourceUserInputType.None)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsWebFetchUrlSourceUserInputType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsWebFetchUrlSourceUserInputType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsWebFetchUrlSourceUserInputType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsWebFetchUrlSourceUserInputType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsWebFetchUrlSourceUserInputType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
