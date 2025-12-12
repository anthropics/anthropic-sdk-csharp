using System.Text.Json;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaClearThinking20251015EditTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaClearThinking20251015Edit { Keep = new BetaThinkingTurns(1) };

        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"clear_thinking_20251015\""
        );
        Keep expectedKeep = new BetaThinkingTurns(1);

        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedKeep, model.Keep);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaClearThinking20251015Edit { Keep = new BetaThinkingTurns(1) };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaClearThinking20251015Edit>(json);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaClearThinking20251015Edit { Keep = new BetaThinkingTurns(1) };

        string json = JsonSerializer.Serialize(model);
        var deserialized = JsonSerializer.Deserialize<BetaClearThinking20251015Edit>(json);
        Assert.NotNull(deserialized);

        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"clear_thinking_20251015\""
        );
        Keep expectedKeep = new BetaThinkingTurns(1);

        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedKeep, deserialized.Keep);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaClearThinking20251015Edit { Keep = new BetaThinkingTurns(1) };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaClearThinking20251015Edit { };

        Assert.Null(model.Keep);
        Assert.False(model.RawData.ContainsKey("keep"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaClearThinking20251015Edit { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaClearThinking20251015Edit
        {
            // Null should be interpreted as omitted for these properties
            Keep = null,
        };

        Assert.Null(model.Keep);
        Assert.False(model.RawData.ContainsKey("keep"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaClearThinking20251015Edit
        {
            // Null should be interpreted as omitted for these properties
            Keep = null,
        };

        model.Validate();
    }
}

public class KeepTest : TestBase
{
    [Fact]
    public void beta_thinking_turnsValidation_Works()
    {
        Keep value = new(new BetaThinkingTurns(1));
        value.Validate();
    }

    [Fact]
    public void beta_all_thinking_turnsValidation_Works()
    {
        Keep value = new(new BetaAllThinkingTurns());
        value.Validate();
    }

    [Fact]
    public void allValidation_Works()
    {
        Keep value = new(new UnionMember2());
        value.Validate();
    }

    [Fact]
    public void beta_thinking_turnsSerializationRoundtrip_Works()
    {
        Keep value = new(new BetaThinkingTurns(1));
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Keep>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void beta_all_thinking_turnsSerializationRoundtrip_Works()
    {
        Keep value = new(new BetaAllThinkingTurns());
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Keep>(json);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void allSerializationRoundtrip_Works()
    {
        Keep value = new(new UnionMember2());
        string json = JsonSerializer.Serialize(value);
        var deserialized = JsonSerializer.Deserialize<Keep>(json);

        Assert.Equal(value, deserialized);
    }
}

public class UnionMember2Test : TestBase
{
    [Fact]
    public void DefaultValidation_Works()
    {
        var constant = new UnionMember2();
        constant.Validate();
    }

    [Fact]
    public void ValidConstantValidation_Works()
    {
        var constant = JsonSerializer.Deserialize<UnionMember2>(
            JsonSerializer.Deserialize<JsonElement>("\"all\"")
        );
        Assert.NotNull(constant);
        constant.Validate();
    }

    [Fact]
    public void InvalidConstantValidationThrows_Works()
    {
        var constant = JsonSerializer.Deserialize<UnionMember2>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\"")
        );
        Assert.NotNull(constant);
        Assert.Throws<AnthropicInvalidDataException>(() => constant.Validate());
    }

    [Fact]
    public void DefaultRoundtrip_Works()
    {
        var constant = new UnionMember2();
        var json = JsonSerializer.Serialize(constant);
        var deserialized = JsonSerializer.Deserialize<UnionMember2>(json);

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void ValidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<UnionMember2>(
            JsonSerializer.Deserialize<JsonElement>("\"all\"")
        );
        var json = JsonSerializer.Serialize(constant);
        var deserialized = JsonSerializer.Deserialize<UnionMember2>(json);

        Assert.Equal(constant, deserialized);
    }

    [Fact]
    public void InvalidConstantRoundtrip_Works()
    {
        var constant = JsonSerializer.Deserialize<UnionMember2>(
            JsonSerializer.Deserialize<JsonElement>("\"invalid value\"")
        );
        var json = JsonSerializer.Serialize(constant);
        var deserialized = JsonSerializer.Deserialize<UnionMember2>(json);

        Assert.Equal(constant, deserialized);
    }
}
