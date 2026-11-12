using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models;

namespace Anthropic.Tests.Models;

public class ParentOrganizationRequiredErrorDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ParentOrganizationRequiredErrorDetails { };

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "parent_organization_required"
        );

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, model.ErrorCode));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ParentOrganizationRequiredErrorDetails { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ParentOrganizationRequiredErrorDetails>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ParentOrganizationRequiredErrorDetails { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ParentOrganizationRequiredErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "parent_organization_required"
        );

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, deserialized.ErrorCode));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ParentOrganizationRequiredErrorDetails { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ParentOrganizationRequiredErrorDetails { };

        ParentOrganizationRequiredErrorDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}
