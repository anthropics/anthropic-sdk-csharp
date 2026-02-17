using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class WebFetchToolResultBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebFetchToolResultBlockParam
        {
            Content = new WebFetchToolResultErrorBlockParam(
                WebFetchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caller = new DirectCaller(),
        };

        WebFetchToolResultBlockParamContent expectedContent = new WebFetchToolResultErrorBlockParam(
            WebFetchToolResultErrorCode.InvalidToolInput
        );
        string expectedToolUseID = "srvtoolu_SQfNkl1n_JR_";
        JsonElement expectedType = JsonSerializer.SerializeToElement("web_fetch_tool_result");
        CacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        WebFetchToolResultBlockParamCaller expectedCaller = new DirectCaller();

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedToolUseID, model.ToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedCacheControl, model.CacheControl);
        Assert.Equal(expectedCaller, model.Caller);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WebFetchToolResultBlockParam
        {
            Content = new WebFetchToolResultErrorBlockParam(
                WebFetchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caller = new DirectCaller(),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebFetchToolResultBlockParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebFetchToolResultBlockParam
        {
            Content = new WebFetchToolResultErrorBlockParam(
                WebFetchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caller = new DirectCaller(),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebFetchToolResultBlockParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        WebFetchToolResultBlockParamContent expectedContent = new WebFetchToolResultErrorBlockParam(
            WebFetchToolResultErrorCode.InvalidToolInput
        );
        string expectedToolUseID = "srvtoolu_SQfNkl1n_JR_";
        JsonElement expectedType = JsonSerializer.SerializeToElement("web_fetch_tool_result");
        CacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        WebFetchToolResultBlockParamCaller expectedCaller = new DirectCaller();

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedToolUseID, deserialized.ToolUseID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedCacheControl, deserialized.CacheControl);
        Assert.Equal(expectedCaller, deserialized.Caller);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WebFetchToolResultBlockParam
        {
            Content = new WebFetchToolResultErrorBlockParam(
                WebFetchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caller = new DirectCaller(),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WebFetchToolResultBlockParam
        {
            Content = new WebFetchToolResultErrorBlockParam(
                WebFetchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };

        Assert.Null(model.Caller);
        Assert.False(model.RawData.ContainsKey("caller"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new WebFetchToolResultBlockParam
        {
            Content = new WebFetchToolResultErrorBlockParam(
                WebFetchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new WebFetchToolResultBlockParam
        {
            Content = new WebFetchToolResultErrorBlockParam(
                WebFetchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { Ttl = Ttl.Ttl5m },

            // Null should be interpreted as omitted for these properties
            Caller = null,
        };

        Assert.Null(model.Caller);
        Assert.False(model.RawData.ContainsKey("caller"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WebFetchToolResultBlockParam
        {
            Content = new WebFetchToolResultErrorBlockParam(
                WebFetchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { Ttl = Ttl.Ttl5m },

            // Null should be interpreted as omitted for these properties
            Caller = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new WebFetchToolResultBlockParam
        {
            Content = new WebFetchToolResultErrorBlockParam(
                WebFetchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            Caller = new DirectCaller(),
        };

        Assert.Null(model.CacheControl);
        Assert.False(model.RawData.ContainsKey("cache_control"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new WebFetchToolResultBlockParam
        {
            Content = new WebFetchToolResultErrorBlockParam(
                WebFetchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            Caller = new DirectCaller(),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new WebFetchToolResultBlockParam
        {
            Content = new WebFetchToolResultErrorBlockParam(
                WebFetchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            Caller = new DirectCaller(),

            CacheControl = null,
        };

        Assert.Null(model.CacheControl);
        Assert.True(model.RawData.ContainsKey("cache_control"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new WebFetchToolResultBlockParam
        {
            Content = new WebFetchToolResultErrorBlockParam(
                WebFetchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            Caller = new DirectCaller(),

            CacheControl = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WebFetchToolResultBlockParam
        {
            Content = new WebFetchToolResultErrorBlockParam(
                WebFetchToolResultErrorCode.InvalidToolInput
            ),
            ToolUseID = "srvtoolu_SQfNkl1n_JR_",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caller = new DirectCaller(),
        };

        WebFetchToolResultBlockParam copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class WebFetchToolResultBlockParamContentTest : TestBase
{
    [Fact]
    public void WebFetchToolResultErrorBlockParamValidationWorks()
    {
        WebFetchToolResultBlockParamContent value = new WebFetchToolResultErrorBlockParam(
            WebFetchToolResultErrorCode.InvalidToolInput
        );
        value.Validate();
    }

    [Fact]
    public void WebFetchBlockParamValidationWorks()
    {
        WebFetchToolResultBlockParamContent value = new WebFetchBlockParam()
        {
            Content = new()
            {
                Source = new Base64PdfSource("U3RhaW5sZXNzIHJvY2tz"),
                CacheControl = new() { Ttl = Ttl.Ttl5m },
                Citations = new() { Enabled = true },
                Context = "x",
                Title = "x",
            },
            Url = "url",
            RetrievedAt = "retrieved_at",
        };
        value.Validate();
    }

    [Fact]
    public void WebFetchToolResultErrorBlockParamSerializationRoundtripWorks()
    {
        WebFetchToolResultBlockParamContent value = new WebFetchToolResultErrorBlockParam(
            WebFetchToolResultErrorCode.InvalidToolInput
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebFetchToolResultBlockParamContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void WebFetchBlockParamSerializationRoundtripWorks()
    {
        WebFetchToolResultBlockParamContent value = new WebFetchBlockParam()
        {
            Content = new()
            {
                Source = new Base64PdfSource("U3RhaW5sZXNzIHJvY2tz"),
                CacheControl = new() { Ttl = Ttl.Ttl5m },
                Citations = new() { Enabled = true },
                Context = "x",
                Title = "x",
            },
            Url = "url",
            RetrievedAt = "retrieved_at",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebFetchToolResultBlockParamContent>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class WebFetchToolResultBlockParamCallerTest : TestBase
{
    [Fact]
    public void DirectValidationWorks()
    {
        WebFetchToolResultBlockParamCaller value = new DirectCaller();
        value.Validate();
    }

    [Fact]
    public void ServerToolValidationWorks()
    {
        WebFetchToolResultBlockParamCaller value = new ServerToolCaller("srvtoolu_SQfNkl1n_JR_");
        value.Validate();
    }

    [Fact]
    public void CodeExecution20260120ValidationWorks()
    {
        WebFetchToolResultBlockParamCaller value =
            new WebFetchToolResultBlockParamCallerCodeExecution20260120("srvtoolu_SQfNkl1n_JR_");
        value.Validate();
    }

    [Fact]
    public void DirectSerializationRoundtripWorks()
    {
        WebFetchToolResultBlockParamCaller value = new DirectCaller();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebFetchToolResultBlockParamCaller>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ServerToolSerializationRoundtripWorks()
    {
        WebFetchToolResultBlockParamCaller value = new ServerToolCaller("srvtoolu_SQfNkl1n_JR_");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebFetchToolResultBlockParamCaller>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CodeExecution20260120SerializationRoundtripWorks()
    {
        WebFetchToolResultBlockParamCaller value =
            new WebFetchToolResultBlockParamCallerCodeExecution20260120("srvtoolu_SQfNkl1n_JR_");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WebFetchToolResultBlockParamCaller>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class WebFetchToolResultBlockParamCallerCodeExecution20260120Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WebFetchToolResultBlockParamCallerCodeExecution20260120
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
        var model = new WebFetchToolResultBlockParamCallerCodeExecution20260120
        {
            ToolID = "srvtoolu_SQfNkl1n_JR_",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<WebFetchToolResultBlockParamCallerCodeExecution20260120>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WebFetchToolResultBlockParamCallerCodeExecution20260120
        {
            ToolID = "srvtoolu_SQfNkl1n_JR_",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<WebFetchToolResultBlockParamCallerCodeExecution20260120>(
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
        var model = new WebFetchToolResultBlockParamCallerCodeExecution20260120
        {
            ToolID = "srvtoolu_SQfNkl1n_JR_",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WebFetchToolResultBlockParamCallerCodeExecution20260120
        {
            ToolID = "srvtoolu_SQfNkl1n_JR_",
        };

        WebFetchToolResultBlockParamCallerCodeExecution20260120 copied = new(model);

        Assert.Equal(model, copied);
    }
}
