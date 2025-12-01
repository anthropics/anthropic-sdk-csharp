using System.Collections.Generic;
using Anthropic.Models.Beta.Messages;

namespace Anthropic.Tests.Models.Beta.Messages;

public class BetaContextManagementConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BetaContextManagementConfig
        {
            Edits =
            [
                new BetaClearToolUses20250919Edit()
                {
                    ClearAtLeast = new(0),
                    ClearToolInputs = true,
                    ExcludeTools = ["string"],
                    Keep = new(0),
                    Trigger = new BetaInputTokensTrigger(1),
                },
            ],
        };

        List<Edit> expectedEdits =
        [
            new BetaClearToolUses20250919Edit()
            {
                ClearAtLeast = new(0),
                ClearToolInputs = true,
                ExcludeTools = ["string"],
                Keep = new(0),
                Trigger = new BetaInputTokensTrigger(1),
            },
        ];

        Assert.Equal(expectedEdits.Count, model.Edits.Count);
        for (int i = 0; i < expectedEdits.Count; i++)
        {
            Assert.Equal(expectedEdits[i], model.Edits[i]);
        }
    }
}
