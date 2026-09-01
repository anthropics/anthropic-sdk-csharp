using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaThinkingBlockBindingTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaThinkingBlockBinding
        {
            PrefixMismatchBehavior = BetaThinkingPrefixMismatchBehavior.Error,
        };

        ApiEnum<string, BetaThinkingPrefixMismatchBehavior> expectedPrefixMismatchBehavior =
            BetaThinkingPrefixMismatchBehavior.Error;

        Assert.Equal(expectedPrefixMismatchBehavior, model.PrefixMismatchBehavior);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaThinkingBlockBinding
        {
            PrefixMismatchBehavior = BetaThinkingPrefixMismatchBehavior.Error,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaThinkingBlockBinding>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaThinkingBlockBinding
        {
            PrefixMismatchBehavior = BetaThinkingPrefixMismatchBehavior.Error,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaThinkingBlockBinding>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, BetaThinkingPrefixMismatchBehavior> expectedPrefixMismatchBehavior =
            BetaThinkingPrefixMismatchBehavior.Error;

        Assert.Equal(expectedPrefixMismatchBehavior, deserialized.PrefixMismatchBehavior);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaThinkingBlockBinding
        {
            PrefixMismatchBehavior = BetaThinkingPrefixMismatchBehavior.Error,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaThinkingBlockBinding { };

        Assert.Null(model.PrefixMismatchBehavior);
        Assert.False(model.RawData.ContainsKey("prefix_mismatch_behavior"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaThinkingBlockBinding { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaThinkingBlockBinding { PrefixMismatchBehavior = null };

        Assert.Null(model.PrefixMismatchBehavior);
        Assert.True(model.RawData.ContainsKey("prefix_mismatch_behavior"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaThinkingBlockBinding { PrefixMismatchBehavior = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaThinkingBlockBinding
        {
            PrefixMismatchBehavior = BetaThinkingPrefixMismatchBehavior.Error,
        };

        BetaThinkingBlockBinding copied = new(model);

        Assert.Equal(model, copied);
    }
}
