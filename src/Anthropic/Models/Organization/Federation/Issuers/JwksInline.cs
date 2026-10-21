using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.Federation.Issuers;

/// <summary>
/// JWKS supplied directly; no network fetch.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<JwksInline, JwksInlineFromRaw>))]
public sealed record class JwksInline : JsonModel
{
    /// <summary>
    /// Inline JWK objects.
    /// </summary>
    public required IReadOnlyList<IReadOnlyDictionary<string, JsonElement>> Keys
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<
                ImmutableArray<FrozenDictionary<string, JsonElement>>
            >("keys");
        }
        init
        {
            this._rawData.Set<ImmutableArray<FrozenDictionary<string, JsonElement>>>(
                "keys",
                ImmutableArray.ToImmutableArray(
                    Enumerable.Select(value, (item) => FrozenDictionary.ToFrozenDictionary(item))
                )
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
        _ = this.Keys;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("inline")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public JwksInline()
    {
        this.Type = JsonSerializer.SerializeToElement("inline");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public JwksInline(JwksInline jwksInline)
        : base(jwksInline) { }
#pragma warning restore CS8618

    public JwksInline(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("inline");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    JwksInline(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="JwksInlineFromRaw.FromRawUnchecked"/>
    public static JwksInline FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public JwksInline(IReadOnlyList<IReadOnlyDictionary<string, JsonElement>> keys)
        : this()
    {
        this.Keys = keys;
    }
}

class JwksInlineFromRaw : IFromRawJson<JwksInline>
{
    /// <inheritdoc/>
    public JwksInline FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        JwksInline.FromRawUnchecked(rawData);
}
