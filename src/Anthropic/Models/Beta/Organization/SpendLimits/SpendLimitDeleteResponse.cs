using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.SpendLimits;

[JsonConverter(
    typeof(JsonModelConverter<SpendLimitDeleteResponse, SpendLimitDeleteResponseFromRaw>)
)]
public sealed record class SpendLimitDeleteResponse : JsonModel
{
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
                JsonSerializer.SerializeToElement("spend_limit_deleted")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public SpendLimitDeleteResponse()
    {
        this.Type = JsonSerializer.SerializeToElement("spend_limit_deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SpendLimitDeleteResponse(SpendLimitDeleteResponse spendLimitDeleteResponse)
        : base(spendLimitDeleteResponse) { }
#pragma warning restore CS8618

    public SpendLimitDeleteResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("spend_limit_deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SpendLimitDeleteResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SpendLimitDeleteResponseFromRaw.FromRawUnchecked"/>
    public static SpendLimitDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SpendLimitDeleteResponse(string id)
        : this()
    {
        this.ID = id;
    }
}

class SpendLimitDeleteResponseFromRaw : IFromRawJson<SpendLimitDeleteResponse>
{
    /// <inheritdoc/>
    public SpendLimitDeleteResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SpendLimitDeleteResponse.FromRawUnchecked(rawData);
}
