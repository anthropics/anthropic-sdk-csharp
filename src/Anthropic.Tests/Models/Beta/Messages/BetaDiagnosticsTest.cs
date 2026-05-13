using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaDiagnosticsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaDiagnostics { CacheMissReason = new BetaCacheMissModelChanged(0) };

        CacheMissReason expectedCacheMissReason = new BetaCacheMissModelChanged(0);

        Assert.Equal(expectedCacheMissReason, model.CacheMissReason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BetaDiagnostics { CacheMissReason = new BetaCacheMissModelChanged(0) };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaDiagnostics>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BetaDiagnostics { CacheMissReason = new BetaCacheMissModelChanged(0) };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BetaDiagnostics>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        CacheMissReason expectedCacheMissReason = new BetaCacheMissModelChanged(0);

        Assert.Equal(expectedCacheMissReason, deserialized.CacheMissReason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BetaDiagnostics { CacheMissReason = new BetaCacheMissModelChanged(0) };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BetaDiagnostics { CacheMissReason = new BetaCacheMissModelChanged(0) };

        BetaDiagnostics copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CacheMissReasonTest : TestBase
{
    [Fact]
    public void BetaCacheMissModelChangedValidationWorks()
    {
        CacheMissReason value = new BetaCacheMissModelChanged(0);
        value.Validate();
    }

    [Fact]
    public void BetaCacheMissSystemChangedValidationWorks()
    {
        CacheMissReason value = new BetaCacheMissSystemChanged(0);
        value.Validate();
    }

    [Fact]
    public void BetaCacheMissToolsChangedValidationWorks()
    {
        CacheMissReason value = new BetaCacheMissToolsChanged(0);
        value.Validate();
    }

    [Fact]
    public void BetaCacheMissMessagesChangedValidationWorks()
    {
        CacheMissReason value = new BetaCacheMissMessagesChanged(0);
        value.Validate();
    }

    [Fact]
    public void BetaCacheMissPreviousMessageNotFoundValidationWorks()
    {
        CacheMissReason value = new BetaCacheMissPreviousMessageNotFound();
        value.Validate();
    }

    [Fact]
    public void BetaCacheMissUnavailableValidationWorks()
    {
        CacheMissReason value = new BetaCacheMissUnavailable();
        value.Validate();
    }

    [Fact]
    public void BetaCacheMissModelChangedSerializationRoundtripWorks()
    {
        CacheMissReason value = new BetaCacheMissModelChanged(0);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CacheMissReason>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaCacheMissSystemChangedSerializationRoundtripWorks()
    {
        CacheMissReason value = new BetaCacheMissSystemChanged(0);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CacheMissReason>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaCacheMissToolsChangedSerializationRoundtripWorks()
    {
        CacheMissReason value = new BetaCacheMissToolsChanged(0);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CacheMissReason>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaCacheMissMessagesChangedSerializationRoundtripWorks()
    {
        CacheMissReason value = new BetaCacheMissMessagesChanged(0);
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CacheMissReason>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaCacheMissPreviousMessageNotFoundSerializationRoundtripWorks()
    {
        CacheMissReason value = new BetaCacheMissPreviousMessageNotFound();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CacheMissReason>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BetaCacheMissUnavailableSerializationRoundtripWorks()
    {
        CacheMissReason value = new BetaCacheMissUnavailable();
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CacheMissReason>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
