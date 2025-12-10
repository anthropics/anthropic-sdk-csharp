using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaMCPToolResultBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaMCPToolResultBlock
        {
            Content = "string",
            IsError = true,
            ToolUseID = "tool_use_id",
        };

        BetaMCPToolResultBlockContent expectedContent = "string";
        bool expectedIsError = true;
        string expectedToolUseID = "tool_use_id";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"mcp_tool_result\"");

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedIsError, model.IsError);
        Assert.Equal(expectedToolUseID, model.ToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaMCPToolResultBlock
        {
            Content = "string",
            IsError = true,
            ToolUseID = "tool_use_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaMCPToolResultBlock>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaMCPToolResultBlock
        {
            Content = "string",
            IsError = true,
            ToolUseID = "tool_use_id",
        };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaMCPToolResultBlock>(json);
        Assert.NotNull(deserialized);

        BetaMCPToolResultBlockContent expectedContent = "string";
        bool expectedIsError = true;
        string expectedToolUseID = "tool_use_id";
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>("\"mcp_tool_result\"");

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedIsError, deserialized.IsError);
        Assert.Equal(expectedToolUseID, deserialized.ToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaMCPToolResultBlock
        {
            Content = "string",
            IsError = true,
            ToolUseID = "tool_use_id",
        };

        model.Validate();
    }
}

public class BetaMCPToolResultBlockContentTest : TestBase
{
    [Fact]
    public void stringValidation_Works()
    {
        BetaMCPToolResultBlockContent value = new("string");
        value.Validate();
    }

    [Fact]
    public void beta_mcp_tool_result_blockValidation_Works()
    {
        BetaMCPToolResultBlockContent value = new(
            [
                new()
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
    public void stringSerializationRoundtrip_Works()
    {
        BetaMCPToolResultBlockContent value = new("string");
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaMCPToolResultBlockContent>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void beta_mcp_tool_result_blockSerializationRoundtrip_Works()
    {
        BetaMCPToolResultBlockContent value = new(
            [
                new()
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
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<BetaMCPToolResultBlockContent>(json);

        Assert.Equal(value, deserialized);
    }
}
