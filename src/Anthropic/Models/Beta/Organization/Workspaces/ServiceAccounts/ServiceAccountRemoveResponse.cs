using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Workspaces.ServiceAccounts;

[JsonConverter(
    typeof(JsonModelConverter<ServiceAccountRemoveResponse, ServiceAccountRemoveResponseFromRaw>)
)]
public sealed record class ServiceAccountRemoveResponse : JsonModel
{
    /// <summary>
    /// Tagged service account ID (`svac_...`) named in the delete request. Removal
    /// is idempotent; see the endpoint description for the implicit-membership no-op.
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

    public JsonElement Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// Tagged workspace ID (`wrkspc_...`) named in the delete request.
    /// </summary>
    public required string WorkspaceID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("workspace_id");
        }
        init { this._rawData.Set("workspace_id", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.ServiceAccountID;
        if (
            !JsonElement.DeepEquals(
                this.Type,
                JsonSerializer.SerializeToElement("service_account_workspace_member_deleted")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.WorkspaceID;
    }

    public ServiceAccountRemoveResponse()
    {
        this.Type = JsonSerializer.SerializeToElement("service_account_workspace_member_deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ServiceAccountRemoveResponse(ServiceAccountRemoveResponse serviceAccountRemoveResponse)
        : base(serviceAccountRemoveResponse) { }
#pragma warning restore CS8618

    public ServiceAccountRemoveResponse(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("service_account_workspace_member_deleted");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ServiceAccountRemoveResponse(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ServiceAccountRemoveResponseFromRaw.FromRawUnchecked"/>
    public static ServiceAccountRemoveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ServiceAccountRemoveResponseFromRaw : IFromRawJson<ServiceAccountRemoveResponse>
{
    /// <inheritdoc/>
    public ServiceAccountRemoveResponse FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ServiceAccountRemoveResponse.FromRawUnchecked(rawData);
}
