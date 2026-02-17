using System.Text.Json;
using Anthropic.Core;
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
            Caller = new BetaDirectCaller(),
        };

        BetaWebFetchToolResultBlockContent expectedContent = new BetaWebFetchToolResultErrorBlock(
            BetaWebFetchToolResultErrorCode.InvalidToolInput
        );
        string expectedToolUseID = "srvtoolu_SQfNkl1n_JR_";
        JsonElement expectedType = JsonSerializer.SerializeToElement("web_fetch_tool_result");
        BetaWebFetchToolResultBlockCaller expectedCaller = new BetaDirectCaller();

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedToolUseID, model.ToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedCaller, model.Caller);
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
            Caller = new BetaDirectCaller(),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebFetchToolResultBlock>(
            json,
            ModelBase.SerializerOptions
        );

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
            Caller = new BetaDirectCaller(),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebFetchToolResultBlock>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaWebFetchToolResultBlockContent expectedContent = new BetaWebFetchToolResultErrorBlock(
            BetaWebFetchToolResultErrorCode.InvalidToolInput
        );
        string expectedToolUseID = "srvtoolu_SQfNkl1n_JR_";
        JsonElement expectedType = JsonSerializer.SerializeToElement("web_fetch_tool_result");
        BetaWebFetchToolResultBlockCaller expectedCaller = new BetaDirectCaller();

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedToolUseID, deserialized.ToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedCaller, deserialized.Caller);
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
            Caller = new BetaDirectCaller(),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaWebFetchToolResultBlock
        {
            Content = new BetaWebFetchToolResultErrorBlock(
                BetaWebFetchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
        };

        Assert.Null(model.Caller);
        Assert.False(model.RawData.ContainsKey("caller"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
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

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaWebFetchToolResultBlock
        {
            Content = new BetaWebFetchToolResultErrorBlock(
                BetaWebFetchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",

            // Null should be interpreted as omitted for these properties
            Caller = null,
        };

        Assert.Null(model.Caller);
        Assert.False(model.RawData.ContainsKey("caller"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaWebFetchToolResultBlock
        {
            Content = new BetaWebFetchToolResultErrorBlock(
                BetaWebFetchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",

            // Null should be interpreted as omitted for these properties
            Caller = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaWebFetchToolResultBlock
        {
            Content = new BetaWebFetchToolResultErrorBlock(
                BetaWebFetchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            Caller = new BetaDirectCaller(),
        };

        BetaWebFetchToolResultBlock copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaWebFetchToolResultBlockContentTest : TestBase
{
    [Fact]
    public void BetaWebFetchToolResultErrorBlockValidationWorks()
    {
        BetaWebFetchToolResultBlockContent value = new BetaWebFetchToolResultErrorBlock(
            BetaWebFetchToolResultErrorCode.InvalidToolInput
        );
        value.Validate();
    }

    [Fact]
    public void BetaWebFetchBlockValidationWorks()
    {
        BetaWebFetchToolResultBlockContent value = new BetaWebFetchBlock()
        {
            Content = new()
            {
                Citations = new(true),
                Source = new BetaBase64PdfSource("U3RhaW5sZXNzIHJvY2tz"),
                Title = "title",
            },
            RetrievedAt = "retrieved_at",
            Url = "url",
        };
        value.Validate();
    }

    [Fact]
    public void BetaWebFetchToolResultErrorBlockSerializationRoundtripWorks()
    {
        BetaWebFetchToolResultBlockContent value = new BetaWebFetchToolResultErrorBlock(
            BetaWebFetchToolResultErrorCode.InvalidToolInput
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebFetchToolResultBlockContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaWebFetchBlockSerializationRoundtripWorks()
    {
        BetaWebFetchToolResultBlockContent value = new BetaWebFetchBlock()
        {
            Content = new()
            {
                Citations = new(true),
                Source = new BetaBase64PdfSource("U3RhaW5sZXNzIHJvY2tz"),
                Title = "title",
            },
            RetrievedAt = "retrieved_at",
            Url = "url",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebFetchToolResultBlockContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class BetaWebFetchToolResultBlockCallerTest : TestBase
{
    [Fact]
    public void BetaDirectValidationWorks()
    {
        BetaWebFetchToolResultBlockCaller value = new BetaDirectCaller();
        value.Validate();
    }

    [Fact]
    public void BetaServerToolValidationWorks()
    {
        BetaWebFetchToolResultBlockCaller value = new BetaServerToolCaller("srvtoolu_SQfNkl1n_JR_");
        value.Validate();
    }

    [Fact]
    public void BetaServerToolCaller20260120ValidationWorks()
    {
        BetaWebFetchToolResultBlockCaller value = new BetaServerToolCaller20260120(
            "srvtoolu_SQfNkl1n_JR_"
        );
        value.Validate();
    }

    [Fact]
    public void BetaDirectSerializationRoundtripWorks()
    {
        BetaWebFetchToolResultBlockCaller value = new BetaDirectCaller();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebFetchToolResultBlockCaller>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaServerToolSerializationRoundtripWorks()
    {
        BetaWebFetchToolResultBlockCaller value = new BetaServerToolCaller("srvtoolu_SQfNkl1n_JR_");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebFetchToolResultBlockCaller>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaServerToolCaller20260120SerializationRoundtripWorks()
    {
        BetaWebFetchToolResultBlockCaller value = new BetaServerToolCaller20260120(
            "srvtoolu_SQfNkl1n_JR_"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWebFetchToolResultBlockCaller>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
