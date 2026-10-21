using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaResponseToolInputSchemaTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaResponseToolInputSchema
        {
            Properties = new Dictionary<string, JsonElement>()
            {
                { "location", JsonSerializer.SerializeToElement("bar") },
                { "unit", JsonSerializer.SerializeToElement("bar") },
            },
            Required = ["location"],
        };

        JsonElement expectedType = JsonSerializer.SerializeToElement("object");
        Dictionary<string, JsonElement> expectedProperties = new()
        {
            { "location", JsonSerializer.SerializeToElement("bar") },
            { "unit", JsonSerializer.SerializeToElement("bar") },
        };
        List<string> expectedRequired = ["location"];

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.NotNull(model.Properties);
        Assert.Equal(expectedProperties.Count, model.Properties.Count);
        foreach (var item in expectedProperties)
        {
            Assert.True(model.Properties.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Properties[item.Key]));
        }
        Assert.NotNull(model.Required);
        Assert.Equal(expectedRequired.Count, model.Required.Count);
        for (int i = 0; i < expectedRequired.Count; i++)
        {
            Assert.Equal(expectedRequired[i], model.Required[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaResponseToolInputSchema
        {
            Properties = new Dictionary<string, JsonElement>()
            {
                { "location", JsonSerializer.SerializeToElement("bar") },
                { "unit", JsonSerializer.SerializeToElement("bar") },
            },
            Required = ["location"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaResponseToolInputSchema>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaResponseToolInputSchema
        {
            Properties = new Dictionary<string, JsonElement>()
            {
                { "location", JsonSerializer.SerializeToElement("bar") },
                { "unit", JsonSerializer.SerializeToElement("bar") },
            },
            Required = ["location"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaResponseToolInputSchema>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("object");
        Dictionary<string, JsonElement> expectedProperties = new()
        {
            { "location", JsonSerializer.SerializeToElement("bar") },
            { "unit", JsonSerializer.SerializeToElement("bar") },
        };
        List<string> expectedRequired = ["location"];

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.NotNull(deserialized.Properties);
        Assert.Equal(expectedProperties.Count, deserialized.Properties.Count);
        foreach (var item in expectedProperties)
        {
            Assert.True(deserialized.Properties.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Properties[item.Key]));
        }
        Assert.NotNull(deserialized.Required);
        Assert.Equal(expectedRequired.Count, deserialized.Required.Count);
        for (int i = 0; i < expectedRequired.Count; i++)
        {
            Assert.Equal(expectedRequired[i], deserialized.Required[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaResponseToolInputSchema
        {
            Properties = new Dictionary<string, JsonElement>()
            {
                { "location", JsonSerializer.SerializeToElement("bar") },
                { "unit", JsonSerializer.SerializeToElement("bar") },
            },
            Required = ["location"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaResponseToolInputSchema { };

        Assert.Null(model.Properties);
        Assert.False(model.RawData.ContainsKey("properties"));
        Assert.Null(model.Required);
        Assert.False(model.RawData.ContainsKey("required"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaResponseToolInputSchema { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaResponseToolInputSchema { Properties = null, Required = null };

        Assert.Null(model.Properties);
        Assert.True(model.RawData.ContainsKey("properties"));
        Assert.Null(model.Required);
        Assert.True(model.RawData.ContainsKey("required"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaResponseToolInputSchema { Properties = null, Required = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaResponseToolInputSchema
        {
            Properties = new Dictionary<string, JsonElement>()
            {
                { "location", JsonSerializer.SerializeToElement("bar") },
                { "unit", JsonSerializer.SerializeToElement("bar") },
            },
            Required = ["location"],
        };

        BetaResponseToolInputSchema copied = new(model);

        Assert.Equal(model, copied);
    }
}
