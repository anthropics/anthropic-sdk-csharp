using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.ExternalKeys;

[JsonConverter(
    typeof(JsonModelConverter<ExternalKeyDeleteResponse, ExternalKeyDeleteResponseFromRaw>)
)]
public sealed record class ExternalKeyDeleteResponse : JsonModel
{
    /// <summary>
    /// ID of the deleted External Key.
    /// </summary>
    public required string ID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("id");
        }
        init { this._rawData.Set("id", value); }
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
        _ = this.ID;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("external_key_deleted")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public ExternalKeyDeleteResponse()
    {
        this.Type = JsonSerializer.SerializeToElement("external_key_deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ExternalKeyDeleteResponse(ExternalKeyDeleteResponse externalKeyDeleteResponse)
        : base(externalKeyDeleteResponse) { }
#pragma warning restore CS8618

    public ExternalKeyDeleteResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("external_key_deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ExternalKeyDeleteResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ExternalKeyDeleteResponseFromRaw.FromRawUnchecked"/>
    public static ExternalKeyDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ExternalKeyDeleteResponse(string id)
        : this()
    {
        this.ID = id;
    }
}

class ExternalKeyDeleteResponseFromRaw : IFromRawJson<ExternalKeyDeleteResponse>
{
    /// <inheritdoc/>
    public ExternalKeyDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ExternalKeyDeleteResponse.FromRawUnchecked(rawData);
}
