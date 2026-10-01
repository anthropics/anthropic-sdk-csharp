using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.RateLimits;

namespace Anthropic.Tests.Models.Beta.Organization.RateLimits;

public class BetaOrganizationRateLimitTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaOrganizationRateLimit
        {
            ID = "id",
            Group = new BetaOrganizationRateLimitModelGroup()
            {
                ID = "id",
                DisplayName = "display_name",
            },
            GroupType = BetaOrganizationRateLimitGroupType.Batch,
            Limits = [new() { Type = "type", Value = 0 }],
            Models = ["string"],
        };

        string expectedID = "id";
        Group expectedGroup = new BetaOrganizationRateLimitModelGroup()
        {
            ID = "id",
            DisplayName = "display_name",
        };
        ApiEnum<string, BetaOrganizationRateLimitGroupType> expectedGroupType =
            BetaOrganizationRateLimitGroupType.Batch;
        List<BetaOrganizationRateLimitValue> expectedLimits = [new() { Type = "type", Value = 0 }];
        List<string> expectedModels = ["string"];
        JsonElement expectedType = JsonSerializer.SerializeToElement("rate_limit");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedGroup, model.Group);
        Assert.Equal(expectedGroupType, model.GroupType);
        Assert.Equal(expectedLimits.Count, model.Limits.Count);
        for (int i = 0; i < expectedLimits.Count; i++)
        {
            Assert.Equal(expectedLimits[i], model.Limits[i]);
        }
        Assert.NotNull(model.Models);
        Assert.Equal(expectedModels.Count, model.Models.Count);
        for (int i = 0; i < expectedModels.Count; i++)
        {
            Assert.Equal(expectedModels[i], model.Models[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaOrganizationRateLimit
        {
            ID = "id",
            Group = new BetaOrganizationRateLimitModelGroup()
            {
                ID = "id",
                DisplayName = "display_name",
            },
            GroupType = BetaOrganizationRateLimitGroupType.Batch,
            Limits = [new() { Type = "type", Value = 0 }],
            Models = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaOrganizationRateLimit>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaOrganizationRateLimit
        {
            ID = "id",
            Group = new BetaOrganizationRateLimitModelGroup()
            {
                ID = "id",
                DisplayName = "display_name",
            },
            GroupType = BetaOrganizationRateLimitGroupType.Batch,
            Limits = [new() { Type = "type", Value = 0 }],
            Models = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaOrganizationRateLimit>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        Group expectedGroup = new BetaOrganizationRateLimitModelGroup()
        {
            ID = "id",
            DisplayName = "display_name",
        };
        ApiEnum<string, BetaOrganizationRateLimitGroupType> expectedGroupType =
            BetaOrganizationRateLimitGroupType.Batch;
        List<BetaOrganizationRateLimitValue> expectedLimits = [new() { Type = "type", Value = 0 }];
        List<string> expectedModels = ["string"];
        JsonElement expectedType = JsonSerializer.SerializeToElement("rate_limit");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedGroup, deserialized.Group);
        Assert.Equal(expectedGroupType, deserialized.GroupType);
        Assert.Equal(expectedLimits.Count, deserialized.Limits.Count);
        for (int i = 0; i < expectedLimits.Count; i++)
        {
            Assert.Equal(expectedLimits[i], deserialized.Limits[i]);
        }
        Assert.NotNull(deserialized.Models);
        Assert.Equal(expectedModels.Count, deserialized.Models.Count);
        for (int i = 0; i < expectedModels.Count; i++)
        {
            Assert.Equal(expectedModels[i], deserialized.Models[i]);
        }
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaOrganizationRateLimit
        {
            ID = "id",
            Group = new BetaOrganizationRateLimitModelGroup()
            {
                ID = "id",
                DisplayName = "display_name",
            },
            GroupType = BetaOrganizationRateLimitGroupType.Batch,
            Limits = [new() { Type = "type", Value = 0 }],
            Models = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaOrganizationRateLimit
        {
            ID = "id",
            Group = new BetaOrganizationRateLimitModelGroup()
            {
                ID = "id",
                DisplayName = "display_name",
            },
            GroupType = BetaOrganizationRateLimitGroupType.Batch,
            Limits = [new() { Type = "type", Value = 0 }],
            Models = ["string"],
        };

        BetaOrganizationRateLimit copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class GroupTest : TestBase
{
    [Fact]
    public void BetaOrganizationRateLimitModelValidationWorks()
    {
        Group value = new BetaOrganizationRateLimitModelGroup()
        {
            ID = "id",
            DisplayName = "display_name",
        };
        value.Validate();
    }

    [Fact]
    public void BetaOrganizationRateLimitBatchValidationWorks()
    {
        Group value = new BetaOrganizationRateLimitBatchGroup("id");
        value.Validate();
    }

    [Fact]
    public void BetaOrganizationRateLimitTokenCountValidationWorks()
    {
        Group value = new BetaOrganizationRateLimitTokenCountGroup("id");
        value.Validate();
    }

    [Fact]
    public void BetaOrganizationRateLimitFilesValidationWorks()
    {
        Group value = new BetaOrganizationRateLimitFilesGroup("id");
        value.Validate();
    }

    [Fact]
    public void BetaOrganizationRateLimitSkillsValidationWorks()
    {
        Group value = new BetaOrganizationRateLimitSkillsGroup("id");
        value.Validate();
    }

    [Fact]
    public void BetaOrganizationRateLimitWebSearchValidationWorks()
    {
        Group value = new BetaOrganizationRateLimitWebSearchGroup("id");
        value.Validate();
    }

    [Fact]
    public void BetaOrganizationRateLimitModelSerializationRoundtripWorks()
    {
        Group value = new BetaOrganizationRateLimitModelGroup()
        {
            ID = "id",
            DisplayName = "display_name",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Group>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaOrganizationRateLimitBatchSerializationRoundtripWorks()
    {
        Group value = new BetaOrganizationRateLimitBatchGroup("id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Group>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaOrganizationRateLimitTokenCountSerializationRoundtripWorks()
    {
        Group value = new BetaOrganizationRateLimitTokenCountGroup("id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Group>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaOrganizationRateLimitFilesSerializationRoundtripWorks()
    {
        Group value = new BetaOrganizationRateLimitFilesGroup("id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Group>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaOrganizationRateLimitSkillsSerializationRoundtripWorks()
    {
        Group value = new BetaOrganizationRateLimitSkillsGroup("id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Group>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaOrganizationRateLimitWebSearchSerializationRoundtripWorks()
    {
        Group value = new BetaOrganizationRateLimitWebSearchGroup("id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Group>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        Group value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "id": "id",
                  "type": "model_group"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        string expectedID = "id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("model_group");

        Assert.Equal(expectedID, value.ID);
        Assert.True(JsonElement.DeepEquals(expectedType, value.Type));

        Group emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.ID);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);

        Group mismatchedValue = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "id": [
                    "invalid"
                  ]
                }
                """
            )
        );

        Assert.Throws<AnthropicInvalidDataException>(() => mismatchedValue.ID);
    }
}

public class BetaOrganizationRateLimitGroupTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaOrganizationRateLimitGroupType.Batch)]
    [InlineData(BetaOrganizationRateLimitGroupType.Files)]
    [InlineData(BetaOrganizationRateLimitGroupType.ModelGroup)]
    [InlineData(BetaOrganizationRateLimitGroupType.Skills)]
    [InlineData(BetaOrganizationRateLimitGroupType.TokenCount)]
    [InlineData(BetaOrganizationRateLimitGroupType.WebSearch)]
    public void Validation_Works(BetaOrganizationRateLimitGroupType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaOrganizationRateLimitGroupType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaOrganizationRateLimitGroupType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaOrganizationRateLimitGroupType.Batch)]
    [InlineData(BetaOrganizationRateLimitGroupType.Files)]
    [InlineData(BetaOrganizationRateLimitGroupType.ModelGroup)]
    [InlineData(BetaOrganizationRateLimitGroupType.Skills)]
    [InlineData(BetaOrganizationRateLimitGroupType.TokenCount)]
    [InlineData(BetaOrganizationRateLimitGroupType.WebSearch)]
    public void SerializationRoundtrip_Works(BetaOrganizationRateLimitGroupType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaOrganizationRateLimitGroupType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaOrganizationRateLimitGroupType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaOrganizationRateLimitGroupType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaOrganizationRateLimitGroupType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
