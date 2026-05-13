using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsSearchResultContentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSearchResultContent
        {
            Text = "x",
            Type = BetaManagedAgentsSearchResultContentType.Text,
        };

        string expectedText = "x";
        ApiEnum<string, BetaManagedAgentsSearchResultContentType> expectedType =
            BetaManagedAgentsSearchResultContentType.Text;

        Assert.Equal(expectedText, model.Text);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSearchResultContent
        {
            Text = "x",
            Type = BetaManagedAgentsSearchResultContentType.Text,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSearchResultContent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsSearchResultContent
        {
            Text = "x",
            Type = BetaManagedAgentsSearchResultContentType.Text,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSearchResultContent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedText = "x";
        ApiEnum<string, BetaManagedAgentsSearchResultContentType> expectedType =
            BetaManagedAgentsSearchResultContentType.Text;

        Assert.Equal(expectedText, deserialized.Text);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsSearchResultContent
        {
            Text = "x",
            Type = BetaManagedAgentsSearchResultContentType.Text,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsSearchResultContent
        {
            Text = "x",
            Type = BetaManagedAgentsSearchResultContentType.Text,
        };

        BetaManagedAgentsSearchResultContent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsSearchResultContentTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsSearchResultContentType.Text)]
    public void Validation_Works(BetaManagedAgentsSearchResultContentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSearchResultContentType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSearchResultContentType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsSearchResultContentType.Text)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsSearchResultContentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSearchResultContentType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSearchResultContentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSearchResultContentType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSearchResultContentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
