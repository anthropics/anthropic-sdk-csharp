using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaComputerScrollToolUseBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaComputerScrollToolUseBlock
        {
            ID = "id",
            Input = new()
            {
                ScrollAmount = 0,
                ScrollDirection = BetaComputerScrollDirection.Up,
                Coordinate = [0, 0],
                Text = "text",
            },
            Caller = new BetaDirectCaller(),
        };

        string expectedID = "id";
        BetaComputerScrollInput expectedInput = new()
        {
            ScrollAmount = 0,
            ScrollDirection = BetaComputerScrollDirection.Up,
            Coordinate = [0, 0],
            Text = "text",
        };
        JsonElement expectedName = JsonSerializer.SerializeToElement("scroll");
        JsonElement expectedToolsetName = JsonSerializer.SerializeToElement("computer");
        JsonElement expectedType = JsonSerializer.SerializeToElement("tool_use");
        BetaToolUseCaller expectedCaller = new BetaDirectCaller();

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedInput, model.Input);
        Assert.True(JsonElement.DeepEquals(expectedName, model.Name));
        Assert.True(JsonElement.DeepEquals(expectedToolsetName, model.ToolsetName));
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedCaller, model.Caller);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaComputerScrollToolUseBlock
        {
            ID = "id",
            Input = new()
            {
                ScrollAmount = 0,
                ScrollDirection = BetaComputerScrollDirection.Up,
                Coordinate = [0, 0],
                Text = "text",
            },
            Caller = new BetaDirectCaller(),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComputerScrollToolUseBlock>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaComputerScrollToolUseBlock
        {
            ID = "id",
            Input = new()
            {
                ScrollAmount = 0,
                ScrollDirection = BetaComputerScrollDirection.Up,
                Coordinate = [0, 0],
                Text = "text",
            },
            Caller = new BetaDirectCaller(),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComputerScrollToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        BetaComputerScrollInput expectedInput = new()
        {
            ScrollAmount = 0,
            ScrollDirection = BetaComputerScrollDirection.Up,
            Coordinate = [0, 0],
            Text = "text",
        };
        JsonElement expectedName = JsonSerializer.SerializeToElement("scroll");
        JsonElement expectedToolsetName = JsonSerializer.SerializeToElement("computer");
        JsonElement expectedType = JsonSerializer.SerializeToElement("tool_use");
        BetaToolUseCaller expectedCaller = new BetaDirectCaller();

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedInput, deserialized.Input);
        Assert.True(JsonElement.DeepEquals(expectedName, deserialized.Name));
        Assert.True(JsonElement.DeepEquals(expectedToolsetName, deserialized.ToolsetName));
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedCaller, deserialized.Caller);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaComputerScrollToolUseBlock
        {
            ID = "id",
            Input = new()
            {
                ScrollAmount = 0,
                ScrollDirection = BetaComputerScrollDirection.Up,
                Coordinate = [0, 0],
                Text = "text",
            },
            Caller = new BetaDirectCaller(),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaComputerScrollToolUseBlock
        {
            ID = "id",
            Input = new()
            {
                ScrollAmount = 0,
                ScrollDirection = BetaComputerScrollDirection.Up,
                Coordinate = [0, 0],
                Text = "text",
            },
        };

        Assert.Null(model.Caller);
        Assert.False(model.RawData.ContainsKey("caller"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaComputerScrollToolUseBlock
        {
            ID = "id",
            Input = new()
            {
                ScrollAmount = 0,
                ScrollDirection = BetaComputerScrollDirection.Up,
                Coordinate = [0, 0],
                Text = "text",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaComputerScrollToolUseBlock
        {
            ID = "id",
            Input = new()
            {
                ScrollAmount = 0,
                ScrollDirection = BetaComputerScrollDirection.Up,
                Coordinate = [0, 0],
                Text = "text",
            },

            // Null should be interpreted as omitted for these properties
            Caller = null,
        };

        Assert.Null(model.Caller);
        Assert.False(model.RawData.ContainsKey("caller"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullInWithAreUnset_Works()
    {
        var model = new BetaComputerScrollToolUseBlock
        {
            ID = "id",
            Input = new()
            {
                ScrollAmount = 0,
                ScrollDirection = BetaComputerScrollDirection.Up,
                Coordinate = [0, 0],
                Text = "text",
            },
            Caller = new BetaDirectCaller(),
        } with
        {
            // Null should be interpreted as omitted for these properties
            Caller = null,
        };

        Assert.Null(model.Caller);
        Assert.False(model.RawData.ContainsKey("caller"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaComputerScrollToolUseBlock
        {
            ID = "id",
            Input = new()
            {
                ScrollAmount = 0,
                ScrollDirection = BetaComputerScrollDirection.Up,
                Coordinate = [0, 0],
                Text = "text",
            },

            // Null should be interpreted as omitted for these properties
            Caller = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaComputerScrollToolUseBlock
        {
            ID = "id",
            Input = new()
            {
                ScrollAmount = 0,
                ScrollDirection = BetaComputerScrollDirection.Up,
                Coordinate = [0, 0],
                Text = "text",
            },
            Caller = new BetaDirectCaller(),
        };

        BetaComputerScrollToolUseBlock copied = new(model);

        Assert.Equal(model, copied);
    }
}
