using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models;

namespace Anthropic.Tests.Models;

public class OrganizationOnHoldErrorDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new OrganizationOnHoldErrorDetails { AppealUrl = "appeal_url" };

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement("organization_on_hold");
        string expectedAppealUrl = "appeal_url";

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, model.ErrorCode));
        Assert.Equal(expectedAppealUrl, model.AppealUrl);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new OrganizationOnHoldErrorDetails { AppealUrl = "appeal_url" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OrganizationOnHoldErrorDetails>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new OrganizationOnHoldErrorDetails { AppealUrl = "appeal_url" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<OrganizationOnHoldErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement("organization_on_hold");
        string expectedAppealUrl = "appeal_url";

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, deserialized.ErrorCode));
        Assert.Equal(expectedAppealUrl, deserialized.AppealUrl);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new OrganizationOnHoldErrorDetails { AppealUrl = "appeal_url" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new OrganizationOnHoldErrorDetails { };

        Assert.Null(model.AppealUrl);
        Assert.False(model.RawData.ContainsKey("appeal_url"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new OrganizationOnHoldErrorDetails { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new OrganizationOnHoldErrorDetails { AppealUrl = null };

        Assert.Null(model.AppealUrl);
        Assert.True(model.RawData.ContainsKey("appeal_url"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new OrganizationOnHoldErrorDetails { AppealUrl = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new OrganizationOnHoldErrorDetails { AppealUrl = "appeal_url" };

        OrganizationOnHoldErrorDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}
