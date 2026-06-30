using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions;

public class BetaManagedAgentsDeltaContentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsDeltaContent
        {
            Content = new()
            {
                Text = "Where is my order #1234?",
                Type = BetaManagedAgentsTextBlockType.Text,
            },
            Type = BetaManagedAgentsDeltaContentType.ContentDelta,
            Index = 0,
        };

        BetaManagedAgentsTextBlock expectedContent = new()
        {
            Text = "Where is my order #1234?",
            Type = BetaManagedAgentsTextBlockType.Text,
        };
        ApiEnum<string, BetaManagedAgentsDeltaContentType> expectedType =
            BetaManagedAgentsDeltaContentType.ContentDelta;
        long expectedIndex = 0;

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedIndex, model.Index);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsDeltaContent
        {
            Content = new()
            {
                Text = "Where is my order #1234?",
                Type = BetaManagedAgentsTextBlockType.Text,
            },
            Type = BetaManagedAgentsDeltaContentType.ContentDelta,
            Index = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsDeltaContent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsDeltaContent
        {
            Content = new()
            {
                Text = "Where is my order #1234?",
                Type = BetaManagedAgentsTextBlockType.Text,
            },
            Type = BetaManagedAgentsDeltaContentType.ContentDelta,
            Index = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsDeltaContent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaManagedAgentsTextBlock expectedContent = new()
        {
            Text = "Where is my order #1234?",
            Type = BetaManagedAgentsTextBlockType.Text,
        };
        ApiEnum<string, BetaManagedAgentsDeltaContentType> expectedType =
            BetaManagedAgentsDeltaContentType.ContentDelta;
        long expectedIndex = 0;

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedIndex, deserialized.Index);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsDeltaContent
        {
            Content = new()
            {
                Text = "Where is my order #1234?",
                Type = BetaManagedAgentsTextBlockType.Text,
            },
            Type = BetaManagedAgentsDeltaContentType.ContentDelta,
            Index = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaManagedAgentsDeltaContent
        {
            Content = new()
            {
                Text = "Where is my order #1234?",
                Type = BetaManagedAgentsTextBlockType.Text,
            },
            Type = BetaManagedAgentsDeltaContentType.ContentDelta,
        };

        Assert.Null(model.Index);
        Assert.False(model.RawData.ContainsKey("index"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaManagedAgentsDeltaContent
        {
            Content = new()
            {
                Text = "Where is my order #1234?",
                Type = BetaManagedAgentsTextBlockType.Text,
            },
            Type = BetaManagedAgentsDeltaContentType.ContentDelta,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaManagedAgentsDeltaContent
        {
            Content = new()
            {
                Text = "Where is my order #1234?",
                Type = BetaManagedAgentsTextBlockType.Text,
            },
            Type = BetaManagedAgentsDeltaContentType.ContentDelta,

            // Null should be interpreted as omitted for these properties
            Index = null,
        };

        Assert.Null(model.Index);
        Assert.False(model.RawData.ContainsKey("index"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaManagedAgentsDeltaContent
        {
            Content = new()
            {
                Text = "Where is my order #1234?",
                Type = BetaManagedAgentsTextBlockType.Text,
            },
            Type = BetaManagedAgentsDeltaContentType.ContentDelta,

            // Null should be interpreted as omitted for these properties
            Index = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsDeltaContent
        {
            Content = new()
            {
                Text = "Where is my order #1234?",
                Type = BetaManagedAgentsTextBlockType.Text,
            },
            Type = BetaManagedAgentsDeltaContentType.ContentDelta,
            Index = 0,
        };

        BetaManagedAgentsDeltaContent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsDeltaContentTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsDeltaContentType.ContentDelta)]
    public void Validation_Works(BetaManagedAgentsDeltaContentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsDeltaContentType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsDeltaContentType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsDeltaContentType.ContentDelta)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsDeltaContentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsDeltaContentType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsDeltaContentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaManagedAgentsDeltaContentType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsDeltaContentType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
