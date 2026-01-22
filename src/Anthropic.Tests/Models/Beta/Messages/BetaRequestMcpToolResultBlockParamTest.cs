using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaRequestMcpToolResultBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaRequestMcpToolResultBlockParam
        {
            ToolUseID = "tool_use_id",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Content = "string",
            IsError = true,
        };

        string expectedToolUseID = "tool_use_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("mcp_tool_result");
        BetaCacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        BetaRequestMcpToolResultBlockParamContent expectedContent = "string";
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
        var model = new BetaRequestMcpToolResultBlockParam
        {
            ToolUseID = "tool_use_id",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Content = "string",
            IsError = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRequestMcpToolResultBlockParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaRequestMcpToolResultBlockParam
        {
            ToolUseID = "tool_use_id",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Content = "string",
            IsError = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRequestMcpToolResultBlockParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedToolUseID = "tool_use_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("mcp_tool_result");
        BetaCacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        BetaRequestMcpToolResultBlockParamContent expectedContent = "string";
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
        var model = new BetaRequestMcpToolResultBlockParam
        {
            ToolUseID = "tool_use_id",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Content = "string",
            IsError = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaRequestMcpToolResultBlockParam
        {
            ToolUseID = "tool_use_id",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };

        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
        Assert.Null(model.IsError);
        Assert.False(model.RawData.ContainsKey("is_error"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaRequestMcpToolResultBlockParam
        {
            ToolUseID = "tool_use_id",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaRequestMcpToolResultBlockParam
        {
            ToolUseID = "tool_use_id",
            CacheControl = new() { Ttl = Ttl.Ttl5m },

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
        var model = new BetaRequestMcpToolResultBlockParam
        {
            ToolUseID = "tool_use_id",
            CacheControl = new() { Ttl = Ttl.Ttl5m },

            // Null should be interpreted as omitted for these properties
            Content = null,
            IsError = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaRequestMcpToolResultBlockParam
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
        var model = new BetaRequestMcpToolResultBlockParam
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
        var model = new BetaRequestMcpToolResultBlockParam
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
        var model = new BetaRequestMcpToolResultBlockParam
        {
            ToolUseID = "tool_use_id",
            Content = "string",
            IsError = true,

            CacheControl = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaRequestMcpToolResultBlockParam
        {
            ToolUseID = "tool_use_id",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Content = "string",
            IsError = true,
        };

        BetaRequestMcpToolResultBlockParam copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaRequestMcpToolResultBlockParamContentTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        BetaRequestMcpToolResultBlockParamContent value = "string";
        value.Validate();
    }

    [Fact]
    public void BetaMcpToolResultBlockParamValidationWorks()
    {
        BetaRequestMcpToolResultBlockParamContent value = new(
            [
                new BetaTextBlockParam()
                {
                    Text = "x",
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
                },
            ]
        );
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        BetaRequestMcpToolResultBlockParamContent value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRequestMcpToolResultBlockParamContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaMcpToolResultBlockParamSerializationRoundtripWorks()
    {
        BetaRequestMcpToolResultBlockParamContent value = new(
            [
                new BetaTextBlockParam()
                {
                    Text = "x",
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
                },
            ]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRequestMcpToolResultBlockParamContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
