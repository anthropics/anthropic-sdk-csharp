using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Organization.TelemetryDestinations;

/// <summary>
/// A telemetry destination's settings for the traces it receives.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaTelemetryDestinationTraces,
        BetaTelemetryDestinationTracesFromRaw
    >)
)]
public sealed record class BetaTelemetryDestinationTraces : JsonModel
{
    /// <summary>
    /// What the exported spans contain.
    /// </summary>
    public required ApiEnum<string, BetaTelemetryDestinationContentMode> ContentMode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaTelemetryDestinationContentMode>
            >("content_mode");
        }
        init { this._rawData.Set("content_mode", value); }
    }

    /// <summary>
    /// Whether the destination receives traces. A destination whose `enabled` is
    /// false keeps its other settings.
    /// </summary>
    public required bool Enabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<bool>("enabled");
        }
        init { this._rawData.Set("enabled", value); }
    }

    /// <summary>
    /// The full URL that the API posts traces to, exactly as registered, or `null`
    /// if the destination doesn't have one.
    ///
    /// <para>When it is `null`, the API posts traces to `endpoint_url` with `/v1/traces` appended.</para>
    /// </summary>
    public required string? EndpointUrl
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("endpoint_url");
        }
        init { this._rawData.Set("endpoint_url", value); }
    }

    /// <summary>
    /// The most bytes of content that one exported span can contain, or `null` if
    /// only the API's maximum applies.
    ///
    /// <para>Content means model prompts and responses, and tool inputs and outputs.
    /// The API shortens longer content to this size before it delivers the span.
    /// A destination whose `content_mode` is `metadata_only` keeps this value. It
    /// applies once `content_mode` is `content`.</para>
    /// </summary>
    public required int? MaxContentBytes
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
        this.ContentMode.Validate();
        _ = this.Enabled;
        _ = this.EndpointUrl;
        _ = this.MaxContentBytes;
    }

    public BetaTelemetryDestinationTraces() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaTelemetryDestinationTraces(
        BetaTelemetryDestinationTraces betaTelemetryDestinationTraces
    )
        : base(betaTelemetryDestinationTraces) { }
#pragma warning restore CS8618

    public BetaTelemetryDestinationTraces(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaTelemetryDestinationTraces(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaTelemetryDestinationTracesFromRaw.FromRawUnchecked"/>
    public static BetaTelemetryDestinationTraces FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaTelemetryDestinationTracesFromRaw : IFromRawJson<BetaTelemetryDestinationTraces>
{
    /// <inheritdoc/>
    public BetaTelemetryDestinationTraces FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaTelemetryDestinationTraces.FromRawUnchecked(rawData);
}
