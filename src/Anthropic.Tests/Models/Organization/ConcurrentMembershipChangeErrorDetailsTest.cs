using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Organization;

namespace Anthropic.Tests.Models.Organization;

public class ConcurrentMembershipChangeErrorDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConcurrentMembershipChangeErrorDetails { };

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "concurrent_membership_change"
        );

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, model.ErrorCode));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ConcurrentMembershipChangeErrorDetails { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConcurrentMembershipChangeErrorDetails>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConcurrentMembershipChangeErrorDetails { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConcurrentMembershipChangeErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "concurrent_membership_change"
        );

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, deserialized.ErrorCode));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ConcurrentMembershipChangeErrorDetails { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ConcurrentMembershipChangeErrorDetails { };

        ConcurrentMembershipChangeErrorDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}
