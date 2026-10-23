using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.ClaudeTag.Bundles.Targets;

namespace Anthropic.Tests.Models.Beta.Organization.ClaudeTag.Bundles.Targets;

public class BetaClaudeTagBundleTargetCreateTest : TestBase
{
    [Fact]
    public void SlackChannelValidationWorks()
    {
        BetaClaudeTagBundleTargetCreate value = new BetaClaudeTagSlackChannelBundleTargetCreate(
            "xxxxxxxx"
        );
        value.Validate();
    }

    [Fact]
    public void SlackWorkspaceValidationWorks()
    {
        BetaClaudeTagBundleTargetCreate value = new BetaClaudeTagSlackWorkspaceBundleTargetCreate(
            "xxxxxxxx"
        );
        value.Validate();
    }

    [Fact]
    public void SlackChannelSerializationRoundtripWorks()
    {
        BetaClaudeTagBundleTargetCreate value = new BetaClaudeTagSlackChannelBundleTargetCreate(
            "xxxxxxxx"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaClaudeTagBundleTargetCreate>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SlackWorkspaceSerializationRoundtripWorks()
    {
        BetaClaudeTagBundleTargetCreate value = new BetaClaudeTagSlackWorkspaceBundleTargetCreate(
            "xxxxxxxx"
        );
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaClaudeTagBundleTargetCreate>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void SlackChannelTypeWorks()
    {
        BetaClaudeTagBundleTargetCreate value = new BetaClaudeTagSlackChannelBundleTargetCreate(
            "xxxxxxxx"
        );
        Assert.Equal(BetaClaudeTagBundleTargetCreateType.SlackChannel, value.Type.Value());
    }

    [Fact]
    public void SlackWorkspaceTypeWorks()
    {
        BetaClaudeTagBundleTargetCreate value = new BetaClaudeTagSlackWorkspaceBundleTargetCreate(
            "xxxxxxxx"
        );
        Assert.Equal(BetaClaudeTagBundleTargetCreateType.SlackWorkspace, value.Type.Value());
    }

    [Fact]
    public void UnknownVariantCommonProperties_Works()
    {
        BetaClaudeTagBundleTargetCreate value = new(
            JsonSerializer.Deserialize<JsonElement>(
                """
                {
                  "type": "slack_channel"
                }
                """
            )
        );
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());

        ApiEnum<string, BetaClaudeTagBundleTargetCreateType> expectedType =
            BetaClaudeTagBundleTargetCreateType.SlackChannel;

        Assert.Equal(expectedType, value.Type);

        BetaClaudeTagBundleTargetCreate emptyValue = new(
            JsonSerializer.Deserialize<JsonElement>("{}")
        );

        Assert.Throws<AnthropicInvalidDataException>(() => emptyValue.Type);
    }
}

public class BetaClaudeTagBundleTargetCreateTypeTest : TestBase
{
    [Theory]
    [InlineData(BetaClaudeTagBundleTargetCreateType.SlackChannel)]
    [InlineData(BetaClaudeTagBundleTargetCreateType.SlackWorkspace)]
    public void Validation_Works(BetaClaudeTagBundleTargetCreateType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaClaudeTagBundleTargetCreateType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaClaudeTagBundleTargetCreateType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BetaClaudeTagBundleTargetCreateType.SlackChannel)]
    [InlineData(BetaClaudeTagBundleTargetCreateType.SlackWorkspace)]
    public void SerializationRoundtrip_Works(BetaClaudeTagBundleTargetCreateType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaClaudeTagBundleTargetCreateType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaClaudeTagBundleTargetCreateType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaClaudeTagBundleTargetCreateType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaClaudeTagBundleTargetCreateType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
