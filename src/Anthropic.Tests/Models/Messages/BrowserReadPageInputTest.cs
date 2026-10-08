using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class BrowserReadPageInputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BrowserReadPageInput
        {
            Depth = 1,
            Filter = BrowserReadPageFilter.All,
            Ref = "ref",
            TabID = "tab_id",
        };

        long expectedDepth = 1;
        ApiEnum<string, BrowserReadPageFilter> expectedFilter = BrowserReadPageFilter.All;
        string expectedRef = "ref";
        string expectedTabID = "tab_id";

        Assert.Equal(expectedDepth, model.Depth);
        Assert.Equal(expectedFilter, model.Filter);
        Assert.Equal(expectedRef, model.Ref);
        Assert.Equal(expectedTabID, model.TabID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BrowserReadPageInput
        {
            Depth = 1,
            Filter = BrowserReadPageFilter.All,
            Ref = "ref",
            TabID = "tab_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserReadPageInput>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BrowserReadPageInput
        {
            Depth = 1,
            Filter = BrowserReadPageFilter.All,
            Ref = "ref",
            TabID = "tab_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserReadPageInput>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedDepth = 1;
        ApiEnum<string, BrowserReadPageFilter> expectedFilter = BrowserReadPageFilter.All;
        string expectedRef = "ref";
        string expectedTabID = "tab_id";

        Assert.Equal(expectedDepth, deserialized.Depth);
        Assert.Equal(expectedFilter, deserialized.Filter);
        Assert.Equal(expectedRef, deserialized.Ref);
        Assert.Equal(expectedTabID, deserialized.TabID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BrowserReadPageInput
        {
            Depth = 1,
            Filter = BrowserReadPageFilter.All,
            Ref = "ref",
            TabID = "tab_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BrowserReadPageInput { };

        Assert.Null(model.Depth);
        Assert.False(model.RawData.ContainsKey("depth"));
        Assert.Null(model.Filter);
        Assert.False(model.RawData.ContainsKey("filter"));
        Assert.Null(model.Ref);
        Assert.False(model.RawData.ContainsKey("ref"));
        Assert.Null(model.TabID);
        Assert.False(model.RawData.ContainsKey("tab_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BrowserReadPageInput { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BrowserReadPageInput
        {
            Depth = null,
            Filter = null,
            Ref = null,
            TabID = null,
        };

        Assert.Null(model.Depth);
        Assert.True(model.RawData.ContainsKey("depth"));
        Assert.Null(model.Filter);
        Assert.True(model.RawData.ContainsKey("filter"));
        Assert.Null(model.Ref);
        Assert.True(model.RawData.ContainsKey("ref"));
        Assert.Null(model.TabID);
        Assert.True(model.RawData.ContainsKey("tab_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BrowserReadPageInput
        {
            Depth = null,
            Filter = null,
            Ref = null,
            TabID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BrowserReadPageInput
        {
            Depth = 1,
            Filter = BrowserReadPageFilter.All,
            Ref = "ref",
            TabID = "tab_id",
        };

        BrowserReadPageInput copied = new(model);

        Assert.Equal(model, copied);
    }
}
