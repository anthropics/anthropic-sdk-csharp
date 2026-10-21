using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaMemoryTool20250818CommandTest : TestBase
{
    [Fact]
    public void Tool20250818ViewValidationWorks()
    {
        BetaMemoryTool20250818Command value = new BetaMemoryTool20250818ViewCommand()
        {
            Path = "/memories",
            ViewRange = [1, 10],
        };
        value.Validate();
    }

    [Fact]
    public void Tool20250818CreateValidationWorks()
    {
        BetaMemoryTool20250818Command value = new BetaMemoryTool20250818CreateCommand()
        {
            FileText = "Meeting notes:\n- Discussed project timeline\n- Next steps defined\n",
            Path = "/memories/notes.txt",
        };
        value.Validate();
    }

    [Fact]
    public void Tool20250818StrReplaceValidationWorks()
    {
        BetaMemoryTool20250818Command value = new BetaMemoryTool20250818StrReplaceCommand()
        {
            NewStr = "Favorite color: green",
            OldStr = "Favorite color: blue",
            Path = "/memories/preferences.txt",
        };
        value.Validate();
    }

    [Fact]
    public void Tool20250818InsertValidationWorks()
    {
        BetaMemoryTool20250818Command value = new BetaMemoryTool20250818InsertCommand()
        {
            InsertLine = 2,
            InsertText = "- Review memory tool documentation\n",
            Path = "/memories/todo.txt",
        };
        value.Validate();
    }

    [Fact]
    public void Tool20250818DeleteValidationWorks()
    {
        BetaMemoryTool20250818Command value = new BetaMemoryTool20250818DeleteCommand(
            "/memories/old_file.txt"
        );
        value.Validate();
    }

    [Fact]
    public void Tool20250818RenameValidationWorks()
    {
        BetaMemoryTool20250818Command value = new BetaMemoryTool20250818RenameCommand()
        {
            NewPath = "/memories/final.txt",
            OldPath = "/memories/draft.txt",
        };
        value.Validate();
    }

    [Fact]
    public void Tool20250818ViewSerializationRoundtripWorks()
    {
        BetaMemoryTool20250818Command value = new BetaMemoryTool20250818ViewCommand()
        {
            Path = "/memories",
            ViewRange = [1, 10],
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaMemoryTool20250818Command>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void Tool20250818CreateSerializationRoundtripWorks()
    {
        BetaMemoryTool20250818Command value = new BetaMemoryTool20250818CreateCommand()
        {
            FileText = "Meeting notes:\n- Discussed project timeline\n- Next steps defined\n",
            Path = "/memories/notes.txt",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaMemoryTool20250818Command>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void Tool20250818StrReplaceSerializationRoundtripWorks()
    {
        BetaMemoryTool20250818Command value = new BetaMemoryTool20250818StrReplaceCommand()
        {
            NewStr = "Favorite color: green",
            OldStr = "Favorite color: blue",
            Path = "/memories/preferences.txt",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaMemoryTool20250818Command>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void Tool20250818InsertSerializationRoundtripWorks()
    {
        BetaMemoryTool20250818Command value = new BetaMemoryTool20250818InsertCommand()
        {
            InsertLine = 2,
            InsertText = "- Review memory tool documentation\n",
            Path = "/memories/todo.txt",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaMemoryTool20250818Command>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void Tool20250818DeleteSerializationRoundtripWorks()
    {
        BetaMemoryTool20250818Command value = new BetaMemoryTool20250818DeleteCommand(
            "/memories/old_file.txt"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaMemoryTool20250818Command>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void Tool20250818RenameSerializationRoundtripWorks()
    {
        BetaMemoryTool20250818Command value = new BetaMemoryTool20250818RenameCommand()
        {
            NewPath = "/memories/final.txt",
            OldPath = "/memories/draft.txt",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaMemoryTool20250818Command>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void Tool20250818ViewCommandWorks()
    {
        BetaMemoryTool20250818Command value = new BetaMemoryTool20250818ViewCommand()
        {
            Path = "/memories",
            ViewRange = [1, 10],
        };
        Assert.Equal(BetaMemoryTool20250818CommandCommand.View, value.Command.Value());
    }

    [Fact]
    public void Tool20250818CreateCommandWorks()
    {
        BetaMemoryTool20250818Command value = new BetaMemoryTool20250818CreateCommand()
        {
            FileText = "Meeting notes:\n- Discussed project timeline\n- Next steps defined\n",
            Path = "/memories/notes.txt",
        };
        Assert.Equal(BetaMemoryTool20250818CommandCommand.Create, value.Command.Value());
    }

    [Fact]
    public void Tool20250818StrReplaceCommandWorks()
    {
        BetaMemoryTool20250818Command value = new BetaMemoryTool20250818StrReplaceCommand()
        {
            NewStr = "Favorite color: green",
            OldStr = "Favorite color: blue",
            Path = "/memories/preferences.txt",
        };
        Assert.Equal(BetaMemoryTool20250818CommandCommand.StrReplace, value.Command.Value());
    }

    [Fact]
    public void Tool20250818InsertCommandWorks()
    {
        BetaMemoryTool20250818Command value = new BetaMemoryTool20250818InsertCommand()
        {
            InsertLine = 2,
            InsertText = "- Review memory tool documentation\n",
            Path = "/memories/todo.txt",
        };
        Assert.Equal(BetaMemoryTool20250818CommandCommand.Insert, value.Command.Value());
    }

    [Fact]
    public void Tool20250818DeleteCommandWorks()
    {
        BetaMemoryTool20250818Command value = new BetaMemoryTool20250818DeleteCommand(
            "/memories/old_file.txt"
        );
        Assert.Equal(BetaMemoryTool20250818CommandCommand.Delete, value.Command.Value());
    }

    [Fact]
    public void Tool20250818RenameCommandWorks()
    {
        BetaMemoryTool20250818Command value = new BetaMemoryTool20250818RenameCommand()
        {
            NewPath = "/memories/final.txt",
            OldPath = "/memories/draft.txt",
        };
        Assert.Equal(BetaMemoryTool20250818CommandCommand.Rename, value.Command.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaMemoryTool20250818Command value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "command": "view",
                  "path": "/memories"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaMemoryTool20250818CommandCommand> expectedCommand =
            BetaMemoryTool20250818CommandCommand.View;
        string expectedPath = "/memories";

        Assert.Equal(expectedCommand, value.Command);
        Assert.Equal(expectedPath, value.Path);

        BetaMemoryTool20250818Command emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Command);
        Assert.Null(emptyValue.Path);

        BetaMemoryTool20250818Command mismatchedValue = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "path": [
                    "invalid"
                  ]
                }
                """
            )
        );

        Assert.Null(mismatchedValue.Path);
    }
}

public class BetaMemoryTool20250818CommandCommandTest : TestBase
{
    [Theory]
    [InlineData(BetaMemoryTool20250818CommandCommand.View)]
    [InlineData(BetaMemoryTool20250818CommandCommand.Create)]
    [InlineData(BetaMemoryTool20250818CommandCommand.StrReplace)]
    [InlineData(BetaMemoryTool20250818CommandCommand.Insert)]
    [InlineData(BetaMemoryTool20250818CommandCommand.Delete)]
    [InlineData(BetaMemoryTool20250818CommandCommand.Rename)]
    public void Validation_Works(BetaMemoryTool20250818CommandCommand rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaMemoryTool20250818CommandCommand> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaMemoryTool20250818CommandCommand>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaMemoryTool20250818CommandCommand.View)]
    [InlineData(BetaMemoryTool20250818CommandCommand.Create)]
    [InlineData(BetaMemoryTool20250818CommandCommand.StrReplace)]
    [InlineData(BetaMemoryTool20250818CommandCommand.Insert)]
    [InlineData(BetaMemoryTool20250818CommandCommand.Delete)]
    [InlineData(BetaMemoryTool20250818CommandCommand.Rename)]
    public void SerializationRoundtrip_Works(BetaMemoryTool20250818CommandCommand rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaMemoryTool20250818CommandCommand> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaMemoryTool20250818CommandCommand>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaMemoryTool20250818CommandCommand>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaMemoryTool20250818CommandCommand>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
