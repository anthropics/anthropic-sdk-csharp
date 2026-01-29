using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaWebSearchToolResultBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaWebSearchToolResultBlock
        {
            Content = new BetaWebSearchToolResultError(
                BetaWebSearchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        BetaWebSearchToolResultBlockContent expectedContent = new BetaWebSearchToolResultError(
            BetaWebSearchToolResultErrorCode.InvalidToolInput
        );
        string expectedToolUseID = "srvtoolu_SQfNkl1n_JR_";
        JsonElement expectedType = JsonSerializer.SerializeToElement("web_search_tool_result");

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedToolUseID, model.ToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaWebSearchToolResultBlock
        {
            Content = new BetaWebSearchToolResultError(
                BetaWebSearchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebSearchToolResultBlock>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaWebSearchToolResultBlock
        {
            Content = new BetaWebSearchToolResultError(
                BetaWebSearchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebSearchToolResultBlock>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaWebSearchToolResultBlockContent expectedContent = new BetaWebSearchToolResultError(
            BetaWebSearchToolResultErrorCode.InvalidToolInput
        );
        string expectedToolUseID = "srvtoolu_SQfNkl1n_JR_";
        JsonElement expectedType = JsonSerializer.SerializeToElement("web_search_tool_result");

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedToolUseID, deserialized.ToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaWebSearchToolResultBlock
        {
            Content = new BetaWebSearchToolResultError(
                BetaWebSearchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaWebSearchToolResultBlock
        {
            Content = new BetaWebSearchToolResultError(
                BetaWebSearchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        BetaWebSearchToolResultBlock copied = new(model);

        Assert.Equal(model, copied);
    }
}
