using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaRequestToolRemovalBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaRequestToolRemovalBlock
        {
            Tool = new BetaToolChangeToolReference("name"),
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };

        BetaRequestToolRemovalBlockTool expectedTool = new BetaToolChangeToolReference("name");
        JsonElement expectedType = JsonSerializer.SerializeToElement("tool_removal");
        BetaCacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };

        Assert.Equal(expectedTool, model.Tool);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedCacheControl, model.CacheControl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaRequestToolRemovalBlock
        {
            Tool = new BetaToolChangeToolReference("name"),
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRequestToolRemovalBlock>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaRequestToolRemovalBlock
        {
            Tool = new BetaToolChangeToolReference("name"),
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRequestToolRemovalBlock>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BetaRequestToolRemovalBlockTool expectedTool = new BetaToolChangeToolReference("name");
        JsonElement expectedType = JsonSerializer.SerializeToElement("tool_removal");
        BetaCacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };

        Assert.Equal(expectedTool, deserialized.Tool);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedCacheControl, deserialized.CacheControl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaRequestToolRemovalBlock
        {
            Tool = new BetaToolChangeToolReference("name"),
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaRequestToolRemovalBlock
        {
            Tool = new BetaToolChangeToolReference("name"),
        };

        Assert.Null(model.CacheControl);
        Assert.False(model.RawData.ContainsKey("cache_control"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaRequestToolRemovalBlock
        {
            Tool = new BetaToolChangeToolReference("name"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaRequestToolRemovalBlock
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
        var model = new BetaRequestToolRemovalBlock
        {
            Tool = new BetaToolChangeToolReference("name"),

            CacheControl = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaRequestToolRemovalBlock
        {
            Tool = new BetaToolChangeToolReference("name"),
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };

        BetaRequestToolRemovalBlock copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaRequestToolRemovalBlockToolTest : TestBase
{
    [Fact]
    public void BetaToolChangeToolReferenceValidationWorks()
    {
        BetaRequestToolRemovalBlockTool value = new BetaToolChangeToolReference("name");
        value.Validate();
    }

    [Fact]
    public void BetaToolChangeMcpToolReferenceValidationWorks()
    {
        BetaRequestToolRemovalBlockTool value = new BetaToolChangeMcpToolReference()
        {
            Name = "name",
            ServerName = "server_name",
        };
        value.Validate();
    }

    [Fact]
    public void BetaToolChangeMcpToolsetReferenceValidationWorks()
    {
        BetaRequestToolRemovalBlockTool value = new BetaToolChangeMcpToolsetReference(
            "server_name"
        );
        value.Validate();
    }

    [Fact]
    public void BetaToolChangeToolReferenceSerializationRoundtripWorks()
    {
        BetaRequestToolRemovalBlockTool value = new BetaToolChangeToolReference("name");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRequestToolRemovalBlockTool>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaToolChangeMcpToolReferenceSerializationRoundtripWorks()
    {
        BetaRequestToolRemovalBlockTool value = new BetaToolChangeMcpToolReference()
        {
            Name = "name",
            ServerName = "server_name",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRequestToolRemovalBlockTool>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaToolChangeMcpToolsetReferenceSerializationRoundtripWorks()
    {
        BetaRequestToolRemovalBlockTool value = new BetaToolChangeMcpToolsetReference(
            "server_name"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRequestToolRemovalBlockTool>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
