using System;
using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.ClaudeTag.Bundles.Targets;

namespace Anthropic.Tests.Models.Beta.Organization.ClaudeTag.Bundles.Targets;

public class BetaClaudeTagBundleTargetTest : TestBase
{
    [Fact]
    public void SlackChannelValidationWorks()
    {
        BetaClaudeTagBundleTarget value = new BetaClaudeTagSlackChannelBundleTarget()
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SlackChannelID = "slack_channel_id",
        };
        value.Validate();
    }

    [Fact]
    public void SlackWorkspaceValidationWorks()
    {
        BetaClaudeTagBundleTarget value = new BetaClaudeTagSlackWorkspaceBundleTarget()
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SlackWorkspaceID = "slack_workspace_id",
        };
        value.Validate();
    }

    [Fact]
    public void SlackChannelSerializationRoundtripWorks()
    {
        BetaClaudeTagBundleTarget value = new BetaClaudeTagSlackChannelBundleTarget()
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SlackChannelID = "slack_channel_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaClaudeTagBundleTarget>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SlackWorkspaceSerializationRoundtripWorks()
    {
        BetaClaudeTagBundleTarget value = new BetaClaudeTagSlackWorkspaceBundleTarget()
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SlackWorkspaceID = "slack_workspace_id",
        };
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaClaudeTagBundleTarget>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SlackChannelTypeWorks()
    {
        BetaClaudeTagBundleTarget value = new BetaClaudeTagSlackChannelBundleTarget()
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SlackChannelID = "slack_channel_id",
        };
        Assert.Equal(BetaClaudeTagBundleTargetType.SlackChannel, value.Type.Value());
    }

    [Fact]
    public void SlackWorkspaceTypeWorks()
    {
        BetaClaudeTagBundleTarget value = new BetaClaudeTagSlackWorkspaceBundleTarget()
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SlackWorkspaceID = "slack_workspace_id",
        };
        Assert.Equal(BetaClaudeTagBundleTargetType.SlackWorkspace, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaClaudeTagBundleTarget value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "id": "id",
                  "created_at": "2019-12-27T18:11:19.117+00:00",
                  "type": "slack_channel"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00");
        ApiEnum<string, BetaClaudeTagBundleTargetType> expectedType =
            BetaClaudeTagBundleTargetType.SlackChannel;

        Assert.Equal(expectedID, value.ID);
        Assert.Equal(expectedCreatedAt, value.CreatedAt);
        Assert.Equal(expectedType, value.Type);

        BetaClaudeTagBundleTarget emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.ID);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.CreatedAt);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);

        BetaClaudeTagBundleTarget mismatchedValue = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "id": [
                    "invalid"
                  ],
                  "created_at": [
                    "invalid"
                  ]
                }
                """
            )
        );

        Assert.Throws<AnthropicInvalidDataException>(() => mismatchedValue.ID);
        Assert.Throws<AnthropicInvalidDataException>(() => mismatchedValue.CreatedAt);
    }
}

public class BetaClaudeTagBundleTargetTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaClaudeTagBundleTargetType.SlackChannel)]
    [InlineData(BetaClaudeTagBundleTargetType.SlackWorkspace)]
    public void Validation_Works(BetaClaudeTagBundleTargetType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaClaudeTagBundleTargetType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaClaudeTagBundleTargetType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaClaudeTagBundleTargetType.SlackChannel, 0, "slack_channel")]
    [InlineData(BetaClaudeTagBundleTargetType.SlackWorkspace, 1, "slack_workspace")]
    public void EnumMemberSerializationRoundtrip_Works(
        BetaClaudeTagBundleTargetType rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaClaudeTagBundleTargetType> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaClaudeTagBundleTargetType>
        >(apiJson, ModelBase.SerializerOptions);

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaClaudeTagBundleTargetType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaClaudeTagBundleTargetType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
