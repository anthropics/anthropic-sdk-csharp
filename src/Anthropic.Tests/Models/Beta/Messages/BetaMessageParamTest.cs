using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaMessageParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaMessageParam { Content = "string", Role = Role.User };

        BetaMessageParamContent expectedContent = "string";
        ApiEnum<string, Role> expectedRole = Role.User;

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedRole, model.Role);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaMessageParam { Content = "string", Role = Role.User };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaMessageParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaMessageParam { Content = "string", Role = Role.User };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaMessageParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaMessageParamContent expectedContent = "string";
        ApiEnum<string, Role> expectedRole = Role.User;

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedRole, deserialized.Role);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaMessageParam { Content = "string", Role = Role.User };

        model.Validate();
    }
}

public class BetaMessageParamContentTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        BetaMessageParamContent value = "string";
        value.Validate();
    }

    [Fact]
    public void BetaContentBlockParamsValidationWorks()
    {
        BetaMessageParamContent value = new(
            [
                new BetaContentBlockParam(
                    new BetaTextBlockParam()
                    {
                        Text = "What is a quaternion?",
                        CacheControl = new() { Ttl = Ttl.Ttl5m },
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
                    }
                ),
            ]
        );
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        BetaMessageParamContent value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaMessageParamContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaContentBlockParamsSerializationRoundtripWorks()
    {
        BetaMessageParamContent value = new(
            [
                new BetaContentBlockParam(
                    new BetaTextBlockParam()
                    {
                        Text = "What is a quaternion?",
                        CacheControl = new() { Ttl = Ttl.Ttl5m },
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
                    }
                ),
            ]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaMessageParamContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class RoleTest : TestBase
{
    [Theory]
    [InlineData(Role.User)]
    [InlineData(Role.Assistant)]
    public void Validation_Works(Role rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Role> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Role>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Role.User)]
    [InlineData(Role.Assistant)]
    public void SerializationRoundtrip_Works(Role rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Role> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Role>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Role>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Role>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
