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
            Content = [new Events::BetaManagedAgentsTextBlock("Where is my order #1234?")],
        };

        List<Content> expectedContent =
        [
            new Events::BetaManagedAgentsTextBlock("Where is my order #1234?"),
        ];
        JsonElement expectedType = JsonSerializer.SerializeToElement("user.message");

        Assert.Equal(expectedContent.Count, model.Content.Count);
        for (int i = 0; i < expectedContent.Count; i++)
        {
            Assert.Equal(expectedContent[i], model.Content[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsDeploymentUserMessageEvent
        {
            Content = [new Events::BetaManagedAgentsTextBlock("Where is my order #1234?")],
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
            Content = [new Events::BetaManagedAgentsTextBlock("Where is my order #1234?")],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsDeploymentUserMessageEvent>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Content> expectedContent =
        [
            new Events::BetaManagedAgentsTextBlock("Where is my order #1234?"),
        ];
        JsonElement expectedType = JsonSerializer.SerializeToElement("user.message");

        Assert.Equal(expectedContent.Count, deserialized.Content.Count);
        for (int i = 0; i < expectedContent.Count; i++)
        {
            Assert.Equal(expectedContent[i], deserialized.Content[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsDeploymentUserMessageEvent
        {
            Content = [new Events::BetaManagedAgentsTextBlock("Where is my order #1234?")],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsDeploymentUserMessageEvent
        {
            Content = [new Events::BetaManagedAgentsTextBlock("Where is my order #1234?")],
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
        Content value = new Events::BetaManagedAgentsTextBlock("Where is my order #1234?");
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsImageBlockValidationWorks()
    {
        Content value = new Events::BetaManagedAgentsImageBlock(
            new Events::BetaManagedAgentsBase64ImageSource() { Data = "x", MediaType = "x" }
        );
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
            },
            Context = "context",
            Title = "title",
        };
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsRedactedBlockValidationWorks()
    {
        Content value = new Events::BetaManagedAgentsRedactedBlock();
        value.Validate();
    }

    [Fact]
    public void BetaManagedAgentsTextBlockSerializationRoundtripWorks()
    {
        Content value = new Events::BetaManagedAgentsTextBlock("Where is my order #1234?");
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
        Content value = new Events::BetaManagedAgentsImageBlock(
            new Events::BetaManagedAgentsBase64ImageSource() { Data = "x", MediaType = "x" }
        );
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
            },
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

    [Fact]
    public void BetaManagedAgentsRedactedBlockSerializationRoundtripWorks()
    {
        Content value = new Events::BetaManagedAgentsRedactedBlock();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Content>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaManagedAgentsTextBlockTypeWorks()
    {
        Content value = new Events::BetaManagedAgentsTextBlock("Where is my order #1234?");
        Assert.Equal(ContentType.Text, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsImageBlockTypeWorks()
    {
        Content value = new Events::BetaManagedAgentsImageBlock(
            new Events::BetaManagedAgentsBase64ImageSource() { Data = "x", MediaType = "x" }
        );
        Assert.Equal(ContentType.Image, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsDocumentBlockTypeWorks()
    {
        Content value = new Events::BetaManagedAgentsDocumentBlock()
        {
            Source = new Events::BetaManagedAgentsBase64DocumentSource()
            {
                Data = "x",
                MediaType = "x",
            },
            Context = "context",
            Title = "title",
        };
        Assert.Equal(ContentType.Document, value.Type.Value());
    }

    [Fact]
    public void BetaManagedAgentsRedactedBlockTypeWorks()
    {
        Content value = new Events::BetaManagedAgentsRedactedBlock();
        Assert.Equal(ContentType.Redacted, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        Content value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "text"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, ContentType> expectedType = ContentType.Text;

        Assert.Equal(expectedType, value.Type);

        Content emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class ContentTypeTest : TestBase
{
    [Theory]
    [InlineData(ContentType.Text)]
    [InlineData(ContentType.Image)]
    [InlineData(ContentType.Document)]
    [InlineData(ContentType.Redacted)]
    public void Validation_Works(ContentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ContentType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ContentType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ContentType.Text)]
    [InlineData(ContentType.Image)]
    [InlineData(ContentType.Document)]
    [InlineData(ContentType.Redacted)]
    public void SerializationRoundtrip_Works(ContentType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ContentType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ContentType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ContentType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ContentType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
