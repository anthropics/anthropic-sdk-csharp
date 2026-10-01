using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.PluginMarketplaces;

/// <summary>
/// The outcome of validating plugin marketplace content: a report, not a stored
/// object, so nothing in it can be retrieved afterwards.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaPluginMarketplaceValidationReport,
        BetaPluginMarketplaceValidationReportFromRaw
    >)
)]
public sealed record class BetaPluginMarketplaceValidationReport : JsonModel
{
    /// <summary>
    /// The full SHA of the commit that was validated: for a repository, the commit
    /// that was read; for an uploaded archive, the commit recorded in the archive's
    /// comment (as a Git host's download writes it; not verified), else null.
    /// </summary>
    public required string? CommitSha
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("commit_sha");
        }
        init { this._rawData.Set("commit_sha", value); }
    }

    /// <summary>
    /// Set when nothing could be validated: the repository or archive could not
    /// be read, or marketplace.json is missing, malformed or over a limit. Null otherwise.
    /// </summary>
    public required string? ManifestError
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("manifest_error");
        }
        init { this._rawData.Set("manifest_error", value); }
    }

    /// <summary>
    /// A stable identifier for `manifest_error`; null when that is.
    /// </summary>
    public required string? ManifestErrorCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("manifest_error_code");
        }
        init { this._rawData.Set("manifest_error_code", value); }
    }

    /// <summary>
    /// One entry per plugin a synchronization would skip entirely, keyed by the
    /// plugin's name in marketplace.json.
    /// </summary>
    public required IReadOnlyList<BetaPluginMarketplaceValidationPluginError> PluginErrors
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<BetaPluginMarketplaceValidationPluginError>
            >("plugin_errors");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaPluginMarketplaceValidationPluginError>>(
                "plugin_errors",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// One entry per plugin that would synchronize with some of its contents left
    /// out, keyed by the plugin's name in marketplace.json.
    /// </summary>
    public required IReadOnlyList<BetaPluginMarketplaceValidationPluginWarnings> PluginWarnings
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<BetaPluginMarketplaceValidationPluginWarnings>
            >("plugin_warnings");
        }
        init
        {
            this._rawData.Set<ImmutableArray<BetaPluginMarketplaceValidationPluginWarnings>>(
                "plugin_warnings",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <summary>
    /// For a repository, the branch that was read by name: the one requested, or
    /// else the branch a synchronization of this repository is set to read. Null
    /// when no branch is named or set and the repository's default branch was read,
    /// for a request by commit SHA, and for an uploaded archive.
    /// </summary>
    public required string? Ref
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("ref");
        }
        init { this._rawData.Set("ref", value); }
    }

    /// <summary>
    /// How many plugins marketplace.json declares; 0 when it could not be read.
    /// </summary>
    public required long TotalPluginCount
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("total_plugin_count");
        }
        init { this._rawData.Set("total_plugin_count", value); }
    }

    /// <summary>
    /// Always `plugin_marketplace_validation_report`.
    /// </summary>
    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// True when marketplace.json is well-formed and no plugin would be skipped;
    /// warnings never make it false.
    /// </summary>
    public required bool Valid
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("valid");
        }
        init { this._rawData.Set("valid", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.CommitSha;
        _ = this.ManifestError;
        _ = this.ManifestErrorCode;
        foreach (var item in this.PluginErrors)
        {
            item.Validate();
        }
        foreach (var item in this.PluginWarnings)
        {
            item.Validate();
        }
        _ = this.Ref;
        _ = this.TotalPluginCount;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("plugin_marketplace_validation_report")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.Valid;
    }

    public BetaPluginMarketplaceValidationReport()
    {
        this.Type = JsonSerializer.SerializeToElement("plugin_marketplace_validation_report");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaPluginMarketplaceValidationReport(
        BetaPluginMarketplaceValidationReport betaPluginMarketplaceValidationReport
    )
        : base(betaPluginMarketplaceValidationReport) { }
#pragma warning restore CS8618

    public BetaPluginMarketplaceValidationReport(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("plugin_marketplace_validation_report");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaPluginMarketplaceValidationReport(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaPluginMarketplaceValidationReportFromRaw.FromRawUnchecked"/>
    public static BetaPluginMarketplaceValidationReport FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaPluginMarketplaceValidationReportFromRaw
    : IFromRawJson<BetaPluginMarketplaceValidationReport>
{
    /// <inheritdoc/>
    public BetaPluginMarketplaceValidationReport FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaPluginMarketplaceValidationReport.FromRawUnchecked(rawData);
}
