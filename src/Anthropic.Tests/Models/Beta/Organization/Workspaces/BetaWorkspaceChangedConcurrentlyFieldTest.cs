using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Organization.Workspaces;

namespace Anthropic.Tests.Models.Beta.Organization.Workspaces;

public class BetaWorkspaceChangedConcurrentlyFieldTest : TestBase
{
    [Theory]
    [InlineData(BetaWorkspaceChangedConcurrentlyField.InferenceDataPrivacyHumanReview)]
    public void Validation_Works(BetaWorkspaceChangedConcurrentlyField rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaWorkspaceChangedConcurrentlyField> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaWorkspaceChangedConcurrentlyField>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        BetaWorkspaceChangedConcurrentlyField.InferenceDataPrivacyHumanReview,
        1973071699,
        "inference_data_privacy.human_review"
    )]
    public void EnumMemberSerializationRoundtrip_Works(
        BetaWorkspaceChangedConcurrentlyField rawValue,
        int number,
        string apiValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BetaWorkspaceChangedConcurrentlyField> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaWorkspaceChangedConcurrentlyField>
        >(apiJson, ModelBase.SerializerOptions);

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, BetaWorkspaceChangedConcurrentlyField>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, BetaWorkspaceChangedConcurrentlyField>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
