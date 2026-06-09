using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.DeploymentRuns;

/// <summary>
/// The deployment's workspace was archived.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsWorkspaceArchivedRunError,
        BetaManagedAgentsWorkspaceArchivedRunErrorFromRaw
    >)
)]
public sealed record class BetaManagedAgentsWorkspaceArchivedRunError : JsonModel
{
    /// <summary>
    /// Human-readable error description.
    /// </summary>
    public required string Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<string>("message");
        }
        init { this._rawData.Set("message", value); }
    }

    public required ApiEnum<string, BetaManagedAgentsWorkspaceArchivedRunErrorType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsWorkspaceArchivedRunErrorType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        _ = this.Message;
        this.Type.Validate();
    }

    public BetaManagedAgentsWorkspaceArchivedRunError() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsWorkspaceArchivedRunError(
        BetaManagedAgentsWorkspaceArchivedRunError betaManagedAgentsWorkspaceArchivedRunError
    )
        : base(betaManagedAgentsWorkspaceArchivedRunError) { }
#pragma warning restore CS8618

    public BetaManagedAgentsWorkspaceArchivedRunError(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsWorkspaceArchivedRunError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsWorkspaceArchivedRunErrorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsWorkspaceArchivedRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class BetaManagedAgentsWorkspaceArchivedRunErrorFromRaw
    : IFromRawJson<BetaManagedAgentsWorkspaceArchivedRunError>
{
    /// <inheritdoc/>
    public BetaManagedAgentsWorkspaceArchivedRunError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsWorkspaceArchivedRunError.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsWorkspaceArchivedRunErrorTypeConverter))]
public enum BetaManagedAgentsWorkspaceArchivedRunErrorType
{
    WorkspaceArchivedError,
}

sealed class BetaManagedAgentsWorkspaceArchivedRunErrorTypeConverter
    : JsonConverter<BetaManagedAgentsWorkspaceArchivedRunErrorType>
{
    public override BetaManagedAgentsWorkspaceArchivedRunErrorType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "workspace_archived_error" =>
                BetaManagedAgentsWorkspaceArchivedRunErrorType.WorkspaceArchivedError,
            _ => (BetaManagedAgentsWorkspaceArchivedRunErrorType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsWorkspaceArchivedRunErrorType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsWorkspaceArchivedRunErrorType.WorkspaceArchivedError =>
                    "workspace_archived_error",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
