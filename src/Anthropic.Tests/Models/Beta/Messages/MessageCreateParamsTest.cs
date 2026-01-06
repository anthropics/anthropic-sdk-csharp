using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class ContainerTest : TestBase
{
    [Fact]
    public void BetaContainerParamsValidationWorks()
    {
        Container value = new(
            new BetaContainerParams()
            {
                ID = "id",
                Skills =
                [
                    new()
                    {
                        SkillID = "x",
                        Type = BetaSkillParamsType.Anthropic,
                        Version = "x",
                    },
                ],
            }
        );
        value.Validate();
    }

    [Fact]
    public void StringValidationWorks()
    {
        Container value = new("string");
        value.Validate();
    }

    [Fact]
    public void BetaContainerParamsSerializationRoundtripWorks()
    {
        Container value = new(
            new BetaContainerParams()
            {
                ID = "id",
                Skills =
                [
                    new()
                    {
                        SkillID = "x",
                        Type = BetaSkillParamsType.Anthropic,
                        Version = "x",
                    },
                ],
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Container>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Container value = new("string");
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Container>(element);

        Assert.Equal(value, deserialized);
    }
}

public class ServiceTierTest : TestBase
{
    [Theory]
    [InlineData(ServiceTier.Auto)]
    [InlineData(ServiceTier.StandardOnly)]
    public void Validation_Works(ServiceTier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ServiceTier> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ServiceTier>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ServiceTier.Auto)]
    [InlineData(ServiceTier.StandardOnly)]
    public void SerializationRoundtrip_Works(ServiceTier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ServiceTier> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ServiceTier>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ServiceTier>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ServiceTier>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class MessageCreateParamsSystemTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        MessageCreateParamsSystem value = new("string");
        value.Validate();
    }

    [Fact]
    public void BetaTextBlockParamsValidationWorks()
    {
        MessageCreateParamsSystem value = new(
            [
                new BetaTextBlockParam()
                {
                    Text = "x",
                    CacheControl = new() { TTL = TTL.TTL5m },
                    Citations =
                    [
                        new BetaCitationCharLocationParam()
                        {
                            CitedText = "cited_text",
                            DocumentIndex = 0,
                            DocumentTitle = "x",
                            EndCharIndex = 0,
                            StartCharIndex = 0,
                        },
                    ],
                },
            ]
        );
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        MessageCreateParamsSystem value = new("string");
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<MessageCreateParamsSystem>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaTextBlockParamsSerializationRoundtripWorks()
    {
        MessageCreateParamsSystem value = new(
            [
                new BetaTextBlockParam()
                {
                    Text = "x",
                    CacheControl = new() { TTL = TTL.TTL5m },
                    Citations =
                    [
                        new BetaCitationCharLocationParam()
                        {
                            CitedText = "cited_text",
                            DocumentIndex = 0,
                            DocumentTitle = "x",
                            EndCharIndex = 0,
                            StartCharIndex = 0,
                        },
                    ],
                },
            ]
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<MessageCreateParamsSystem>(element);

        Assert.Equal(value, deserialized);
    }
}
