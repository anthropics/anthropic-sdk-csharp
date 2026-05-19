using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Environments.Work;

namespace Anthropic.Tests.Models.Beta.Environments.Work;

public class BetaSelfHostedWorkStopRequestTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaSelfHostedWorkStopRequest { Force = true };

        bool expectedForce = true;

        Assert.Equal(expectedForce, model.Force);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaSelfHostedWorkStopRequest { Force = true };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaSelfHostedWorkStopRequest>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaSelfHostedWorkStopRequest { Force = true };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaSelfHostedWorkStopRequest>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedForce = true;

        Assert.Equal(expectedForce, deserialized.Force);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaSelfHostedWorkStopRequest { Force = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaSelfHostedWorkStopRequest { };

        Assert.Null(model.Force);
        Assert.False(model.RawData.ContainsKey("force"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaSelfHostedWorkStopRequest { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BetaSelfHostedWorkStopRequest
        {
            // Null should be interpreted as omitted for these properties
            Force = null,
        };

        Assert.Null(model.Force);
        Assert.False(model.RawData.ContainsKey("force"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaSelfHostedWorkStopRequest
        {
            // Null should be interpreted as omitted for these properties
            Force = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaSelfHostedWorkStopRequest { Force = true };

        BetaSelfHostedWorkStopRequest copied = new(model);

        Assert.Equal(model, copied);
    }
}
