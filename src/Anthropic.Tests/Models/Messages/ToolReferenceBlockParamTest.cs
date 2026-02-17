using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ToolReferenceBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ToolReferenceBlockParam
        {
            ToolName = "tool_name",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };

        string expectedToolName = "tool_name";
        JsonElement expectedType = JsonSerializer.SerializeToElement("tool_reference");
        CacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };

        Assert.Equal(expectedToolName, model.ToolName);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedCacheControl, model.CacheControl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ToolReferenceBlockParam
        {
            ToolName = "tool_name",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolReferenceBlockParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ToolReferenceBlockParam
        {
            ToolName = "tool_name",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolReferenceBlockParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedToolName = "tool_name";
        JsonElement expectedType = JsonSerializer.SerializeToElement("tool_reference");
        CacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };

        Assert.Equal(expectedToolName, deserialized.ToolName);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedCacheControl, deserialized.CacheControl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ToolReferenceBlockParam
        {
            ToolName = "tool_name",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ToolReferenceBlockParam { ToolName = "tool_name" };

        Assert.Null(model.CacheControl);
        Assert.False(model.RawData.ContainsKey("cache_control"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ToolReferenceBlockParam { ToolName = "tool_name" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ToolReferenceBlockParam
        {
            ToolName = "tool_name",

            CacheControl = null,
        };

        Assert.Null(model.CacheControl);
        Assert.True(model.RawData.ContainsKey("cache_control"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ToolReferenceBlockParam
        {
            ToolName = "tool_name",

            CacheControl = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ToolReferenceBlockParam
        {
            ToolName = "tool_name",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };

        ToolReferenceBlockParam copied = new(model);

        Assert.Equal(model, copied);
    }
}
