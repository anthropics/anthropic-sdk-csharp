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

public class ToolResultBlockParamContentTest : TestBase
{
    [Fact]
    public void stringValidation_Works()
    {
        ToolResultBlockParamContent value = new("string");
        value.Validate();
    }

    [Fact]
    public void BlocksValidation_Works()
    {
        ToolResultBlockParamContent value = new(
            [
                new TextBlockParam()
                {
                    Text = "x",
                    CacheControl = new() { TTL = TTL.TTL5m },
                    Citations =
                    [
                        new CitationCharLocationParam()
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
    public void stringSerializationRoundtrip_Works()
    {
        ToolResultBlockParamContent value = new("string");
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ToolResultBlockParamContent>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BlocksSerializationRoundtrip_Works()
    {
        ToolResultBlockParamContent value = new(
            [
                new TextBlockParam()
                {
                    Text = "x",
                    CacheControl = new() { TTL = TTL.TTL5m },
                    Citations =
                    [
                        new CitationCharLocationParam()
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
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<ToolResultBlockParamContent>(json);

        Assert.Equal(value, deserialized);
    }
}

public class BlockTest : TestBase
{
    [Fact]
    public void text_block_paramValidation_Works()
    {
        Block value = new(
            new TextBlockParam()
            {
                Text = "x",
                CacheControl = new() { TTL = TTL.TTL5m },
                Citations =
                [
                    new CitationCharLocationParam()
                    {
                        CitedText = "cited_text",
                        DocumentIndex = 0,
                        DocumentTitle = "x",
                        EndCharIndex = 0,
                        StartCharIndex = 0,
                    },
                ],
            }
        );
        value.Validate();
    }

    [Fact]
    public void image_block_paramValidation_Works()
    {
        Block value = new(
            new ImageBlockParam()
            {
                Source = new Base64ImageSource()
                {
                    Data = "U3RhaW5sZXNzIHJvY2tz",
                    MediaType = MediaType.ImageJPEG,
                },
                CacheControl = new() { TTL = TTL.TTL5m },
            }
        );
        value.Validate();
    }

    [Fact]
    public void search_result_block_paramValidation_Works()
    {
        Block value = new(
            new SearchResultBlockParam()
            {
                Content =
                [
                    new()
                    {
                        Text = "x",
                        CacheControl = new() { TTL = TTL.TTL5m },
                        Citations =
                        [
                            new CitationCharLocationParam()
                            {
                                CitedText = "cited_text",
                                DocumentIndex = 0,
                                DocumentTitle = "x",
                                EndCharIndex = 0,
                                StartCharIndex = 0,
                            },
                        ],
                    },
                ],
                Source = "source",
                Title = "title",
                CacheControl = new() { TTL = TTL.TTL5m },
                Citations = new() { Enabled = true },
            }
        );
        value.Validate();
    }

    [Fact]
    public void document_block_paramValidation_Works()
    {
        Block value = new(
            new DocumentBlockParam()
            {
                Source = new Base64PDFSource("U3RhaW5sZXNzIHJvY2tz"),
                CacheControl = new() { TTL = TTL.TTL5m },
                Citations = new() { Enabled = true },
                Context = "x",
                Title = "x",
            }
        );
        value.Validate();
    }

    [Fact]
    public void text_block_paramSerializationRoundtrip_Works()
    {
        Block value = new(
            new TextBlockParam()
            {
                Text = "x",
                CacheControl = new() { TTL = TTL.TTL5m },
                Citations =
                [
                    new CitationCharLocationParam()
                    {
                        CitedText = "cited_text",
                        DocumentIndex = 0,
                        DocumentTitle = "x",
                        EndCharIndex = 0,
                        StartCharIndex = 0,
                    },
                ],
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Block>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void image_block_paramSerializationRoundtrip_Works()
    {
        Block value = new(
            new ImageBlockParam()
            {
                Source = new Base64ImageSource()
                {
                    Data = "U3RhaW5sZXNzIHJvY2tz",
                    MediaType = MediaType.ImageJPEG,
                },
                CacheControl = new() { TTL = TTL.TTL5m },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Block>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void search_result_block_paramSerializationRoundtrip_Works()
    {
        Block value = new(
            new SearchResultBlockParam()
            {
                Content =
                [
                    new()
                    {
                        Text = "x",
                        CacheControl = new() { TTL = TTL.TTL5m },
                        Citations =
                        [
                            new CitationCharLocationParam()
                            {
                                CitedText = "cited_text",
                                DocumentIndex = 0,
                                DocumentTitle = "x",
                                EndCharIndex = 0,
                                StartCharIndex = 0,
                            },
                        ],
                    },
                ],
                Source = "source",
                Title = "title",
                CacheControl = new() { TTL = TTL.TTL5m },
                Citations = new() { Enabled = true },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Block>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void document_block_paramSerializationRoundtrip_Works()
    {
        Block value = new(
            new DocumentBlockParam()
            {
                Source = new Base64PDFSource("U3RhaW5sZXNzIHJvY2tz"),
                CacheControl = new() { TTL = TTL.TTL5m },
                Citations = new() { Enabled = true },
                Context = "x",
                Title = "x",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Block>(json);

        Assert.Equal(value, deserialized);
    }
}
