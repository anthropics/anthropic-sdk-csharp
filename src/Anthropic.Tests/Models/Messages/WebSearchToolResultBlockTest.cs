using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class WebSearchToolResultBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebSearchToolResultBlock
        {
            Caller = new DirectCaller(),
            Content = new WebSearchToolResultError(
                WebSearchToolResultErrorErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        WebSearchToolResultBlockCaller expectedCaller = new DirectCaller();
        WebSearchToolResultBlockContent expectedContent = new WebSearchToolResultError(
            WebSearchToolResultErrorErrorCode.InvalidToolInput
        );
        string expectedToolUseID = "srvtoolu_SQfNkl1n_JR_";
        JsonElement expectedType = JsonSerializer.SerializeToElement("web_search_tool_result");

        Assert.Equal(expectedCaller, model.Caller);
        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedToolUseID, model.ToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebSearchToolResultBlock
        {
            Caller = new DirectCaller(),
            Content = new WebSearchToolResultError(
                WebSearchToolResultErrorErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebSearchToolResultBlock>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebSearchToolResultBlock
        {
            Caller = new DirectCaller(),
            Content = new WebSearchToolResultError(
                WebSearchToolResultErrorErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebSearchToolResultBlock>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        WebSearchToolResultBlockCaller expectedCaller = new DirectCaller();
        WebSearchToolResultBlockContent expectedContent = new WebSearchToolResultError(
            WebSearchToolResultErrorErrorCode.InvalidToolInput
        );
        string expectedToolUseID = "srvtoolu_SQfNkl1n_JR_";
        JsonElement expectedType = JsonSerializer.SerializeToElement("web_search_tool_result");

        Assert.Equal(expectedCaller, deserialized.Caller);
        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedToolUseID, deserialized.ToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebSearchToolResultBlock
        {
            Caller = new DirectCaller(),
            Content = new WebSearchToolResultError(
                WebSearchToolResultErrorErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WebSearchToolResultBlock
        {
            Caller = new DirectCaller(),
            Content = new WebSearchToolResultError(
                WebSearchToolResultErrorErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        WebSearchToolResultBlock copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WebSearchToolResultBlockCallerTest : TestBase
{
    [Fact]
    public void DirectValidationWorks()
    {
        WebSearchToolResultBlockCaller value = new DirectCaller();
        value.Validate();
    }

    [Fact]
    public void ServerToolValidationWorks()
    {
        WebSearchToolResultBlockCaller value = new ServerToolCaller("srvtoolu_SQfNkl1n_JR_");
        value.Validate();
    }

    [Fact]
    public void CodeExecution20260120ValidationWorks()
    {
        WebSearchToolResultBlockCaller value =
            new WebSearchToolResultBlockCallerCodeExecution20260120("srvtoolu_SQfNkl1n_JR_");
        value.Validate();
    }

    [Fact]
    public void DirectSerializationRoundtripWorks()
    {
        WebSearchToolResultBlockCaller value = new DirectCaller();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebSearchToolResultBlockCaller>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ServerToolSerializationRoundtripWorks()
    {
        WebSearchToolResultBlockCaller value = new ServerToolCaller("srvtoolu_SQfNkl1n_JR_");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebSearchToolResultBlockCaller>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CodeExecution20260120SerializationRoundtripWorks()
    {
        WebSearchToolResultBlockCaller value =
            new WebSearchToolResultBlockCallerCodeExecution20260120("srvtoolu_SQfNkl1n_JR_");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebSearchToolResultBlockCaller>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class WebSearchToolResultBlockCallerCodeExecution20260120Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebSearchToolResultBlockCallerCodeExecution20260120
        {
            ToolID = "srvtoolu_SQfNkl1n_JR_",
        };

        string expectedToolID = "srvtoolu_SQfNkl1n_JR_";
        JsonElement expectedType = JsonSerializer.SerializeToElement("code_execution_20260120");

        Assert.Equal(expectedToolID, model.ToolID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebSearchToolResultBlockCallerCodeExecution20260120
        {
            ToolID = "srvtoolu_SQfNkl1n_JR_",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<WebSearchToolResultBlockCallerCodeExecution20260120>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebSearchToolResultBlockCallerCodeExecution20260120
        {
            ToolID = "srvtoolu_SQfNkl1n_JR_",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<WebSearchToolResultBlockCallerCodeExecution20260120>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedToolID = "srvtoolu_SQfNkl1n_JR_";
        JsonElement expectedType = JsonSerializer.SerializeToElement("code_execution_20260120");

        Assert.Equal(expectedToolID, deserialized.ToolID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebSearchToolResultBlockCallerCodeExecution20260120
        {
            ToolID = "srvtoolu_SQfNkl1n_JR_",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WebSearchToolResultBlockCallerCodeExecution20260120
        {
            ToolID = "srvtoolu_SQfNkl1n_JR_",
        };

        WebSearchToolResultBlockCallerCodeExecution20260120 copied = new(model);

        Assert.Equal(model, copied);
    }
}
