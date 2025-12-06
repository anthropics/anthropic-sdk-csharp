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
[JsonConverter(typeof(ModelConverter<BetaToolChoiceAuto, BetaToolChoiceAutoFromRaw>))]
public sealed record class BetaToolChoiceAuto : ModelBase
{
    public JsonElement Type
    {
        get { return ModelBase.GetNotNullStruct<JsonElement>(this.RawData, "type"); }
        init { ModelBase.Set(this._rawData, "type", value); }
    }

    /// <summary>
    /// Whether to disable parallel tool use.
    ///
    /// <para>Defaults to `false`. If set to `true`, the model will output at most
    /// one tool use.</para>
    /// </summary>
    public bool? DisableParallelToolUse
    {
        get { return ModelBase.GetNullableStruct<bool>(this.RawData, "disable_parallel_tool_use"); }
        init
        {
            if (value == null)
            {
                return;
            }

            ModelBase.Set(this._rawData, "disable_parallel_tool_use", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.Deserialize<JsonElement>("\"auto\"")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.DisableParallelToolUse;
    }

    public BetaToolChoiceAuto()
    {
        this.Type = JsonSerializer.Deserialize<JsonElement>("\"auto\"");
    }

    public BetaToolChoiceAuto(BetaToolChoiceAuto betaToolChoiceAuto)
        : base(betaToolChoiceAuto) { }

    public BetaToolChoiceAuto(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];

        this.Type = JsonSerializer.Deserialize<JsonElement>("\"auto\"");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaToolChoiceAuto(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
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

class BetaToolChoiceAutoFromRaw : IFromRaw<BetaToolChoiceAuto>
{
    /// <inheritdoc/>
    public BetaToolChoiceAuto FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaToolChoiceAuto.FromRawUnchecked(rawData);
}
