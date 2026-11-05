using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta;

namespace Anthropic.Tests.Models.Beta;

public class BetaOrganizationNotEnrolledInBetaErrorDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaOrganizationNotEnrolledInBetaErrorDetails { };

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "organization_not_enrolled_in_beta"
        );

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, model.ErrorCode));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaOrganizationNotEnrolledInBetaErrorDetails { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaOrganizationNotEnrolledInBetaErrorDetails>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaOrganizationNotEnrolledInBetaErrorDetails { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaOrganizationNotEnrolledInBetaErrorDetails>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "organization_not_enrolled_in_beta"
        );

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, deserialized.ErrorCode));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaOrganizationNotEnrolledInBetaErrorDetails { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaOrganizationNotEnrolledInBetaErrorDetails { };

        BetaOrganizationNotEnrolledInBetaErrorDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}
