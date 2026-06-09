using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Deployments;
using Events = Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Deployments;

public class BetaManagedAgentsDeploymentUserMessageEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsDeploymentUserMessageEvent
        {
            Content =
            [
                new Events::BetaManagedAgentsTextBlock()
                {
                    Text = "Where is my order #1234?",
                    Type = Events::BetaManagedAgentsTextBlockType.Text,
                },
            ],
            Type = BetaManagedAgentsDeploymentUserMessageEventType.UserMessage,
        };

        List<Content> expectedContent =
        [
            new Events::BetaManagedAgentsTextBlock()
            {
                Text = "Where is my order #1234?",
                Type = Events::BetaManagedAgentsTextBlockType.Text,
            },
        ];
        ApiEnum<string, BetaManagedAgentsDeploymentUserMessageEventType> expectedType =
            BetaManagedAgentsDeploymentUserMessageEventType.UserMessage;

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
        var model = new BetaManagedAgentsDeploymentUserMessageEvent
        {
            Content =
            [
                new Events::BetaManagedAgentsTextBlock()
                {
                    Text = "Where is my order #1234?",
                    Type = Events::BetaManagedAgentsTextBlockType.Text,
                },
            ],
            Type = BetaManagedAgentsDeploymentUserMessageEventType.UserMessage,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsDeploymentUserMessageEvent>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsDeploymentUserMessageEvent
        {
            Content =
            [
                new Events::BetaManagedAgentsTextBlock()
                {
                    Text = "Where is my order #1234?",
                    Type = Events::BetaManagedAgentsTextBlockType.Text,
                },
            ],
            Type = BetaManagedAgentsDeploymentUserMessageEventType.UserMessage,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsDeploymentUserMessageEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Content> expectedContent =
        [
            new Events::BetaManagedAgentsTextBlock()
            {
                Text = "Where is my order #1234?",
                Type = Events::BetaManagedAgentsTextBlockType.Text,
            },
        ];
        ApiEnum<string, BetaManagedAgentsDeploymentUserMessageEventType> expectedType =
            BetaManagedAgentsDeploymentUserMessageEventType.UserMessage;

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
        var model = new BetaManagedAgentsDeploymentUserMessageEvent
        {
            Content =
            [
                new Events::BetaManagedAgentsTextBlock()
                {
                    Text = "Where is my order #1234?",
                    Type = Events::BetaManagedAgentsTextBlockType.Text,
                },
            ],
            Type = BetaManagedAgentsDeploymentUserMessageEventType.UserMessage,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsDeploymentUserMessageEvent
        {
            Content =
            [
                new Events::BetaManagedAgentsTextBlock()
                {
                    Text = "Where is my order #1234?",
                    Type = Events::BetaManagedAgentsTextBlockType.Text,
                },
            ],
            Type = BetaManagedAgentsDeploymentUserMessageEventType.UserMessage,
        };

        BetaManagedAgentsDeploymentUserMessageEvent copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ContentTest : TestBase
{
    [Fact]
    public void BetaManagedAgentsTextBlockValidationWorks()
    {
        Content value = new Events::BetaManagedAgentsTextBlock()
        {
            Text = "Where is my order #1234?",
            Type = Events::BetaManagedAgentsTextBlockType.Text,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsImageBlockValidationWorks()
    {
        Content value = new Events::BetaManagedAgentsImageBlock()
        {
            Source = new Events::BetaManagedAgentsBase64ImageSource()
            {
                Data = "x",
                MediaType = "x",
                Type = Events::BetaManagedAgentsBase64ImageSourceType.Base64,
            },
            Type = Events::BetaManagedAgentsImageBlockType.Image,
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsDocumentBlockValidationWorks()
    {
        Content value = new Events::BetaManagedAgentsDocumentBlock()
        {
            Source = new Events::BetaManagedAgentsBase64DocumentSource()
            {
                Data = "x",
                MediaType = "x",
                Type = Events::BetaManagedAgentsBase64DocumentSourceType.Base64,
            },
            Type = Events::BetaManagedAgentsDocumentBlockType.Document,
            Context = "context",
            Title = "title",
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsTextBlockSerializationRoundtripWorks()
    {
        Content value = new Events::BetaManagedAgentsTextBlock()
        {
            Text = "Where is my order #1234?",
            Type = Events::BetaManagedAgentsTextBlockType.Text,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Content>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsImageBlockSerializationRoundtripWorks()
    {
        Content value = new Events::BetaManagedAgentsImageBlock()
        {
            Source = new Events::BetaManagedAgentsBase64ImageSource()
            {
                Data = "x",
                MediaType = "x",
                Type = Events::BetaManagedAgentsBase64ImageSourceType.Base64,
            },
            Type = Events::BetaManagedAgentsImageBlockType.Image,
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Content>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsDocumentBlockSerializationRoundtripWorks()
    {
        Content value = new Events::BetaManagedAgentsDocumentBlock()
        {
            Source = new Events::BetaManagedAgentsBase64DocumentSource()
            {
                Data = "x",
                MediaType = "x",
                Type = Events::BetaManagedAgentsBase64DocumentSourceType.Base64,
            },
            Type = Events::BetaManagedAgentsDocumentBlockType.Document,
            Context = "context",
            Title = "title",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Content>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class BetaManagedAgentsDeploymentUserMessageEventTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsDeploymentUserMessageEventType.UserMessage)]
    public void Validation_Works(BetaManagedAgentsDeploymentUserMessageEventType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsDeploymentUserMessageEventType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsDeploymentUserMessageEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsDeploymentUserMessageEventType.UserMessage)]
    public void SerializationRoundtrip_Works(
        BetaManagedAgentsDeploymentUserMessageEventType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsDeploymentUserMessageEventType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsDeploymentUserMessageEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsDeploymentUserMessageEventType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsDeploymentUserMessageEventType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
