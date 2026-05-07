using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsTextRubricParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsTextRubricParams
        {
            Content = "Must cover all five sections; cite sources inline.",
            Type = BetaManagedAgentsTextRubricParamsType.Text,
        };

        string expectedContent = "Must cover all five sections; cite sources inline.";
        ApiEnum<string, BetaManagedAgentsTextRubricParamsType> expectedType =
            BetaManagedAgentsTextRubricParamsType.Text;

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsTextRubricParams
        {
            Content = "Must cover all five sections; cite sources inline.",
            Type = BetaManagedAgentsTextRubricParamsType.Text,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsTextRubricParams>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsTextRubricParams
        {
            Content = "Must cover all five sections; cite sources inline.",
            Type = BetaManagedAgentsTextRubricParamsType.Text,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsTextRubricParams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedContent = "Must cover all five sections; cite sources inline.";
        ApiEnum<string, BetaManagedAgentsTextRubricParamsType> expectedType =
            BetaManagedAgentsTextRubricParamsType.Text;

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsTextRubricParams
        {
            Content = "Must cover all five sections; cite sources inline.",
            Type = BetaManagedAgentsTextRubricParamsType.Text,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsTextRubricParams
        {
            Content = "Must cover all five sections; cite sources inline.",
            Type = BetaManagedAgentsTextRubricParamsType.Text,
        };

        BetaManagedAgentsTextRubricParams copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsTextRubricParamsTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsTextRubricParamsType.Text)]
    public void Validation_Works(BetaManagedAgentsTextRubricParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsTextRubricParamsType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsTextRubricParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsTextRubricParamsType.Text)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsTextRubricParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsTextRubricParamsType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsTextRubricParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsTextRubricParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsTextRubricParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
