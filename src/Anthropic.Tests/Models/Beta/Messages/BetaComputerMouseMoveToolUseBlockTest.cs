using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaComputerMouseMoveToolUseBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaComputerMouseMoveToolUseBlock
        {
            ID = "id",
            Input = new([0, 0]),
            Caller = new BetaDirectCaller(),
        };

        string expectedID = "id";
        BetaComputerMouseMoveInput expectedInput = new([0, 0]);
        JsonElement expectedName = JsonSerializer.SerializeToElement("mouse_move");
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
        var model = new BetaComputerMouseMoveToolUseBlock
        {
            ID = "id",
            Input = new([0, 0]),
            Caller = new BetaDirectCaller(),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComputerMouseMoveToolUseBlock>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaComputerMouseMoveToolUseBlock
        {
            ID = "id",
            Input = new([0, 0]),
            Caller = new BetaDirectCaller(),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComputerMouseMoveToolUseBlock>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        BetaComputerMouseMoveInput expectedInput = new([0, 0]);
        JsonElement expectedName = JsonSerializer.SerializeToElement("mouse_move");
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
        var model = new BetaComputerMouseMoveToolUseBlock
        {
            ID = "id",
            Input = new([0, 0]),
            Caller = new BetaDirectCaller(),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaComputerMouseMoveToolUseBlock { ID = "id", Input = new([0, 0]) };

        Assert.Null(model.Caller);
        Assert.False(model.RawData.ContainsKey("caller"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaComputerMouseMoveToolUseBlock { ID = "id", Input = new([0, 0]) };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaComputerMouseMoveToolUseBlock
        {
            ID = "id",
            Input = new([0, 0]),

            // Null should be interpreted as omitted for these properties
            Caller = null,
        };

        Assert.Null(model.Caller);
        Assert.False(model.RawData.ContainsKey("caller"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullInWithAreUnset_Works()
    {
        var model = new BetaComputerMouseMoveToolUseBlock
        {
            ID = "id",
            Input = new([0, 0]),
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
        var model = new BetaComputerMouseMoveToolUseBlock
        {
            ID = "id",
            Input = new([0, 0]),

            // Null should be interpreted as omitted for these properties
            Caller = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaComputerMouseMoveToolUseBlock
        {
            ID = "id",
            Input = new([0, 0]),
            Caller = new BetaDirectCaller(),
        };

        BetaComputerMouseMoveToolUseBlock copied = new(model);

        Assert.Equal(model, copied);
    }
}
