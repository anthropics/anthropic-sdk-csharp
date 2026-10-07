using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ComputerScrollToolUseBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ComputerScrollToolUseBlock
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new()
            {
                ScrollAmount = 0,
                ScrollDirection = ComputerScrollDirection.Up,
                Coordinate = [0, 0],
                Text = "text",
            },
        };

        string expectedID = "id";
        ToolUseCaller expectedCaller = new DirectCaller();
        ComputerScrollInput expectedInput = new()
        {
            ScrollAmount = 0,
            ScrollDirection = ComputerScrollDirection.Up,
            Coordinate = [0, 0],
            Text = "text",
        };
        JsonElement expectedName = JsonSerializer.SerializeToElement("scroll");
        JsonElement expectedToolsetName = JsonSerializer.SerializeToElement("computer");
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
        var model = new ComputerScrollToolUseBlock
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new()
            {
                ScrollAmount = 0,
                ScrollDirection = ComputerScrollDirection.Up,
                Coordinate = [0, 0],
                Text = "text",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComputerScrollToolUseBlock>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ComputerScrollToolUseBlock
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new()
            {
                ScrollAmount = 0,
                ScrollDirection = ComputerScrollDirection.Up,
                Coordinate = [0, 0],
                Text = "text",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ComputerScrollToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ToolUseCaller expectedCaller = new DirectCaller();
        ComputerScrollInput expectedInput = new()
        {
            ScrollAmount = 0,
            ScrollDirection = ComputerScrollDirection.Up,
            Coordinate = [0, 0],
            Text = "text",
        };
        JsonElement expectedName = JsonSerializer.SerializeToElement("scroll");
        JsonElement expectedToolsetName = JsonSerializer.SerializeToElement("computer");
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
        var model = new ComputerScrollToolUseBlock
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new()
            {
                ScrollAmount = 0,
                ScrollDirection = ComputerScrollDirection.Up,
                Coordinate = [0, 0],
                Text = "text",
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ComputerScrollToolUseBlock
        {
            ID = "id",
            Caller = new DirectCaller(),
            Input = new()
            {
                ScrollAmount = 0,
                ScrollDirection = ComputerScrollDirection.Up,
                Coordinate = [0, 0],
                Text = "text",
            },
        };

        ComputerScrollToolUseBlock copied = new(model);

        Assert.Equal(model, copied);
    }
}
