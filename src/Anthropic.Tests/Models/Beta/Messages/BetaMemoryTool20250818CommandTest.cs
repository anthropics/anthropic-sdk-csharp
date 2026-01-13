using System.Text.Json;
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
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaMemoryTool20250818Command>(element);

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
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaMemoryTool20250818Command>(element);

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
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaMemoryTool20250818Command>(element);

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
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaMemoryTool20250818Command>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void Tool20250818DeleteSerializationRoundtripWorks()
    {
        BetaMemoryTool20250818Command value = new BetaMemoryTool20250818DeleteCommand(
            "/memories/old_file.txt"
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaMemoryTool20250818Command>(element);

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
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaMemoryTool20250818Command>(element);

        Assert.Equal(value, deserialized);
    }
}
