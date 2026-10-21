using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class DiagnosticsParamTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DiagnosticsParam { PreviousMessageID = "previous_message_id" };

        string expectedPreviousMessageID = "previous_message_id";

        Assert.Equal(expectedPreviousMessageID, model.PreviousMessageID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DiagnosticsParam { PreviousMessageID = "previous_message_id" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DiagnosticsParam>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DiagnosticsParam { PreviousMessageID = "previous_message_id" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DiagnosticsParam>(
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
        var model = new DiagnosticsParam { PreviousMessageID = "previous_message_id" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DiagnosticsParam { };

        Assert.Null(model.PreviousMessageID);
        Assert.False(model.RawData.ContainsKey("previous_message_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new DiagnosticsParam { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new DiagnosticsParam { PreviousMessageID = null };

        Assert.Null(model.PreviousMessageID);
        Assert.True(model.RawData.ContainsKey("previous_message_id"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DiagnosticsParam { PreviousMessageID = null };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DiagnosticsParam { PreviousMessageID = "previous_message_id" };

        DiagnosticsParam copied = new(model);

        Assert.Equal(model, copied);
    }
}
