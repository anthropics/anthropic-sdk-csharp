using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.Organization.Plugins;

[JsonConverter(typeof(JsonModelConverter<BetaPluginContentScan, BetaPluginContentScanFromRaw>))]
public sealed record class BetaPluginContentScan : JsonModel
{
    /// <summary>
    /// The scan's verdict; set only when `status` is `completed`.
    /// </summary>
    public required ApiEnum<string, Assessment>? Assessment
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<ApiEnum<string, Assessment>>("assessment");
        }
        init { this._rawData.Set("assessment", value); }
    }

    /// <summary>
    /// The primary mechanism behind a `warn` or `fail`, such as `credential-exposure`
    /// or `guardrail-tampering`; a mechanism this API does not yet name reads as
    /// `other`. Null on a `pass`, whenever `assessment` is null, and when no mechanism
    /// is reported for the verdict.
    /// </summary>
    public required string? Reason
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("reason");
        }
        init { this._rawData.Set("reason", value); }
    }

    /// <summary>
    /// `processing` while a scan runs, `completed` when it ran to completion, `errored`
    /// when it could not run or its outcome cannot be read.
    /// </summary>
    public required ApiEnum<string, Status> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, Status>>("status");
        }
        init { this._rawData.Set("status", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Assessment?.Validate();
        _ = this.Reason;
        this.Status.Validate();
    }

    public BetaPluginContentScan() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaPluginContentScan(BetaPluginContentScan betaPluginContentScan)
        : base(betaPluginContentScan) { }
#pragma warning restore CS8618

    public BetaPluginContentScan(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaPluginContentScan(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaPluginContentScanFromRaw.FromRawUnchecked"/>
    public static BetaPluginContentScan FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaPluginContentScanFromRaw : IFromRawJson<BetaPluginContentScan>
{
    /// <inheritdoc/>
    public BetaPluginContentScan FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaPluginContentScan.FromRawUnchecked(rawData);
}

/// <summary>
/// The scan's verdict; set only when `status` is `completed`.
/// </summary>
[JsonConverter(typeof(AssessmentConverter))]
public enum Assessment
{
    Fail,
    Pass,
    Unknown,
    Warn,
}

sealed class AssessmentConverter : JsonConverter<Assessment>
{
    public override Assessment Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "fail" => Assessment.Fail,
            "pass" => Assessment.Pass,
            "unknown" => Assessment.Unknown,
            "warn" => Assessment.Warn,
            _ => (Assessment)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        Assessment value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Assessment.Fail => "fail",
                Assessment.Pass => "pass",
                Assessment.Unknown => "unknown",
                Assessment.Warn => "warn",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}

/// <summary>
/// `processing` while a scan runs, `completed` when it ran to completion, `errored`
/// when it could not run or its outcome cannot be read.
/// </summary>
[JsonConverter(typeof(StatusConverter))]
public enum Status
{
    Completed,
    Errored,
    Processing,
}

sealed class StatusConverter : JsonConverter<Status>
{
    public override Status Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "completed" => Status.Completed,
            "errored" => Status.Errored,
            "processing" => Status.Processing,
            _ => (Status)(-1),
        };
    }

    public override void Write(Utf8JsonWriter writer, Status value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                Status.Completed => "completed",
                Status.Errored => "errored",
                Status.Processing => "processing",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
