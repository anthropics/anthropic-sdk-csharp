using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;
using System = System;

namespace Anthropic.Models.Beta.MemoryStores.Memories;

/// <summary>
/// The error returned with HTTP status 409 when a create or rename targets a path
/// that another memory uses, or a path that overlaps another memory's path.
///
/// <para>Two paths overlap when one is an ancestor of the other, such as `/notes`
/// and `/notes/todo.md`. To free the path, rename or delete the memory that `conflicting_memory_id`
/// references, then retry. To change that memory instead of creating a new one,
/// update it.</para>
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        BetaManagedAgentsMemoryPathConflictError,
        BetaManagedAgentsMemoryPathConflictErrorFromRaw
    >)
)]
public sealed record class BetaManagedAgentsMemoryPathConflictError : JsonModel
{
    public required ApiEnum<string, BetaManagedAgentsMemoryPathConflictErrorType> Type
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullClass<
                ApiEnum<string, BetaManagedAgentsMemoryPathConflictErrorType>
            >("type");
        }
        init { this._rawData.Set("type", value); }
    }

    /// <summary>
    /// The ID of the memory that blocked the write (`mem_...`), or an empty string
    /// if that memory can't be identified.
    ///
    /// <para>Retry the request when it is empty.</para>
    /// </summary>
    public string? ConflictingMemoryID
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("conflicting_memory_id");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("conflicting_memory_id", value);
        }
    }

    /// <summary>
    /// The path that blocked the write: the requested path, or the path of a memory
    /// that is an ancestor or descendant of it.
    /// </summary>
    public string? ConflictingPath
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("conflicting_path");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("conflicting_path", value);
        }
    }

    /// <summary>
    /// A human-readable explanation of the conflict. To handle the error in code,
    /// use `conflicting_path` and `conflicting_memory_id` instead.
    /// </summary>
    public string? Message
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNullableClass<string>("message");
        }
        init
        {
            if (value == null)
            {
                return;
            }

            this._rawData.Set("message", value);
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        this.Type.Validate();
        _ = this.ConflictingMemoryID;
        _ = this.ConflictingPath;
        _ = this.Message;
    }

    public BetaManagedAgentsMemoryPathConflictError() { }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public BetaManagedAgentsMemoryPathConflictError(
        BetaManagedAgentsMemoryPathConflictError betaManagedAgentsMemoryPathConflictError
    )
        : base(betaManagedAgentsMemoryPathConflictError) { }
#pragma warning restore CS8618

    public BetaManagedAgentsMemoryPathConflictError(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        this._rawData = new(rawData);
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    BetaManagedAgentsMemoryPathConflictError(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="BetaManagedAgentsMemoryPathConflictErrorFromRaw.FromRawUnchecked"/>
    public static BetaManagedAgentsMemoryPathConflictError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }

    [SetsRequiredMembers]
    public BetaManagedAgentsMemoryPathConflictError(
        ApiEnum<string, BetaManagedAgentsMemoryPathConflictErrorType> type
    )
        : this()
    {
        this.Type = type;
    }
}

class BetaManagedAgentsMemoryPathConflictErrorFromRaw
    : IFromRawJson<BetaManagedAgentsMemoryPathConflictError>
{
    /// <inheritdoc/>
    public BetaManagedAgentsMemoryPathConflictError FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => BetaManagedAgentsMemoryPathConflictError.FromRawUnchecked(rawData);
}

[JsonConverter(typeof(BetaManagedAgentsMemoryPathConflictErrorTypeConverter))]
public enum BetaManagedAgentsMemoryPathConflictErrorType
{
    MemoryPathConflictError,
}

sealed class BetaManagedAgentsMemoryPathConflictErrorTypeConverter
    : JsonConverter<BetaManagedAgentsMemoryPathConflictErrorType>
{
    public override BetaManagedAgentsMemoryPathConflictErrorType Read(
        ref Utf8JsonReader reader,
        System::Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        return JsonSerializer.Deserialize<string>(ref reader, options) switch
        {
            "memory_path_conflict_error" =>
                BetaManagedAgentsMemoryPathConflictErrorType.MemoryPathConflictError,
            _ => (BetaManagedAgentsMemoryPathConflictErrorType)(-1),
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        BetaManagedAgentsMemoryPathConflictErrorType value,
        JsonSerializerOptions options
    )
    {
        JsonSerializer.Serialize(
            writer,
            value switch
            {
                BetaManagedAgentsMemoryPathConflictErrorType.MemoryPathConflictError =>
                    "memory_path_conflict_error",
                _ => throw new AnthropicInvalidDataException(
                    string.Format("Invalid value '{0}' in {1}", value, nameof(value))
                ),
            },
            options
        );
    }
}
