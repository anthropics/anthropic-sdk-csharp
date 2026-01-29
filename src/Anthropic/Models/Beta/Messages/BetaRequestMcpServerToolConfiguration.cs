using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(JsonModelConverter<
        BetaRequestMcpServerToolConfiguration,
        BetaRequestMcpServerToolConfigurationFromRaw
    >)
)]
public sealed record class BetaRequestMcpServerToolConfiguration : JsonModel
{
    public IReadOnlyList<string>? AllowedTools
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<ImmutableArray<string>>("allowed_tools");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>?>(
                "allowed_tools",
                value == null ? null : ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    public bool? Enabled
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("enabled");
        }
        init { this._rawData.Set("enabled", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AllowedTools;
        _ = this.Enabled;
    }

    public BetaRequestMcpServerToolConfiguration() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaRequestMcpServerToolConfiguration(
        BetaRequestMcpServerToolConfiguration betaRequestMcpServerToolConfiguration
    )
        : base(betaRequestMcpServerToolConfiguration) { }
#pragma warning restore CS8618

    public BetaRequestMcpServerToolConfiguration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaRequestMcpServerToolConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaRequestMcpServerToolConfigurationFromRaw.FromRawUnchecked"/>
    public static BetaRequestMcpServerToolConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaRequestMcpServerToolConfigurationFromRaw
    : IFromRawJson<BetaRequestMcpServerToolConfiguration>
{
    /// <inheritdoc/>
    public BetaRequestMcpServerToolConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaRequestMcpServerToolConfiguration.FromRawUnchecked(rawData);
}
