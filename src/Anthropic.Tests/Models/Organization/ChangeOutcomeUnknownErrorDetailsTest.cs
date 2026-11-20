using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Organization;

namespace Anthropic.Tests.Models.Organization;

public class ChangeOutcomeUnknownErrorDetailsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChangeOutcomeUnknownErrorDetails { };

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement("change_outcome_unknown");

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, model.ErrorCode));
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChangeOutcomeUnknownErrorDetails { };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChangeOutcomeUnknownErrorDetails>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChangeOutcomeUnknownErrorDetails { };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChangeOutcomeUnknownErrorDetails>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        JsonElement expectedErrorCode = JsonSerializer.SerializeToElement("change_outcome_unknown");

        Assert.True(JsonElement.DeepEquals(expectedErrorCode, deserialized.ErrorCode));
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChangeOutcomeUnknownErrorDetails { };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChangeOutcomeUnknownErrorDetails { };

        ChangeOutcomeUnknownErrorDetails copied = new(model);

        Assert.Equal(model, copied);
    }
}
