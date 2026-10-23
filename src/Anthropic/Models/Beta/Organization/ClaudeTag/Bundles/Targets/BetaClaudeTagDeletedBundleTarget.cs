using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ClaudeTag.Bundles.Targets;

/// <summary>
/// Confirms that a Bundle was detached.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaClaudeTagDeletedBundleTarget,
        BetaClaudeTagDeletedBundleTargetFromRaw
    >)
)]
public sealed record class BetaClaudeTagDeletedBundleTarget : JsonModel
{
    /// <summary>
    /// The identifier the Bundle Target had.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
    }

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
        _ = this.ID;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("bundle_target_deleted")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaClaudeTagDeletedBundleTarget()
    {
        this.Type = JsonSerializer.SerializeToElement("bundle_target_deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaClaudeTagDeletedBundleTarget(
        BetaClaudeTagDeletedBundleTarget betaClaudeTagDeletedBundleTarget
    )
        : base(betaClaudeTagDeletedBundleTarget) { }
#pragma warning restore CS8618

    public BetaClaudeTagDeletedBundleTarget(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("bundle_target_deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaClaudeTagDeletedBundleTarget(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaClaudeTagDeletedBundleTargetFromRaw.FromRawUnchecked"/>
    public static BetaClaudeTagDeletedBundleTarget FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaClaudeTagDeletedBundleTarget(string id)
        : this()
    {
        this.ID = id;
    }
}

class BetaClaudeTagDeletedBundleTargetFromRaw : IFromRawJson<BetaClaudeTagDeletedBundleTarget>
{
    /// <inheritdoc/>
    public BetaClaudeTagDeletedBundleTarget FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaClaudeTagDeletedBundleTarget.FromRawUnchecked(rawData);
}
