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
        BetaClaudeCodeRbacGroupStatusDeleted,
        BetaClaudeCodeRbacGroupStatusDeletedFromRaw
    >)
)]
public sealed record class BetaClaudeCodeRbacGroupStatusDeleted : JsonModel
{
    /// <summary>
    /// Always `deleted`.
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("deleted")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaClaudeCodeRbacGroupStatusDeleted()
    {
        this.Type = JsonSerializer.SerializeToElement("deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaClaudeCodeRbacGroupStatusDeleted(
        BetaClaudeCodeRbacGroupStatusDeleted betaClaudeCodeRbacGroupStatusDeleted
    )
        : base(betaClaudeCodeRbacGroupStatusDeleted) { }
#pragma warning restore CS8618

    public BetaClaudeCodeRbacGroupStatusDeleted(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaClaudeCodeRbacGroupStatusDeleted(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaClaudeCodeRbacGroupStatusDeletedFromRaw.FromRawUnchecked"/>
    public static BetaClaudeCodeRbacGroupStatusDeleted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaClaudeCodeRbacGroupStatusDeletedFromRaw
    : IFromRawJson<BetaClaudeCodeRbacGroupStatusDeleted>
{
    /// <inheritdoc/>
    public BetaClaudeCodeRbacGroupStatusDeleted FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaClaudeCodeRbacGroupStatusDeleted.FromRawUnchecked(rawData);
}
