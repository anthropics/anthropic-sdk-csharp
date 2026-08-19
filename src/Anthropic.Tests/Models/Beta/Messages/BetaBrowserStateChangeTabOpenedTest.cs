using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaBrowserStateChangeTabOpenedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaBrowserStateChangeTabOpened { TabID = "tab_id" };

        string expectedTabID = "tab_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("tab_opened");

        Assert.Equal(expectedTabID, model.TabID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaBrowserStateChangeTabOpened { TabID = "tab_id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserStateChangeTabOpened>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaBrowserStateChangeTabOpened { TabID = "tab_id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserStateChangeTabOpened>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedTabID = "tab_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("tab_opened");

        Assert.Equal(expectedTabID, deserialized.TabID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaBrowserStateChangeTabOpened { TabID = "tab_id" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaBrowserStateChangeTabOpened { TabID = "tab_id" };

        BetaBrowserStateChangeTabOpened copied = new(model);

        Assert.Equal(model, copied);
    }
}
