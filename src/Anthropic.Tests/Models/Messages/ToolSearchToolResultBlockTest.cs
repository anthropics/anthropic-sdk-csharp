using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ToolSearchToolResultBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ToolSearchToolResultBlock
        {
            Content = new ToolSearchToolResultError()
            {
                ErrorCode = ToolSearchToolResultErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        ToolSearchToolResultBlockContent expectedContent = new ToolSearchToolResultError()
        {
            ErrorCode = ToolSearchToolResultErrorCode.InvalidToolInput,
            ErrorMessage = "error_message",
        };
        string expectedToolUseID = "srvtoolu_SQfNkl1n_JR_";
        JsonElement expectedType = JsonSerializer.SerializeToElement("tool_search_tool_result");

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedToolUseID, model.ToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ToolSearchToolResultBlock
        {
            Content = new ToolSearchToolResultError()
            {
                ErrorCode = ToolSearchToolResultErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolSearchToolResultBlock>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ToolSearchToolResultBlock
        {
            Content = new ToolSearchToolResultError()
            {
                ErrorCode = ToolSearchToolResultErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolSearchToolResultBlock>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ToolSearchToolResultBlockContent expectedContent = new ToolSearchToolResultError()
        {
            ErrorCode = ToolSearchToolResultErrorCode.InvalidToolInput,
            ErrorMessage = "error_message",
        };
        string expectedToolUseID = "srvtoolu_SQfNkl1n_JR_";
        JsonElement expectedType = JsonSerializer.SerializeToElement("tool_search_tool_result");

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedToolUseID, deserialized.ToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ToolSearchToolResultBlock
        {
            Content = new ToolSearchToolResultError()
            {
                ErrorCode = ToolSearchToolResultErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ToolSearchToolResultBlock
        {
            Content = new ToolSearchToolResultError()
            {
                ErrorCode = ToolSearchToolResultErrorCode.InvalidToolInput,
                ErrorMessage = "error_message",
            },
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        ToolSearchToolResultBlock copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ToolSearchToolResultBlockContentTest : TestBase
{
    [Fact]
    public void ToolSearchToolResultErrorValidationWorks()
    {
        ToolSearchToolResultBlockContent value = new ToolSearchToolResultError()
        {
            ErrorCode = ToolSearchToolResultErrorCode.InvalidToolInput,
            ErrorMessage = "error_message",
        };
        value.Validate();
    }

    [Fact]
    public void ToolSearchToolSearchResultBlockValidationWorks()
    {
        ToolSearchToolResultBlockContent value = new ToolSearchToolSearchResultBlock(
            [new("tool_name")]
        );
        value.Validate();
    }

    [Fact]
    public void ToolSearchToolResultErrorSerializationRoundtripWorks()
    {
        ToolSearchToolResultBlockContent value = new ToolSearchToolResultError()
        {
            ErrorCode = ToolSearchToolResultErrorCode.InvalidToolInput,
            ErrorMessage = "error_message",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolSearchToolResultBlockContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ToolSearchToolSearchResultBlockSerializationRoundtripWorks()
    {
        ToolSearchToolResultBlockContent value = new ToolSearchToolSearchResultBlock(
            [new("tool_name")]
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolSearchToolResultBlockContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
