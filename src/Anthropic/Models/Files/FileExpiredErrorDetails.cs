using System.Collections.Frozen;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Files;

/// <summary>
/// The file's `expires_at` has passed, so its content is no longer available.
/// </summary>
[JsonConverter(typeof(JsonModelConverter<FileExpiredErrorDetails, FileExpiredErrorDetailsFromRaw>))]
public sealed record class FileExpiredErrorDetails : JsonModel
{
    public JsonElement ErrorCode
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<JsonElement>("error_code");
        }
        init { this._rawData.Set("error_code", value); }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.ErrorCode,
                JsonSerializer.SerializeToElement("file_expired")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
    }

    public FileExpiredErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("file_expired");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public FileExpiredErrorDetails(FileExpiredErrorDetails fileExpiredErrorDetails)
        : base(fileExpiredErrorDetails) { }
#pragma warning restore CS8618

    public FileExpiredErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("file_expired");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    FileExpiredErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="FileExpiredErrorDetailsFromRaw.FromRawUnchecked"/>
    public static FileExpiredErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class FileExpiredErrorDetailsFromRaw : IFromRawJson<FileExpiredErrorDetails>
{
    /// <inheritdoc/>
    public FileExpiredErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => FileExpiredErrorDetails.FromRawUnchecked(rawData);
}
