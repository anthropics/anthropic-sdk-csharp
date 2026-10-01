using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaCompactionBlockTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaCompactionBlock
        {
            Content = "content",
            EncryptedContent = "encrypted_content",
            Signature = "signature",
            ToolChanges =
            [
                new BetaResponseToolAdditionBlock(
                    new BetaResponseToolAdditionBlockTool(
                        new BetaResponseToolChangeToolReference("name")
                    )
                ),
            ],
        };

        string expectedContent = "content";
        string expectedEncryptedContent = "encrypted_content";
        JsonElement expectedType = JsonSerializer.SerializeToElement("compaction");
        string expectedSignature = "signature";
        List<ToolChange> expectedToolChanges =
        [
            new BetaResponseToolAdditionBlock(
                new BetaResponseToolAdditionBlockTool(
                    new BetaResponseToolChangeToolReference("name")
                )
            ),
        ];

        Assert.Equal(expectedContent, model.Content);
        Assert.Equal(expectedEncryptedContent, model.EncryptedContent);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
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
        var model = new BetaCompactionBlock
        {
            Content = "content",
            EncryptedContent = "encrypted_content",
            Signature = "signature",
            ToolChanges =
            [
                new BetaResponseToolAdditionBlock(
                    new BetaResponseToolAdditionBlockTool(
                        new BetaResponseToolChangeToolReference("name")
                    )
                ),
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaCompactionBlock>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaCompactionBlock
        {
            Content = "content",
            EncryptedContent = "encrypted_content",
            Signature = "signature",
            ToolChanges =
            [
                new BetaResponseToolAdditionBlock(
                    new BetaResponseToolAdditionBlockTool(
                        new BetaResponseToolChangeToolReference("name")
                    )
                ),
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaCompactionBlock>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedContent = "content";
        string expectedEncryptedContent = "encrypted_content";
        JsonElement expectedType = JsonSerializer.SerializeToElement("compaction");
        string expectedSignature = "signature";
        List<ToolChange> expectedToolChanges =
        [
            new BetaResponseToolAdditionBlock(
                new BetaResponseToolAdditionBlockTool(
                    new BetaResponseToolChangeToolReference("name")
                )
            ),
        ];

        Assert.Equal(expectedContent, deserialized.Content);
        Assert.Equal(expectedEncryptedContent, deserialized.EncryptedContent);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
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
        var model = new BetaCompactionBlock
        {
            Content = "content",
            EncryptedContent = "encrypted_content",
            Signature = "signature",
            ToolChanges =
            [
                new BetaResponseToolAdditionBlock(
                    new BetaResponseToolAdditionBlockTool(
                        new BetaResponseToolChangeToolReference("name")
                    )
                ),
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaCompactionBlock
        {
            Content = "content",
            EncryptedContent = "encrypted_content",
        };

        Assert.Null(model.Signature);
        Assert.False(model.RawData.ContainsKey("signature"));
        Assert.Null(model.ToolChanges);
        Assert.False(model.RawData.ContainsKey("tool_changes"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaCompactionBlock
        {
            Content = "content",
            EncryptedContent = "encrypted_content",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaCompactionBlock
        {
            Content = "content",
            EncryptedContent = "encrypted_content",

            Signature = null,
            ToolChanges = null,
        };

        Assert.Null(model.Signature);
        Assert.True(model.RawData.ContainsKey("signature"));
        Assert.Null(model.ToolChanges);
        Assert.True(model.RawData.ContainsKey("tool_changes"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaCompactionBlock
        {
            Content = "content",
            EncryptedContent = "encrypted_content",

            Signature = null,
            ToolChanges = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaCompactionBlock
        {
            Content = "content",
            EncryptedContent = "encrypted_content",
            Signature = "signature",
            ToolChanges =
            [
                new BetaResponseToolAdditionBlock(
                    new BetaResponseToolAdditionBlockTool(
                        new BetaResponseToolChangeToolReference("name")
                    )
                ),
            ],
        };

        BetaCompactionBlock copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ToolChangeTest : TestBase
{
    [Fact]
    public void BetaResponseToolAdditionBlockValidationWorks()
    {
        ToolChange value = new BetaResponseToolAdditionBlock(
            new BetaResponseToolAdditionBlockTool(new BetaResponseToolChangeToolReference("name"))
        );
        value.Validate();
    }

    [Fact]
    public void BetaResponseToolRemovalBlockValidationWorks()
    {
        ToolChange value = new BetaResponseToolRemovalBlock(
            new BetaResponseToolRemovalBlockTool(new BetaResponseToolChangeToolReference("name"))
        );
        value.Validate();
    }

    [Fact]
    public void BetaResponseToolAdditionBlockSerializationRoundtripWorks()
    {
        ToolChange value = new BetaResponseToolAdditionBlock(
            new BetaResponseToolAdditionBlockTool(new BetaResponseToolChangeToolReference("name"))
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolChange>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaResponseToolRemovalBlockSerializationRoundtripWorks()
    {
        ToolChange value = new BetaResponseToolRemovalBlock(
            new BetaResponseToolRemovalBlockTool(new BetaResponseToolChangeToolReference("name"))
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ToolChange>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        ToolChange value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "tool_addition"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        JsonElement expectedType = JsonSerializer.SerializeToElement("tool_addition");

        Assert.True(JsonElement.DeepEquals(expectedType, value.Type));

        ToolChange emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}
