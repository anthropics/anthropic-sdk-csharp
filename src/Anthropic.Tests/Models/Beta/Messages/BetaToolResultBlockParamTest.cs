using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaToolResultBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaToolResultBlockParam
        {
            ToolUseID = "tool_use_id",
            CacheControl = new() { TTL = TTL.TTL5m },
            Content = "string",
            IsError = true,
        };

        string expectedToolUseID = "tool_use_id";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"tool_result\"");
        BetaCacheControlEphemeral expectedCacheControl = new() { TTL = TTL.TTL5m };
        BetaToolResultBlockParamContent expectedContent = "string";
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
        var model = new BetaToolResultBlockParam
        {
            ToolUseID = "tool_use_id",
            CacheControl = new() { TTL = TTL.TTL5m },
            Content = "string",
            IsError = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaToolResultBlockParam>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaToolResultBlockParam
        {
            ToolUseID = "tool_use_id",
            CacheControl = new() { TTL = TTL.TTL5m },
            Content = "string",
            IsError = true,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaToolResultBlockParam>(json);
        Assert.NotNull(deserialized);

        string expectedToolUseID = "tool_use_id";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"tool_result\"");
        BetaCacheControlEphemeral expectedCacheControl = new() { TTL = TTL.TTL5m };
        BetaToolResultBlockParamContent expectedContent = "string";
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
        var model = new BetaToolResultBlockParam
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
        var model = new BetaToolResultBlockParam
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
        var model = new BetaToolResultBlockParam
        {
            ToolUseID = "tool_use_id",
            CacheControl = new() { TTL = TTL.TTL5m },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaToolResultBlockParam
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
        var model = new BetaToolResultBlockParam
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
        var model = new BetaToolResultBlockParam
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
        var model = new BetaToolResultBlockParam
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
        var model = new BetaToolResultBlockParam
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
        var model = new BetaToolResultBlockParam
        {
            ToolUseID = "tool_use_id",
            Content = "string",
            IsError = true,

            CacheControl = null,
        };

        model.Validate();
    }
}

public class BetaToolResultBlockParamContentTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        BetaToolResultBlockParamContent value = new("string");
        value.Validate();
    }

    [Fact]
    public void BlocksValidationWorks()
    {
        BetaToolResultBlockParamContent value = new(
            [
                new Block(
                    new BetaTextBlockParam()
                    {
                        Text = "x",
                        CacheControl = new() { TTL = TTL.TTL5m },
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
        BetaToolResultBlockParamContent value = new("string");
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaToolResultBlockParamContent>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BlocksSerializationRoundtripWorks()
    {
        BetaToolResultBlockParamContent value = new(
            [
                new Block(
                    new BetaTextBlockParam()
                    {
                        Text = "x",
                        CacheControl = new() { TTL = TTL.TTL5m },
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
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaToolResultBlockParamContent>(json);

        Assert.Equal(value, deserialized);
    }
}

public class BlockTest : TestBase
{
    [Fact]
    public void BetaTextBlockParamValidationWorks()
    {
        Block value = new(
            new BetaTextBlockParam()
            {
                Text = "x",
                CacheControl = new() { TTL = TTL.TTL5m },
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
        );
        value.Validate();
    }

    [Fact]
    public void BetaImageBlockParamValidationWorks()
    {
        Block value = new(
            new BetaImageBlockParam()
            {
                Source = new BetaBase64ImageSource()
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
    public void BetaSearchResultBlockParamValidationWorks()
    {
        Block value = new(
            new BetaSearchResultBlockParam()
            {
                Content =
                [
                    new()
                    {
                        Text = "x",
                        CacheControl = new() { TTL = TTL.TTL5m },
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
    public void BetaRequestDocumentValidationWorks()
    {
        Block value = new(
            new BetaRequestDocumentBlock()
            {
                Source = new BetaBase64PDFSource("U3RhaW5sZXNzIHJvY2tz"),
                CacheControl = new() { TTL = TTL.TTL5m },
                Citations = new() { Enabled = true },
                Context = "x",
                Title = "x",
            }
        );
        value.Validate();
    }

    [Fact]
    public void BetaToolReferenceBlockParamValidationWorks()
    {
        Block value = new(
            new BetaToolReferenceBlockParam()
            {
                ToolName = "tool_name",
                CacheControl = new() { TTL = TTL.TTL5m },
            }
        );
        value.Validate();
    }

    [Fact]
    public void BetaTextBlockParamSerializationRoundtripWorks()
    {
        Block value = new(
            new BetaTextBlockParam()
            {
                Text = "x",
                CacheControl = new() { TTL = TTL.TTL5m },
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
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Block>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaImageBlockParamSerializationRoundtripWorks()
    {
        Block value = new(
            new BetaImageBlockParam()
            {
                Source = new BetaBase64ImageSource()
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
    public void BetaSearchResultBlockParamSerializationRoundtripWorks()
    {
        Block value = new(
            new BetaSearchResultBlockParam()
            {
                Content =
                [
                    new()
                    {
                        Text = "x",
                        CacheControl = new() { TTL = TTL.TTL5m },
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
    public void BetaRequestDocumentSerializationRoundtripWorks()
    {
        Block value = new(
            new BetaRequestDocumentBlock()
            {
                Source = new BetaBase64PDFSource("U3RhaW5sZXNzIHJvY2tz"),
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

    [Fact]
    public void BetaToolReferenceBlockParamSerializationRoundtripWorks()
    {
        Block value = new(
            new BetaToolReferenceBlockParam()
            {
                ToolName = "tool_name",
                CacheControl = new() { TTL = TTL.TTL5m },
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Block>(json);

        Assert.Equal(value, deserialized);
    }
}
