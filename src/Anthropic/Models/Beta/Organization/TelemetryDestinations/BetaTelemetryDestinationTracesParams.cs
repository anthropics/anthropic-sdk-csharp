using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.TelemetryDestinations;

/// <summary>
/// The settings for the traces that a telemetry destination receives, as a create
/// or update request sets them. An omitted field takes its default on create and
/// keeps its stored value on update.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaTelemetryDestinationTracesParams,
        BetaTelemetryDestinationTracesParamsFromRaw
    >)
)]
public sealed record class BetaTelemetryDestinationTracesParams : JsonModel
{
    /// <summary>
    /// What the exported spans contain. Defaults to `metadata_only` on create.
    ///
    /// <para>On update, `null` sets `metadata_only`.</para>
    /// </summary>
    public ApiEnum<string, BetaTelemetryDestinationContentMode>? ContentMode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<
                ApiEnum<string, BetaTelemetryDestinationContentMode>
            >("content_mode");
        }
        init { this._rawData.Set("content_mode", value); }
    }

    /// <summary>
    /// Whether the destination receives traces. Defaults to true on create. It cannot
    /// be null.
    /// </summary>
    public bool? Enabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("enabled");
        }
        init
        {
            if (value == null)
            {
                this._rawData.Remove("enabled");
                return;
            }

            this._rawData.Set("enabled", value);
        }
    }

    /// <summary>
    /// The full URL of your collector's traces endpoint, for a collector that takes
    /// traces on a path other than `/v1/traces`. The API posts traces to it exactly
    /// as given and appends nothing.
    ///
    /// <para>The same rules as for `endpoint_url` apply, except that any path is
    /// allowed. It must have the same scheme, host, and port as `endpoint_url`.
    /// At most 2,048 characters.</para>
    ///
    /// <para>On create, `null` is the same as leaving it out. On update, `null` removes
    /// it. The API then posts traces to `endpoint_url` with `/v1/traces` appended.
    /// A change of this URL alone keeps the registered headers.</para>
    /// </summary>
    public string? EndpointUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("endpoint_url");
        }
        init { this._rawData.Set("endpoint_url", value); }
    }

    /// <summary>
    /// The most bytes of content that one exported span can contain, from 1 up to
    /// the API's maximum. `null` sets no bound, so only the API's maximum applies.
    ///
    /// <para>On create, leaving it out is the same as `null`. The error for a value
    /// above the maximum states the maximum.</para>
    /// </summary>
    public int? MaxContentBytes
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<int>("max_content_bytes");
        }
        init { this._rawData.Set("max_content_bytes", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.ContentMode?.Validate();
        _ = this.Enabled;
        _ = this.EndpointUrl;
        _ = this.MaxContentBytes;
    }

    public BetaTelemetryDestinationTracesParams() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaTelemetryDestinationTracesParams(
        BetaTelemetryDestinationTracesParams betaTelemetryDestinationTracesParams
    )
        : base(betaTelemetryDestinationTracesParams) { }
#pragma warning restore CS8618

    public BetaTelemetryDestinationTracesParams(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaTelemetryDestinationTracesParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaTelemetryDestinationTracesParamsFromRaw.FromRawUnchecked"/>
    public static BetaTelemetryDestinationTracesParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaTelemetryDestinationTracesParamsFromRaw
    : IFromRawJson<BetaTelemetryDestinationTracesParams>
{
    /// <inheritdoc/>
    public BetaTelemetryDestinationTracesParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaTelemetryDestinationTracesParams.FromRawUnchecked(rawData);
}
