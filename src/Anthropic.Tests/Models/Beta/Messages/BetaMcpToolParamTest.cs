using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaMcpToolParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaMcpToolParam
        {
            InputSchema = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",
            Description = "description",
        };

        Dictionary<string, JsonElement> expectedInputSchema = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedName = "x";
        string expectedDescription = "description";

        Assert.Equal(expectedInputSchema.Count, model.InputSchema.Count);
        foreach (var item in expectedInputSchema)
        {
            Assert.True(model.InputSchema.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.InputSchema[item.Key]));
        }
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedDescription, model.Description);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaMcpToolParam
        {
            InputSchema = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",
            Description = "description",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaMcpToolParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaMcpToolParam
        {
            InputSchema = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",
            Description = "description",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaMcpToolParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Dictionary<string, JsonElement> expectedInputSchema = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedName = "x";
        string expectedDescription = "description";

        Assert.Equal(expectedInputSchema.Count, deserialized.InputSchema.Count);
        foreach (var item in expectedInputSchema)
        {
            Assert.True(deserialized.InputSchema.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.InputSchema[item.Key]));
        }
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedDescription, deserialized.Description);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaMcpToolParam
        {
            InputSchema = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",
            Description = "description",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaMcpToolParam
        {
            InputSchema = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaMcpToolParam
        {
            InputSchema = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaMcpToolParam
        {
            InputSchema = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",

            Description = null,
        };

        Assert.Null(model.Description);
        Assert.True(model.RawData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaMcpToolParam
        {
            InputSchema = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",

            Description = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaMcpToolParam
        {
            InputSchema = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",
            Description = "description",
        };

        BetaMcpToolParam copied = new(model);

        Assert.Equal(model, copied);
    }
}
