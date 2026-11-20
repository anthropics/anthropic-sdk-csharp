using System.Net.Http;
using Anthropic.Core;
using Anthropic.Exceptions;

namespace Anthropic.Models.Messages;

/// <summary>
/// The longest side of one or more images in the request exceeds the image size limit.
/// Scale each image in `paths` so that neither side exceeds `max_side_length_pixels`,
/// or remove it, then retry.
/// </summary>
public sealed class AnthropicImageDimensionsTooLargeException : AnthropicBadRequestException
{
    public AnthropicImageDimensionsTooLargeException(HttpRequestException? innerException = null)
        : base(innerException) { }

    /// <summary>
    /// <c>error.details.error_code</c> of <see cref="AnthropicServiceException.Body"/>.
    /// </summary>
    public new string ErrorCode
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<string>(
                this.ErrorDetailsJson,
                "error_code"
            );
        }
    }

    /// <summary>
    /// <c>error.details</c> of <see cref="AnthropicServiceException.Body"/>.
    /// </summary>
    public new ImageDimensionsTooLargeErrorDetails Details
    {
        get
        {
            return WrappedJsonSerializer.GetNotNullClassProperty<ImageDimensionsTooLargeErrorDetails>(
                this.ErrorJson,
                "details"
            );
        }
    }
}
