using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ToolsetToolUseBlockTest : TestBase
{
    [Fact]
    public void BrowserValidationWorks()
    {
        ToolsetToolUseBlock value = new BrowserToolUseBlock(
            new BrowserNavigateToolUseBlock()
            {
                ID = "id",
                Caller = new DirectCaller(),
                Input = new() { Url = "url", TabID = "tab_id" },
            }
        );
        value.Validate();
    }

    [Fact]
    public void ComputerValidationWorks()
    {
        ToolsetToolUseBlock value = new ComputerToolUseBlock(
            new ComputerKeyToolUseBlock()
            {
                ID = "id",
                Caller = new DirectCaller(),
                Input = new() { Text = "text", Repeat = 1 },
            }
        );
        value.Validate();
    }

    [Fact]
    public void ToolUseBlockValidationWorks()
    {
        ToolsetToolUseBlock value = new ToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",
            ToolsetName = "toolset_name",
        };
        value.Validate();
    }

    [Fact]
    public void BrowserSerializationRoundtripWorks()
    {
        ToolsetToolUseBlock value = new BrowserToolUseBlock(
            new BrowserNavigateToolUseBlock()
            {
                ID = "id",
                Caller = new DirectCaller(),
                Input = new() { Url = "url", TabID = "tab_id" },
            }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolsetToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ComputerSerializationRoundtripWorks()
    {
        ToolsetToolUseBlock value = new ComputerToolUseBlock(
            new ComputerKeyToolUseBlock()
            {
                ID = "id",
                Caller = new DirectCaller(),
                Input = new() { Text = "text", Repeat = 1 },
            }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolsetToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ToolUseBlockSerializationRoundtripWorks()
    {
        ToolsetToolUseBlock value = new ToolUseBlock()
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",
            ToolsetName = "toolset_name",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolsetToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
