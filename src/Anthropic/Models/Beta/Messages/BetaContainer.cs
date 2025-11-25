using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Messages;

/// <summary>
/// Information about the container used in the request (for the code execution tool)
/// </summary>
[JsonConverter(typeof(ModelConverter<BetaContainer>))]
public sealed record class BetaContainer : ModelBase, IFromRaw<BetaContainer>
{
    /// <summary>
    /// Identifier for the container used in this request
    /// </summary>
    public required string ID
    {
        get
        {
            if (!this._rawData.TryGetValue("id", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'id' cannot be null",
                    new ArgumentOutOfRangeException("id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'id' cannot be null",
                    new ArgumentNullException("id")
                );
        }
        init
        {
            this._rawData["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The time at which the container will expire.
    /// </summary>
    public required DateTimeOffset ExpiresAt
    {
        get
        {
            if (!this._rawData.TryGetValue("expires_at", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'expires_at' cannot be null",
                    new ArgumentOutOfRangeException("expires_at", "Missing required argument")
                );

            return JsonSerializer.Deserialize<DateTimeOffset>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._rawData["expires_at"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// Skills loaded in the container
    /// </summary>
    public required List<BetaSkill>? Skills
    {
        get
        {
            if (!this._rawData.TryGetValue("skills", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<BetaSkill>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        init
        {
            this._rawData["skills"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.ID;
        _ = this.ExpiresAt;
        foreach (var item in this.Skills ?? [])
        {
            item.Validate();
        }
    }

    public BetaContainer() { }

    public BetaContainer(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaContainer(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = [.. rawData];
    }
#pragma warning restore CS8618

    public static BetaContainer FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}
