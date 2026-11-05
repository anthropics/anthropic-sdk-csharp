using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Organization.Users;

namespace Anthropic.Tests.Models.Beta.Organization.Users;

public class BetaCannotSignOutPrimaryOwnerErrorDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaCannotSignOutPrimaryOwnerErrorDetails { };

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "cannot_sign_out_primary_owner"
        );

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, model.ErrorCode));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaCannotSignOutPrimaryOwnerErrorDetails { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaCannotSignOutPrimaryOwnerErrorDetails>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaCannotSignOutPrimaryOwnerErrorDetails { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaCannotSignOutPrimaryOwnerErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement(
            "cannot_sign_out_primary_owner"
        );

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, deserialized.ErrorCode));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaCannotSignOutPrimaryOwnerErrorDetails { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaCannotSignOutPrimaryOwnerErrorDetails { };

        BetaCannotSignOutPrimaryOwnerErrorDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}
