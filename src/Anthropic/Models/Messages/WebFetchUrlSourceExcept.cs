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
/// The tool filter variant under which every result but the named tools' contributes.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<WebFetchUrlSourceExcept, WebFetchUrlSourceExceptFromRaw>))]
public sealed record class WebFetchUrlSourceExcept : JsonModel
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
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("except")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public WebFetchUrlSourceExcept()
    {
        this.Type = JsonSerializer.SerializeToElement("except");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public WebFetchUrlSourceExcept(WebFetchUrlSourceExcept webFetchUrlSourceExcept)
        : base(webFetchUrlSourceExcept) { }
#pragma warning restore CS8618

    public WebFetchUrlSourceExcept(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("except");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    WebFetchUrlSourceExcept(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="WebFetchUrlSourceExceptFromRaw.FromRawUnchecked"/>
    public static WebFetchUrlSourceExcept FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public WebFetchUrlSourceExcept(IReadOnlyList<WebFetchUrlSourceToolReference> tools)
        : this()
    {
        this.Tools = tools;
    }
}

class WebFetchUrlSourceExceptFromRaw : IFromRawJson<WebFetchUrlSourceExcept>
{
    /// <inheritdoc/>
    public WebFetchUrlSourceExcept FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => WebFetchUrlSourceExcept.FromRawUnchecked(rawData);
}
