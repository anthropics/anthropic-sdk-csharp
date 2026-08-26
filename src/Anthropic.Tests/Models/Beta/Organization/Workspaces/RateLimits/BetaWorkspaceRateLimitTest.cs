using System.Collections.Generic;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Workspaces.RateLimits;

namespace Anthropic.Tests.Models.Beta.Organization.Workspaces.RateLimits;

public class BetaWorkspaceRateLimitTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaWorkspaceRateLimit
        {
            GroupType = BetaWorkspaceRateLimitGroupType.Batch,
            Limits =
            [
                new()
                {
                    OrgLimit = 0,
                    Type = "type",
                    Value = 0,
                },
            ],
            Models = ["string"],
            RateLimitID = "rate_limit_id",
            WorkspaceID = "workspace_id",
        };

        ApiEnum<string, BetaWorkspaceRateLimitGroupType> expectedGroupType =
            BetaWorkspaceRateLimitGroupType.Batch;
        List<BetaWorkspaceRateLimitValue> expectedLimits =
        [
            new()
            {
                OrgLimit = 0,
                Type = "type",
                Value = 0,
            },
        ];
        List<string> expectedModels = ["string"];
        string expectedRateLimitID = "rate_limit_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("workspace_rate_limit");
        string expectedWorkspaceID = "workspace_id";

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
        Assert.Equal(expectedRateLimitID, model.RateLimitID);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
        Assert.Equal(expectedWorkspaceID, model.WorkspaceID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaWorkspaceRateLimit
        {
            GroupType = BetaWorkspaceRateLimitGroupType.Batch,
            Limits =
            [
                new()
                {
                    OrgLimit = 0,
                    Type = "type",
                    Value = 0,
                },
            ],
            Models = ["string"],
            RateLimitID = "rate_limit_id",
            WorkspaceID = "workspace_id",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWorkspaceRateLimit>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaWorkspaceRateLimit
        {
            GroupType = BetaWorkspaceRateLimitGroupType.Batch,
            Limits =
            [
                new()
                {
                    OrgLimit = 0,
                    Type = "type",
                    Value = 0,
                },
            ],
            Models = ["string"],
            RateLimitID = "rate_limit_id",
            WorkspaceID = "workspace_id",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaWorkspaceRateLimit>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, BetaWorkspaceRateLimitGroupType> expectedGroupType =
            BetaWorkspaceRateLimitGroupType.Batch;
        List<BetaWorkspaceRateLimitValue> expectedLimits =
        [
            new()
            {
                OrgLimit = 0,
                Type = "type",
                Value = 0,
            },
        ];
        List<string> expectedModels = ["string"];
        string expectedRateLimitID = "rate_limit_id";
        JsonElement expectedType = JsonSerializer.SerializeToElement("workspace_rate_limit");
        string expectedWorkspaceID = "workspace_id";

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
        Assert.Equal(expectedRateLimitID, deserialized.RateLimitID);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
        Assert.Equal(expectedWorkspaceID, deserialized.WorkspaceID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaWorkspaceRateLimit
        {
            GroupType = BetaWorkspaceRateLimitGroupType.Batch,
            Limits =
            [
                new()
                {
                    OrgLimit = 0,
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
        var model = new BetaWorkspaceRateLimit
        {
            GroupType = BetaWorkspaceRateLimitGroupType.Batch,
            Limits =
            [
                new()
                {
                    OrgLimit = 0,
                    Type = "type",
                    Value = 0,
                },
            ],
            Models = ["string"],
            RateLimitID = "rate_limit_id",
            WorkspaceID = "workspace_id",
        };

        BetaWorkspaceRateLimit copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BetaWorkspaceRateLimitGroupTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaWorkspaceRateLimitGroupType.Batch)]
    [InlineData(BetaWorkspaceRateLimitGroupType.Files)]
    [InlineData(BetaWorkspaceRateLimitGroupType.ModelGroup)]
    [InlineData(BetaWorkspaceRateLimitGroupType.Skills)]
    [InlineData(BetaWorkspaceRateLimitGroupType.TokenCount)]
    [InlineData(BetaWorkspaceRateLimitGroupType.WebSearch)]
    public void Validation_Works(BetaWorkspaceRateLimitGroupType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaWorkspaceRateLimitGroupType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaWorkspaceRateLimitGroupType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaWorkspaceRateLimitGroupType.Batch)]
    [InlineData(BetaWorkspaceRateLimitGroupType.Files)]
    [InlineData(BetaWorkspaceRateLimitGroupType.ModelGroup)]
    [InlineData(BetaWorkspaceRateLimitGroupType.Skills)]
    [InlineData(BetaWorkspaceRateLimitGroupType.TokenCount)]
    [InlineData(BetaWorkspaceRateLimitGroupType.WebSearch)]
    public void SerializationRoundtrip_Works(BetaWorkspaceRateLimitGroupType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaWorkspaceRateLimitGroupType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaWorkspaceRateLimitGroupType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaWorkspaceRateLimitGroupType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaWorkspaceRateLimitGroupType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
