using System.Text.Json;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaRawContentBlockStartEventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaRawContentBlockStartEvent
        {
            ContentBlock = new BetaTextBlock()
            {
                Citations =
                [
                    new BetaCitationCharLocation()
                    {
                        CitedText = "cited_text",
                        DocumentIndex = 0,
                        DocumentTitle = "document_title",
                        EndCharIndex = 0,
                        FileID = "file_id",
                        StartCharIndex = 0,
                    },
                ],
                Text = "text",
            },
            Index = 0,
            Type = JsonSerializer.Deserialize<JsonElement>("\"content_block_start\""),
        };

        ContentBlock expectedContentBlock = new BetaTextBlock()
        {
            Citations =
            [
                new BetaCitationCharLocation()
                {
                    CitedText = "cited_text",
                    DocumentIndex = 0,
                    DocumentTitle = "document_title",
                    EndCharIndex = 0,
                    FileID = "file_id",
                    StartCharIndex = 0,
                },
            ],
            Text = "text",
        };
        long expectedIndex = 0;
        JsonElement expectedType = JsonSerializer.Deserialize<JsonElement>(
            "\"content_block_start\""
        );

        Assert.Equal(expectedContentBlock, model.ContentBlock);
        Assert.Equal(expectedIndex, model.Index);
        Assert.True(JsonElement.DeepEquals(expectedType, model.Type));
    }
}
