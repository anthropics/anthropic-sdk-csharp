using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class SystemMessageParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SystemMessageParam { Content = "string" };

        SystemMessageParamContent expectedContent = "string";
        JsonElement expectedRole = JsonSerializer.SerializeToElement("system");

        Assert.Equal(expectedContent, model.Content);
        Assert.True(JsonElement.DeepEquals(expectedRole, model.Role));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SystemMessageParam { Content = "string" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SystemMessageParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SystemMessageParam { Content = "string" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SystemMessageParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        SystemMessageParamContent expectedContent = "string";
        JsonElement expectedRole = JsonSerializer.SerializeToElement("system");

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.True(JsonElement.DeepEquals(expectedRole, deserialized.Role));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SystemMessageParam { Content = "string" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SystemMessageParam { Content = "string" };

        SystemMessageParam copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SystemMessageParamContentTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        SystemMessageParamContent value = "string";
        value.Validate();
    }

    [Fact]
    public void BlocksValidationWorks()
    {
        SystemMessageParamContent value = new(
            [
                new TextBlockParam()
                {
                    Text = "x",
                    CacheControl = new() { Ttl = Ttl.Ttl5m },
                    Citations =
                    [
                        new CitationCharLocationParam()
                        {
                            CitedText = "The grass is green. The sky is blue.",
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
        SystemMessageParamContent value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SystemMessageParamContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BlocksSerializationRoundtripWorks()
    {
        SystemMessageParamContent value = new(
            [
                new TextBlockParam()
                {
                    Text = "x",
                    CacheControl = new() { Ttl = Ttl.Ttl5m },
                    Citations =
                    [
                        new CitationCharLocationParam()
                        {
                            CitedText = "The grass is green. The sky is blue.",
                            DocumentIndex = 0,
                            DocumentTitle = "x",
                            EndCharIndex = 0,
                            StartCharIndex = 0,
                        },
                    ],
                },
            ]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SystemMessageParamContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
