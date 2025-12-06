using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ToolResultBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ToolResultBlockParam
        {
            ToolUseID = "tool_use_id",
            CacheControl = new() { TTL = TTL.TTL5m },
            Content = "string",
            IsError = true,
        };

        string expectedToolUseID = "tool_use_id";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"tool_result\"");
        CacheControlEphemeral expectedCacheControl = new() { TTL = TTL.TTL5m };
        ToolResultBlockParamContent expectedContent = "string";
        bool expectedIsError = true;

        Assert.Equal(expectedToolUseID, model.ToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedCacheControl, model.CacheControl);
        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedIsError, model.IsError);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ToolResultBlockParam
        {
            ToolUseID = "tool_use_id",
            CacheControl = new() { TTL = TTL.TTL5m },
            Content = "string",
            IsError = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ToolResultBlockParam>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ToolResultBlockParam
        {
            ToolUseID = "tool_use_id",
            CacheControl = new() { TTL = TTL.TTL5m },
            Content = "string",
            IsError = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<ToolResultBlockParam>(json);
        Assert.NotNull(deserialized);

        string expectedToolUseID = "tool_use_id";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"tool_result\"");
        CacheControlEphemeral expectedCacheControl = new() { TTL = TTL.TTL5m };
        ToolResultBlockParamContent expectedContent = "string";
        bool expectedIsError = true;

        Assert.Equal(expectedToolUseID, deserialized.ToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedCacheControl, deserialized.CacheControl);
        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedIsError, deserialized.IsError);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ToolResultBlockParam
        {
            ToolUseID = "tool_use_id",
            CacheControl = new() { TTL = TTL.TTL5m },
            Content = "string",
            IsError = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ToolResultBlockParam
        {
            ToolUseID = "tool_use_id",
            CacheControl = new() { TTL = TTL.TTL5m },
        };

        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
        Assert.Null(model.IsError);
        Assert.False(model.RawData.ContainsKey("is_error"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ToolResultBlockParam
        {
            ToolUseID = "tool_use_id",
            CacheControl = new() { TTL = TTL.TTL5m },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ToolResultBlockParam
        {
            ToolUseID = "tool_use_id",
            CacheControl = new() { TTL = TTL.TTL5m },

            // Null should be interpreted as omitted for these properties
            Content = null,
            IsError = null,
        };

        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
        Assert.Null(model.IsError);
        Assert.False(model.RawData.ContainsKey("is_error"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ToolResultBlockParam
        {
            ToolUseID = "tool_use_id",
            CacheControl = new() { TTL = TTL.TTL5m },

            // Null should be interpreted as omitted for these properties
            Content = null,
            IsError = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ToolResultBlockParam
        {
            ToolUseID = "tool_use_id",
            Content = "string",
            IsError = true,
        };

        Assert.Null(model.CacheControl);
        Assert.False(model.RawData.ContainsKey("cache_control"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ToolResultBlockParam
        {
            ToolUseID = "tool_use_id",
            Content = "string",
            IsError = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ToolResultBlockParam
        {
            ToolUseID = "tool_use_id",
            Content = "string",
            IsError = true,

            CacheControl = null,
        };

        Assert.Null(model.CacheControl);
        Assert.True(model.RawData.ContainsKey("cache_control"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ToolResultBlockParam
        {
            ToolUseID = "tool_use_id",
            Content = "string",
            IsError = true,

            CacheControl = null,
        };

        model.Validate();
    }
}
