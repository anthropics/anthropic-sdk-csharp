using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaBrowserLeftClickDragToolUseBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaBrowserLeftClickDragToolUseBlock
        {
            ID = "id",
            Input = new()
            {
                From = new() { X = 0, Y = 0 },
                Target = new() { X = 0, Y = 0 },
                TabID = "tab_id",
            },
            Caller = new BetaDirectCaller(),
        };

        string expectedID = "id";
        BetaBrowserLeftClickDragInput expectedInput = new()
        {
            From = new() { X = 0, Y = 0 },
            Target = new() { X = 0, Y = 0 },
            TabID = "tab_id",
        };
        JsonElement expectedName = JsonSerializer.SerializeToElement("left_click_drag");
        JsonElement expectedToolsetName = JsonSerializer.SerializeToElement("browser");
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
        var model = new BetaBrowserLeftClickDragToolUseBlock
        {
            ID = "id",
            Input = new()
            {
                From = new() { X = 0, Y = 0 },
                Target = new() { X = 0, Y = 0 },
                TabID = "tab_id",
            },
            Caller = new BetaDirectCaller(),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserLeftClickDragToolUseBlock>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaBrowserLeftClickDragToolUseBlock
        {
            ID = "id",
            Input = new()
            {
                From = new() { X = 0, Y = 0 },
                Target = new() { X = 0, Y = 0 },
                TabID = "tab_id",
            },
            Caller = new BetaDirectCaller(),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserLeftClickDragToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        BetaBrowserLeftClickDragInput expectedInput = new()
        {
            From = new() { X = 0, Y = 0 },
            Target = new() { X = 0, Y = 0 },
            TabID = "tab_id",
        };
        JsonElement expectedName = JsonSerializer.SerializeToElement("left_click_drag");
        JsonElement expectedToolsetName = JsonSerializer.SerializeToElement("browser");
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
        var model = new BetaBrowserLeftClickDragToolUseBlock
        {
            ID = "id",
            Input = new()
            {
                From = new() { X = 0, Y = 0 },
                Target = new() { X = 0, Y = 0 },
                TabID = "tab_id",
            },
            Caller = new BetaDirectCaller(),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaBrowserLeftClickDragToolUseBlock
        {
            ID = "id",
            Input = new()
            {
                From = new() { X = 0, Y = 0 },
                Target = new() { X = 0, Y = 0 },
                TabID = "tab_id",
            },
        };

        Assert.Null(model.Caller);
        Assert.False(model.RawData.ContainsKey("caller"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaBrowserLeftClickDragToolUseBlock
        {
            ID = "id",
            Input = new()
            {
                From = new() { X = 0, Y = 0 },
                Target = new() { X = 0, Y = 0 },
                TabID = "tab_id",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaBrowserLeftClickDragToolUseBlock
        {
            ID = "id",
            Input = new()
            {
                From = new() { X = 0, Y = 0 },
                Target = new() { X = 0, Y = 0 },
                TabID = "tab_id",
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
        var model = new BetaBrowserLeftClickDragToolUseBlock
        {
            ID = "id",
            Input = new()
            {
                From = new() { X = 0, Y = 0 },
                Target = new() { X = 0, Y = 0 },
                TabID = "tab_id",
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
        var model = new BetaBrowserLeftClickDragToolUseBlock
        {
            ID = "id",
            Input = new()
            {
                From = new() { X = 0, Y = 0 },
                Target = new() { X = 0, Y = 0 },
                TabID = "tab_id",
            },

            // Null should be interpreted as omitted for these properties
            Caller = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaBrowserLeftClickDragToolUseBlock
        {
            ID = "id",
            Input = new()
            {
                From = new() { X = 0, Y = 0 },
                Target = new() { X = 0, Y = 0 },
                TabID = "tab_id",
            },
            Caller = new BetaDirectCaller(),
        };

        BetaBrowserLeftClickDragToolUseBlock copied = new(model);

        Assert.Equal(model, copied);
    }
}
