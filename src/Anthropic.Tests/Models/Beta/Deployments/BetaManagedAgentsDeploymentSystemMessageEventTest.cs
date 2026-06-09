using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Deployments;
using Anthropic.Models.Beta.Sessions;

namespace Anthropic.Tests.Models.Beta.Deployments;

public class BetaManagedAgentsDeploymentSystemMessageEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsDeploymentSystemMessageEvent
        {
            Content =
            [
                new()
                {
                    Text = "Where is my order #1234?",
                    Type = BetaManagedAgentsSystemContentBlockType.Text,
                },
            ],
            Type = BetaManagedAgentsDeploymentSystemMessageEventType.SystemMessage,
        };

        List<BetaManagedAgentsSystemContentBlock> expectedContent =
        [
            new()
            {
                Text = "Where is my order #1234?",
                Type = BetaManagedAgentsSystemContentBlockType.Text,
            },
        ];
        ApiEnum<string, BetaManagedAgentsDeploymentSystemMessageEventType> expectedType =
            BetaManagedAgentsDeploymentSystemMessageEventType.SystemMessage;

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
        var model = new BetaManagedAgentsDeploymentSystemMessageEvent
        {
            Content =
            [
                new()
                {
                    Text = "Where is my order #1234?",
                    Type = BetaManagedAgentsSystemContentBlockType.Text,
                },
            ],
            Type = BetaManagedAgentsDeploymentSystemMessageEventType.SystemMessage,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsDeploymentSystemMessageEvent>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsDeploymentSystemMessageEvent
        {
            Content =
            [
                new()
                {
                    Text = "Where is my order #1234?",
                    Type = BetaManagedAgentsSystemContentBlockType.Text,
                },
            ],
            Type = BetaManagedAgentsDeploymentSystemMessageEventType.SystemMessage,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaManagedAgentsDeploymentSystemMessageEvent>(
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
        ApiEnum<string, BetaManagedAgentsDeploymentSystemMessageEventType> expectedType =
            BetaManagedAgentsDeploymentSystemMessageEventType.SystemMessage;

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
        var model = new BetaManagedAgentsDeploymentSystemMessageEvent
        {
            Content =
            [
                new()
                {
                    Text = "Where is my order #1234?",
                    Type = BetaManagedAgentsSystemContentBlockType.Text,
                },
            ],
            Type = BetaManagedAgentsDeploymentSystemMessageEventType.SystemMessage,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsDeploymentSystemMessageEvent
        {
            Content =
            [
                new()
                {
                    Text = "Where is my order #1234?",
                    Type = BetaManagedAgentsSystemContentBlockType.Text,
                },
            ],
            Type = BetaManagedAgentsDeploymentSystemMessageEventType.SystemMessage,
        };

        BetaManagedAgentsDeploymentSystemMessageEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsDeploymentSystemMessageEventTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsDeploymentSystemMessageEventType.SystemMessage)]
    public void Validation_Works(BetaManagedAgentsDeploymentSystemMessageEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsDeploymentSystemMessageEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsDeploymentSystemMessageEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsDeploymentSystemMessageEventType.SystemMessage)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsDeploymentSystemMessageEventType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsDeploymentSystemMessageEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsDeploymentSystemMessageEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsDeploymentSystemMessageEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsDeploymentSystemMessageEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
