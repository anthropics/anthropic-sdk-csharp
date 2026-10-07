using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaBrowserFormInputInputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaBrowserFormInputInput
        {
            Target = new("ref"),
            Value = "string",
            TabID = "tab_id",
        };

        BetaBrowserRefTarget expectedTarget = new("ref");
        BetaBrowserFormInputValue expectedValue = "string";
        string expectedTabID = "tab_id";

        Assert.Equal(expectedTarget, model.Target);
        Assert.Equal(expectedValue, model.Value);
        Assert.Equal(expectedTabID, model.TabID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaBrowserFormInputInput
        {
            Target = new("ref"),
            Value = "string",
            TabID = "tab_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserFormInputInput>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaBrowserFormInputInput
        {
            Target = new("ref"),
            Value = "string",
            TabID = "tab_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserFormInputInput>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaBrowserRefTarget expectedTarget = new("ref");
        BetaBrowserFormInputValue expectedValue = "string";
        string expectedTabID = "tab_id";

        Assert.Equal(expectedTarget, deserialized.Target);
        Assert.Equal(expectedValue, deserialized.Value);
        Assert.Equal(expectedTabID, deserialized.TabID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaBrowserFormInputInput
        {
            Target = new("ref"),
            Value = "string",
            TabID = "tab_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaBrowserFormInputInput { Target = new("ref"), Value = "string" };

        Assert.Null(model.TabID);
        Assert.False(model.RawData.ContainsKey("tab_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaBrowserFormInputInput { Target = new("ref"), Value = "string" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaBrowserFormInputInput
        {
            Target = new("ref"),
            Value = "string",

            TabID = null,
        };

        Assert.Null(model.TabID);
        Assert.True(model.RawData.ContainsKey("tab_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaBrowserFormInputInput
        {
            Target = new("ref"),
            Value = "string",

            TabID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaBrowserFormInputInput
        {
            Target = new("ref"),
            Value = "string",
            TabID = "tab_id",
        };

        BetaBrowserFormInputInput copied = new(model);

        Assert.Equal(model, copied);
    }
}
