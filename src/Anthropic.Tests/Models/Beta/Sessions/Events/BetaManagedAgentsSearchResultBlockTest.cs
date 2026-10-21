using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Sessions.Events;

namespace Anthropic.Tests.Models.Beta.Sessions.Events;

public class BetaManagedAgentsSearchResultBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSearchResultBlock
        {
            Citations = new(true),
            Content = [new("x")],
            Source = "x",
            Title = "x",
        };

        BetaManagedAgentsSearchResultCitations expectedCitations = new(true);
        List<BetaManagedAgentsSearchResultContent> expectedContent = [new("x")];
        string expectedSource = "x";
        string expectedTitle = "x";
        JsonElement expectedType = JsonSerializer.SerializeToElement("search_result");

        Assert.Equal(expectedCitations, model.Citations);
        Assert.Equal(expectedContent.Count, model.Content.Count);
        for (int i = 0; i < expectedContent.Count; i++)
        {
            Assert.Equal(expectedContent[i], model.Content[i]);
        }
        Assert.Equal(expectedSource, model.Source);
        Assert.Equal(expectedTitle, model.Title);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSearchResultBlock
        {
            Citations = new(true),
            Content = [new("x")],
            Source = "x",
            Title = "x",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSearchResultBlock>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsSearchResultBlock
        {
            Citations = new(true),
            Content = [new("x")],
            Source = "x",
            Title = "x",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSearchResultBlock>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaManagedAgentsSearchResultCitations expectedCitations = new(true);
        List<BetaManagedAgentsSearchResultContent> expectedContent = [new("x")];
        string expectedSource = "x";
        string expectedTitle = "x";
        JsonElement expectedType = JsonSerializer.SerializeToElement("search_result");

        Assert.Equal(expectedCitations, deserialized.Citations);
        Assert.Equal(expectedContent.Count, deserialized.Content.Count);
        for (int i = 0; i < expectedContent.Count; i++)
        {
            Assert.Equal(expectedContent[i], deserialized.Content[i]);
        }
        Assert.Equal(expectedSource, deserialized.Source);
        Assert.Equal(expectedTitle, deserialized.Title);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsSearchResultBlock
        {
            Citations = new(true),
            Content = [new("x")],
            Source = "x",
            Title = "x",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsSearchResultBlock
        {
            Citations = new(true),
            Content = [new("x")],
            Source = "x",
            Title = "x",
        };

        BetaManagedAgentsSearchResultBlock copied = new(model);

        Assert.Equal(model, copied);
    }
}
