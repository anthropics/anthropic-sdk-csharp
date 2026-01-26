using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using Anthropic.Core;

namespace Anthropic;

public static class IPageExtensions
{
    /// <summary>
    /// Returns a lazy async enumerable that auto-paginates by yielding the given
    /// page's data and then requesting and yielding additional pages from the API.
    /// </summary>
    public static async IAsyncEnumerable<T> Paginate<T>(
        this IPage<T> page,
        [EnumeratorCancellation] CancellationToken cancellationToken = default
    )
    {
        while (true)
        {
            foreach (var element in page.Items)
            {
                yield return element;
            }
            cancellationToken.ThrowIfCancellationRequested();
            if (!page.HasNext())
            {
                break;
            }
            page = await page.Next(cancellationToken);
        }
    }
}
