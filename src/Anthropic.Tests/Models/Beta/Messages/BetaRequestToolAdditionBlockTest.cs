using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaRequestToolAdditionBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaRequestToolAdditionBlock
        {
            Tool = new BetaToolChangeToolReference("name"),
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };

        BetaRequestToolAdditionBlockTool expectedTool = new BetaToolChangeToolReference("name");
        JsonElement expectedType = JsonSerializer.SerializeToElement("tool_addition");
        BetaCacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };

        Assert.Equal(expectedTool, model.Tool);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedCacheControl, model.CacheControl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaRequestToolAdditionBlock
        {
            Tool = new BetaToolChangeToolReference("name"),
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRequestToolAdditionBlock>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaRequestToolAdditionBlock
        {
            Tool = new BetaToolChangeToolReference("name"),
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRequestToolAdditionBlock>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaRequestToolAdditionBlockTool expectedTool = new BetaToolChangeToolReference("name");
        JsonElement expectedType = JsonSerializer.SerializeToElement("tool_addition");
        BetaCacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };

        Assert.Equal(expectedTool, deserialized.Tool);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedCacheControl, deserialized.CacheControl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaRequestToolAdditionBlock
        {
            Tool = new BetaToolChangeToolReference("name"),
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaRequestToolAdditionBlock
        {
            Tool = new BetaToolChangeToolReference("name"),
        };

        Assert.Null(model.CacheControl);
        Assert.False(model.RawData.ContainsKey("cache_control"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaRequestToolAdditionBlock
        {
            Tool = new BetaToolChangeToolReference("name"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaRequestToolAdditionBlock
        {
            Tool = new BetaToolChangeToolReference("name"),

            CacheControl = null,
        };

        Assert.Null(model.CacheControl);
        Assert.True(model.RawData.ContainsKey("cache_control"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaRequestToolAdditionBlock
        {
            Tool = new BetaToolChangeToolReference("name"),

            CacheControl = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaRequestToolAdditionBlock
        {
            Tool = new BetaToolChangeToolReference("name"),
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };

        BetaRequestToolAdditionBlock copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaRequestToolAdditionBlockToolTest : TestBase
{
    [Fact]
    public void BetaToolChangeToolReferenceValidationWorks()
    {
        BetaRequestToolAdditionBlockTool value = new BetaToolChangeToolReference("name");
        value.Validate();
    }

    [Fact]
    public void BetaToolChangeMcpToolReferenceValidationWorks()
    {
        BetaRequestToolAdditionBlockTool value = new BetaToolChangeMcpToolReference()
        {
            Name = "name",
            ServerName = "server_name",
        };
        value.Validate();
    }

    [Fact]
    public void BetaToolChangeMcpToolsetReferenceValidationWorks()
    {
        BetaRequestToolAdditionBlockTool value = new BetaToolChangeMcpToolsetReference(
            "server_name"
        );
        value.Validate();
    }

    [Fact]
    public void BetaToolChangeToolReferenceSerializationRoundtripWorks()
    {
        BetaRequestToolAdditionBlockTool value = new BetaToolChangeToolReference("name");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRequestToolAdditionBlockTool>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaToolChangeMcpToolReferenceSerializationRoundtripWorks()
    {
        BetaRequestToolAdditionBlockTool value = new BetaToolChangeMcpToolReference()
        {
            Name = "name",
            ServerName = "server_name",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRequestToolAdditionBlockTool>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaToolChangeMcpToolsetReferenceSerializationRoundtripWorks()
    {
        BetaRequestToolAdditionBlockTool value = new BetaToolChangeMcpToolsetReference(
            "server_name"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRequestToolAdditionBlockTool>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
