using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaAdvisorToolResultBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAdvisorToolResultBlock
        {
            Content = new BetaAdvisorToolResultError(ErrorCode.MaxUsesExceeded),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        Content expectedContent = new BetaAdvisorToolResultError(ErrorCode.MaxUsesExceeded);
        string expectedToolUseID = "srvtoolu_SQfNkl1n_JR_";
        JsonElement expectedType = JsonSerializer.SerializeToElement("advisor_tool_result");

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedToolUseID, model.ToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAdvisorToolResultBlock
        {
            Content = new BetaAdvisorToolResultError(ErrorCode.MaxUsesExceeded),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAdvisorToolResultBlock>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAdvisorToolResultBlock
        {
            Content = new BetaAdvisorToolResultError(ErrorCode.MaxUsesExceeded),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaAdvisorToolResultBlock>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Content expectedContent = new BetaAdvisorToolResultError(ErrorCode.MaxUsesExceeded);
        string expectedToolUseID = "srvtoolu_SQfNkl1n_JR_";
        JsonElement expectedType = JsonSerializer.SerializeToElement("advisor_tool_result");

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedToolUseID, deserialized.ToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAdvisorToolResultBlock
        {
            Content = new BetaAdvisorToolResultError(ErrorCode.MaxUsesExceeded),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAdvisorToolResultBlock
        {
            Content = new BetaAdvisorToolResultError(ErrorCode.MaxUsesExceeded),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        BetaAdvisorToolResultBlock copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ContentTest : TestBase
{
    [Fact]
    public void BetaAdvisorToolResultErrorValidationWorks()
    {
        Content value = new BetaAdvisorToolResultError(ErrorCode.MaxUsesExceeded);
        value.Validate();
    }

    [Fact]
    public void BetaAdvisorResultBlockValidationWorks()
    {
        Content value = new BetaAdvisorResultBlock("text");
        value.Validate();
    }

    [Fact]
    public void BetaAdvisorRedactedResultBlockValidationWorks()
    {
        Content value = new BetaAdvisorRedactedResultBlock("encrypted_content");
        value.Validate();
    }

    [Fact]
    public void BetaAdvisorToolResultErrorSerializationRoundtripWorks()
    {
        Content value = new BetaAdvisorToolResultError(ErrorCode.MaxUsesExceeded);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Content>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaAdvisorResultBlockSerializationRoundtripWorks()
    {
        Content value = new BetaAdvisorResultBlock("text");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Content>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaAdvisorRedactedResultBlockSerializationRoundtripWorks()
    {
        Content value = new BetaAdvisorRedactedResultBlock("encrypted_content");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Content>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
