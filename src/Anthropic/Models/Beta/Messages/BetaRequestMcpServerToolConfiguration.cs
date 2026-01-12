using System.Collections.Frozen;
using System.Collections.Generic;
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

    public BetaRequestMcpServerToolConfiguration() { }

    public BetaRequestMcpServerToolConfiguration(
        BetaRequestMcpServerToolConfiguration betaRequestMcpServerToolConfiguration
    )
        : base(betaRequestMcpServerToolConfiguration) { }

    public BetaRequestMcpServerToolConfiguration(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaRequestMcpServerToolConfiguration(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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
