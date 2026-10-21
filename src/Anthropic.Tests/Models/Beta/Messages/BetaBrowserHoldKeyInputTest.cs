using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaBrowserHoldKeyInputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaBrowserHoldKeyInput
        {
            Duration = 0,
            Text = "text",
            TabID = "tab_id",
        };

        double expectedDuration = 0;
        string expectedText = "text";
        string expectedTabID = "tab_id";

        Assert.Equal(expectedDuration, model.Duration);
        Assert.Equal(expectedText, model.Text);
        Assert.Equal(expectedTabID, model.TabID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaBrowserHoldKeyInput
        {
            Duration = 0,
            Text = "text",
            TabID = "tab_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserHoldKeyInput>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaBrowserHoldKeyInput
        {
            Duration = 0,
            Text = "text",
            TabID = "tab_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserHoldKeyInput>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedDuration = 0;
        string expectedText = "text";
        string expectedTabID = "tab_id";

        Assert.Equal(expectedDuration, deserialized.Duration);
        Assert.Equal(expectedText, deserialized.Text);
        Assert.Equal(expectedTabID, deserialized.TabID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaBrowserHoldKeyInput
        {
            Duration = 0,
            Text = "text",
            TabID = "tab_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaBrowserHoldKeyInput { Duration = 0, Text = "text" };

        Assert.Null(model.TabID);
        Assert.False(model.RawData.ContainsKey("tab_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaBrowserHoldKeyInput { Duration = 0, Text = "text" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaBrowserHoldKeyInput
        {
            Duration = 0,
            Text = "text",

            TabID = null,
        };

        Assert.Null(model.TabID);
        Assert.True(model.RawData.ContainsKey("tab_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaBrowserHoldKeyInput
        {
            Duration = 0,
            Text = "text",

            TabID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaBrowserHoldKeyInput
        {
            Duration = 0,
            Text = "text",
            TabID = "tab_id",
        };

        BetaBrowserHoldKeyInput copied = new(model);

        Assert.Equal(model, copied);
    }
}
