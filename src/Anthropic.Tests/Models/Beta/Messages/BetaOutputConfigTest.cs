using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaOutputConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaOutputConfig
        {
            Effort = Effort.Low,
            Format = new()
            {
                Schema = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },
            TaskBudget = new() { Total = 1024, Remaining = 0 },
        };

        ApiEnum<string, Effort> expectedEffort = Effort.Low;
        BetaJsonOutputFormat expectedFormat = new()
        {
            Schema = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };
        BetaTokenTaskBudget expectedTaskBudget = new() { Total = 1024, Remaining = 0 };

        Assert.Equal(expectedEffort, model.Effort);
        Assert.Equal(expectedFormat, model.Format);
        Assert.Equal(expectedTaskBudget, model.TaskBudget);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaOutputConfig
        {
            Effort = Effort.Low,
            Format = new()
            {
                Schema = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },
            TaskBudget = new() { Total = 1024, Remaining = 0 },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaOutputConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaOutputConfig
        {
            Effort = Effort.Low,
            Format = new()
            {
                Schema = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },
            TaskBudget = new() { Total = 1024, Remaining = 0 },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaOutputConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Effort> expectedEffort = Effort.Low;
        BetaJsonOutputFormat expectedFormat = new()
        {
            Schema = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
        };
        BetaTokenTaskBudget expectedTaskBudget = new() { Total = 1024, Remaining = 0 };

        Assert.Equal(expectedEffort, deserialized.Effort);
        Assert.Equal(expectedFormat, deserialized.Format);
        Assert.Equal(expectedTaskBudget, deserialized.TaskBudget);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaOutputConfig
        {
            Effort = Effort.Low,
            Format = new()
            {
                Schema = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },
            TaskBudget = new() { Total = 1024, Remaining = 0 },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaOutputConfig { };

        Assert.Null(model.Effort);
        Assert.False(model.RawData.ContainsKey("effort"));
        Assert.Null(model.Format);
        Assert.False(model.RawData.ContainsKey("format"));
        Assert.Null(model.TaskBudget);
        Assert.False(model.RawData.ContainsKey("task_budget"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaOutputConfig { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaOutputConfig
        {
            Effort = null,
            Format = null,
            TaskBudget = null,
        };

        Assert.Null(model.Effort);
        Assert.True(model.RawData.ContainsKey("effort"));
        Assert.Null(model.Format);
        Assert.True(model.RawData.ContainsKey("format"));
        Assert.Null(model.TaskBudget);
        Assert.True(model.RawData.ContainsKey("task_budget"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaOutputConfig
        {
            Effort = null,
            Format = null,
            TaskBudget = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaOutputConfig
        {
            Effort = Effort.Low,
            Format = new()
            {
                Schema = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
            },
            TaskBudget = new() { Total = 1024, Remaining = 0 },
        };

        BetaOutputConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EffortTest : TestBase
{
    [Theory]
    [InlineData(Effort.Low)]
    [InlineData(Effort.Medium)]
    [InlineData(Effort.High)]
    [InlineData(Effort.Max)]
    public void Validation_Works(Effort rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Effort> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Effort>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Effort.Low)]
    [InlineData(Effort.Medium)]
    [InlineData(Effort.High)]
    [InlineData(Effort.Max)]
    public void SerializationRoundtrip_Works(Effort rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Effort> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Effort>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Effort>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Effort>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
