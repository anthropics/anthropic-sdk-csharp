using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaBrowserFindInputTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaBrowserFindInput { Query = "query", TabID = "tab_id" };

        string expectedQuery = "query";
        string expectedTabID = "tab_id";

        Assert.Equal(expectedQuery, model.Query);
        Assert.Equal(expectedTabID, model.TabID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaBrowserFindInput { Query = "query", TabID = "tab_id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserFindInput>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaBrowserFindInput { Query = "query", TabID = "tab_id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaBrowserFindInput>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedQuery = "query";
        string expectedTabID = "tab_id";

        Assert.Equal(expectedQuery, deserialized.Query);
        Assert.Equal(expectedTabID, deserialized.TabID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaBrowserFindInput { Query = "query", TabID = "tab_id" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaBrowserFindInput { Query = "query" };

        Assert.Null(model.TabID);
        Assert.False(model.RawData.ContainsKey("tab_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaBrowserFindInput { Query = "query" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaBrowserFindInput
        {
            Query = "query",

            TabID = null,
        };

        Assert.Null(model.TabID);
        Assert.True(model.RawData.ContainsKey("tab_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaBrowserFindInput
        {
            Query = "query",

            TabID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaBrowserFindInput { Query = "query", TabID = "tab_id" };

        BetaBrowserFindInput copied = new(model);

        Assert.Equal(model, copied);
    }
}
