using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Sessions;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsSystemMessageEventParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSystemMessageEventParams
        {
            Content =
            [
                new()
                {
                    Text = "Where is my order #1234?",
                    Type = BetaManagedAgentsSystemContentBlockType.Text,
                },
            ],
            Type = BetaManagedAgentsSystemMessageEventParamsType.SystemMessage,
        };

        List<BetaManagedAgentsSystemContentBlock> expectedContent =
        [
            new()
            {
                Text = "Where is my order #1234?",
                Type = BetaManagedAgentsSystemContentBlockType.Text,
            },
        ];
        ApiEnum<string, BetaManagedAgentsSystemMessageEventParamsType> expectedType =
            BetaManagedAgentsSystemMessageEventParamsType.SystemMessage;

        Assert.Equal(expectedContent.Count, model.Content.Count);
        for (int i = 0; i < expectedContent.Count; i++)
        {
            Assert.Equal(expectedContent[i], model.Content[i]);
        }
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSystemMessageEventParams
        {
            Content =
            [
                new()
                {
                    Text = "Where is my order #1234?",
                    Type = BetaManagedAgentsSystemContentBlockType.Text,
                },
            ],
            Type = BetaManagedAgentsSystemMessageEventParamsType.SystemMessage,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSystemMessageEventParams>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsSystemMessageEventParams
        {
            Content =
            [
                new()
                {
                    Text = "Where is my order #1234?",
                    Type = BetaManagedAgentsSystemContentBlockType.Text,
                },
            ],
            Type = BetaManagedAgentsSystemMessageEventParamsType.SystemMessage,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSystemMessageEventParams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<BetaManagedAgentsSystemContentBlock> expectedContent =
        [
            new()
            {
                Text = "Where is my order #1234?",
                Type = BetaManagedAgentsSystemContentBlockType.Text,
            },
        ];
        ApiEnum<string, BetaManagedAgentsSystemMessageEventParamsType> expectedType =
            BetaManagedAgentsSystemMessageEventParamsType.SystemMessage;

        Assert.Equal(expectedContent.Count, deserialized.Content.Count);
        for (int i = 0; i < expectedContent.Count; i++)
        {
            Assert.Equal(expectedContent[i], deserialized.Content[i]);
        }
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsSystemMessageEventParams
        {
            Content =
            [
                new()
                {
                    Text = "Where is my order #1234?",
                    Type = BetaManagedAgentsSystemContentBlockType.Text,
                },
            ],
            Type = BetaManagedAgentsSystemMessageEventParamsType.SystemMessage,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsSystemMessageEventParams
        {
            Content =
            [
                new()
                {
                    Text = "Where is my order #1234?",
                    Type = BetaManagedAgentsSystemContentBlockType.Text,
                },
            ],
            Type = BetaManagedAgentsSystemMessageEventParamsType.SystemMessage,
        };

        BetaManagedAgentsSystemMessageEventParams copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsSystemMessageEventParamsTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsSystemMessageEventParamsType.SystemMessage)]
    public void Validation_Works(BetaManagedAgentsSystemMessageEventParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSystemMessageEventParamsType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSystemMessageEventParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsSystemMessageEventParamsType.SystemMessage)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsSystemMessageEventParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSystemMessageEventParamsType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSystemMessageEventParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSystemMessageEventParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSystemMessageEventParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
