using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.Messages;

[JsonConverter(typeof(ModelConverter<Metadata>))]
public sealed record class Metadata : ModelBase, IFromRaw<Metadata>
{
    /// <summary>
    /// An external identifier for the user who is associated with the request.
    ///
    /// <para>This should be a uuid, hash value, or other opaque identifier. Anthropic
    /// may use this id to help detect abuse. Do not include any identifying information
    /// such as name, email address, or phone number.</para>
    /// </summary>
    public string? UserID
    {
        get
        {
            if (!this._properties.TryGetValue("user_id", out JsonElement element))
                return null;

            return JsonSerializer.Deserialize<string?>(element, ModelBase.SerializerOptions);
        }
        init
        {
            this._properties["user_id"] = JsonSerializer.SerializeToElement(
                value,
                ModelBase.SerializerOptions
            );
        }
    }

    public override void Validate()
    {
        _ = this.UserID;
    }

    public Metadata() { }

    public Metadata(IReadOnlyDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    Metadata(FrozenDictionary<string, JsonElement> properties)
    {
        this._properties = [.. properties];
    }
#pragma warning restore CS8618

    public static Metadata FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> properties)
    {
        return new(FrozenDictionary.ToFrozenDictionary(properties));
    }
}
