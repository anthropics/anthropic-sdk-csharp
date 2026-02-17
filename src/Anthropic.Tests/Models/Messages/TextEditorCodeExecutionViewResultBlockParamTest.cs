using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class TextEditorCodeExecutionViewResultBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TextEditorCodeExecutionViewResultBlockParam
        {
            Content = "content",
            FileType = TextEditorCodeExecutionViewResultBlockParamFileType.Text,
            NumLines = 0,
            StartLine = 0,
            TotalLines = 0,
        };

        string expectedContent = "content";
        ApiEnum<string, TextEditorCodeExecutionViewResultBlockParamFileType> expectedFileType =
            TextEditorCodeExecutionViewResultBlockParamFileType.Text;
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "text_editor_code_execution_view_result"
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
        var model = new TextEditorCodeExecutionViewResultBlockParam
        {
            Content = "content",
            FileType = TextEditorCodeExecutionViewResultBlockParamFileType.Text,
            NumLines = 0,
            StartLine = 0,
            TotalLines = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TextEditorCodeExecutionViewResultBlockParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TextEditorCodeExecutionViewResultBlockParam
        {
            Content = "content",
            FileType = TextEditorCodeExecutionViewResultBlockParamFileType.Text,
            NumLines = 0,
            StartLine = 0,
            TotalLines = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TextEditorCodeExecutionViewResultBlockParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedContent = "content";
        ApiEnum<string, TextEditorCodeExecutionViewResultBlockParamFileType> expectedFileType =
            TextEditorCodeExecutionViewResultBlockParamFileType.Text;
        JsonElement expectedType = JsonSerializer.SerializeToElement(
            "text_editor_code_execution_view_result"
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
        var model = new TextEditorCodeExecutionViewResultBlockParam
        {
            Content = "content",
            FileType = TextEditorCodeExecutionViewResultBlockParamFileType.Text,
            NumLines = 0,
            StartLine = 0,
            TotalLines = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TextEditorCodeExecutionViewResultBlockParam
        {
            Content = "content",
            FileType = TextEditorCodeExecutionViewResultBlockParamFileType.Text,
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
        var model = new TextEditorCodeExecutionViewResultBlockParam
        {
            Content = "content",
            FileType = TextEditorCodeExecutionViewResultBlockParamFileType.Text,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new TextEditorCodeExecutionViewResultBlockParam
        {
            Content = "content",
            FileType = TextEditorCodeExecutionViewResultBlockParamFileType.Text,

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
        var model = new TextEditorCodeExecutionViewResultBlockParam
        {
            Content = "content",
            FileType = TextEditorCodeExecutionViewResultBlockParamFileType.Text,

            NumLines = null,
            StartLine = null,
            TotalLines = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TextEditorCodeExecutionViewResultBlockParam
        {
            Content = "content",
            FileType = TextEditorCodeExecutionViewResultBlockParamFileType.Text,
            NumLines = 0,
            StartLine = 0,
            TotalLines = 0,
        };

        TextEditorCodeExecutionViewResultBlockParam copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TextEditorCodeExecutionViewResultBlockParamFileTypeTest : TestBase
{
    [Theory]
    [InlineData(TextEditorCodeExecutionViewResultBlockParamFileType.Text)]
    [InlineData(TextEditorCodeExecutionViewResultBlockParamFileType.Image)]
    [InlineData(TextEditorCodeExecutionViewResultBlockParamFileType.Pdf)]
    public void Validation_Works(TextEditorCodeExecutionViewResultBlockParamFileType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TextEditorCodeExecutionViewResultBlockParamFileType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, TextEditorCodeExecutionViewResultBlockParamFileType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TextEditorCodeExecutionViewResultBlockParamFileType.Text)]
    [InlineData(TextEditorCodeExecutionViewResultBlockParamFileType.Image)]
    [InlineData(TextEditorCodeExecutionViewResultBlockParamFileType.Pdf)]
    public void SerializationRoundtrip_Works(
        TextEditorCodeExecutionViewResultBlockParamFileType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TextEditorCodeExecutionViewResultBlockParamFileType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, TextEditorCodeExecutionViewResultBlockParamFileType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, TextEditorCodeExecutionViewResultBlockParamFileType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, TextEditorCodeExecutionViewResultBlockParamFileType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
