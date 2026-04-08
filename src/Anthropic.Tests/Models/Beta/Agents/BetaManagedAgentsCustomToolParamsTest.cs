using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Agents;

namespace Anthropic.Tests.Models.Beta.Agents;

public class BetaManagedAgentsCustomToolParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaManagedAgentsCustomToolParams
        {
            Description = "x",
            InputSchema = new()
            {
                Properties = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Required = ["string"],
                Type = BetaManagedAgentsCustomToolInputSchemaType.Object,
            },
            Name = "x",
            Type = BetaManagedAgentsCustomToolParamsType.Custom,
        };

        string expectedDescription = "x";
        BetaManagedAgentsCustomToolInputSchema expectedInputSchema = new()
        {
            Properties = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Required = ["string"],
            Type = BetaManagedAgentsCustomToolInputSchemaType.Object,
        };
        string expectedName = "x";
        ApiEnum<string, BetaManagedAgentsCustomToolParamsType> expectedType =
            BetaManagedAgentsCustomToolParamsType.Custom;

        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedInputSchema, model.InputSchema);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaManagedAgentsCustomToolParams
        {
            Description = "x",
            InputSchema = new()
            {
                Properties = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Required = ["string"],
                Type = BetaManagedAgentsCustomToolInputSchemaType.Object,
            },
            Name = "x",
            Type = BetaManagedAgentsCustomToolParamsType.Custom,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsCustomToolParams>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaManagedAgentsCustomToolParams
        {
            Description = "x",
            InputSchema = new()
            {
                Properties = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Required = ["string"],
                Type = BetaManagedAgentsCustomToolInputSchemaType.Object,
            },
            Name = "x",
            Type = BetaManagedAgentsCustomToolParamsType.Custom,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaManagedAgentsCustomToolParams>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedDescription = "x";
        BetaManagedAgentsCustomToolInputSchema expectedInputSchema = new()
        {
            Properties = new Dictionary<string, JsonElement>()
            {
                { "foo", JsonSerializer.SerializeToElement("bar") },
            },
            Required = ["string"],
            Type = BetaManagedAgentsCustomToolInputSchemaType.Object,
        };
        string expectedName = "x";
        ApiEnum<string, BetaManagedAgentsCustomToolParamsType> expectedType =
            BetaManagedAgentsCustomToolParamsType.Custom;

        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedInputSchema, deserialized.InputSchema);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaManagedAgentsCustomToolParams
        {
            Description = "x",
            InputSchema = new()
            {
                Properties = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Required = ["string"],
                Type = BetaManagedAgentsCustomToolInputSchemaType.Object,
            },
            Name = "x",
            Type = BetaManagedAgentsCustomToolParamsType.Custom,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaManagedAgentsCustomToolParams
        {
            Description = "x",
            InputSchema = new()
            {
                Properties = new Dictionary<string, JsonElement>()
                {
                    { "foo", JsonSerializer.SerializeToElement("bar") },
                },
                Required = ["string"],
                Type = BetaManagedAgentsCustomToolInputSchemaType.Object,
            },
            Name = "x",
            Type = BetaManagedAgentsCustomToolParamsType.Custom,
        };

        BetaManagedAgentsCustomToolParams copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaManagedAgentsCustomToolParamsTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaManagedAgentsCustomToolParamsType.Custom)]
    public void Validation_Works(BetaManagedAgentsCustomToolParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsCustomToolParamsType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsCustomToolParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaManagedAgentsCustomToolParamsType.Custom)]
    public void SerializationRoundtrip_Works(BetaManagedAgentsCustomToolParamsType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaManagedAgentsCustomToolParamsType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsCustomToolParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsCustomToolParamsType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaManagedAgentsCustomToolParamsType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
