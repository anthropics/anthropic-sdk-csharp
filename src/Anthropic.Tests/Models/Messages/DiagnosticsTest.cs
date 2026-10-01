using System.Text.Json;
using Anthropic.Core;
using Anthropic.Models.Messages;

namespace Anthropic.Tests.Models.Messages;

public class DiagnosticsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Diagnostics { CacheMissReason = new CacheMissModelChanged(0) };

        CacheMissReason expectedCacheMissReason = new CacheMissModelChanged(0);

        Assert.Equal(expectedCacheMissReason, model.CacheMissReason);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Diagnostics { CacheMissReason = new CacheMissModelChanged(0) };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Diagnostics>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Diagnostics { CacheMissReason = new CacheMissModelChanged(0) };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Diagnostics>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        CacheMissReason expectedCacheMissReason = new CacheMissModelChanged(0);

        Assert.Equal(expectedCacheMissReason, deserialized.CacheMissReason);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Diagnostics { CacheMissReason = new CacheMissModelChanged(0) };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Diagnostics { CacheMissReason = new CacheMissModelChanged(0) };

        Diagnostics copied = new(model);

        Assert.Equal(model, copied);
    }
}
