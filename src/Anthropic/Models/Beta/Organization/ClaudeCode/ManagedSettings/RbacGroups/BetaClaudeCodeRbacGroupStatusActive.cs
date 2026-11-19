using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeCode.ManagedSettings.RbacGroups;

[JsonConverter(
    typeof(JsonModelConverter<
        BetaClaudeCodeRbacGroupStatusActive,
        BetaClaudeCodeRbacGroupStatusActiveFromRaw
    >)
)]
public sealed record class BetaClaudeCodeRbacGroupStatusActive : JsonModel
{
    /// <summary>
    /// Always `active`.
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

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("active")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaClaudeCodeRbacGroupStatusActive()
    {
        this.Type = JsonSerializer.SerializeToElement("active");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaClaudeCodeRbacGroupStatusActive(
        BetaClaudeCodeRbacGroupStatusActive betaClaudeCodeRbacGroupStatusActive
    )
        : base(betaClaudeCodeRbacGroupStatusActive) { }
#pragma warning restore CS8618

    public BetaClaudeCodeRbacGroupStatusActive(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("active");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaClaudeCodeRbacGroupStatusActive(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaClaudeCodeRbacGroupStatusActiveFromRaw.FromRawUnchecked"/>
    public static BetaClaudeCodeRbacGroupStatusActive FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaClaudeCodeRbacGroupStatusActiveFromRaw : IFromRawJson<BetaClaudeCodeRbacGroupStatusActive>
{
    /// <inheritdoc/>
    public BetaClaudeCodeRbacGroupStatusActive FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaClaudeCodeRbacGroupStatusActive.FromRawUnchecked(rawData);
}
