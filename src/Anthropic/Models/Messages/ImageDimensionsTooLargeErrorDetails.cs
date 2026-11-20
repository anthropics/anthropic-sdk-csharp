using System.Collections.Frozen;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

/// <summary>
/// The longest side of one or more images in the request exceeds the image size limit.
/// Scale each image in `paths` so that neither side exceeds `max_side_length_pixels`,
/// or remove it, then retry.
/// </summary>
[JsonConverter(
    typeof(JsonModelConverter<
        ImageDimensionsTooLargeErrorDetails,
        ImageDimensionsTooLargeErrorDetailsFromRaw
    >)
)]
public sealed record class ImageDimensionsTooLargeErrorDetails : JsonModel
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

    /// <summary>
    /// The limit the images exceeded: the largest width or height, in pixels, that
    /// an image on this request may have.
    /// </summary>
    public required long MaxSideLengthPixels
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<long>("max_side_length_pixels");
        }
        init { this._rawData.Set("max_side_length_pixels", value); }
    }

    /// <summary>
    /// The position of every image over the limit, in the order you sent them, nested
    /// blocks included, such as `messages.0.content.1`, or `messages.0.content.1.content.0`
    /// for an image in a `tool_result` block.
    /// </summary>
    public required IReadOnlyList<string> Paths
    {
        get
        {
            this._rawData.Freeze();
            return this._rawData.GetNotNullStruct<ImmutableArray<string>>("paths");
        }
        init
        {
            this._rawData.Set<ImmutableArray<string>>(
                "paths",
                ImmutableArray.ToImmutableArray(value)
            );
        }
    }

    /// <inheritdoc/>
    public override void Validate()
    {
        if (
            !JsonElement.DeepEquals(
                this.ErrorCode,
                JsonSerializer.SerializeToElement("image_dimensions_too_large")
            )
        )
        {
            throw new AnthropicInvalidDataException("Invalid value given for constant");
        }
        _ = this.MaxSideLengthPixels;
        _ = this.Paths;
    }

    public ImageDimensionsTooLargeErrorDetails()
    {
        this.ErrorCode = JsonSerializer.SerializeToElement("image_dimensions_too_large");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    public ImageDimensionsTooLargeErrorDetails(
        ImageDimensionsTooLargeErrorDetails imageDimensionsTooLargeErrorDetails
    )
        : base(imageDimensionsTooLargeErrorDetails) { }
#pragma warning restore CS8618

    public ImageDimensionsTooLargeErrorDetails(IReadOnlyDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);

        this.ErrorCode = JsonSerializer.SerializeToElement("image_dimensions_too_large");
    }

#pragma warning disable CS8618
    [SetsRequiredMembers]
    ImageDimensionsTooLargeErrorDetails(FrozenDictionary<string, JsonElement> rawData)
    {
        this._rawData = new(rawData);
    }
#pragma warning restore CS8618

    /// <inheritdoc cref="ImageDimensionsTooLargeErrorDetailsFromRaw.FromRawUnchecked"/>
    public static ImageDimensionsTooLargeErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    )
    {
        return new(FrozenDictionary.ToFrozenDictionary(rawData));
    }
}

class ImageDimensionsTooLargeErrorDetailsFromRaw : IFromRawJson<ImageDimensionsTooLargeErrorDetails>
{
    /// <inheritdoc/>
    public ImageDimensionsTooLargeErrorDetails FromRawUnchecked(
        IReadOnlyDictionary<string, JsonElement> rawData
    ) => ImageDimensionsTooLargeErrorDetails.FromRawUnchecked(rawData);
}
