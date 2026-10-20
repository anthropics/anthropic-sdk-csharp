using System;
using Anthropic.Core;
using Anthropic.Core.Telemetry;

namespace Anthropic.Tests.Core.Telemetry;

[Collection("EnvVarMutating")]
public sealed class OpenTelemetryDefaultsTest : IDisposable
{
    const string FormerContentModeVariable = "ANTHROPIC_OPEN_TELEMETRY_CONTENT_MODE";

    static readonly string[] Variables =
    [
        OpenTelemetryDefaults.TracesVariable,
        OpenTelemetryDefaults.ContentModeVariable,
        OpenTelemetryDefaults.MaxContentBytesVariable,
        FormerContentModeVariable,
    ];

    readonly string?[] _values = Array.ConvertAll(Variables, Environment.GetEnvironmentVariable);

    public OpenTelemetryDefaultsTest()
    {
        foreach (var variable in Variables)
        {
            Environment.SetEnvironmentVariable(variable, null);
        }
    }

    public void Dispose()
    {
        for (var index = 0; index < Variables.Length; index++)
        {
            Environment.SetEnvironmentVariable(Variables[index], _values[index]);
        }
    }

    static OpenTelemetryOptions Options(
        bool enabled,
        OpenTelemetryContentMode contentMode,
        long maxContentBytes = Content.ContentLimit
    ) =>
        new()
        {
            Traces = new()
            {
                Enabled = enabled,
                ContentMode = contentMode,
                MaxContentBytes = maxContentBytes,
            },
        };

    [Theory]
    [InlineData(null, null, true, OpenTelemetryContentMode.MetadataOnly)]
    [InlineData("FALSE", "Content", false, OpenTelemetryContentMode.Content)]
    [InlineData("0", "everything", true, OpenTelemetryContentMode.MetadataOnly)]
    public void Environment_GivesTheOptionsOfAClientThatIsGivenNone(
        string? traces,
        string? content,
        bool expectedEnabled,
        OpenTelemetryContentMode expectedContentMode
    )
    {
        Environment.SetEnvironmentVariable(OpenTelemetryDefaults.TracesVariable, traces);
        Environment.SetEnvironmentVariable(OpenTelemetryDefaults.ContentModeVariable, content);

        var defaults = new OpenTelemetryDefaults();

        Assert.Equal(Options(expectedEnabled, expectedContentMode), defaults.Resolve(null));
    }

    [Theory]
    [InlineData("2048", 2048L)]
    [InlineData(" 1 ", 1L)]
    [InlineData("9223372036854775807", long.MaxValue)]
    [InlineData(null, 750_000L)]
    [InlineData("", (long)Content.ContentLimit)]
    [InlineData("0", (long)Content.ContentLimit)]
    [InlineData("-5", (long)Content.ContentLimit)]
    [InlineData("1.5", (long)Content.ContentLimit)]
    [InlineData("1e3", (long)Content.ContentLimit)]
    [InlineData("many", (long)Content.ContentLimit)]
    [InlineData("9223372036854775808", (long)Content.ContentLimit)]
    public void MaxContentBytesVariable_IsUsedWhenItIsAWholeNumberOfAtLeastOne_AndIgnoredOtherwise(
        string? value,
        long expected
    )
    {
        Environment.SetEnvironmentVariable(OpenTelemetryDefaults.MaxContentBytesVariable, value);

        var resolved = new OpenTelemetryDefaults().Resolve(null);

        Assert.Equal(expected, resolved.Traces?.MaxContentBytes);
    }

    [Fact]
    public void FormerContentModeVariable_IsNotRead()
    {
        Environment.SetEnvironmentVariable(FormerContentModeVariable, "content");

        var resolved = new OpenTelemetryDefaults().Resolve(null);

        Assert.Equal(OpenTelemetryContentMode.MetadataOnly, resolved.Traces?.ContentMode);
    }

    [Fact]
    public void Resolve_KeepsWhatIsSet_AndTakesNothingFromTheEnvironment_ForOptionsThatAreSet()
    {
        Environment.SetEnvironmentVariable(OpenTelemetryDefaults.TracesVariable, "false");
        Environment.SetEnvironmentVariable(OpenTelemetryDefaults.ContentModeVariable, "content");
        Environment.SetEnvironmentVariable(OpenTelemetryDefaults.MaxContentBytesVariable, "2048");
        var defaults = new OpenTelemetryDefaults();
        var set = Options(enabled: true, OpenTelemetryContentMode.MetadataOnly, 512);

        Assert.Same(set, defaults.Resolve(set));
        Assert.Equal(
            Options(enabled: false, OpenTelemetryContentMode.Content, 2048),
            defaults.Resolve(null)
        );
        Assert.Equal(
            Options(enabled: true, OpenTelemetryContentMode.MetadataOnly),
            defaults.Resolve(new())
        );
        Assert.Equal(
            Options(enabled: true, OpenTelemetryContentMode.MetadataOnly),
            defaults.Resolve(new() { Traces = new() })
        );
        Assert.Equal(
            Options(enabled: true, OpenTelemetryContentMode.MetadataOnly),
            defaults.Resolve(true)
        );
        Assert.Equal(
            Options(enabled: false, OpenTelemetryContentMode.MetadataOnly),
            defaults.Resolve(false)
        );
        Assert.Equal(
            Options(enabled: true, OpenTelemetryContentMode.Content),
            defaults.Resolve(
                new() { Traces = new() { ContentMode = OpenTelemetryContentMode.Content } }
            )
        );
        Assert.Equal(
            Options(enabled: true, OpenTelemetryContentMode.MetadataOnly, 64),
            defaults.Resolve(new() { Traces = new() { MaxContentBytes = 64 } })
        );
    }

    [Fact]
    public void Defaults_KeepWhatTheyRead_WhenTheEnvironmentChangesLater()
    {
        Environment.SetEnvironmentVariable(OpenTelemetryDefaults.MaxContentBytesVariable, "2048");
        var defaults = new OpenTelemetryDefaults();

        Environment.SetEnvironmentVariable(OpenTelemetryDefaults.MaxContentBytesVariable, "64");

        Assert.Equal(2048, defaults.Resolve(null).Traces?.MaxContentBytes);
    }
}
