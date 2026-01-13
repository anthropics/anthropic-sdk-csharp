using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaMcpToolResultBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaMcpToolResultBlock
        {
            Content = "string",
            IsError = true,
            ToolUseID = "tool_use_id",
        };

        BetaMcpToolResultBlockContent expectedContent = "string";
        bool expectedIsError = true;
        string expectedToolUseID = "tool_use_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("mcp_tool_result");

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedIsError, model.IsError);
        Assert.Equal(expectedToolUseID, model.ToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaMcpToolResultBlock
        {
            Content = "string",
            IsError = true,
            ToolUseID = "tool_use_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaMcpToolResultBlock>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaMcpToolResultBlock
        {
            Content = "string",
            IsError = true,
            ToolUseID = "tool_use_id",
        };

        string element = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaMcpToolResultBlock>(element);
        Assert.NotNull(deserialized);

        BetaMcpToolResultBlockContent expectedContent = "string";
        bool expectedIsError = true;
        string expectedToolUseID = "tool_use_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("mcp_tool_result");

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedIsError, deserialized.IsError);
        Assert.Equal(expectedToolUseID, deserialized.ToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaMcpToolResultBlock
        {
            Content = "string",
            IsError = true,
            ToolUseID = "tool_use_id",
        };

        model.Validate();
    }
}

public class BetaMcpToolResultBlockContentTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        BetaMcpToolResultBlockContent value = "string";
        value.Validate();
    }

    [Fact]
    public void BetaMcpToolResultBlockValidationWorks()
    {
        BetaMcpToolResultBlockContent value = new(
            [
                new BetaTextBlock()
                {
                    Citations =
                    [
                        new BetaCitationCharLocation()
                        {
                            CitedText = "cited_text",
                            DocumentIndex = 0,
                            DocumentTitle = "document_title",
                            EndCharIndex = 0,
                            FileID = "file_id",
                            StartCharIndex = 0,
                        },
                    ],
                    Text = "text",
                },
            ]
        );
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        BetaMcpToolResultBlockContent value = "string";
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaMcpToolResultBlockContent>(element);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaMcpToolResultBlockSerializationRoundtripWorks()
    {
        BetaMcpToolResultBlockContent value = new(
            [
                new BetaTextBlock()
                {
                    Citations =
                    [
                        new BetaCitationCharLocation()
                        {
                            CitedText = "cited_text",
                            DocumentIndex = 0,
                            DocumentTitle = "document_title",
                            EndCharIndex = 0,
                            FileID = "file_id",
                            StartCharIndex = 0,
                        },
                    ],
                    Text = "text",
                },
            ]
        );
        string element = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaMcpToolResultBlockContent>(element);

        Assert.Equal(value, deserialized);
    }
}
