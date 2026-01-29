using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// The model will automatically decide whether to use tools.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaToolChoiceAuto, BetaToolChoiceAutoFromRaw>))]
public sealed record class BetaToolChoiceAuto : JsonModel
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
    /// <para>Defaults to `false`. If set to `true`, the model will output at most
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("auto")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.DisableParallelToolUse;
    }

    public BetaToolChoiceAuto()
    {
        this.Type = JsonSerializer.SerializeToElement("auto");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaToolChoiceAuto(BetaToolChoiceAuto betaToolChoiceAuto)
        : base(betaToolChoiceAuto) { }
#pragma warning restore CS8618

    public BetaToolChoiceAuto(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("auto");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaToolChoiceAuto(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaToolChoiceAutoFromRaw.FromRawUnchecked"/>
    public static BetaToolChoiceAuto FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaToolChoiceAutoFromRaw : IFromRawJson<BetaToolChoiceAuto>
{
    /// <inheritdoc/>
    public BetaToolChoiceAuto FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaToolChoiceAuto.FromRawUnchecked(rawData);
}
