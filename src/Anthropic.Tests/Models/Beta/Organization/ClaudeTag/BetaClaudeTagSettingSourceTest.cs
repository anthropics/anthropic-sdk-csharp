using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.ClaudeTag;

namespace Anthropic.Tests.Models.Beta.Organization.ClaudeTag;

public class BetaClaudeTagSettingSourceTest : TestBase
{
    [Fact]
    public void SlackChannelValidationWorks()
    {
        BetaClaudeTagSettingSource value = new BetaClaudeTagSlackChannelSettingSource(
            "slack_channel_id"
        );
        value.Validate();
    }

    [Fact]
    public void SlackWorkspaceValidationWorks()
    {
        BetaClaudeTagSettingSource value = new BetaClaudeTagSlackWorkspaceSettingSource(
            "slack_workspace_id"
        );
        value.Validate();
    }

    [Fact]
    public void SlackParentChannelValidationWorks()
    {
        BetaClaudeTagSettingSource value = new BetaClaudeTagSlackParentChannelSettingSource(
            "slack_channel_id"
        );
        value.Validate();
    }

    [Fact]
    public void SlackDefaultValidationWorks()
    {
        BetaClaudeTagSettingSource value = new BetaClaudeTagSlackDefaultSettingSource();
        value.Validate();
    }

    [Fact]
    public void DefaultValidationWorks()
    {
        BetaClaudeTagSettingSource value = new BetaClaudeTagDefaultSettingSource();
        value.Validate();
    }

    [Fact]
    public void SlackGridChannelValidationWorks()
    {
        BetaClaudeTagSettingSource value = new BetaClaudeTagSlackGridChannelSettingSource(
            new BetaClaudeTagSlackChannelIdentifiers() { ChannelID = "xx", WorkspaceID = "xx" }
        );
        value.Validate();
    }

    [Fact]
    public void SlackChannelSerializationRoundtripWorks()
    {
        BetaClaudeTagSettingSource value = new BetaClaudeTagSlackChannelSettingSource(
            "slack_channel_id"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaClaudeTagSettingSource>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SlackWorkspaceSerializationRoundtripWorks()
    {
        BetaClaudeTagSettingSource value = new BetaClaudeTagSlackWorkspaceSettingSource(
            "slack_workspace_id"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaClaudeTagSettingSource>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SlackParentChannelSerializationRoundtripWorks()
    {
        BetaClaudeTagSettingSource value = new BetaClaudeTagSlackParentChannelSettingSource(
            "slack_channel_id"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaClaudeTagSettingSource>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SlackDefaultSerializationRoundtripWorks()
    {
        BetaClaudeTagSettingSource value = new BetaClaudeTagSlackDefaultSettingSource();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaClaudeTagSettingSource>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DefaultSerializationRoundtripWorks()
    {
        BetaClaudeTagSettingSource value = new BetaClaudeTagDefaultSettingSource();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaClaudeTagSettingSource>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SlackGridChannelSerializationRoundtripWorks()
    {
        BetaClaudeTagSettingSource value = new BetaClaudeTagSlackGridChannelSettingSource(
            new BetaClaudeTagSlackChannelIdentifiers() { ChannelID = "xx", WorkspaceID = "xx" }
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaClaudeTagSettingSource>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SlackChannelTypeWorks()
    {
        BetaClaudeTagSettingSource value = new BetaClaudeTagSlackChannelSettingSource(
            "slack_channel_id"
        );
        Assert.Equal(BetaClaudeTagSettingSourceType.SlackChannel, value.Type.Value());
    }

    [Fact]
    public void SlackWorkspaceTypeWorks()
    {
        BetaClaudeTagSettingSource value = new BetaClaudeTagSlackWorkspaceSettingSource(
            "slack_workspace_id"
        );
        Assert.Equal(BetaClaudeTagSettingSourceType.SlackWorkspace, value.Type.Value());
    }

    [Fact]
    public void SlackParentChannelTypeWorks()
    {
        BetaClaudeTagSettingSource value = new BetaClaudeTagSlackParentChannelSettingSource(
            "slack_channel_id"
        );
        Assert.Equal(BetaClaudeTagSettingSourceType.SlackParentChannel, value.Type.Value());
    }

    [Fact]
    public void SlackDefaultTypeWorks()
    {
        BetaClaudeTagSettingSource value = new BetaClaudeTagSlackDefaultSettingSource();
        Assert.Equal(BetaClaudeTagSettingSourceType.SlackDefault, value.Type.Value());
    }

    [Fact]
    public void DefaultTypeWorks()
    {
        BetaClaudeTagSettingSource value = new BetaClaudeTagDefaultSettingSource();
        Assert.Equal(BetaClaudeTagSettingSourceType.Default, value.Type.Value());
    }

    [Fact]
    public void SlackGridChannelTypeWorks()
    {
        BetaClaudeTagSettingSource value = new BetaClaudeTagSlackGridChannelSettingSource(
            new BetaClaudeTagSlackChannelIdentifiers() { ChannelID = "xx", WorkspaceID = "xx" }
        );
        Assert.Equal(BetaClaudeTagSettingSourceType.SlackGridChannel, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaClaudeTagSettingSource value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "slack_channel_id": "slack_channel_id",
                  "type": "slack_channel"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        string expectedSlackChannelID = "slack_channel_id";
        ApiEnum<string, BetaClaudeTagSettingSourceType> expectedType =
            BetaClaudeTagSettingSourceType.SlackChannel;

        Assert.Equal(expectedSlackChannelID, value.SlackChannelID);
        Assert.Equal(expectedType, value.Type);

        BetaClaudeTagSettingSource emptyValue = new(JsonSerializer.Deserialize<JsonElement>("{}"));

        Assert.Null(emptyValue.SlackChannelID);
        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);

        BetaClaudeTagSettingSource mismatchedValue = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "slack_channel_id": [
                    "invalid"
                  ]
                }
                """
            )
        );

        Assert.Null(mismatchedValue.SlackChannelID);
    }
}

public class BetaClaudeTagSettingSourceTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaClaudeTagSettingSourceType.SlackChannel)]
    [InlineData(BetaClaudeTagSettingSourceType.SlackWorkspace)]
    [InlineData(BetaClaudeTagSettingSourceType.SlackParentChannel)]
    [InlineData(BetaClaudeTagSettingSourceType.SlackDefault)]
    [InlineData(BetaClaudeTagSettingSourceType.Default)]
    [InlineData(BetaClaudeTagSettingSourceType.SlackGridChannel)]
    public void Validation_Works(BetaClaudeTagSettingSourceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaClaudeTagSettingSourceType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaClaudeTagSettingSourceType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaClaudeTagSettingSourceType.SlackChannel)]
    [InlineData(BetaClaudeTagSettingSourceType.SlackWorkspace)]
    [InlineData(BetaClaudeTagSettingSourceType.SlackParentChannel)]
    [InlineData(BetaClaudeTagSettingSourceType.SlackDefault)]
    [InlineData(BetaClaudeTagSettingSourceType.Default)]
    [InlineData(BetaClaudeTagSettingSourceType.SlackGridChannel)]
    public void SerializationRoundtrip_Works(BetaClaudeTagSettingSourceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaClaudeTagSettingSourceType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaClaudeTagSettingSourceType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BetaClaudeTagSettingSourceType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaClaudeTagSettingSourceType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
