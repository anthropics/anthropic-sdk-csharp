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
    typeof(JsonModelConverter<BetaManagedAgentsTextRubric, BetaManagedAgentsTextRubricFromRaw>)
)]
public sealed record class BetaManagedAgentsTextRubric : JsonModel
{
    /// <summary>
    /// Rubric content. Plain text or markdown — the grader treats it as freeform text.
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

    public BetaManagedAgentsTextRubric()
    {
        this.Type = JsonSerializer.SerializeToElement("text");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsTextRubric(BetaManagedAgentsTextRubric betaManagedAgentsTextRubric)
        : base(betaManagedAgentsTextRubric) { }
#pragma warning restore CS8618

    public BetaManagedAgentsTextRubric(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("text");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsTextRubric(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsTextRubricFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsTextRubric FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsTextRubric(string content)
        : this()
    {
        this.Content = content;
    }
}

class BetaManagedAgentsTextRubricFromRaw : IFromRawJson<BetaManagedAgentsTextRubric>
{
    /// <inheritdoc/>
    public BetaManagedAgentsTextRubric FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsTextRubric.FromRawUnchecked(rawData);
}
