using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaTextEditorCodeExecutionViewResultBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaTextEditorCodeExecutionViewResultBlock
        {
            Content = "content",
            FileType = FileType.Text,
            NumLines = 0,
            StartLine = 0,
            TotalLines = 0,
        };

        string expectedContent = "content";
        ApiEnum<string, FileType> expectedFileType = FileType.Text;
        long expectedNumLines = 0;
        long expectedStartLine = 0;
        long expectedTotalLines = 0;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"text_editor_code_execution_view_result\""
        );

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedFileType, model.FileType);
        Assert.Equal(expectedNumLines, model.NumLines);
        Assert.Equal(expectedStartLine, model.StartLine);
        Assert.Equal(expectedTotalLines, model.TotalLines);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaTextEditorCodeExecutionViewResultBlock
        {
            Content = "content",
            FileType = FileType.Text,
            NumLines = 0,
            StartLine = 0,
            TotalLines = 0,
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaTextEditorCodeExecutionViewResultBlock>(
            json
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaTextEditorCodeExecutionViewResultBlock
        {
            Content = "content",
            FileType = FileType.Text,
            NumLines = 0,
            StartLine = 0,
            TotalLines = 0,
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaTextEditorCodeExecutionViewResultBlock>(
            element
        );
        Assert.NotNull(deserialized);

        string expectedContent = "content";
        ApiEnum<string, FileType> expectedFileType = FileType.Text;
        long expectedNumLines = 0;
        long expectedStartLine = 0;
        long expectedTotalLines = 0;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"text_editor_code_execution_view_result\""
        );

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedFileType, deserialized.FileType);
        Assert.Equal(expectedNumLines, deserialized.NumLines);
        Assert.Equal(expectedStartLine, deserialized.StartLine);
        Assert.Equal(expectedTotalLines, deserialized.TotalLines);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaTextEditorCodeExecutionViewResultBlock
        {
            Content = "content",
            FileType = FileType.Text,
            NumLines = 0,
            StartLine = 0,
            TotalLines = 0,
        };

        model.Validate();
    }
}

public class FileTypeTest : TestBase
{
    [Theory]
    [InlineData(FileType.Text)]
    [InlineData(FileType.Image)]
    [InlineData(FileType.PDF)]
    public void Validation_Works(FileType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FileType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FileType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(FileType.Text)]
    [InlineData(FileType.Image)]
    [InlineData(FileType.PDF)]
    public void SerializationRoundtrip_Works(FileType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, FileType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FileType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, FileType>>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\""),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, FileType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
