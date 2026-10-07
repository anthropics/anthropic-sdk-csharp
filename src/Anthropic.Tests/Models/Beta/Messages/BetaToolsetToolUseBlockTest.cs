using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaToolsetToolUseBlockTest : TestBase
{
    [Fact]
    public void BrowserValidationWorks()
    {
        BetaToolsetToolUseBlock value = new BetaBrowserToolUseBlock(
            new BetaBrowserNavigateToolUseBlock()
            {
                ID = "id",
                Input = new() { Url = "url", TabID = "tab_id" },
                Caller = new BetaDirectCaller(),
            }
        );
        value.Validate();
    }

    [Fact]
    public void ComputerValidationWorks()
    {
        BetaToolsetToolUseBlock value = new BetaComputerToolUseBlock(
            new BetaComputerKeyToolUseBlock()
            {
                ID = "id",
                Input = new() { Text = "text", Repeat = 1 },
                Caller = new BetaDirectCaller(),
            }
        );
        value.Validate();
    }

    [Fact]
    public void BetaToolUseBlockValidationWorks()
    {
        BetaToolsetToolUseBlock value = new BetaToolUseBlock()
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",
            Caller = new BetaDirectCaller(),
            ToolsetName = "toolset_name",
        };
        value.Validate();
    }

    [Fact]
    public void BrowserSerializationRoundtripWorks()
    {
        BetaToolsetToolUseBlock value = new BetaBrowserToolUseBlock(
            new BetaBrowserNavigateToolUseBlock()
            {
                ID = "id",
                Input = new() { Url = "url", TabID = "tab_id" },
                Caller = new BetaDirectCaller(),
            }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaToolsetToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ComputerSerializationRoundtripWorks()
    {
        BetaToolsetToolUseBlock value = new BetaComputerToolUseBlock(
            new BetaComputerKeyToolUseBlock()
            {
                ID = "id",
                Input = new() { Text = "text", Repeat = 1 },
                Caller = new BetaDirectCaller(),
            }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaToolsetToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaToolUseBlockSerializationRoundtripWorks()
    {
        BetaToolsetToolUseBlock value = new BetaToolUseBlock()
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",
            Caller = new BetaDirectCaller(),
            ToolsetName = "toolset_name",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaToolsetToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
