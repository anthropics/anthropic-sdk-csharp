using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class BrowserStateTabEntryTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BrowserStateTabEntry
        {
            TabID = "tab_id",
            Title = "title",
            Url = "url",
            Active = true,
        };

        string expectedTabID = "tab_id";
        string expectedTitle = "title";
        string expectedUrl = "url";
        bool expectedActive = true;

        Assert.Equal(expectedTabID, model.TabID);
        Assert.Equal(expectedTitle, model.Title);
        Assert.Equal(expectedUrl, model.Url);
        Assert.Equal(expectedActive, model.Active);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BrowserStateTabEntry
        {
            TabID = "tab_id",
            Title = "title",
            Url = "url",
            Active = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserStateTabEntry>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BrowserStateTabEntry
        {
            TabID = "tab_id",
            Title = "title",
            Url = "url",
            Active = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BrowserStateTabEntry>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedTabID = "tab_id";
        string expectedTitle = "title";
        string expectedUrl = "url";
        bool expectedActive = true;

        Assert.Equal(expectedTabID, deserialized.TabID);
        Assert.Equal(expectedTitle, deserialized.Title);
        Assert.Equal(expectedUrl, deserialized.Url);
        Assert.Equal(expectedActive, deserialized.Active);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BrowserStateTabEntry
        {
            TabID = "tab_id",
            Title = "title",
            Url = "url",
            Active = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BrowserStateTabEntry
        {
            TabID = "tab_id",
            Title = "title",
            Url = "url",
        };

        Assert.Null(model.Active);
        Assert.False(model.RawData.ContainsKey("active"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BrowserStateTabEntry
        {
            TabID = "tab_id",
            Title = "title",
            Url = "url",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BrowserStateTabEntry
        {
            TabID = "tab_id",
            Title = "title",
            Url = "url",

            // Null should be interpreted as omitted for these properties
            Active = null,
        };

        Assert.Null(model.Active);
        Assert.False(model.RawData.ContainsKey("active"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BrowserStateTabEntry
        {
            TabID = "tab_id",
            Title = "title",
            Url = "url",

            // Null should be interpreted as omitted for these properties
            Active = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BrowserStateTabEntry
        {
            TabID = "tab_id",
            Title = "title",
            Url = "url",
            Active = true,
        };

        BrowserStateTabEntry copied = new(model);

        Assert.Equal(model, copied);
    }
}
