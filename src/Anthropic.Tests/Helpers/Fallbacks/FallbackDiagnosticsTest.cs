using System;
using System.IO;
using System.Net;
using Anthropic.Helpers.Fallbacks;

namespace Anthropic.Tests.Helpers.Fallbacks;

public class FallbackDiagnosticsTest
{
    [Fact]
    public void WarnPrefixesTheComponentName()
    {
        StringWriter writer = new();

        new FallbackDiagnostics(writer).Warn("something happened");

        Assert.Equal(
            "WARNING: `BetaRefusalFallbackHandler`: something happened" + Environment.NewLine,
            writer.ToString()
        );
    }

    [Fact]
    public void WarnHopFailureIncludesModelStatusAndBody()
    {
        StringWriter writer = new();

        new FallbackDiagnostics(writer).WarnHopFailure(
            "model-x",
            HttpStatusCode.BadGateway,
            "boom"
        );

        Assert.Contains("fallback request to model-x failed: HTTP 502: boom", writer.ToString());
    }

    [Fact]
    public void MissingTokenWarningFiresOnce()
    {
        StringWriter writer = new();
        var diagnostics = new FallbackDiagnostics(writer);

        diagnostics.WarnMissingTokenOnce("nothing to retry", betaEnabled: false);
        diagnostics.WarnMissingTokenOnce("nothing to retry", betaEnabled: false);

        var text = writer.ToString();
        Assert.Single(text.Split(["WARNING"], StringSplitOptions.RemoveEmptyEntries));
        Assert.Contains("beta may not be enabled", text);
    }

    [Fact]
    public void MissingTokenWarningOmitsTheBetaCauseWhenTheBetaIsProven()
    {
        StringWriter writer = new();

        new FallbackDiagnostics(writer).WarnMissingTokenOnce("consequence", betaEnabled: true);

        Assert.DoesNotContain("beta may not be enabled", writer.ToString());
        Assert.Contains("so consequence", writer.ToString());
    }

    [Fact]
    public void MissingStateWarningFiresOnce()
    {
        StringWriter writer = new();
        var diagnostics = new FallbackDiagnostics(writer);

        diagnostics.WarnMissingStateOnce();
        diagnostics.WarnMissingStateOnce();

        Assert.Single(writer.ToString().Split(["WARNING"], StringSplitOptions.RemoveEmptyEntries));
    }

    [Fact]
    public void DeltaTypeWarningFiresOncePerType()
    {
        StringWriter writer = new();
        var diagnostics = new FallbackDiagnostics(writer);

        diagnostics.WarnDeltaTypeOnce("alpha_delta");
        diagnostics.WarnDeltaTypeOnce("alpha_delta");
        diagnostics.WarnDeltaTypeOnce("beta_delta");

        var text = writer.ToString();
        Assert.Equal(2, text.Split(["WARNING"], StringSplitOptions.RemoveEmptyEntries).Length);
        Assert.Contains("\"alpha_delta\"", text);
        Assert.Contains("\"beta_delta\"", text);
    }
}
