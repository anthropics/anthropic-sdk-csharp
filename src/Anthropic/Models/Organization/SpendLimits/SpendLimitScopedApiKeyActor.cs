using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.SpendLimits;

/// <summary>
/// A scoped Admin API key acting on behalf of the organization.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<SpendLimitScopedApiKeyActor, SpendLimitScopedApiKeyActorFromRaw>)
)]
public sealed record class SpendLimitScopedApiKeyActor : JsonModel
{
    public required string ScopedApiKeyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("scoped_api_key_id");
        }
        init { this._rawData.Set("scoped_api_key_id", value); }
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
        _ = this.ScopedApiKeyID;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("scoped_api_key_actor")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public SpendLimitScopedApiKeyActor()
    {
        this.Type = JsonSerializer.SerializeToElement("scoped_api_key_actor");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public SpendLimitScopedApiKeyActor(SpendLimitScopedApiKeyActor spendLimitScopedApiKeyActor)
        : base(spendLimitScopedApiKeyActor) { }
#pragma warning restore CS8618

    public SpendLimitScopedApiKeyActor(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("scoped_api_key_actor");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    SpendLimitScopedApiKeyActor(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="SpendLimitScopedApiKeyActorFromRaw.FromRawUnchecked"/>
    public static SpendLimitScopedApiKeyActor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public SpendLimitScopedApiKeyActor(string scopedApiKeyID)
        : this()
    {
        this.ScopedApiKeyID = scopedApiKeyID;
    }
}

class SpendLimitScopedApiKeyActorFromRaw : IFromRawJson<SpendLimitScopedApiKeyActor>
{
    /// <inheritdoc/>
    public SpendLimitScopedApiKeyActor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => SpendLimitScopedApiKeyActor.FromRawUnchecked(rawData);
}
