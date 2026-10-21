using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Organization.Workspaces.RateLimits;
using RateLimits = Anthropic.Models.Organization.RateLimits;

namespace Anthropic.Tests.Models.Organization.Workspaces.RateLimits;

public class WorkspaceRateLimitTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new WorkspaceRateLimit
        {
            Group = new RateLimits::OrganizationRateLimitModelGroup()
            {
                ID = "id",
                DisplayName = "display_name",
            },
            Limits =
            [
                new()
                {
                    OrgLimit = 0,
                    Source = new WorkspaceRateLimitWorkspaceSource(),
                    Type = "type",
                    Value = 0,
                },
            ],
            Models = ["string"],
            RateLimitID = "rate_limit_id",
            WorkspaceID = "workspace_id",
        };

        Group expectedGroup = new RateLimits::OrganizationRateLimitModelGroup()
        {
            ID = "id",
            DisplayName = "display_name",
        };
        List<WorkspaceRateLimitValue> expectedLimits =
        [
            new()
            {
                OrgLimit = 0,
                Source = new WorkspaceRateLimitWorkspaceSource(),
                Type = "type",
                Value = 0,
            },
        ];
        List<string> expectedModels = ["string"];
        string expectedRateLimitID = "rate_limit_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("workspace_rate_limit");
        string expectedWorkspaceID = "workspace_id";

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
        Assert.Equal(expectedRateLimitID, model.RateLimitID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedWorkspaceID, model.WorkspaceID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new WorkspaceRateLimit
        {
            Group = new RateLimits::OrganizationRateLimitModelGroup()
            {
                ID = "id",
                DisplayName = "display_name",
            },
            Limits =
            [
                new()
                {
                    OrgLimit = 0,
                    Source = new WorkspaceRateLimitWorkspaceSource(),
                    Type = "type",
                    Value = 0,
                },
            ],
            Models = ["string"],
            RateLimitID = "rate_limit_id",
            WorkspaceID = "workspace_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkspaceRateLimit>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new WorkspaceRateLimit
        {
            Group = new RateLimits::OrganizationRateLimitModelGroup()
            {
                ID = "id",
                DisplayName = "display_name",
            },
            Limits =
            [
                new()
                {
                    OrgLimit = 0,
                    Source = new WorkspaceRateLimitWorkspaceSource(),
                    Type = "type",
                    Value = 0,
                },
            ],
            Models = ["string"],
            RateLimitID = "rate_limit_id",
            WorkspaceID = "workspace_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<WorkspaceRateLimit>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Group expectedGroup = new RateLimits::OrganizationRateLimitModelGroup()
        {
            ID = "id",
            DisplayName = "display_name",
        };
        List<WorkspaceRateLimitValue> expectedLimits =
        [
            new()
            {
                OrgLimit = 0,
                Source = new WorkspaceRateLimitWorkspaceSource(),
                Type = "type",
                Value = 0,
            },
        ];
        List<string> expectedModels = ["string"];
        string expectedRateLimitID = "rate_limit_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("workspace_rate_limit");
        string expectedWorkspaceID = "workspace_id";

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
        Assert.Equal(expectedRateLimitID, deserialized.RateLimitID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedWorkspaceID, deserialized.WorkspaceID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new WorkspaceRateLimit
        {
            Group = new RateLimits::OrganizationRateLimitModelGroup()
            {
                ID = "id",
                DisplayName = "display_name",
            },
            Limits =
            [
                new()
                {
                    OrgLimit = 0,
                    Source = new WorkspaceRateLimitWorkspaceSource(),
                    Type = "type",
                    Value = 0,
                },
            ],
            Models = ["string"],
            RateLimitID = "rate_limit_id",
            WorkspaceID = "workspace_id",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new WorkspaceRateLimit
        {
            Group = new RateLimits::OrganizationRateLimitModelGroup()
            {
                ID = "id",
                DisplayName = "display_name",
            },
            Limits =
            [
                new()
                {
                    OrgLimit = 0,
                    Source = new WorkspaceRateLimitWorkspaceSource(),
                    Type = "type",
                    Value = 0,
                },
            ],
            Models = ["string"],
            RateLimitID = "rate_limit_id",
            WorkspaceID = "workspace_id",
        };

        WorkspaceRateLimit copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class GroupTest : TestBase
{
    [Fact]
    public void OrganizationRateLimitModelValidationWorks()
    {
        Group value = new RateLimits::OrganizationRateLimitModelGroup()
        {
            ID = "id",
            DisplayName = "display_name",
        };
        value.Validate();
    }

    [Fact]
    public void OrganizationRateLimitBatchValidationWorks()
    {
        Group value = new RateLimits::OrganizationRateLimitBatchGroup("id");
        value.Validate();
    }

    [Fact]
    public void OrganizationRateLimitTokenCountValidationWorks()
    {
        Group value = new RateLimits::OrganizationRateLimitTokenCountGroup("id");
        value.Validate();
    }

    [Fact]
    public void OrganizationRateLimitFilesValidationWorks()
    {
        Group value = new RateLimits::OrganizationRateLimitFilesGroup("id");
        value.Validate();
    }

    [Fact]
    public void OrganizationRateLimitSkillsValidationWorks()
    {
        Group value = new RateLimits::OrganizationRateLimitSkillsGroup("id");
        value.Validate();
    }

    [Fact]
    public void OrganizationRateLimitWebSearchValidationWorks()
    {
        Group value = new RateLimits::OrganizationRateLimitWebSearchGroup("id");
        value.Validate();
    }

    [Fact]
    public void OrganizationRateLimitModelSerializationRoundtripWorks()
    {
        Group value = new RateLimits::OrganizationRateLimitModelGroup()
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
        Group value = new RateLimits::OrganizationRateLimitBatchGroup("id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Group>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void OrganizationRateLimitTokenCountSerializationRoundtripWorks()
    {
        Group value = new RateLimits::OrganizationRateLimitTokenCountGroup("id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Group>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void OrganizationRateLimitFilesSerializationRoundtripWorks()
    {
        Group value = new RateLimits::OrganizationRateLimitFilesGroup("id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Group>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void OrganizationRateLimitSkillsSerializationRoundtripWorks()
    {
        Group value = new RateLimits::OrganizationRateLimitSkillsGroup("id");
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Group>(element, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void OrganizationRateLimitWebSearchSerializationRoundtripWorks()
    {
        Group value = new RateLimits::OrganizationRateLimitWebSearchGroup("id");
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
