using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Organization.Federation.Issuers;

namespace Anthropic.Tests.Models.Organization.Federation.Issuers;

public class JwksInlineTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new JwksInline
        {
            Keys =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
        };

        List<Dictionary<string, JsonElement>> expectedKeys =
        [
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        ];
        JsonElement expectedType = JsonSerializer.SerializeToElement("inline");

        Assert.Equal(expectedKeys.Count, model.Keys.Count);
        for (int i = 0; i < expectedKeys.Count; i++)
        {
            Assert.Equal(expectedKeys[i].Count, model.Keys[i].Count);
            foreach (var item in expectedKeys[i])
            {
                Assert.True(model.Keys[i].TryGetValue(item.Key, out var value));

                Assert.True(JsonElement.DeepEquals(value, model.Keys[i][item.Key]));
            }
        }
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new JwksInline
        {
            Keys =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JwksInline>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new JwksInline
        {
            Keys =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<JwksInline>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Dictionary<string, JsonElement>> expectedKeys =
        [
            new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        ];
        JsonElement expectedType = JsonSerializer.SerializeToElement("inline");

        Assert.Equal(expectedKeys.Count, deserialized.Keys.Count);
        for (int i = 0; i < expectedKeys.Count; i++)
        {
            Assert.Equal(expectedKeys[i].Count, deserialized.Keys[i].Count);
            foreach (var item in expectedKeys[i])
            {
                Assert.True(deserialized.Keys[i].TryGetValue(item.Key, out var value));

                Assert.True(JsonElement.DeepEquals(value, deserialized.Keys[i][item.Key]));
            }
        }
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new JwksInline
        {
            Keys =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new JwksInline
        {
            Keys =
            [
                new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            ],
        };

        JwksInline copied = new(model);

        Assert.Equal(model, copied);
    }
}
