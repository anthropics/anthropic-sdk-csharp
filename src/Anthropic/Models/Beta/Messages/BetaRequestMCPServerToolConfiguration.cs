using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Beta.Messages;

[JsonConverter(
    typeof(JsonModelConverter<
        BetaRequestMCPServerToolConfiguration,
        BetaRequestMCPServerToolConfigurationFromRaw
    >)
)]
public sealed record class BetaRequestMCPServerToolConfiguration : JsonModel
{
    public IReadOnlyList<string>? AllowedTools
    {
        get { return JsonModel.GetNullableClass<List<string>>(this.RawData, "allowed_tools"); }
        init { JsonModel.Set(this._rawData, "allowed_tools", value); }
    }

    public bool? Enabled
    {
        get { return JsonModel.GetNullableStruct<bool>(this.RawData, "enabled"); }
        init { JsonModel.Set(this._rawData, "enabled", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.AllowedTools;
        _ = this.Enabled;
    }

    public BetaRequestMCPServerToolConfiguration() { }

    public BetaRequestMCPServerToolConfiguration(
        BetaRequestMCPServerToolConfiguration betaRequestMCPServerToolConfiguration
    )
        : base(betaRequestMCPServerToolConfiguration) { }

    public BetaRequestMCPServerToolConfiguration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaRequestMCPServerToolConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaRequestMCPServerToolConfigurationFromRaw.FromRawUnchecked"/>
    public static BetaRequestMCPServerToolConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaRequestMCPServerToolConfigurationFromRaw
    : IFromRawJson<BetaRequestMCPServerToolConfiguration>
{
    /// <inheritdoc/>
    public BetaRequestMCPServerToolConfiguration FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaRequestMCPServerToolConfiguration.FromRawUnchecked(rawData);
}
