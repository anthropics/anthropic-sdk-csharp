using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;

namespace Anthropic.Models.UserProfiles;

/// <summary>
/// A user profile's standing in Enterprise Frontier Safeguards, a program under which
/// Anthropic approves the entity the profile represents and may approve any of the
/// program's features.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<UserProfileEfsProgram, UserProfileEfsProgramFromRaw>))]
public sealed record class UserProfileEfsProgram : JsonModel
{
    /// <summary>
    /// The program's features, keyed by feature: `data_retention_exemption` (use
    /// of models that normally require data retention, without the data being retained),
    /// `cmek` (customer-managed encryption keys) and `storage` (customer-owned storage).
    /// Every feature that the caller's organization may read has a key, whether
    /// or not it is approved; a missing key does not mean that the feature is inactive.
    /// Anthropic may add features; ignore a key you do not recognize.
    /// </summary>
    public required IReadOnlyDictionary<string, UserProfileEfsFeature> Features
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<FrozenDictionary<string, UserProfileEfsFeature>>(
                "features"
            );
        }
        init
        {
            this._rawData.Set<FrozenDictionary<string, UserProfileEfsFeature>>(
                "features",
                FrozenDictionary.ToFrozenDictionary(value)
            );
        }
    }

    /// <summary>
    /// Anthropic's decision on the entity the profile represents: `pending` while
    /// it is awaited, `active` once Anthropic has approved the entity for the program,
    /// or `rejected` once Anthropic has declined or has removed the entity from the
    /// program. `active` does not mean that any one feature is approved: read the
    /// feature you need in `features`.
    /// </summary>
    public required ApiEnum<string, UserProfileProgramStatus> Status
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<ApiEnum<string, UserProfileProgramStatus>>(
                "status"
            );
        }
        init { this._rawData.Set("status", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        foreach (var item in this.Features.Values)
        {
            item.Validate();
        }
        this.Status.Validate();
    }

    public UserProfileEfsProgram() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public UserProfileEfsProgram(UserProfileEfsProgram userProfileEfsProgram)
        : base(userProfileEfsProgram) { }
#pragma warning restore CS8618

    public UserProfileEfsProgram(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    UserProfileEfsProgram(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="UserProfileEfsProgramFromRaw.FromRawUnchecked"/>
    public static UserProfileEfsProgram FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class UserProfileEfsProgramFromRaw : IFromRawJson<UserProfileEfsProgram>
{
    /// <inheritdoc/>
    public UserProfileEfsProgram FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => UserProfileEfsProgram.FromRawUnchecked(rawData);
}
