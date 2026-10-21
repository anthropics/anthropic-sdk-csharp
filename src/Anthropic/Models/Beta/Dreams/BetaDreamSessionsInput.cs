using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Dreams;

/// <summary>
/// The sessions that a dream reads, given as an entry in `inputs`.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<BetaDreamSessionsInput, BetaDreamSessionsInputFromRaw>))]
public sealed record class BetaDreamSessionsInput : JsonModel
{
    /// <summary>
    /// The IDs of the sessions whose transcripts the dream reads (`sesn_...`).
    ///
    /// <para>Give 1 to 100 IDs, with no duplicates. Each session must be in the
    /// same workspace as the dream. Responses list the IDs in sorted order.</para>
    ///
    /// <para>The [limits table in the Dreams guide](https://platform.claude.com/docs/en/managed-agents/dreams#limits)
    /// lists all the limits on a dream.</para>
    /// </summary>
    public required IReadOnlyList<string> SessionIds
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("session_ids");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "session_ids",
                ImmutableArray.ToImmutableArray(value)
            );
        }
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
        _ = this.SessionIds;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("sessions")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaDreamSessionsInput()
    {
        this.Type = JsonSerializer.SerializeToElement("sessions");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaDreamSessionsInput(BetaDreamSessionsInput betaDreamSessionsInput)
        : base(betaDreamSessionsInput) { }
#pragma warning restore CS8618

    public BetaDreamSessionsInput(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("sessions");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaDreamSessionsInput(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaDreamSessionsInputFromRaw.FromRawUnchecked"/>
    public static BetaDreamSessionsInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaDreamSessionsInput(IReadOnlyList<string> sessionIds)
        : this()
    {
        this.SessionIds = sessionIds;
    }
}

class BetaDreamSessionsInputFromRaw : IFromRawJson<BetaDreamSessionsInput>
{
    /// <inheritdoc/>
    public BetaDreamSessionsInput FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaDreamSessionsInput.FromRawUnchecked(rawData);
}
