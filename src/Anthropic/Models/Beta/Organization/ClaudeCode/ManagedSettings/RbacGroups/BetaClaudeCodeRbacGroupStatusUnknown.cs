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
        BetaClaudeCodeRbacGroupStatusUnknown,
        BetaClaudeCodeRbacGroupStatusUnknownFromRaw
    >)
)]
public sealed record class BetaClaudeCodeRbacGroupStatusUnknown : JsonModel
{
    /// <summary>
    /// Always `unknown`.
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("unknown")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaClaudeCodeRbacGroupStatusUnknown()
    {
        this.Type = JsonSerializer.SerializeToElement("unknown");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaClaudeCodeRbacGroupStatusUnknown(
        BetaClaudeCodeRbacGroupStatusUnknown betaClaudeCodeRbacGroupStatusUnknown
    )
        : base(betaClaudeCodeRbacGroupStatusUnknown) { }
#pragma warning restore CS8618

    public BetaClaudeCodeRbacGroupStatusUnknown(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("unknown");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaClaudeCodeRbacGroupStatusUnknown(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaClaudeCodeRbacGroupStatusUnknownFromRaw.FromRawUnchecked"/>
    public static BetaClaudeCodeRbacGroupStatusUnknown FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaClaudeCodeRbacGroupStatusUnknownFromRaw
    : IFromRawJson<BetaClaudeCodeRbacGroupStatusUnknown>
{
    /// <inheritdoc/>
    public BetaClaudeCodeRbacGroupStatusUnknown FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaClaudeCodeRbacGroupStatusUnknown.FromRawUnchecked(rawData);
}
