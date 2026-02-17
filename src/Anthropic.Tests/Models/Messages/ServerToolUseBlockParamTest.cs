using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ServerToolUseBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ServerToolUseBlockParam
        {
            ID = "srvtoolu_SQfNkl1n_JR_",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = ServerToolUseBlockParamName.WebSearch,
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caller = new DirectCaller(),
        };

        string expectedID = "srvtoolu_SQfNkl1n_JR_";
        Dictionary<string, JsonElement> expectedInput = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        ApiEnum<string, ServerToolUseBlockParamName> expectedName =
            ServerToolUseBlockParamName.WebSearch;
        JsonElement expectedType = JsonSerializer.SerializeToElement("server_tool_use");
        CacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        ServerToolUseBlockParamCaller expectedCaller = new DirectCaller();

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedInput.Count, model.Input.Count);
        foreach (var item in expectedInput)
        {
            Assert.True(model.Input.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, model.Input[item.Key]));
        }
        Assert.Equal(expectedName, model.Name);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedCacheControl, model.CacheControl);
        Assert.Equal(expectedCaller, model.Caller);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ServerToolUseBlockParam
        {
            ID = "srvtoolu_SQfNkl1n_JR_",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = ServerToolUseBlockParamName.WebSearch,
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caller = new DirectCaller(),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ServerToolUseBlockParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ServerToolUseBlockParam
        {
            ID = "srvtoolu_SQfNkl1n_JR_",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = ServerToolUseBlockParamName.WebSearch,
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caller = new DirectCaller(),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ServerToolUseBlockParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "srvtoolu_SQfNkl1n_JR_";
        Dictionary<string, JsonElement> expectedInput = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        ApiEnum<string, ServerToolUseBlockParamName> expectedName =
            ServerToolUseBlockParamName.WebSearch;
        JsonElement expectedType = JsonSerializer.SerializeToElement("server_tool_use");
        CacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        ServerToolUseBlockParamCaller expectedCaller = new DirectCaller();

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedInput.Count, deserialized.Input.Count);
        foreach (var item in expectedInput)
        {
            Assert.True(deserialized.Input.TryGetValue(item.Key, out var value));

            Assert.True(JsonElement.DeepEquals(value, deserialized.Input[item.Key]));
        }
        Assert.Equal(expectedName, deserialized.Name);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedCacheControl, deserialized.CacheControl);
        Assert.Equal(expectedCaller, deserialized.Caller);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ServerToolUseBlockParam
        {
            ID = "srvtoolu_SQfNkl1n_JR_",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = ServerToolUseBlockParamName.WebSearch,
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caller = new DirectCaller(),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ServerToolUseBlockParam
        {
            ID = "srvtoolu_SQfNkl1n_JR_",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = ServerToolUseBlockParamName.WebSearch,
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };

        Assert.Null(model.Caller);
        Assert.False(model.RawData.ContainsKey("caller"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ServerToolUseBlockParam
        {
            ID = "srvtoolu_SQfNkl1n_JR_",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = ServerToolUseBlockParamName.WebSearch,
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ServerToolUseBlockParam
        {
            ID = "srvtoolu_SQfNkl1n_JR_",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = ServerToolUseBlockParamName.WebSearch,
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
        var model = new ServerToolUseBlockParam
        {
            ID = "srvtoolu_SQfNkl1n_JR_",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = ServerToolUseBlockParamName.WebSearch,
            CacheControl = new() { Ttl = Ttl.Ttl5m },

            // Null should be interpreted as omitted for these properties
            Caller = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ServerToolUseBlockParam
        {
            ID = "srvtoolu_SQfNkl1n_JR_",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = ServerToolUseBlockParamName.WebSearch,
            Caller = new DirectCaller(),
        };

        Assert.Null(model.CacheControl);
        Assert.False(model.RawData.ContainsKey("cache_control"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ServerToolUseBlockParam
        {
            ID = "srvtoolu_SQfNkl1n_JR_",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = ServerToolUseBlockParamName.WebSearch,
            Caller = new DirectCaller(),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ServerToolUseBlockParam
        {
            ID = "srvtoolu_SQfNkl1n_JR_",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = ServerToolUseBlockParamName.WebSearch,
            Caller = new DirectCaller(),

            CacheControl = null,
        };

        Assert.Null(model.CacheControl);
        Assert.True(model.RawData.ContainsKey("cache_control"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ServerToolUseBlockParam
        {
            ID = "srvtoolu_SQfNkl1n_JR_",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = ServerToolUseBlockParamName.WebSearch,
            Caller = new DirectCaller(),

            CacheControl = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ServerToolUseBlockParam
        {
            ID = "srvtoolu_SQfNkl1n_JR_",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = ServerToolUseBlockParamName.WebSearch,
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caller = new DirectCaller(),
        };

        ServerToolUseBlockParam copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ServerToolUseBlockParamNameTest : TestBase
{
    [Theory]
    [InlineData(ServerToolUseBlockParamName.WebSearch)]
    [InlineData(ServerToolUseBlockParamName.WebFetch)]
    [InlineData(ServerToolUseBlockParamName.CodeExecution)]
    [InlineData(ServerToolUseBlockParamName.BashCodeExecution)]
    [InlineData(ServerToolUseBlockParamName.TextEditorCodeExecution)]
    [InlineData(ServerToolUseBlockParamName.ToolSearchToolRegex)]
    [InlineData(ServerToolUseBlockParamName.ToolSearchToolBm25)]
    public void Validation_Works(ServerToolUseBlockParamName rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ServerToolUseBlockParamName> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ServerToolUseBlockParamName>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ServerToolUseBlockParamName.WebSearch)]
    [InlineData(ServerToolUseBlockParamName.WebFetch)]
    [InlineData(ServerToolUseBlockParamName.CodeExecution)]
    [InlineData(ServerToolUseBlockParamName.BashCodeExecution)]
    [InlineData(ServerToolUseBlockParamName.TextEditorCodeExecution)]
    [InlineData(ServerToolUseBlockParamName.ToolSearchToolRegex)]
    [InlineData(ServerToolUseBlockParamName.ToolSearchToolBm25)]
    public void SerializationRoundtrip_Works(ServerToolUseBlockParamName rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ServerToolUseBlockParamName> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ServerToolUseBlockParamName>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ServerToolUseBlockParamName>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ServerToolUseBlockParamName>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ServerToolUseBlockParamCallerTest : TestBase
{
    [Fact]
    public void DirectValidationWorks()
    {
        ServerToolUseBlockParamCaller value = new DirectCaller();
        value.Validate();
    }

    [Fact]
    public void ServerToolValidationWorks()
    {
        ServerToolUseBlockParamCaller value = new ServerToolCaller("srvtoolu_SQfNkl1n_JR_");
        value.Validate();
    }

    [Fact]
    public void CodeExecution20260120ValidationWorks()
    {
        ServerToolUseBlockParamCaller value =
            new ServerToolUseBlockParamCallerCodeExecution20260120("srvtoolu_SQfNkl1n_JR_");
        value.Validate();
    }

    [Fact]
    public void DirectSerializationRoundtripWorks()
    {
        ServerToolUseBlockParamCaller value = new DirectCaller();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ServerToolUseBlockParamCaller>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ServerToolSerializationRoundtripWorks()
    {
        ServerToolUseBlockParamCaller value = new ServerToolCaller("srvtoolu_SQfNkl1n_JR_");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ServerToolUseBlockParamCaller>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void CodeExecution20260120SerializationRoundtripWorks()
    {
        ServerToolUseBlockParamCaller value =
            new ServerToolUseBlockParamCallerCodeExecution20260120("srvtoolu_SQfNkl1n_JR_");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ServerToolUseBlockParamCaller>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ServerToolUseBlockParamCallerCodeExecution20260120Test : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ServerToolUseBlockParamCallerCodeExecution20260120
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
        var model = new ServerToolUseBlockParamCallerCodeExecution20260120
        {
            ToolID = "srvtoolu_SQfNkl1n_JR_",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ServerToolUseBlockParamCallerCodeExecution20260120>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ServerToolUseBlockParamCallerCodeExecution20260120
        {
            ToolID = "srvtoolu_SQfNkl1n_JR_",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ServerToolUseBlockParamCallerCodeExecution20260120>(
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
        var model = new ServerToolUseBlockParamCallerCodeExecution20260120
        {
            ToolID = "srvtoolu_SQfNkl1n_JR_",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ServerToolUseBlockParamCallerCodeExecution20260120
        {
            ToolID = "srvtoolu_SQfNkl1n_JR_",
        };

        ServerToolUseBlockParamCallerCodeExecution20260120 copied = new(model);

        Assert.Equal(model, copied);
    }
}
