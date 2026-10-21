using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaCompactionBlockParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaCompactionBlockParam
        {
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Content = "content",
            EncryptedContent = "encrypted_content",
            Signature = "signature",
            ToolChanges =
            [
                new BetaRequestToolAdditionBlock()
                {
                    Tool = new BetaToolChangeToolReference("name"),
                    CacheControl = new() { Ttl = Ttl.Ttl5m },
                },
            ],
        };

        JsonElement expectedType = JsonSerializer.SerializeToElement("compaction");
        BetaCacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        string expectedContent = "content";
        string expectedEncryptedContent = "encrypted_content";
        string expectedSignature = "signature";
        List<BetaCompactionBlockParamToolChange> expectedToolChanges =
        [
            new BetaRequestToolAdditionBlock()
            {
                Tool = new BetaToolChangeToolReference("name"),
                CacheControl = new() { Ttl = Ttl.Ttl5m },
            },
        ];

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedCacheControl, model.CacheControl);
        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedEncryptedContent, model.EncryptedContent);
        Assert.Equal(expectedSignature, model.Signature);
        Assert.NotNull(model.ToolChanges);
        Assert.Equal(expectedToolChanges.Count, model.ToolChanges.Count);
        for (int i = 0; i < expectedToolChanges.Count; i++)
        {
            Assert.Equal(expectedToolChanges[i], model.ToolChanges[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaCompactionBlockParam
        {
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Content = "content",
            EncryptedContent = "encrypted_content",
            Signature = "signature",
            ToolChanges =
            [
                new BetaRequestToolAdditionBlock()
                {
                    Tool = new BetaToolChangeToolReference("name"),
                    CacheControl = new() { Ttl = Ttl.Ttl5m },
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaCompactionBlockParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaCompactionBlockParam
        {
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Content = "content",
            EncryptedContent = "encrypted_content",
            Signature = "signature",
            ToolChanges =
            [
                new BetaRequestToolAdditionBlock()
                {
                    Tool = new BetaToolChangeToolReference("name"),
                    CacheControl = new() { Ttl = Ttl.Ttl5m },
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaCompactionBlockParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.SerializeToElement("compaction");
        BetaCacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };
        string expectedContent = "content";
        string expectedEncryptedContent = "encrypted_content";
        string expectedSignature = "signature";
        List<BetaCompactionBlockParamToolChange> expectedToolChanges =
        [
            new BetaRequestToolAdditionBlock()
            {
                Tool = new BetaToolChangeToolReference("name"),
                CacheControl = new() { Ttl = Ttl.Ttl5m },
            },
        ];

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedCacheControl, deserialized.CacheControl);
        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedEncryptedContent, deserialized.EncryptedContent);
        Assert.Equal(expectedSignature, deserialized.Signature);
        Assert.NotNull(deserialized.ToolChanges);
        Assert.Equal(expectedToolChanges.Count, deserialized.ToolChanges.Count);
        for (int i = 0; i < expectedToolChanges.Count; i++)
        {
            Assert.Equal(expectedToolChanges[i], deserialized.ToolChanges[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaCompactionBlockParam
        {
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Content = "content",
            EncryptedContent = "encrypted_content",
            Signature = "signature",
            ToolChanges =
            [
                new BetaRequestToolAdditionBlock()
                {
                    Tool = new BetaToolChangeToolReference("name"),
                    CacheControl = new() { Ttl = Ttl.Ttl5m },
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaCompactionBlockParam { };

        Assert.Null(model.CacheControl);
        Assert.False(model.RawData.ContainsKey("cache_control"));
        Assert.Null(model.Content);
        Assert.False(model.RawData.ContainsKey("content"));
        Assert.Null(model.EncryptedContent);
        Assert.False(model.RawData.ContainsKey("encrypted_content"));
        Assert.Null(model.Signature);
        Assert.False(model.RawData.ContainsKey("signature"));
        Assert.Null(model.ToolChanges);
        Assert.False(model.RawData.ContainsKey("tool_changes"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaCompactionBlockParam { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaCompactionBlockParam
        {
            CacheControl = null,
            Content = null,
            EncryptedContent = null,
            Signature = null,
            ToolChanges = null,
        };

        Assert.Null(model.CacheControl);
        Assert.True(model.RawData.ContainsKey("cache_control"));
        Assert.Null(model.Content);
        Assert.True(model.RawData.ContainsKey("content"));
        Assert.Null(model.EncryptedContent);
        Assert.True(model.RawData.ContainsKey("encrypted_content"));
        Assert.Null(model.Signature);
        Assert.True(model.RawData.ContainsKey("signature"));
        Assert.Null(model.ToolChanges);
        Assert.True(model.RawData.ContainsKey("tool_changes"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaCompactionBlockParam
        {
            CacheControl = null,
            Content = null,
            EncryptedContent = null,
            Signature = null,
            ToolChanges = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaCompactionBlockParam
        {
            CacheControl = new() { Ttl = Ttl.Ttl5m },
            Content = "content",
            EncryptedContent = "encrypted_content",
            Signature = "signature",
            ToolChanges =
            [
                new BetaRequestToolAdditionBlock()
                {
                    Tool = new BetaToolChangeToolReference("name"),
                    CacheControl = new() { Ttl = Ttl.Ttl5m },
                },
            ],
        };

        BetaCompactionBlockParam copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaCompactionBlockParamToolChangeTest : TestBase
{
    [Fact]
    public void BetaRequestToolAdditionBlockValidationWorks()
    {
        BetaCompactionBlockParamToolChange value = new BetaRequestToolAdditionBlock()
        {
            Tool = new BetaToolChangeToolReference("name"),
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };
        value.Validate();
    }

    [Fact]
    public void BetaRequestToolRemovalBlockValidationWorks()
    {
        BetaCompactionBlockParamToolChange value = new BetaRequestToolRemovalBlock()
        {
            Tool = new BetaToolChangeToolReference("name"),
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };
        value.Validate();
    }

    [Fact]
    public void BetaRequestToolAdditionBlockSerializationRoundtripWorks()
    {
        BetaCompactionBlockParamToolChange value = new BetaRequestToolAdditionBlock()
        {
            Tool = new BetaToolChangeToolReference("name"),
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaCompactionBlockParamToolChange>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaRequestToolRemovalBlockSerializationRoundtripWorks()
    {
        BetaCompactionBlockParamToolChange value = new BetaRequestToolRemovalBlock()
        {
            Tool = new BetaToolChangeToolReference("name"),
            CacheControl = new() { Ttl = Ttl.Ttl5m },
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaCompactionBlockParamToolChange>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaCompactionBlockParamToolChange value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "tool_addition",
                  "cache_control": {
                    "type": "ephemeral",
                    "ttl": "5m"
                  }
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        JsonElement expectedType = JsonSerializer.SerializeToElement("tool_addition");
        BetaCacheControlEphemeral expectedCacheControl = new() { Ttl = Ttl.Ttl5m };

        Assert.True(JsonElement.DeepEquals(expectedType, value.Type));
        Assert.Equal(expectedCacheControl, value.CacheControl);

        BetaCompactionBlockParamToolChange emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
        Assert.Null(emptyValue.CacheControl);

        BetaCompactionBlockParamToolChange mismatchedValue = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "cache_control": [
                    "invalid"
                  ]
                }
                """
            )
        );

        Assert.Null(mismatchedValue.CacheControl);
    }
}
