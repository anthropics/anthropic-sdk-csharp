using System.Threading.Tasks;
using Anthropic.Models.Completions;

namespace Anthropic.Service.Completions;

public interface ICompletionService
{
    /// <summary>
    /// [Legacy] Create a Text Completion.
    ///
    /// The Text Completions API is a legacy API. We recommend using the [Messages
    /// API](https://docs.anthropic.com/en/api/messages) going forward.
    ///
    /// Future models and features will not be compatible with Text Completions. See
    /// our [migration guide](https://docs.anthropic.com/en/api/migrating-from-text-completions-to-messages)
    /// for guidance in migrating from Text Completions to Messages.
    /// </summary>
    Task<Completion> Create(CompletionCreateParams @params);
}
