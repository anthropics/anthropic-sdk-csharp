using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaMcpToolTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaMcpTool
        {
            InputSchema = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",
            Description = "description",
        };

        Dictionary<string, JsonElement> expectedInputSchema = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedName = "name";
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
        var model = new BetaMcpTool
        {
            InputSchema = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",
            Description = "description",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaMcpTool>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaMcpTool
        {
            InputSchema = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",
            Description = "description",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaMcpTool>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Dictionary<string, JsonElement> expectedInputSchema = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedName = "name";
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
        var model = new BetaMcpTool
        {
            InputSchema = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",
            Description = "description",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaMcpTool
        {
            InputSchema = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaMcpTool
        {
            InputSchema = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaMcpTool
        {
            InputSchema = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",

            // Null should be interpreted as omitted for these properties
            Description = null,
        };

        Assert.Null(model.Description);
        Assert.False(model.RawData.ContainsKey("description"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaMcpTool
        {
            InputSchema = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",

            // Null should be interpreted as omitted for these properties
            Description = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaMcpTool
        {
            InputSchema = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "name",
            Description = "description",
        };

        BetaMcpTool copied = new(model);

        Assert.Equal(model, copied);
    }
}
