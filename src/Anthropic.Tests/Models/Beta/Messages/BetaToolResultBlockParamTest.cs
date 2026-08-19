using System.Text.Json;
using Anthropic.Core;
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
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Content = "string",
            IsError = true,
            ToolsetName = "toolset_name",
        };

        string expectedToolUseID = "tool_use_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("tool_result");
        BetaCacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        BetaToolResultBlockParamContent expectedContent = "string";
        bool expectedIsError = true;
        string expectedToolsetName = "toolset_name";

        Assert.Equal(expectedToolUseID, model.ToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedCacheControl, model.CacheControl);
        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedIsError, model.IsError);
        Assert.Equal(expectedToolsetName, model.ToolsetName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaToolResultBlockParam
        {
            ToolUseID = "tool_use_id",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Content = "string",
            IsError = true,
            ToolsetName = "toolset_name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaToolResultBlockParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaToolResultBlockParam
        {
            ToolUseID = "tool_use_id",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Content = "string",
            IsError = true,
            ToolsetName = "toolset_name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaToolResultBlockParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedToolUseID = "tool_use_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("tool_result");
        BetaCacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        BetaToolResultBlockParamContent expectedContent = "string";
        bool expectedIsError = true;
        string expectedToolsetName = "toolset_name";

        Assert.Equal(expectedToolUseID, deserialized.ToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedCacheControl, deserialized.CacheControl);
        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedIsError, deserialized.IsError);
        Assert.Equal(expectedToolsetName, deserialized.ToolsetName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaToolResultBlockParam
        {
            ToolUseID = "tool_use_id",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Content = "string",
            IsError = true,
            ToolsetName = "toolset_name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaToolResultBlockParam
        {
            ToolUseID = "tool_use_id",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            ToolsetName = "toolset_name",
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
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            ToolsetName = "toolset_name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaToolResultBlockParam
        {
            ToolUseID = "tool_use_id",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            ToolsetName = "toolset_name",

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
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            ToolsetName = "toolset_name",

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
        Assert.Null(model.ToolsetName);
        Assert.False(model.RawData.ContainsKey("toolset_name"));
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
            ToolsetName = null,
        };

        Assert.Null(model.CacheControl);
        Assert.True(model.RawData.ContainsKey("cache_control"));
        Assert.Null(model.ToolsetName);
        Assert.True(model.RawData.ContainsKey("toolset_name"));
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
            ToolsetName = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaToolResultBlockParam
        {
            ToolUseID = "tool_use_id",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Content = "string",
            IsError = true,
            ToolsetName = "toolset_name",
        };

        BetaToolResultBlockParam copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaToolResultBlockParamContentTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        BetaToolResultBlockParamContent value = "string";
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
                        CacheControl = new() { Ttl = Ttl.Ttl5m },
                        Citations =
                        [
                            new BetaCitationCharLocationParam()
                            {
                                CitedText = "The grass is green. The sky is blue.",
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
        BetaToolResultBlockParamContent value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaToolResultBlockParamContent>(
            element,
            ModelBase.SerializerOptions
        );

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
                        CacheControl = new() { Ttl = Ttl.Ttl5m },
                        Citations =
                        [
                            new BetaCitationCharLocationParam()
                            {
                                CitedText = "The grass is green. The sky is blue.",
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
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaToolResultBlockParamContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class BlockTest : TestBase
{
    [Fact]
    public void BetaTextBlockParamValidationWorks()
    {
        Block value = new BetaTextBlockParam()
        {
            Text = "x",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Citations =
            [
                new BetaCitationCharLocationParam()
                {
                    CitedText = "The grass is green. The sky is blue.",
                    DocumentIndex = 0,
                    DocumentTitle = "x",
                    EndCharIndex = 0,
                    StartCharIndex = 0,
                },
            ],
        };
        value.Validate();
    }

    [Fact]
    public void BetaImageBlockParamValidationWorks()
    {
        Block value = new BetaImageBlockParam()
        {
            Source = new BetaBase64ImageSource()
            {
                Data = "U3RhaW5sZXNzIHJvY2tz",
                MediaType = MediaType.ImageJpeg,
            },
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Transformations = new() { OversizedImage = OversizedImage.Downsize },
        };
        value.Validate();
    }

    [Fact]
    public void BetaSearchResultBlockParamValidationWorks()
    {
        Block value = new BetaSearchResultBlockParam()
        {
            Content =
            [
                new()
                {
                    Text = "x",
                    CacheControl = new() { Ttl = Ttl.Ttl5m },
                    Citations =
                    [
                        new BetaCitationCharLocationParam()
                        {
                            CitedText = "The grass is green. The sky is blue.",
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
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Citations = new() { Enabled = true },
        };
        value.Validate();
    }

    [Fact]
    public void BetaRequestDocumentValidationWorks()
    {
        Block value = new BetaRequestDocumentBlock()
        {
            Source = new BetaBase64PdfSource("U3RhaW5sZXNzIHJvY2tz"),
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Citations = new() { Enabled = true },
            Context = "x",
            Title = "x",
        };
        value.Validate();
    }

    [Fact]
    public void BetaToolReferenceBlockParamValidationWorks()
    {
        Block value = new BetaToolReferenceBlockParam()
        {
            ToolName = "tool_name",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };
        value.Validate();
    }

    [Fact]
    public void BetaBrowserStateBlockParamValidationWorks()
    {
        Block value = new BetaBrowserStateBlockParam()
        {
            Tabs =
            [
                new()
                {
                    TabID = "tab_id",
                    Title = "title",
                    Url = "url",
                    Active = true,
                },
            ],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            StateChanges = [new BetaBrowserStateChangeTabOpened("tab_id")],
        };
        value.Validate();
    }

    [Fact]
    public void BetaTextBlockParamSerializationRoundtripWorks()
    {
        Block value = new BetaTextBlockParam()
        {
            Text = "x",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Citations =
            [
                new BetaCitationCharLocationParam()
                {
                    CitedText = "The grass is green. The sky is blue.",
                    DocumentIndex = 0,
                    DocumentTitle = "x",
                    EndCharIndex = 0,
                    StartCharIndex = 0,
                },
            ],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Block>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaImageBlockParamSerializationRoundtripWorks()
    {
        Block value = new BetaImageBlockParam()
        {
            Source = new BetaBase64ImageSource()
            {
                Data = "U3RhaW5sZXNzIHJvY2tz",
                MediaType = MediaType.ImageJpeg,
            },
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Transformations = new() { OversizedImage = OversizedImage.Downsize },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Block>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaSearchResultBlockParamSerializationRoundtripWorks()
    {
        Block value = new BetaSearchResultBlockParam()
        {
            Content =
            [
                new()
                {
                    Text = "x",
                    CacheControl = new() { Ttl = Ttl.Ttl5m },
                    Citations =
                    [
                        new BetaCitationCharLocationParam()
                        {
                            CitedText = "The grass is green. The sky is blue.",
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
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Citations = new() { Enabled = true },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Block>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaRequestDocumentSerializationRoundtripWorks()
    {
        Block value = new BetaRequestDocumentBlock()
        {
            Source = new BetaBase64PdfSource("U3RhaW5sZXNzIHJvY2tz"),
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Citations = new() { Enabled = true },
            Context = "x",
            Title = "x",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Block>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaToolReferenceBlockParamSerializationRoundtripWorks()
    {
        Block value = new BetaToolReferenceBlockParam()
        {
            ToolName = "tool_name",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Block>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaBrowserStateBlockParamSerializationRoundtripWorks()
    {
        Block value = new BetaBrowserStateBlockParam()
        {
            Tabs =
            [
                new()
                {
                    TabID = "tab_id",
                    Title = "title",
                    Url = "url",
                    Active = true,
                },
            ],
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            StateChanges = [new BetaBrowserStateChangeTabOpened("tab_id")],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Block>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
