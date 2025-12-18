using System;
using System.Collections.Generic;
using System.Linq;
using Anthropic.Models.Messages;

namespace Anthropic.Services.Messages;

/// <summary>
/// An implementation of the <see cref="SseAggregator{TMessage, TResult}"/> for aggregating BlockDeltaEvents from the <see cref="IMessageService.CreateStreaming(MessageCreateParams)"/> method.
/// </summary>
public sealed class MessageContentAggregator : SseAggregator<RawMessageStreamEvent, Message>
{
    /// <summary>
    /// Creates a new instance of the <see cref="MessageContentAggregator"/>.
    /// </summary>
    /// <param name="messages">The async enumerable representing a stream of messages.</param>
    public MessageContentAggregator(IAsyncEnumerable<RawMessageStreamEvent> messages)
        : base(messages) { }

    protected override Message GetResult(
        IReadOnlyDictionary<FilterResult, IList<RawMessageStreamEvent>> messages
    )
    {
        var content = messages[FilterResult.Content].GroupBy(e => e.Index);

        var startMessage =
            messages[FilterResult.StartMessage]
                .Select(e => e.Value!)
                .OfType<RawMessageStartEvent>()
                .Single()
            ?? throw new InvalidOperationException(
                $"Expected to find exactly one {nameof(RawMessageStartEvent)} but found either non or more then one."
            );

        var contentBlocks = new List<ContentBlock>();
        foreach (var item in messages.OrderBy(e => e.Key))
        {
            var blockContents = item.Value;
            var startContent = blockContents
                .Select(e => e.Value)
                .OfType<RawContentBlockStartEvent>()
                .Single();
            var blockContent = blockContents
                .Select(e => e.Value)
                .OfType<RawContentBlockDelta>()
                .ToArray();
            var endContent = blockContents
                .Select(e => e.Value)
                .OfType<RawContentBlockStartEvent>()
                .Single();

            var contentBlock = startContent.ContentBlock;
            contentBlocks.Add(MergeBlock(contentBlock, blockContent));
        }

        return new()
        {
            Content = [.. contentBlocks],
            ID = startMessage.Message.ID,
            Model = startMessage.Message.Model,
            StopReason = startMessage.Message.StopReason,
            StopSequence = startMessage.Message.StopSequence,
            Usage = startMessage.Message.Usage,
        };
    }

    private static ContentBlock MergeBlock(
        RawContentBlockStartEventContentBlock contentBlock,
        IList<RawContentBlockDelta> blockContents
    )
    {
        ContentBlock resultBlock = null!;

        string StringJoinHelper<T>(IEnumerable<T> sources, Func<T, string> expression)
        {
            return string.Join(null, sources.Select(expression));
        }

        void With<T>(T source, Func<IEnumerable<T>, ContentBlock> factory)
        {
            resultBlock = factory([source, .. blockContents.Select(e => e.Value).OfType<T>()]);
        }

        void Single<T>(T item)
        {
            resultBlock = (
                blockContents.Select(e => e.Value).OfType<T>().Single() as ContentBlock
            )!;
        }

        contentBlock.Switch(
            e =>
                With(
                    e,
                    blocks => new TextBlock()
                    {
                        Text = StringJoinHelper(blocks, e => e.Text),
                        Citations = [.. blocks.SelectMany(f => f.Citations!)],
                    }
                ),
            e =>
                With(
                    e,
                    blocks => new ThinkingBlock()
                    {
                        Signature = StringJoinHelper(blocks, e => e.Signature),
                        Thinking = StringJoinHelper(blocks, e => e.Thinking),
                    }
                ),
            e => Single(e),
            e => Single(e),
            e => Single(e),
            e => Single(e)
        );

        return resultBlock;
    }

    protected override FilterResult Filter(RawMessageStreamEvent message) =>
        message.Value switch
        {
            RawContentBlockStartEvent _ => FilterResult.Content,
            RawContentBlockStopEvent _ => FilterResult.Content,
            RawContentBlockDeltaEvent _ => FilterResult.Content,
            RawMessageDeltaEvent => FilterResult.Content,
            RawMessageStartEvent => FilterResult.StartMessage,
            RawMessageStopEvent _ => FilterResult.EndMessage,
            _ => FilterResult.Ignore,
        };
}
