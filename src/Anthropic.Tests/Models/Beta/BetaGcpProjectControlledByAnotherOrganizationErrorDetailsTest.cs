using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta;

namespace Anthropic.Tests.Models.Beta;

public class BetaGcpProjectControlledByAnotherOrganizationErrorDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaGcpProjectControlledByAnotherOrganizationErrorDetails { };

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "gcp_project_controlled_by_another_organization"
        );

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, model.ErrorCode));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaGcpProjectControlledByAnotherOrganizationErrorDetails { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaGcpProjectControlledByAnotherOrganizationErrorDetails>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaGcpProjectControlledByAnotherOrganizationErrorDetails { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<BetaGcpProjectControlledByAnotherOrganizationErrorDetails>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "gcp_project_controlled_by_another_organization"
        );

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, deserialized.ErrorCode));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaGcpProjectControlledByAnotherOrganizationErrorDetails { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaGcpProjectControlledByAnotherOrganizationErrorDetails { };

        BetaGcpProjectControlledByAnotherOrganizationErrorDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}
