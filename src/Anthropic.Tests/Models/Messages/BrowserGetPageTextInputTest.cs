using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class BrowserGetPageTextInputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BrowserGetPageTextInput { TabID = "tab_id" };

        string expectedTabID = "tab_id";

        Assert.Equal(expectedTabID, model.TabID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BrowserGetPageTextInput { TabID = "tab_id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserGetPageTextInput>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BrowserGetPageTextInput { TabID = "tab_id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserGetPageTextInput>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedTabID = "tab_id";

        Assert.Equal(expectedTabID, deserialized.TabID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BrowserGetPageTextInput { TabID = "tab_id" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BrowserGetPageTextInput { };

        Assert.Null(model.TabID);
        Assert.False(model.RawData.ContainsKey("tab_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BrowserGetPageTextInput { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BrowserGetPageTextInput { TabID = null };

        Assert.Null(model.TabID);
        Assert.True(model.RawData.ContainsKey("tab_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BrowserGetPageTextInput { TabID = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BrowserGetPageTextInput { TabID = "tab_id" };

        BrowserGetPageTextInput copied = new(model);

        Assert.Equal(model, copied);
    }
}
