using System;
using Anthropic.Core;

namespace Anthropic.Tests.Core.Telemetry;

public sealed class OpenTelemetryOptionsTest
{
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void Bool_IsTheShortFormOfTracesWithOnlyEnabledSet(bool enabled)
    {
        OpenTelemetryOptions fromBool = enabled;
        OpenTelemetryOptions tracesFromBool = new() { Traces = enabled };
        OpenTelemetryTraces traces = enabled;
        ClientOptions clientOptions = new() { OpenTelemetry = enabled };

        OpenTelemetryOptions longForm = new() { Traces = new() { Enabled = enabled } };
        Assert.Equal(longForm, fromBool);
        Assert.Equal(longForm, tracesFromBool);
        Assert.Equal(longForm, clientOptions.OpenTelemetry);
        Assert.Equal(new OpenTelemetryTraces { Enabled = enabled }, traces);
        Assert.Null(traces.ContentMode);
        Assert.Null(traces.MaxContentBytes);
    }

    [Fact]
    public void Traces_LeaveEverySettingUnset_ByDefault()
    {
        Assert.Null(new OpenTelemetryOptions().Traces);

        var traces = new OpenTelemetryTraces();
        Assert.Null(traces.Enabled);
        Assert.Null(traces.ContentMode);
        Assert.Null(traces.MaxContentBytes);
    }

    [Theory]
    [InlineData(1L)]
    [InlineData(750_000L)]
    [InlineData(long.MaxValue)]
    [InlineData(null)]
    public void MaxContentBytes_OfAtLeastOne_OrUnset_IsKept(long? maxContentBytes)
    {
        var traces = new OpenTelemetryTraces { MaxContentBytes = maxContentBytes };

        Assert.Equal(maxContentBytes, traces.MaxContentBytes);
        Assert.Equal(maxContentBytes, (traces with { Enabled = true }).MaxContentBytes);
    }

    [Theory]
    [InlineData(0L)]
    [InlineData(-1L)]
    [InlineData(long.MinValue)]
    public void MaxContentBytes_UnderOne_IsRejectedWithItsValue(long maxContentBytes)
    {
        var error = Assert.Throws<ArgumentOutOfRangeException>(() =>
            new OpenTelemetryTraces { MaxContentBytes = maxContentBytes }
        );

        Assert.Equal(nameof(OpenTelemetryTraces.MaxContentBytes), error.ParamName);
        Assert.Equal(maxContentBytes, error.ActualValue);
        Assert.Throws<ArgumentOutOfRangeException>(() =>
            new OpenTelemetryTraces() with
            {
                MaxContentBytes = maxContentBytes,
            }
        );
    }

    [Fact]
    public void MaxContentBytes_OverWhatAStringHolds_IsAsManyAsAStringHolds()
    {
        OpenTelemetryOptions options = new() { Traces = new() { MaxContentBytes = long.MaxValue } };

        Assert.Equal(int.MaxValue, Anthropic.Core.Telemetry.Content.Limit(options));
    }
}
