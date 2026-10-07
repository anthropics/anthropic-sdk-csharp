using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaBrowserZoomInputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaBrowserZoomInput { Region = [0, 0, 0, 0], TabID = "tab_id" };

        List<long> expectedRegion = [0, 0, 0, 0];
        string expectedTabID = "tab_id";

        Assert.Equal(expectedRegion.Count, model.Region.Count);
        for (int i = 0; i < expectedRegion.Count; i++)
        {
            Assert.Equal(expectedRegion[i], model.Region[i]);
        }
        Assert.Equal(expectedTabID, model.TabID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaBrowserZoomInput { Region = [0, 0, 0, 0], TabID = "tab_id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserZoomInput>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaBrowserZoomInput { Region = [0, 0, 0, 0], TabID = "tab_id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserZoomInput>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<long> expectedRegion = [0, 0, 0, 0];
        string expectedTabID = "tab_id";

        Assert.Equal(expectedRegion.Count, deserialized.Region.Count);
        for (int i = 0; i < expectedRegion.Count; i++)
        {
            Assert.Equal(expectedRegion[i], deserialized.Region[i]);
        }
        Assert.Equal(expectedTabID, deserialized.TabID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaBrowserZoomInput { Region = [0, 0, 0, 0], TabID = "tab_id" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaBrowserZoomInput { Region = [0, 0, 0, 0] };

        Assert.Null(model.TabID);
        Assert.False(model.RawData.ContainsKey("tab_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaBrowserZoomInput { Region = [0, 0, 0, 0] };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaBrowserZoomInput
        {
            Region = [0, 0, 0, 0],

            TabID = null,
        };

        Assert.Null(model.TabID);
        Assert.True(model.RawData.ContainsKey("tab_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaBrowserZoomInput
        {
            Region = [0, 0, 0, 0],

            TabID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaBrowserZoomInput { Region = [0, 0, 0, 0], TabID = "tab_id" };

        BetaBrowserZoomInput copied = new(model);

        Assert.Equal(model, copied);
    }
}
