using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaCitationSearchResultLocationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaCitationSearchResultLocation
        {
            CitedText = "cited_text",
            EndBlockIndex = 0,
            SearchResultIndex = 0,
            Source = "source",
            StartBlockIndex = 0,
            Title = "title",
        };

        string expectedCitedText = "cited_text";
        long expectedEndBlockIndex = 0;
        long expectedSearchResultIndex = 0;
        string expectedSource = "source";
        long expectedStartBlockIndex = 0;
        string expectedTitle = "title";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"search_result_location\""
        );

        Assert.Equal(expectedCitedText, model.CitedText);
        Assert.Equal(expectedEndBlockIndex, model.EndBlockIndex);
        Assert.Equal(expectedSearchResultIndex, model.SearchResultIndex);
        Assert.Equal(expectedSource, model.Source);
        Assert.Equal(expectedStartBlockIndex, model.StartBlockIndex);
        Assert.Equal(expectedTitle, model.Title);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaCitationSearchResultLocation
        {
            CitedText = "cited_text",
            EndBlockIndex = 0,
            SearchResultIndex = 0,
            Source = "source",
            StartBlockIndex = 0,
            Title = "title",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaCitationSearchResultLocation>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaCitationSearchResultLocation
        {
            CitedText = "cited_text",
            EndBlockIndex = 0,
            SearchResultIndex = 0,
            Source = "source",
            StartBlockIndex = 0,
            Title = "title",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaCitationSearchResultLocation>(element);
        Assert.NotNull(deserialized);

        string expectedCitedText = "cited_text";
        long expectedEndBlockIndex = 0;
        long expectedSearchResultIndex = 0;
        string expectedSource = "source";
        long expectedStartBlockIndex = 0;
        string expectedTitle = "title";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"search_result_location\""
        );

        Assert.Equal(expectedCitedText, deserialized.CitedText);
        Assert.Equal(expectedEndBlockIndex, deserialized.EndBlockIndex);
        Assert.Equal(expectedSearchResultIndex, deserialized.SearchResultIndex);
        Assert.Equal(expectedSource, deserialized.Source);
        Assert.Equal(expectedStartBlockIndex, deserialized.StartBlockIndex);
        Assert.Equal(expectedTitle, deserialized.Title);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaCitationSearchResultLocation
        {
            CitedText = "cited_text",
            EndBlockIndex = 0,
            SearchResultIndex = 0,
            Source = "source",
            StartBlockIndex = 0,
            Title = "title",
        };

        model.Validate();
    }
}
