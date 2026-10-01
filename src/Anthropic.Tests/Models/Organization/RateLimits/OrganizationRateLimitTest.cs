using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Organization.RateLimits;

namespace Anthropic.Tests.Models.Organization.RateLimits;

public class OrganizationRateLimitTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OrganizationRateLimit
        {
            ID = "id",
            Group = new OrganizationRateLimitModelGroup()
            {
                ID = "id",
                DisplayName = "display_name",
            },
            Limits = [new() { Type = "type", Value = 0 }],
            Models = ["string"],
        };

        string expectedID = "id";
        Group expectedGroup = new OrganizationRateLimitModelGroup()
        {
            ID = "id",
            DisplayName = "display_name",
        };
        List<OrganizationRateLimitValue> expectedLimits = [new() { Type = "type", Value = 0 }];
        List<string> expectedModels = ["string"];
        JsonElement expectedType = JsonSerializer.SerializeToElement("rate_limit");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedGroup, model.Group);
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
        var model = new OrganizationRateLimit
        {
            ID = "id",
            Group = new OrganizationRateLimitModelGroup()
            {
                ID = "id",
                DisplayName = "display_name",
            },
            Limits = [new() { Type = "type", Value = 0 }],
            Models = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OrganizationRateLimit>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OrganizationRateLimit
        {
            ID = "id",
            Group = new OrganizationRateLimitModelGroup()
            {
                ID = "id",
                DisplayName = "display_name",
            },
            Limits = [new() { Type = "type", Value = 0 }],
            Models = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OrganizationRateLimit>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        Group expectedGroup = new OrganizationRateLimitModelGroup()
        {
            ID = "id",
            DisplayName = "display_name",
        };
        List<OrganizationRateLimitValue> expectedLimits = [new() { Type = "type", Value = 0 }];
        List<string> expectedModels = ["string"];
        JsonElement expectedType = JsonSerializer.SerializeToElement("rate_limit");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedGroup, deserialized.Group);
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
        var model = new OrganizationRateLimit
        {
            ID = "id",
            Group = new OrganizationRateLimitModelGroup()
            {
                ID = "id",
                DisplayName = "display_name",
            },
            Limits = [new() { Type = "type", Value = 0 }],
            Models = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OrganizationRateLimit
        {
            ID = "id",
            Group = new OrganizationRateLimitModelGroup()
            {
                ID = "id",
                DisplayName = "display_name",
            },
            Limits = [new() { Type = "type", Value = 0 }],
            Models = ["string"],
        };

        OrganizationRateLimit copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class GroupTest : TestBase
{
    [Fact]
    public void OrganizationRateLimitModelValidationWorks()
    {
        Group value = new OrganizationRateLimitModelGroup()
        {
            ID = "id",
            DisplayName = "display_name",
        };
        value.Validate();
    }

    [Fact]
    public void OrganizationRateLimitBatchValidationWorks()
    {
        Group value = new OrganizationRateLimitBatchGroup("id");
        value.Validate();
    }

    [Fact]
    public void OrganizationRateLimitTokenCountValidationWorks()
    {
        Group value = new OrganizationRateLimitTokenCountGroup("id");
        value.Validate();
    }

    [Fact]
    public void OrganizationRateLimitFilesValidationWorks()
    {
        Group value = new OrganizationRateLimitFilesGroup("id");
        value.Validate();
    }

    [Fact]
    public void OrganizationRateLimitSkillsValidationWorks()
    {
        Group value = new OrganizationRateLimitSkillsGroup("id");
        value.Validate();
    }

    [Fact]
    public void OrganizationRateLimitWebSearchValidationWorks()
    {
        Group value = new OrganizationRateLimitWebSearchGroup("id");
        value.Validate();
    }

    [Fact]
    public void OrganizationRateLimitModelSerializationRoundtripWorks()
    {
        Group value = new OrganizationRateLimitModelGroup()
        {
            ID = "id",
            DisplayName = "display_name",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Group>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void OrganizationRateLimitBatchSerializationRoundtripWorks()
    {
        Group value = new OrganizationRateLimitBatchGroup("id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Group>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void OrganizationRateLimitTokenCountSerializationRoundtripWorks()
    {
        Group value = new OrganizationRateLimitTokenCountGroup("id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Group>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void OrganizationRateLimitFilesSerializationRoundtripWorks()
    {
        Group value = new OrganizationRateLimitFilesGroup("id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Group>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void OrganizationRateLimitSkillsSerializationRoundtripWorks()
    {
        Group value = new OrganizationRateLimitSkillsGroup("id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Group>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void OrganizationRateLimitWebSearchSerializationRoundtripWorks()
    {
        Group value = new OrganizationRateLimitWebSearchGroup("id");
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
