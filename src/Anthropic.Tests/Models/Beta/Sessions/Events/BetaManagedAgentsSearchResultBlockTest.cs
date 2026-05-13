using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
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
            Content = [new() { Text = "x", Type = BetaManagedAgentsSearchResultContentType.Text }],
            Source = "x",
            Title = "x",
            ToolUseID = "x",
            Type = BetaManagedAgentsSearchResultBlockType.SearchResult,
        };

        BetaManagedAgentsSearchResultCitations expectedCitations = new(true);
        List<BetaManagedAgentsSearchResultContent> expectedContent =
        [
            new() { Text = "x", Type = BetaManagedAgentsSearchResultContentType.Text },
        ];
        string expectedSource = "x";
        string expectedTitle = "x";
        string expectedToolUseID = "x";
        ApiEnum<string, BetaManagedAgentsSearchResultBlockType> expectedType =
            BetaManagedAgentsSearchResultBlockType.SearchResult;

        Assert.Equal(expectedCitations, model.Citations);
        Assert.Equal(expectedContent.Count, model.Content.Count);
        for (int i = 0; i < expectedContent.Count; i++)
        {
            Assert.Equal(expectedContent[i], model.Content[i]);
        }
        Assert.Equal(expectedSource, model.Source);
        Assert.Equal(expectedTitle, model.Title);
        Assert.Equal(expectedToolUseID, model.ToolUseID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsSearchResultBlock
        {
            Citations = new(true),
            Content = [new() { Text = "x", Type = BetaManagedAgentsSearchResultContentType.Text }],
            Source = "x",
            Title = "x",
            ToolUseID = "x",
            Type = BetaManagedAgentsSearchResultBlockType.SearchResult,
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
            Content = [new() { Text = "x", Type = BetaManagedAgentsSearchResultContentType.Text }],
            Source = "x",
            Title = "x",
            ToolUseID = "x",
            Type = BetaManagedAgentsSearchResultBlockType.SearchResult,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsSearchResultBlock>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaManagedAgentsSearchResultCitations expectedCitations = new(true);
        List<BetaManagedAgentsSearchResultContent> expectedContent =
        [
            new() { Text = "x", Type = BetaManagedAgentsSearchResultContentType.Text },
        ];
        string expectedSource = "x";
        string expectedTitle = "x";
        string expectedToolUseID = "x";
        ApiEnum<string, BetaManagedAgentsSearchResultBlockType> expectedType =
            BetaManagedAgentsSearchResultBlockType.SearchResult;

        Assert.Equal(expectedCitations, deserialized.Citations);
        Assert.Equal(expectedContent.Count, deserialized.Content.Count);
        for (int i = 0; i < expectedContent.Count; i++)
        {
            Assert.Equal(expectedContent[i], deserialized.Content[i]);
        }
        Assert.Equal(expectedSource, deserialized.Source);
        Assert.Equal(expectedTitle, deserialized.Title);
        Assert.Equal(expectedToolUseID, deserialized.ToolUseID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsSearchResultBlock
        {
            Citations = new(true),
            Content = [new() { Text = "x", Type = BetaManagedAgentsSearchResultContentType.Text }],
            Source = "x",
            Title = "x",
            ToolUseID = "x",
            Type = BetaManagedAgentsSearchResultBlockType.SearchResult,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsSearchResultBlock
        {
            Citations = new(true),
            Content = [new() { Text = "x", Type = BetaManagedAgentsSearchResultContentType.Text }],
            Source = "x",
            Title = "x",
            ToolUseID = "x",
            Type = BetaManagedAgentsSearchResultBlockType.SearchResult,
        };

        BetaManagedAgentsSearchResultBlock copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsSearchResultBlockTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsSearchResultBlockType.SearchResult)]
    public void Validation_Works(BetaManagedAgentsSearchResultBlockType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSearchResultBlockType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSearchResultBlockType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsSearchResultBlockType.SearchResult)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsSearchResultBlockType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsSearchResultBlockType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSearchResultBlockType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSearchResultBlockType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsSearchResultBlockType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
