using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Helpers.Beta;
using Anthropic.Models.Beta.Messages;
using Anthropic.Services.Beta;
using Moq;
using Messages = Anthropic.Models.Messages;

namespace Anthropic.Tests.Helpers.Beta;

public class BetaAbstractMemoryToolTest
{
    private static readonly JsonSerializerOptions s_jsonOptions = new();

    private sealed class CapturingMemoryTool : BetaAbstractMemoryTool
    {
        public List<string> Calls { get; } = [];

        public CapturingMemoryTool(BetaCacheControlEphemeral? cacheControl = null)
            : base(cacheControl) { }

        protected override Task<BetaToolResultBlockParamContent> ViewAsync(
            BetaMemoryTool20250818ViewCommand command,
            CancellationToken cancellationToken
        )
        {
            Calls.Add($"view:{command.Path}");
            return Task.FromResult<BetaToolResultBlockParamContent>($"viewed {command.Path}");
        }

        protected override Task<BetaToolResultBlockParamContent> CreateAsync(
            BetaMemoryTool20250818CreateCommand command,
            CancellationToken cancellationToken
        )
        {
            Calls.Add($"create:{command.Path}");
            return Task.FromResult<BetaToolResultBlockParamContent>($"created {command.Path}");
        }

        protected override Task<BetaToolResultBlockParamContent> StrReplaceAsync(
            BetaMemoryTool20250818StrReplaceCommand command,
            CancellationToken cancellationToken
        )
        {
            Calls.Add($"str_replace:{command.Path}");
            return Task.FromResult<BetaToolResultBlockParamContent>($"replaced in {command.Path}");
        }

        protected override Task<BetaToolResultBlockParamContent> InsertAsync(
            BetaMemoryTool20250818InsertCommand command,
            CancellationToken cancellationToken
        )
        {
            Calls.Add($"insert:{command.Path}:{command.InsertLine}");
            return Task.FromResult<BetaToolResultBlockParamContent>(
                $"inserted into {command.Path}"
            );
        }

        protected override Task<BetaToolResultBlockParamContent> DeleteAsync(
            BetaMemoryTool20250818DeleteCommand command,
            CancellationToken cancellationToken
        )
        {
            Calls.Add($"delete:{command.Path}");
            return Task.FromResult<BetaToolResultBlockParamContent>($"deleted {command.Path}");
        }

        protected override Task<BetaToolResultBlockParamContent> RenameAsync(
            BetaMemoryTool20250818RenameCommand command,
            CancellationToken cancellationToken
        )
        {
            Calls.Add($"rename:{command.OldPath}->{command.NewPath}");
            return Task.FromResult<BetaToolResultBlockParamContent>(
                $"renamed {command.OldPath} to {command.NewPath}"
            );
        }
    }

    private static BetaToolUseBlock MakeMemoryToolUse(object input)
    {
        var json = JsonSerializer.SerializeToElement(
            new
            {
                type = "tool_use",
                id = "tu_test",
                name = "memory",
                input,
            }
        );
        return JsonSerializer.Deserialize<BetaToolUseBlock>(json, s_jsonOptions)!;
    }

    [Fact]
    public void Definition_HasCorrectNameAndType()
    {
        var tool = new CapturingMemoryTool();

        Assert.Equal("memory", tool.Name);
        Assert.True(tool.Definition.TryPickMemoryTool20250818(out var memTool));
        Assert.Equal("memory", JsonSerializer.Deserialize<string>(memTool!.Name, s_jsonOptions));
        Assert.Equal(
            "memory_20250818",
            JsonSerializer.Deserialize<string>(memTool.Type, s_jsonOptions)
        );
        Assert.Null(memTool.CacheControl);
    }

    [Fact]
    public void Definition_PropagatesCacheControl()
    {
        var cacheControl = new BetaCacheControlEphemeral();
        var tool = new CapturingMemoryTool(cacheControl);

        Assert.True(tool.Definition.TryPickMemoryTool20250818(out var memTool));
        Assert.NotNull(memTool!.CacheControl);
    }

    [Fact]
    public async Task ExecuteAsync_DispatchesViewCommand()
    {
        var ct = TestContext.Current.CancellationToken;
        var tool = new CapturingMemoryTool();

        var result = await tool.ExecuteAsync(
            MakeMemoryToolUse(new { command = "view", path = "/memories/notes.md" }),
            ct
        );

        Assert.Equal(["view:/memories/notes.md"], tool.Calls);
        Assert.True(result.TryPickString(out var text));
        Assert.Equal("viewed /memories/notes.md", text);
    }

    [Fact]
    public async Task ExecuteAsync_DispatchesCreateCommand()
    {
        var ct = TestContext.Current.CancellationToken;
        var tool = new CapturingMemoryTool();

        await tool.ExecuteAsync(
            MakeMemoryToolUse(
                new
                {
                    command = "create",
                    path = "/memories/new.md",
                    file_text = "hello",
                }
            ),
            ct
        );

        Assert.Equal(["create:/memories/new.md"], tool.Calls);
    }

    [Fact]
    public async Task ExecuteAsync_DispatchesStrReplaceCommand()
    {
        var ct = TestContext.Current.CancellationToken;
        var tool = new CapturingMemoryTool();

        await tool.ExecuteAsync(
            MakeMemoryToolUse(
                new
                {
                    command = "str_replace",
                    path = "/memories/x.md",
                    old_str = "old",
                    new_str = "new",
                }
            ),
            ct
        );

        Assert.Equal(["str_replace:/memories/x.md"], tool.Calls);
    }

    [Fact]
    public async Task ExecuteAsync_DispatchesInsertCommand()
    {
        var ct = TestContext.Current.CancellationToken;
        var tool = new CapturingMemoryTool();

        await tool.ExecuteAsync(
            MakeMemoryToolUse(
                new
                {
                    command = "insert",
                    path = "/memories/x.md",
                    insert_line = 3,
                    insert_text = "line",
                }
            ),
            ct
        );

        Assert.Equal(["insert:/memories/x.md:3"], tool.Calls);
    }

    [Fact]
    public async Task ExecuteAsync_DispatchesDeleteCommand()
    {
        var ct = TestContext.Current.CancellationToken;
        var tool = new CapturingMemoryTool();

        await tool.ExecuteAsync(
            MakeMemoryToolUse(new { command = "delete", path = "/memories/x.md" }),
            ct
        );

        Assert.Equal(["delete:/memories/x.md"], tool.Calls);
    }

    [Fact]
    public async Task ExecuteAsync_DispatchesRenameCommand()
    {
        var ct = TestContext.Current.CancellationToken;
        var tool = new CapturingMemoryTool();

        await tool.ExecuteAsync(
            MakeMemoryToolUse(
                new
                {
                    command = "rename",
                    old_path = "/memories/a.md",
                    new_path = "/memories/b.md",
                }
            ),
            ct
        );

        Assert.Equal(["rename:/memories/a.md->/memories/b.md"], tool.Calls);
    }

    [Fact]
    public async Task ClearAllMemoryAsync_DefaultThrows()
    {
        var tool = new CapturingMemoryTool();

        await Assert.ThrowsAsync<NotImplementedException>(() =>
            tool.ClearAllMemoryAsync(TestContext.Current.CancellationToken)
        );
    }

    [Fact]
    public async Task IntegratesWithBetaToolRunner()
    {
        var ct = TestContext.Current.CancellationToken;
        var mock = new Mock<IMessageService>();
        var callCount = 0;

        mock.Setup(s => s.Create(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(() =>
            {
                callCount++;
                if (callCount == 1)
                {
                    var json = JsonSerializer.SerializeToElement(
                        new
                        {
                            type = "tool_use",
                            id = "tu_1",
                            name = "memory",
                            input = new { command = "view", path = "/memories" },
                        }
                    );
                    var block = JsonSerializer.Deserialize<BetaContentBlock>(json, s_jsonOptions)!;
                    return MakeMessage([block], BetaStopReason.ToolUse);
                }

                var textJson = JsonSerializer.SerializeToElement(
                    new { type = "text", text = "Done." }
                );
                var textBlock = JsonSerializer.Deserialize<BetaContentBlock>(
                    textJson,
                    s_jsonOptions
                )!;
                return MakeMessage([textBlock]);
            });

        var memoryTool = new CapturingMemoryTool();
        var parameters = new MessageCreateParams
        {
            MaxTokens = 1024,
            Messages = [new() { Content = "What's in memory?", Role = Role.User }],
            Model = Messages::Model.ClaudeOpus4_6,
        };

        var runner = mock.Object.ToolRunner(parameters, [memoryTool]);
        await runner.RunUntilDoneAsync(ct);

        Assert.Equal(["view:/memories"], memoryTool.Calls);
        mock.Verify(
            s => s.Create(It.IsAny<MessageCreateParams>(), It.IsAny<CancellationToken>()),
            Times.Exactly(2)
        );
    }

    private static BetaMessage MakeMessage(
        IReadOnlyList<BetaContentBlock> content,
        BetaStopReason stopReason = BetaStopReason.EndTurn
    )
    {
        return new()
        {
            ID = "msg_test",
            Content = content,
            Model = Messages::Model.ClaudeOpus4_6,
            StopDetails = null,
            StopReason = stopReason,
            StopSequence = null,
            Usage = new()
            {
                CacheCreation = null,
                CacheCreationInputTokens = null,
                CacheReadInputTokens = null,
                InputTokens = 10,
                OutputTokens = 10,
                OutputTokensDetails = new(0),
                ServerToolUse = null,
                ServiceTier = BetaUsageServiceTier.Standard,
                Speed = null,
                InferenceGeo = null,
                Iterations = null,
            },
            Container = null,
            ContextManagement = null,
            Diagnostics = null,
        };
    }
}
