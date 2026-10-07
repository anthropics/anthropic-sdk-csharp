using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class BrowserKeyInputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BrowserKeyInput
        {
            Text = "text",
            Repeat = 1,
            TabID = "tab_id",
        };

        string expectedText = "text";
        long expectedRepeat = 1;
        string expectedTabID = "tab_id";

        Assert.Equal(expectedText, model.Text);
        Assert.Equal(expectedRepeat, model.Repeat);
        Assert.Equal(expectedTabID, model.TabID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BrowserKeyInput
        {
            Text = "text",
            Repeat = 1,
            TabID = "tab_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserKeyInput>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BrowserKeyInput
        {
            Text = "text",
            Repeat = 1,
            TabID = "tab_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserKeyInput>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedText = "text";
        long expectedRepeat = 1;
        string expectedTabID = "tab_id";

        Assert.Equal(expectedText, deserialized.Text);
        Assert.Equal(expectedRepeat, deserialized.Repeat);
        Assert.Equal(expectedTabID, deserialized.TabID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BrowserKeyInput
        {
            Text = "text",
            Repeat = 1,
            TabID = "tab_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BrowserKeyInput { Text = "text" };

        Assert.Null(model.Repeat);
        Assert.False(model.RawData.ContainsKey("repeat"));
        Assert.Null(model.TabID);
        Assert.False(model.RawData.ContainsKey("tab_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BrowserKeyInput { Text = "text" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BrowserKeyInput
        {
            Text = "text",

            Repeat = null,
            TabID = null,
        };

        Assert.Null(model.Repeat);
        Assert.True(model.RawData.ContainsKey("repeat"));
        Assert.Null(model.TabID);
        Assert.True(model.RawData.ContainsKey("tab_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BrowserKeyInput
        {
            Text = "text",

            Repeat = null,
            TabID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BrowserKeyInput
        {
            Text = "text",
            Repeat = 1,
            TabID = "tab_id",
        };

        BrowserKeyInput copied = new(model);

        Assert.Equal(model, copied);
    }
}
