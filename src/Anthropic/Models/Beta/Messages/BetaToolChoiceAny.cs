using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// The model will use any available tools.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaToolChoiceAny, BetaToolChoiceAnyFromRaw>))]
public sealed record class BetaToolChoiceAny : JsonModel
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

    /// <summary>
    /// Whether to disable parallel tool use.
    ///
    /// <para>Defaults to `false`. If set to `true`, the model will output exactly
    /// one tool use.</para>
    /// </summary>
    public bool? DisableParallelToolUse
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<bool>("disable_parallel_tool_use");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("disable_parallel_tool_use", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("any")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.DisableParallelToolUse;
    }

    public BetaToolChoiceAny()
    {
        this.Type = JsonSerializer.SerializeToElement("any");
    }

    public BetaToolChoiceAny(BetaToolChoiceAny betaToolChoiceAny)
        : base(betaToolChoiceAny) { }

    public BetaToolChoiceAny(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("any");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaToolChoiceAny(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaToolChoiceAnyFromRaw.FromRawUnchecked"/>
    public static BetaToolChoiceAny FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaToolChoiceAnyFromRaw : IFromRawJson<BetaToolChoiceAny>
{
    /// <inheritdoc/>
    public BetaToolChoiceAny FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaToolChoiceAny.FromRawUnchecked(rawData);
}
