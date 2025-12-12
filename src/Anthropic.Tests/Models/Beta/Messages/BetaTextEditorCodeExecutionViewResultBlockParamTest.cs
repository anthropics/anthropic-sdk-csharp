using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaTextEditorCodeExecutionViewResultBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaTextEditorCodeExecutionViewResultBlockParam
        {
            Content = "content",
            FileType = BetaTextEditorCodeExecutionViewResultBlockParamFileType.Text,
            NumLines = 0,
            StartLine = 0,
            TotalLines = 0,
        };

        string expectedContent = "content";
        ApiEnum<string, BetaTextEditorCodeExecutionViewResultBlockParamFileType> expectedFileType =
            BetaTextEditorCodeExecutionViewResultBlockParamFileType.Text;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"text_editor_code_execution_view_result\""
        );
        long expectedNumLines = 0;
        long expectedStartLine = 0;
        long expectedTotalLines = 0;

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedFileType, model.FileType);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedNumLines, model.NumLines);
        Assert.Equal(expectedStartLine, model.StartLine);
        Assert.Equal(expectedTotalLines, model.TotalLines);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaTextEditorCodeExecutionViewResultBlockParam
        {
            Content = "content",
            FileType = BetaTextEditorCodeExecutionViewResultBlockParamFileType.Text,
            NumLines = 0,
            StartLine = 0,
            TotalLines = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<BetaTextEditorCodeExecutionViewResultBlockParam>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaTextEditorCodeExecutionViewResultBlockParam
        {
            Content = "content",
            FileType = BetaTextEditorCodeExecutionViewResultBlockParamFileType.Text,
            NumLines = 0,
            StartLine = 0,
            TotalLines = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized =
            JsonSerializer.Deserialize<BetaTextEditorCodeExecutionViewResultBlockParam>(json);
        Assert.NotNull(deserialized);

        string expectedContent = "content";
        ApiEnum<string, BetaTextEditorCodeExecutionViewResultBlockParamFileType> expectedFileType =
            BetaTextEditorCodeExecutionViewResultBlockParamFileType.Text;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"text_editor_code_execution_view_result\""
        );
        long expectedNumLines = 0;
        long expectedStartLine = 0;
        long expectedTotalLines = 0;

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedFileType, deserialized.FileType);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedNumLines, deserialized.NumLines);
        Assert.Equal(expectedStartLine, deserialized.StartLine);
        Assert.Equal(expectedTotalLines, deserialized.TotalLines);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaTextEditorCodeExecutionViewResultBlockParam
        {
            Content = "content",
            FileType = BetaTextEditorCodeExecutionViewResultBlockParamFileType.Text,
            NumLines = 0,
            StartLine = 0,
            TotalLines = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaTextEditorCodeExecutionViewResultBlockParam
        {
            Content = "content",
            FileType = BetaTextEditorCodeExecutionViewResultBlockParamFileType.Text,
        };

        Assert.Null(model.NumLines);
        Assert.False(model.RawData.ContainsKey("num_lines"));
        Assert.Null(model.StartLine);
        Assert.False(model.RawData.ContainsKey("start_line"));
        Assert.Null(model.TotalLines);
        Assert.False(model.RawData.ContainsKey("total_lines"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaTextEditorCodeExecutionViewResultBlockParam
        {
            Content = "content",
            FileType = BetaTextEditorCodeExecutionViewResultBlockParamFileType.Text,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaTextEditorCodeExecutionViewResultBlockParam
        {
            Content = "content",
            FileType = BetaTextEditorCodeExecutionViewResultBlockParamFileType.Text,

            NumLines = null,
            StartLine = null,
            TotalLines = null,
        };

        Assert.Null(model.NumLines);
        Assert.True(model.RawData.ContainsKey("num_lines"));
        Assert.Null(model.StartLine);
        Assert.True(model.RawData.ContainsKey("start_line"));
        Assert.Null(model.TotalLines);
        Assert.True(model.RawData.ContainsKey("total_lines"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaTextEditorCodeExecutionViewResultBlockParam
        {
            Content = "content",
            FileType = BetaTextEditorCodeExecutionViewResultBlockParamFileType.Text,

            NumLines = null,
            StartLine = null,
            TotalLines = null,
        };

        model.Validate();
    }
}

public class BetaTextEditorCodeExecutionViewResultBlockParamFileTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaTextEditorCodeExecutionViewResultBlockParamFileType.Text)]
    [InlineData(BetaTextEditorCodeExecutionViewResultBlockParamFileType.Image)]
    [InlineData(BetaTextEditorCodeExecutionViewResultBlockParamFileType.PDF)]
    public void Validation_Works(BetaTextEditorCodeExecutionViewResultBlockParamFileType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaTextEditorCodeExecutionViewResultBlockParamFileType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaTextEditorCodeExecutionViewResultBlockParamFileType>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaTextEditorCodeExecutionViewResultBlockParamFileType.Text)]
    [InlineData(BetaTextEditorCodeExecutionViewResultBlockParamFileType.Image)]
    [InlineData(BetaTextEditorCodeExecutionViewResultBlockParamFileType.PDF)]
    public void SerializationRoundtrip_Works(
        BetaTextEditorCodeExecutionViewResultBlockParamFileType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaTextEditorCodeExecutionViewResultBlockParamFileType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaTextEditorCodeExecutionViewResultBlockParamFileType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaTextEditorCodeExecutionViewResultBlockParamFileType>
        >(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaTextEditorCodeExecutionViewResultBlockParamFileType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
