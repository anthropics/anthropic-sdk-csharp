using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization;

namespace Anthropic.Tests.Models.Beta.Organization;

public class BetaAuthorizationCheckUnavailableErrorDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaAuthorizationCheckUnavailableErrorDetails { };

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "authorization_check_unavailable"
        );

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, model.ErrorCode));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaAuthorizationCheckUnavailableErrorDetails { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaAuthorizationCheckUnavailableErrorDetails>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaAuthorizationCheckUnavailableErrorDetails { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaAuthorizationCheckUnavailableErrorDetails>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "authorization_check_unavailable"
        );

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, deserialized.ErrorCode));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaAuthorizationCheckUnavailableErrorDetails { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaAuthorizationCheckUnavailableErrorDetails { };

        BetaAuthorizationCheckUnavailableErrorDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}
