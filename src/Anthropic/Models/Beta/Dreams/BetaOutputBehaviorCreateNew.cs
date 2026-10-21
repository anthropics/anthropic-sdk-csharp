using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Dreams;

/// <summary>
/// Write the result to a new memory store that starts as a copy of the input memory
/// store. This is the default.
///
/// <para>The new memory store is in the same workspace as the dream. The dream doesn't
/// change the input memory store.</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<BetaOutputBehaviorCreateNew, BetaOutputBehaviorCreateNewFromRaw>)
)]
public sealed record class BetaOutputBehaviorCreateNew : JsonModel
{
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("create_new")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaOutputBehaviorCreateNew()
    {
        this.Type = JsonSerializer.SerializeToElement("create_new");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaOutputBehaviorCreateNew(BetaOutputBehaviorCreateNew betaOutputBehaviorCreateNew)
        : base(betaOutputBehaviorCreateNew) { }
#pragma warning restore CS8618

    public BetaOutputBehaviorCreateNew(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("create_new");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaOutputBehaviorCreateNew(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaOutputBehaviorCreateNewFromRaw.FromRawUnchecked"/>
    public static BetaOutputBehaviorCreateNew FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaOutputBehaviorCreateNewFromRaw : IFromRawJson<BetaOutputBehaviorCreateNew>
{
    /// <inheritdoc/>
    public BetaOutputBehaviorCreateNew FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaOutputBehaviorCreateNew.FromRawUnchecked(rawData);
}
