using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Sessions.Events;

/// <summary>
/// Rubric content provided inline as text.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsTextRubricParams,
        BetaManagedAgentsTextRubricParamsFromRaw
    >)
)]
public sealed record class BetaManagedAgentsTextRubricParams : JsonModel
{
    /// <summary>
    /// Rubric content. Plain text or markdown — the grader treats it as freeform
    /// text. Maximum 262144 characters.
    /// </summary>
    public required string Content
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("content");
        }
        init { this._rawData.Set("content", value); }
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
        _ = this.Content;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("text")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaManagedAgentsTextRubricParams()
    {
        this.Type = JsonSerializer.SerializeToElement("text");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsTextRubricParams(
        BetaManagedAgentsTextRubricParams betaManagedAgentsTextRubricParams
    )
        : base(betaManagedAgentsTextRubricParams) { }
#pragma warning restore CS8618

    public BetaManagedAgentsTextRubricParams(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("text");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsTextRubricParams(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsTextRubricParamsFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsTextRubricParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsTextRubricParams(string content)
        : this()
    {
        this.Content = content;
    }
}

class BetaManagedAgentsTextRubricParamsFromRaw : IFromRawJson<BetaManagedAgentsTextRubricParams>
{
    /// <inheritdoc/>
    public BetaManagedAgentsTextRubricParams FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsTextRubricParams.FromRawUnchecked(rawData);
}
