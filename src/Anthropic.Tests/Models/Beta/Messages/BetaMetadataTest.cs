using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaMetadataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaMetadata { UserID = "13803d75-b4b5-4c3e-b2a2-6f21399b021b" };

        string expectedUserID = "13803d75-b4b5-4c3e-b2a2-6f21399b021b";

        Assert.Equal(expectedUserID, model.UserID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaMetadata { UserID = "13803d75-b4b5-4c3e-b2a2-6f21399b021b" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaMetadata>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaMetadata { UserID = "13803d75-b4b5-4c3e-b2a2-6f21399b021b" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaMetadata>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedUserID = "13803d75-b4b5-4c3e-b2a2-6f21399b021b";

        Assert.Equal(expectedUserID, deserialized.UserID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaMetadata { UserID = "13803d75-b4b5-4c3e-b2a2-6f21399b021b" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaMetadata { };

        Assert.Null(model.UserID);
        Assert.False(model.RawData.ContainsKey("user_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaMetadata { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaMetadata { UserID = null };

        Assert.Null(model.UserID);
        Assert.True(model.RawData.ContainsKey("user_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaMetadata { UserID = null };

        model.Validate();
    }
}
