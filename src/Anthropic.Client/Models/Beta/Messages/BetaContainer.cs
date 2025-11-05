using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Client.Core;
using Anthropic.Client.Exceptions;
using System = System;

namespace Anthropic.Client.Models.Beta.Messages;

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
            if (!this.Properties.TryGetValue("id", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentOutOfRangeException("id", "Missing required argument")
                );

            return JsonSerializer.Deserialize<string>(element, ModelBase.SerializerOptions)
                ?? throw new AnthropicInvalidDataException(
                    "'id' cannot be null",
                    new System::ArgumentNullException("id")
                );
        }
        set
        {
            this.Properties["id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    /// <summary>
    /// The time at which the container will expire.
    /// </summary>
    public required System::DateTime ExpiresAt
    {
        get
        {
            if (!this.Properties.TryGetValue("expires_at", out JsonElement element))
                throw new AnthropicInvalidDataException(
                    "'expires_at' cannot be null",
                    new System::ArgumentOutOfRangeException(
                        "expires_at",
                        "Missing required argument"
                    )
                );

            return JsonSerializer.Deserialize<System::DateTime>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["expires_at"] = JsonSerializer.SerializeToElement(
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
            if (!this.Properties.TryGetValue("skills", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<List<BetaSkill>?>(
                element,
                ModelBase.SerializerOptions
            );
        }
        set
        {
            this.Properties["skills"] = JsonSerializer.SerializeToElement(
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

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaContainer(Dictionary<string, JsonElement> properties)
    {
        Properties = properties;
    }
#pragma warning restore CS8618

    public static BetaContainer FromRawUnchecked(Dictionary<string, JsonElement> properties)
    {
        return new(properties);
    }
}
