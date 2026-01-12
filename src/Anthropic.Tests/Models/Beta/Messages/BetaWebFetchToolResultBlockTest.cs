using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaWebFetchToolResultBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaWebFetchToolResultBlock
        {
            Content = new BetaWebFetchToolResultErrorBlock(
                BetaWebFetchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        BetaWebFetchToolResultBlockContent expectedContent = new BetaWebFetchToolResultErrorBlock(
            BetaWebFetchToolResultErrorCode.InvalidToolInput
        );
        string expectedToolUseID = "srvtoolu_SQfNkl1n_JR_";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"web_fetch_tool_result\""
        );

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedToolUseID, model.ToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaWebFetchToolResultBlock
        {
            Content = new BetaWebFetchToolResultErrorBlock(
                BetaWebFetchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaWebFetchToolResultBlock>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaWebFetchToolResultBlock
        {
            Content = new BetaWebFetchToolResultErrorBlock(
                BetaWebFetchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaWebFetchToolResultBlock>(element);
        Assert.NotNull(deserialized);

        BetaWebFetchToolResultBlockContent expectedContent = new BetaWebFetchToolResultErrorBlock(
            BetaWebFetchToolResultErrorCode.InvalidToolInput
        );
        string expectedToolUseID = "srvtoolu_SQfNkl1n_JR_";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"web_fetch_tool_result\""
        );

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedToolUseID, deserialized.ToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaWebFetchToolResultBlock
        {
            Content = new BetaWebFetchToolResultErrorBlock(
                BetaWebFetchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        model.Validate();
    }
}

public class BetaWebFetchToolResultBlockContentTest : TestBase
{
    [Fact]
    public void BetaWebFetchToolResultErrorBlockValidationWorks()
    {
        BetaWebFetchToolResultBlockContent value = new(
            new BetaWebFetchToolResultErrorBlock(BetaWebFetchToolResultErrorCode.InvalidToolInput)
        );
        value.Validate();
    }

    [Fact]
    public void BetaWebFetchBlockValidationWorks()
    {
        BetaWebFetchToolResultBlockContent value = new(
            new BetaWebFetchBlock()
            {
                Content = new()
                {
                    Citations = new(true),
                    Source = new BetaBase64PdfSource("U3RhaW5sZXNzIHJvY2tz"),
                    Title = "title",
                },
                RetrievedAt = "retrieved_at",
                Url = "url",
            }
        );
        value.Validate();
    }

    [Fact]
    public void BetaWebFetchToolResultErrorBlockSerializationRoundtripWorks()
    {
        BetaWebFetchToolResultBlockContent value = new(
            new BetaWebFetchToolResultErrorBlock(BetaWebFetchToolResultErrorCode.InvalidToolInput)
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaWebFetchToolResultBlockContent>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaWebFetchBlockSerializationRoundtripWorks()
    {
        BetaWebFetchToolResultBlockContent value = new(
            new BetaWebFetchBlock()
            {
                Content = new()
                {
                    Citations = new(true),
                    Source = new BetaBase64PdfSource("U3RhaW5sZXNzIHJvY2tz"),
                    Title = "title",
                },
                RetrievedAt = "retrieved_at",
                Url = "url",
            }
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaWebFetchToolResultBlockContent>(element);

        Assert.Equal(value, deserialized);
    }
}
