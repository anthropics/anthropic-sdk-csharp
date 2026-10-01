using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Organization.ApiKeys;

[JsonConverter(
    typeof(JsonModelConverter<ApiKeyServiceAccountActor, ApiKeyServiceAccountActorFromRaw>)
)]
public sealed record class ApiKeyServiceAccountActor : JsonModel
{
    /// <summary>
    /// ID of the Service Account the API key acts as.
    /// </summary>
    public required string ServiceAccountID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("service_account_id");
        }
        init { this._rawData.Set("service_account_id", value); }
    }

    /// <summary>
    /// Principal type. Always `"service_account_actor"` for a Service Account.
    /// </summary>
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
        _ = this.ServiceAccountID;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("service_account_actor")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public ApiKeyServiceAccountActor()
    {
        this.Type = JsonSerializer.SerializeToElement("service_account_actor");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ApiKeyServiceAccountActor(ApiKeyServiceAccountActor apiKeyServiceAccountActor)
        : base(apiKeyServiceAccountActor) { }
#pragma warning restore CS8618

    public ApiKeyServiceAccountActor(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("service_account_actor");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ApiKeyServiceAccountActor(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ApiKeyServiceAccountActorFromRaw.FromRawUnchecked"/>
    public static ApiKeyServiceAccountActor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public ApiKeyServiceAccountActor(string serviceAccountID)
        : this()
    {
        this.ServiceAccountID = serviceAccountID;
    }
}

class ApiKeyServiceAccountActorFromRaw : IFromRawJson<ApiKeyServiceAccountActor>
{
    /// <inheritdoc/>
    public ApiKeyServiceAccountActor FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ApiKeyServiceAccountActor.FromRawUnchecked(rawData);
}
