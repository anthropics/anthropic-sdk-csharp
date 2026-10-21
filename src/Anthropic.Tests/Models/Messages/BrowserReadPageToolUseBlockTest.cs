using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class BrowserReadPageToolUseBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BrowserReadPageToolUseBlock
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new()
            {
                Depth = 1,
                Filter = BrowserReadPageFilter.All,
                Ref = "ref",
                TabID = "tab_id",
            },
        };

        string expectedID = "id";
        ToolUseCaller expectedCaller = new DirectCaller();
        BrowserReadPageInput expectedInput = new()
        {
            Depth = 1,
            Filter = BrowserReadPageFilter.All,
            Ref = "ref",
            TabID = "tab_id",
        };
        JsonElement expectedName = JsonSerializer.SerializeToElement("read_page");
        JsonElement expectedToolsetName = JsonSerializer.SerializeToElement("browser");
        JsonElement expectedType = JsonSerializer.SerializeToElement("tool_use");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCaller, model.Caller);
        Assert.Equal(expectedInput, model.Input);
        Assert.True(JsonElement.DeepEquals(expectedName, model.Name));
        Assert.True(JsonElement.DeepEquals(expectedToolsetName, model.ToolsetName));
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BrowserReadPageToolUseBlock
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new()
            {
                Depth = 1,
                Filter = BrowserReadPageFilter.All,
                Ref = "ref",
                TabID = "tab_id",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserReadPageToolUseBlock>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BrowserReadPageToolUseBlock
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new()
            {
                Depth = 1,
                Filter = BrowserReadPageFilter.All,
                Ref = "ref",
                TabID = "tab_id",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserReadPageToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ToolUseCaller expectedCaller = new DirectCaller();
        BrowserReadPageInput expectedInput = new()
        {
            Depth = 1,
            Filter = BrowserReadPageFilter.All,
            Ref = "ref",
            TabID = "tab_id",
        };
        JsonElement expectedName = JsonSerializer.SerializeToElement("read_page");
        JsonElement expectedToolsetName = JsonSerializer.SerializeToElement("browser");
        JsonElement expectedType = JsonSerializer.SerializeToElement("tool_use");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCaller, deserialized.Caller);
        Assert.Equal(expectedInput, deserialized.Input);
        Assert.True(JsonElement.DeepEquals(expectedName, deserialized.Name));
        Assert.True(JsonElement.DeepEquals(expectedToolsetName, deserialized.ToolsetName));
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BrowserReadPageToolUseBlock
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new()
            {
                Depth = 1,
                Filter = BrowserReadPageFilter.All,
                Ref = "ref",
                TabID = "tab_id",
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BrowserReadPageToolUseBlock
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new()
            {
                Depth = 1,
                Filter = BrowserReadPageFilter.All,
                Ref = "ref",
                TabID = "tab_id",
            },
        };

        BrowserReadPageToolUseBlock copied = new(model);

        Assert.Equal(model, copied);
    }
}
