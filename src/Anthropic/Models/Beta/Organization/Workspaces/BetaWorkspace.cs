using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Beta.Organization.Workspaces;

[JsonConverter(typeof(JsonModelConverter<BetaWorkspace, BetaWorkspaceFromRaw>))]
public sealed record class BetaWorkspace : JsonModel
{
    /// <summary>
    /// ID of the Workspace.
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

    /// <summary>
    /// RFC 3339 datetime string indicating when the Workspace was archived, or `null`
    /// if the Workspace is not archived.
    /// </summary>
    public required DateTimeOffset? ArchivedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableStruct<DateTimeOffset>("archived_at");
        }
        init { this._rawData.Set("archived_at", value); }
    }

    /// <summary>
    /// Identifier for this Workspace's encryption compartment. When you configure
    /// a customer-managed encryption key (CMEK) on AWS, reference this value in
    /// your KMS key-policy condition so the key is scoped to this compartment. On
    /// GCP and Azure, Anthropic enforces the compartment binding automatically;
    /// you do not need to reference this value in your key configuration. See the
    /// CMEK integration guide for the required key configuration, including the
    /// value used during key validation.
    /// </summary>
    public required string CompartmentID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("compartment_id");
        }
        init { this._rawData.Set("compartment_id", value); }
    }

    /// <summary>
    /// RFC 3339 datetime string indicating when the Workspace was created.
    /// </summary>
    public required DateTimeOffset CreatedAt
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<DateTimeOffset>("created_at");
        }
        init { this._rawData.Set("created_at", value); }
    }

    /// <summary>
    /// Data residency configuration.
    /// </summary>
    public required BetaDataResidency DataResidency
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<BetaDataResidency>("data_residency");
        }
        init { this._rawData.Set("data_residency", value); }
    }

    /// <summary>
    /// Hex color code representing the Workspace in the Anthropic Console.
    /// </summary>
    public required string DisplayColor
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("display_color");
        }
        init { this._rawData.Set("display_color", value); }
    }

    /// <summary>
    /// ID of the customer-managed encryption key (CMEK) configuration to use for
    /// this Workspace. Setting this field requires CMEK to be enabled for your organization.
    /// When set, data stored for this Workspace is encrypted with the referenced
    /// key. Create key configurations with the External Keys API. This field is
    /// write-once: once a key is attached to a Workspace it cannot be detached or
    /// replaced. To rotate key material, rotate the underlying key on your cloud
    /// KMS; the `external_key_id` stays the same.
    /// </summary>
    public required string? ExternalKeyID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("external_key_id");
        }
        init { this._rawData.Set("external_key_id", value); }
    }

    /// <summary>
    /// Name of the Workspace.
    /// </summary>
    public required string Name
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("name");
        }
        init { this._rawData.Set("name", value); }
    }

    /// <summary>
    /// User-defined tags as string key-value pairs. Keys may not begin with `anthropic`.
    /// </summary>
    public required IReadOnlyDictionary<string, string> Tags
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, string>>("tags");
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, string>>(
                "tags",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Object type.
    ///
    /// <para>For Workspaces, this is always `"workspace"`.</para>
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
        _ = this.ID;
        _ = this.ArchivedAt;
        _ = this.CompartmentID;
        _ = this.CreatedAt;
        this.DataResidency.Validate();
        _ = this.DisplayColor;
        _ = this.ExternalKeyID;
        _ = this.Name;
        _ = this.Tags;
        if (!JsonElement.DeepEquals(this.Type, JsonSerializer.SerializeToElement("workspace")))
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public BetaWorkspace()
    {
        this.Type = JsonSerializer.SerializeToElement("workspace");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaWorkspace(BetaWorkspace betaWorkspace)
        : base(betaWorkspace) { }
#pragma warning restore CS8618

    public BetaWorkspace(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.Type = JsonSerializer.SerializeToElement("workspace");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaWorkspace(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaWorkspaceFromRaw.FromRawUnchecked"/>
    public static BetaWorkspace FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaWorkspaceFromRaw : IFromRawJson<BetaWorkspace>
{
    /// <inheritdoc/>
    public BetaWorkspace FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData) =>
        BetaWorkspace.FromRawUnchecked(rawData);
}
