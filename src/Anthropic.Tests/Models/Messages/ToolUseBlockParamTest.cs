using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class ToolUseBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ToolUseBlockParam
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caller = new DirectCaller(),
            ToolsetName = "toolset_name",
        };

        string expectedID = "id";
        Dictionary<string, JsonElement> expectedInput = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedName = "x";
        JsonElement expectedType = JsonSerializer.SerializeToElement("tool_use");
        CacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        ToolUseBlockParamCaller expectedCaller = new DirectCaller();
        string expectedToolsetName = "toolset_name";

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
        Assert.Equal(expectedToolsetName, model.ToolsetName);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ToolUseBlockParam
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caller = new DirectCaller(),
            ToolsetName = "toolset_name",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolUseBlockParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ToolUseBlockParam
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caller = new DirectCaller(),
            ToolsetName = "toolset_name",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolUseBlockParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        Dictionary<string, JsonElement> expectedInput = new()
        {
            { "foo", JsonSerializer.SerializeToElement("bar") },
        };
        string expectedName = "x";
        JsonElement expectedType = JsonSerializer.SerializeToElement("tool_use");
        CacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        ToolUseBlockParamCaller expectedCaller = new DirectCaller();
        string expectedToolsetName = "toolset_name";

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
        Assert.Equal(expectedToolsetName, deserialized.ToolsetName);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ToolUseBlockParam
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caller = new DirectCaller(),
            ToolsetName = "toolset_name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ToolUseBlockParam
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            ToolsetName = "toolset_name",
        };

        Assert.Null(model.Caller);
        Assert.False(model.RawData.ContainsKey("caller"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ToolUseBlockParam
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            ToolsetName = "toolset_name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ToolUseBlockParam
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            ToolsetName = "toolset_name",

            // Null should be interpreted as omitted for these properties
            Caller = null,
        };

        Assert.Null(model.Caller);
        Assert.False(model.RawData.ContainsKey("caller"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ToolUseBlockParam
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            ToolsetName = "toolset_name",

            // Null should be interpreted as omitted for these properties
            Caller = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ToolUseBlockParam
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",
            Caller = new DirectCaller(),
        };

        Assert.Null(model.CacheControl);
        Assert.False(model.RawData.ContainsKey("cache_control"));
        Assert.Null(model.ToolsetName);
        Assert.False(model.RawData.ContainsKey("toolset_name"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ToolUseBlockParam
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",
            Caller = new DirectCaller(),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ToolUseBlockParam
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",
            Caller = new DirectCaller(),

            CacheControl = null,
            ToolsetName = null,
        };

        Assert.Null(model.CacheControl);
        Assert.True(model.RawData.ContainsKey("cache_control"));
        Assert.Null(model.ToolsetName);
        Assert.True(model.RawData.ContainsKey("toolset_name"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ToolUseBlockParam
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",
            Caller = new DirectCaller(),

            CacheControl = null,
            ToolsetName = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ToolUseBlockParam
        {
            ID = "id",
            Input = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Name = "x",
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Caller = new DirectCaller(),
            ToolsetName = "toolset_name",
        };

        ToolUseBlockParam copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ToolUseBlockParamCallerTest : TestBase
{
    [Fact]
    public void DirectValidationWorks()
    {
        ToolUseBlockParamCaller value = new DirectCaller();
        value.Validate();
    }

    [Fact]
    public void ServerToolValidationWorks()
    {
        ToolUseBlockParamCaller value = new ServerToolCaller("srvtoolu_SQfNkl1n_JR_");
        value.Validate();
    }

    [Fact]
    public void ServerToolCaller20260120ValidationWorks()
    {
        ToolUseBlockParamCaller value = new ServerToolCaller20260120("srvtoolu_SQfNkl1n_JR_");
        value.Validate();
    }

    [Fact]
    public void DirectSerializationRoundtripWorks()
    {
        ToolUseBlockParamCaller value = new DirectCaller();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolUseBlockParamCaller>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ServerToolSerializationRoundtripWorks()
    {
        ToolUseBlockParamCaller value = new ServerToolCaller("srvtoolu_SQfNkl1n_JR_");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolUseBlockParamCaller>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void ServerToolCaller20260120SerializationRoundtripWorks()
    {
        ToolUseBlockParamCaller value = new ServerToolCaller20260120("srvtoolu_SQfNkl1n_JR_");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolUseBlockParamCaller>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
