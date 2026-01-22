using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaMemoryTool20250818InsertCommandTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaMemoryTool20250818InsertCommand
        {
            InsertLine = 2,
            InsertText = "- Review memory tool documentation\n",
            Path = "/memories/todo.txt",
        };

        JsonElement expectedCommand = JsonSerializer.SerializeToElement("insert");
        long expectedInsertLine = 2;
        string expectedInsertText = "- Review memory tool documentation\n";
        string expectedPath = "/memories/todo.txt";

        Assert.True(JsonElement.DeepEquals(expectedCommand, model.Command));
        Assert.Equal(expectedInsertLine, model.InsertLine);
        Assert.Equal(expectedInsertText, model.InsertText);
        Assert.Equal(expectedPath, model.Path);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaMemoryTool20250818InsertCommand
        {
            InsertLine = 2,
            InsertText = "- Review memory tool documentation\n",
            Path = "/memories/todo.txt",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaMemoryTool20250818InsertCommand>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaMemoryTool20250818InsertCommand
        {
            InsertLine = 2,
            InsertText = "- Review memory tool documentation\n",
            Path = "/memories/todo.txt",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaMemoryTool20250818InsertCommand>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedCommand = JsonSerializer.SerializeToElement("insert");
        long expectedInsertLine = 2;
        string expectedInsertText = "- Review memory tool documentation\n";
        string expectedPath = "/memories/todo.txt";

        Assert.True(JsonElement.DeepEquals(expectedCommand, deserialized.Command));
        Assert.Equal(expectedInsertLine, deserialized.InsertLine);
        Assert.Equal(expectedInsertText, deserialized.InsertText);
        Assert.Equal(expectedPath, deserialized.Path);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaMemoryTool20250818InsertCommand
        {
            InsertLine = 2,
            InsertText = "- Review memory tool documentation\n",
            Path = "/memories/todo.txt",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaMemoryTool20250818InsertCommand
        {
            InsertLine = 2,
            InsertText = "- Review memory tool documentation\n",
            Path = "/memories/todo.txt",
        };

        BetaMemoryTool20250818InsertCommand copied = new(model);

        Assert.Equal(model, copied);
    }
}
