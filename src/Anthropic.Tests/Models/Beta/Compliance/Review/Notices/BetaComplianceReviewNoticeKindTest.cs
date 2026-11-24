using System.Text.Json;
using Anthropic.Core;
using Anthropic.Exceptions;
using Anthropic.Models.Beta.Compliance.Review.Notices;

namespace Anthropic.Tests.Models.Beta.Compliance.Review.Notices;

public class BetaComplianceReviewNoticeKindTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaComplianceReviewNoticeKind { Type = Type.ResponseRequested };

        ApiEnum<string, Type> expectedType = Type.ResponseRequested;

        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaComplianceReviewNoticeKind { Type = Type.ResponseRequested };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComplianceReviewNoticeKind>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaComplianceReviewNoticeKind { Type = Type.ResponseRequested };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaComplianceReviewNoticeKind>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Type> expectedType = Type.ResponseRequested;

        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaComplianceReviewNoticeKind { Type = Type.ResponseRequested };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaComplianceReviewNoticeKind { Type = Type.ResponseRequested };

        BetaComplianceReviewNoticeKind copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Type.ResponseRequested)]
    [InlineData(Type.Warning)]
    [InlineData(Type.Question)]
    public void Validation_Works(Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<AnthropicInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Type.ResponseRequested, 2053735556, "response_requested")]
    [InlineData(Type.Warning, 1688719099, "warning")]
    [InlineData(Type.Question, 917918359, "question")]
    public void EnumMemberSerializationRoundtrip_Works(Type rawValue, int number, string apiValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Type> value = rawValue;
        string apiJson = JsonSerializer.Serialize(apiValue, ModelBase.SerializerOptions);

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            apiJson,
            ModelBase.SerializerOptions
        );

        Assert.Equal(number, (int)rawValue);
        Assert.Equal(apiJson, json);
        Assert.NotNull(deserialized);
        Assert.Equal(rawValue, deserialized.Value());
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
