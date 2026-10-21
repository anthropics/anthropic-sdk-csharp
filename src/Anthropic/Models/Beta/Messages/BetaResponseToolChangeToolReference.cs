using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Reference to a single tool, by the name the model uses to call it, as a ``compaction``
/// block's ``tool_changes`` entry reports it: a tool declared in ``tools`` or defined
/// by an earlier ``tool_addition`` block. Send it back unchanged with the block.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaResponseToolChangeToolReference,
        BetaResponseToolChangeToolReferenceFromRaw
    >)
)]
public sealed record class BetaResponseToolChangeToolReference : JsonModel
{
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
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
        _ = this.Name;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("tool_reference")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaResponseToolChangeToolReference()
    {
        this.Type = JsonSerializer.SerializeToElement("tool_reference");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaResponseToolChangeToolReference(
        BetaResponseToolChangeToolReference betaResponseToolChangeToolReference
    )
        : base(betaResponseToolChangeToolReference) { }
#pragma warning restore CS8618

    public BetaResponseToolChangeToolReference(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("tool_reference");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaResponseToolChangeToolReference(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaResponseToolChangeToolReferenceFromRaw.FromRawUnchecked"/>
    public static BetaResponseToolChangeToolReference FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaResponseToolChangeToolReference(string name)
        : this()
    {
        this.Name = name;
    }
}

class BetaResponseToolChangeToolReferenceFromRaw : IFromRawJson<BetaResponseToolChangeToolReference>
{
    /// <inheritdoc/>
    public BetaResponseToolChangeToolReference FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaResponseToolChangeToolReference.FromRawUnchecked(rawData);
}
