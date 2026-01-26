using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

/// <summary>
/// The model will not be allowed to use tools.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<ToolChoiceNone, ToolChoiceNoneFromRaw>))]
public sealed record class ToolChoiceNone : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("none")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public ToolChoiceNone()
    {
        this.Type = JsonSerializer.SerializeToElement("none");
    }

    public ToolChoiceNone(ToolChoiceNone toolChoiceNone)
        : base(toolChoiceNone) { }

    public ToolChoiceNone(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("none");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ToolChoiceNone(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ToolChoiceNoneFromRaw.FromRawUnchecked"/>
    public static ToolChoiceNone FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ToolChoiceNoneFromRaw : IFromRawJson<ToolChoiceNone>
{
    /// <inheritdoc/>
    public ToolChoiceNone FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        ToolChoiceNone.FromRawUnchecked(rawData);
}
