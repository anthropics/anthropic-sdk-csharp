using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.ClaudeCode.ManagedSettings;

namespace Anthropic.Tests.Models.Beta.Organization.ClaudeCode.ManagedSettings;

public class BetaRbacGroupOrderLimitExceededErrorDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaRbacGroupOrderLimitExceededErrorDetails { };

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "rbac_group_order_limit_exceeded"
        );

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, model.ErrorCode));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaRbacGroupOrderLimitExceededErrorDetails { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRbacGroupOrderLimitExceededErrorDetails>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaRbacGroupOrderLimitExceededErrorDetails { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaRbacGroupOrderLimitExceededErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "rbac_group_order_limit_exceeded"
        );

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, deserialized.ErrorCode));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaRbacGroupOrderLimitExceededErrorDetails { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaRbacGroupOrderLimitExceededErrorDetails { };

        BetaRbacGroupOrderLimitExceededErrorDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}
