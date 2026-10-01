using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

/// <summary>
/// The tool filter variant under which only the named tools' results contribute.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<WebFetchUrlSourceOnly, WebFetchUrlSourceOnlyFromRaw>))]
public sealed record class WebFetchUrlSourceOnly : JsonModel
{
    public required IReadOnlyList<WebFetchUrlSourceToolReference> Tools
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<WebFetchUrlSourceToolReference>>(
                "tools"
            );
        }
        init
        {
            this._rawData.Set<ImmutableArray<WebFetchUrlSourceToolReference>>(
                "tools",
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
        foreach (var item in this.Tools)
        {
            item.Validate();
        }
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("only")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public WebFetchUrlSourceOnly()
    {
        this.Type = JsonSerializer.SerializeToElement("only");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebFetchUrlSourceOnly(WebFetchUrlSourceOnly webFetchUrlSourceOnly)
        : base(webFetchUrlSourceOnly) { }
#pragma warning restore CS8618

    public WebFetchUrlSourceOnly(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("only");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebFetchUrlSourceOnly(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebFetchUrlSourceOnlyFromRaw.FromRawUnchecked"/>
    public static WebFetchUrlSourceOnly FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public WebFetchUrlSourceOnly(IReadOnlyList<WebFetchUrlSourceToolReference> tools)
        : this()
    {
        this.Tools = tools;
    }
}

class WebFetchUrlSourceOnlyFromRaw : IFromRawJson<WebFetchUrlSourceOnly>
{
    /// <inheritdoc/>
    public WebFetchUrlSourceOnly FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WebFetchUrlSourceOnly.FromRawUnchecked(rawData);
}
