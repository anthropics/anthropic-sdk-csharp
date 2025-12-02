using System.Text.Json;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class WebSearchToolResultBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebSearchToolResultBlock
        {
            Content = new WebSearchToolResultError(
                WebSearchToolResultErrorErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        WebSearchToolResultBlockContent expectedContent = new WebSearchToolResultError(
            WebSearchToolResultErrorErrorCode.InvalidToolInput
        );
        string expectedToolUseID = "srvtoolu_SQfNkl1n_JR_";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"web_search_tool_result\""
        );

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedToolUseID, model.ToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebSearchToolResultBlock
        {
            Content = new WebSearchToolResultError(
                WebSearchToolResultErrorErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<WebSearchToolResultBlock>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebSearchToolResultBlock
        {
            Content = new WebSearchToolResultError(
                WebSearchToolResultErrorErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<WebSearchToolResultBlock>(json);
        Assert.NotNull(deserialized);

        WebSearchToolResultBlockContent expectedContent = new WebSearchToolResultError(
            WebSearchToolResultErrorErrorCode.InvalidToolInput
        );
        string expectedToolUseID = "srvtoolu_SQfNkl1n_JR_";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"web_search_tool_result\""
        );

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedToolUseID, deserialized.ToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebSearchToolResultBlock
        {
            Content = new WebSearchToolResultError(
                WebSearchToolResultErrorErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        model.Validate();
    }
}
