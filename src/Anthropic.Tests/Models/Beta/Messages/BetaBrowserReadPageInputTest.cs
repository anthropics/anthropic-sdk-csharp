using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaBrowserReadPageInputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaBrowserReadPageInput
        {
            Depth = 1,
            Filter = BetaBrowserReadPageFilter.All,
            Ref = "ref",
            TabID = "tab_id",
        };

        long expectedDepth = 1;
        ApiEnum<string, BetaBrowserReadPageFilter> expectedFilter = BetaBrowserReadPageFilter.All;
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
        var model = new BetaBrowserReadPageInput
        {
            Depth = 1,
            Filter = BetaBrowserReadPageFilter.All,
            Ref = "ref",
            TabID = "tab_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserReadPageInput>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaBrowserReadPageInput
        {
            Depth = 1,
            Filter = BetaBrowserReadPageFilter.All,
            Ref = "ref",
            TabID = "tab_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserReadPageInput>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        long expectedDepth = 1;
        ApiEnum<string, BetaBrowserReadPageFilter> expectedFilter = BetaBrowserReadPageFilter.All;
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
        var model = new BetaBrowserReadPageInput
        {
            Depth = 1,
            Filter = BetaBrowserReadPageFilter.All,
            Ref = "ref",
            TabID = "tab_id",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaBrowserReadPageInput { };

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
        var model = new BetaBrowserReadPageInput { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaBrowserReadPageInput
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
        var model = new BetaBrowserReadPageInput
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
        var model = new BetaBrowserReadPageInput
        {
            Depth = 1,
            Filter = BetaBrowserReadPageFilter.All,
            Ref = "ref",
            TabID = "tab_id",
        };

        BetaBrowserReadPageInput copied = new(model);

        Assert.Equal(model, copied);
    }
}
