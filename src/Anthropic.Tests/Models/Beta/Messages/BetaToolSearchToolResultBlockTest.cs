using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaToolSearchToolResultBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaToolSearchToolResultBlock
        {
            Content = new BetaToolSearchToolResultError()
            {
                ErrorCode = BetaToolSearchToolResultErrorErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        BetaToolSearchToolResultBlockContent expectedContent = new BetaToolSearchToolResultError()
        {
            ErrorCode = BetaToolSearchToolResultErrorErrorCode.InvalidToolInput,
            ErrorMessage = "error_message",
        };
        string expectedToolUseID = "srvtoolu_SQfNkl1n_JR_";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"tool_search_tool_result\""
        );

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedToolUseID, model.ToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaToolSearchToolResultBlock
        {
            Content = new BetaToolSearchToolResultError()
            {
                ErrorCode = BetaToolSearchToolResultErrorErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaToolSearchToolResultBlock>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaToolSearchToolResultBlock
        {
            Content = new BetaToolSearchToolResultError()
            {
                ErrorCode = BetaToolSearchToolResultErrorErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaToolSearchToolResultBlock>(json);
        Assert.NotNull(deserialized);

        BetaToolSearchToolResultBlockContent expectedContent = new BetaToolSearchToolResultError()
        {
            ErrorCode = BetaToolSearchToolResultErrorErrorCode.InvalidToolInput,
            ErrorMessage = "error_message",
        };
        string expectedToolUseID = "srvtoolu_SQfNkl1n_JR_";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"tool_search_tool_result\""
        );

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedToolUseID, deserialized.ToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaToolSearchToolResultBlock
        {
            Content = new BetaToolSearchToolResultError()
            {
                ErrorCode = BetaToolSearchToolResultErrorErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        model.Validate();
    }
}

public class BetaToolSearchToolResultBlockContentTest : TestBase
{
    [Fact]
    public void BetaToolSearchToolResultErrorValidationWorks()
    {
        BetaToolSearchToolResultBlockContent value = new(
            new BetaToolSearchToolResultError()
            {
                ErrorCode = BetaToolSearchToolResultErrorErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            }
        );
        value.Validate();
    }

    [Fact]
    public void BetaToolSearchToolSearchResultBlockValidationWorks()
    {
        BetaToolSearchToolResultBlockContent value = new(
            new BetaToolSearchToolSearchResultBlock([new("tool_name")])
        );
        value.Validate();
    }

    [Fact]
    public void BetaToolSearchToolResultErrorSerializationRoundtripWorks()
    {
        BetaToolSearchToolResultBlockContent value = new(
            new BetaToolSearchToolResultError()
            {
                ErrorCode = BetaToolSearchToolResultErrorErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            }
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaToolSearchToolResultBlockContent>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaToolSearchToolSearchResultBlockSerializationRoundtripWorks()
    {
        BetaToolSearchToolResultBlockContent value = new(
            new BetaToolSearchToolSearchResultBlock([new("tool_name")])
        );
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaToolSearchToolResultBlockContent>(json);

        Assert.Equal(value, deserialized);
    }
}
