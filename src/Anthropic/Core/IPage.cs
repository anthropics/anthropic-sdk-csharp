using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Exceptions;

namespace Anthropic.Core;

/// <summary>
/// An interface representing a single page, with items of type <typeparamref name="T"/>, from a
/// paginated endpoint response.
/// </summary>
public interface IPage<T>
{
    /// <summary>
    /// The items in this page.
    /// </summary>
    IReadOnlyList<T> Items { get; }

    /// <summary>
    /// Returns whether there's another page after this one.
    ///
    /// <para>The method doesn't make requests so the result depends entirely on the
    /// data in this page. If a significant amount of time has passed between requesting
    /// this page and calling this method, then the result could be stale.</para>
    /// </summary>
    bool HasNext();

    /// <summary>
    /// Returns the page after this one by making another request.
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when it's impossible to get the next page. This exception is avoidable by calling
    /// <see cref="HasNext"/> first.
    /// </exception>
    /// </summary>
    Task<IPage<T>> Next(CancellationToken cancellationToken = default);

    /// <summary>
    /// Validates that the page was constructed with a valid response (based on its own
    /// <c>Validate</c> method).
    ///
    /// <exception cref="AnthropicInvalidDataException">
    /// Thrown when the instance does not pass validation.
    /// </exception>
    /// </summary>
    void Validate();

#if NET
    /// <inheritdoc cref="IPageExtensions.Paginate"/>
    public IAsyncEnumerable<T> Paginate(CancellationToken cancellationToken = default) =>
        IPageExtensions.Paginate(this, cancellationToken);
#endif
}
