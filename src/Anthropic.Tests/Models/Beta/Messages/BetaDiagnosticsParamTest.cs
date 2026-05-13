using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaDiagnosticsParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaDiagnosticsParam { PreviousMessageID = "previous_message_id" };

        string expectedPreviousMessageID = "previous_message_id";

        Assert.Equal(expectedPreviousMessageID, model.PreviousMessageID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaDiagnosticsParam { PreviousMessageID = "previous_message_id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaDiagnosticsParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaDiagnosticsParam { PreviousMessageID = "previous_message_id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaDiagnosticsParam>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedPreviousMessageID = "previous_message_id";

        Assert.Equal(expectedPreviousMessageID, deserialized.PreviousMessageID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaDiagnosticsParam { PreviousMessageID = "previous_message_id" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BetaDiagnosticsParam { };

        Assert.Null(model.PreviousMessageID);
        Assert.False(model.RawData.ContainsKey("previous_message_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new BetaDiagnosticsParam { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new BetaDiagnosticsParam { PreviousMessageID = null };

        Assert.Null(model.PreviousMessageID);
        Assert.True(model.RawData.ContainsKey("previous_message_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BetaDiagnosticsParam { PreviousMessageID = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaDiagnosticsParam { PreviousMessageID = "previous_message_id" };

        BetaDiagnosticsParam copied = new(model);

        Assert.Equal(model, copied);
    }
}
