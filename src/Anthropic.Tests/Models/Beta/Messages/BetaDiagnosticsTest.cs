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

        BetaCacheMissReason expectedCacheMissReason = new BetaCacheMissModelChanged(0);

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

        BetaCacheMissReason expectedCacheMissReason = new BetaCacheMissModelChanged(0);

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
