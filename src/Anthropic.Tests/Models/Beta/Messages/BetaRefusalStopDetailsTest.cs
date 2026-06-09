using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaRefusalStopDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaRefusalStopDetails
        {
            Category = Category.Cyber,
            Explanation = "explanation",
            FallbackCreditToken = "fallback_credit_token",
            FallbackHasPrefillClaim = true,
            RecommendedModel = "recommended_model",
        };

        ApiEnum<string, Category> expectedCategory = Category.Cyber;
        string expectedExplanation = "explanation";
        string expectedFallbackCreditToken = "fallback_credit_token";
        bool expectedFallbackHasPrefillClaim = true;
        string expectedRecommendedModel = "recommended_model";
        JsonElement expectedType = JsonSerializer.SerializeToElement("refusal");

        Assert.Equal(expectedCategory, model.Category);
        Assert.Equal(expectedExplanation, model.Explanation);
        Assert.Equal(expectedFallbackCreditToken, model.FallbackCreditToken);
        Assert.Equal(expectedFallbackHasPrefillClaim, model.FallbackHasPrefillClaim);
        Assert.Equal(expectedRecommendedModel, model.RecommendedModel);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaRefusalStopDetails
        {
            Category = Category.Cyber,
            Explanation = "explanation",
            FallbackCreditToken = "fallback_credit_token",
            FallbackHasPrefillClaim = true,
            RecommendedModel = "recommended_model",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRefusalStopDetails>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaRefusalStopDetails
        {
            Category = Category.Cyber,
            Explanation = "explanation",
            FallbackCreditToken = "fallback_credit_token",
            FallbackHasPrefillClaim = true,
            RecommendedModel = "recommended_model",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRefusalStopDetails>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Category> expectedCategory = Category.Cyber;
        string expectedExplanation = "explanation";
        string expectedFallbackCreditToken = "fallback_credit_token";
        bool expectedFallbackHasPrefillClaim = true;
        string expectedRecommendedModel = "recommended_model";
        JsonElement expectedType = JsonSerializer.SerializeToElement("refusal");

        Assert.Equal(expectedCategory, deserialized.Category);
        Assert.Equal(expectedExplanation, deserialized.Explanation);
        Assert.Equal(expectedFallbackCreditToken, deserialized.FallbackCreditToken);
        Assert.Equal(expectedFallbackHasPrefillClaim, deserialized.FallbackHasPrefillClaim);
        Assert.Equal(expectedRecommendedModel, deserialized.RecommendedModel);
        Assert.True(JsonElement.DeepEquals(expectedType, deserialized.Type));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaRefusalStopDetails
        {
            Category = Category.Cyber,
            Explanation = "explanation",
            FallbackCreditToken = "fallback_credit_token",
            FallbackHasPrefillClaim = true,
            RecommendedModel = "recommended_model",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaRefusalStopDetails
        {
            Category = Category.Cyber,
            Explanation = "explanation",
            FallbackCreditToken = "fallback_credit_token",
            FallbackHasPrefillClaim = true,
            RecommendedModel = "recommended_model",
        };

        BetaRefusalStopDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CategoryTest : TestBase
{
    [Theory]
    [InlineData(Category.Cyber)]
    [InlineData(Category.Bio)]
    [InlineData(Category.FrontierLlm)]
    [InlineData(Category.ReasoningExtraction)]
    public void Validation_Works(Category rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Category> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Category>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Category.Cyber)]
    [InlineData(Category.Bio)]
    [InlineData(Category.FrontierLlm)]
    [InlineData(Category.ReasoningExtraction)]
    public void SerializationRoundtrip_Works(Category rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Category> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Category>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Category>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Category>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
