using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models;

namespace Anthropic.Tests.Models;

public class ClaudeCodeKeyCreatorNotMemberErrorDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ClaudeCodeKeyCreatorNotMemberErrorDetails { };

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "claude_code_key_creator_not_member"
        );

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, model.ErrorCode));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ClaudeCodeKeyCreatorNotMemberErrorDetails { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClaudeCodeKeyCreatorNotMemberErrorDetails>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ClaudeCodeKeyCreatorNotMemberErrorDetails { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ClaudeCodeKeyCreatorNotMemberErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "claude_code_key_creator_not_member"
        );

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, deserialized.ErrorCode));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ClaudeCodeKeyCreatorNotMemberErrorDetails { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ClaudeCodeKeyCreatorNotMemberErrorDetails { };

        ClaudeCodeKeyCreatorNotMemberErrorDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}
