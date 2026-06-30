using System.Text;
using Anthropic;
using Anthropic.Helpers.Beta;
using Anthropic.Models.Beta.Messages;

// Example demonstrating a filesystem-backed memory tool with the tool runner.
//
// Files are written under `.artifacts/memory-example` at the repo root, which
// is git-ignored.
//
// The example runs two separate conversations against the same on-disk store
// to demonstrate persistence: the first writes a fact, the second reads it back.
var memoryRoot = Path.Combine(FindRepoRoot(), ".artifacts", "memory-example");

static string FindRepoRoot()
{
    var dir = new DirectoryInfo(AppContext.BaseDirectory);
    while (dir != null && !Directory.Exists(Path.Combine(dir.FullName, ".git")))
        dir = dir.Parent;
    return dir?.FullName ?? Directory.GetCurrentDirectory();
}

Console.WriteLine($"=== Memory Tool Example (root: {memoryRoot}) ===\n");

Console.WriteLine("---- Conversation 1 ----");
await Converse("Remember that my favorite color is deep purple.", memoryRoot);

Console.WriteLine("\n---- Conversation 2 ----");
await Converse("What is my favorite color?", memoryRoot);

Console.WriteLine("\n=== Done ===");

static async Task Converse(string userMessage, string memoryRoot)
{
    // Configured using the ANTHROPIC_API_KEY environment variable.
    var client = new AnthropicClient();
    var memory = new FilesystemMemoryTool(memoryRoot);

    var runner = client.Beta.Messages.ToolRunner(
        new MessageCreateParams
        {
            Model = Anthropic.Models.Messages.Model.ClaudeSonnet5,
            MaxTokens = 2048,
            Betas = ["context-management-2025-06-27"],
            Messages = [new() { Role = Role.User, Content = userMessage }],
        },
        [memory],
        maxIterations: 50
    );

    await foreach (var message in runner)
    {
        foreach (var block in message.Content)
        {
            if (block.TryPickText(out var text))
            {
                Console.WriteLine(text.Text);
            }
            else if (block.TryPickToolUse(out var toolUse))
            {
                var commandValue = toolUse.Input.TryGetValue("command", out var c)
                    ? c.GetString()
                    : "?";
                Console.WriteLine($"  → memory tool: {commandValue}");
            }
        }
    }
}

// A filesystem-backed BetaAbstractMemoryTool. The memory tool always passes
// paths starting with "/memories"; this implementation maps that prefix to
// the provided sandbox root on disk.
//
// The implementation:
// - Validates that all paths start with "/memories".
// - Resolves to a normalized absolute path and verifies it stays within the
//   sandbox, including a real-path (symlink) check.
// - Uses UTF-8 for file contents and 1-based line numbering for view/insert.
// - Returns response strings in the format documented for the memory tool API.
//
// This is a demo backend — not robust enough for production. Real backends
// should add file size limits, atomic writes, and stricter access controls.
file sealed class FilesystemMemoryTool : BetaAbstractMemoryTool
{
    private const string AliasPrefix = "/memories";
    private const int MaxLines = 999_999;

    private readonly string _sandboxRoot;

    public FilesystemMemoryTool(string sandboxRoot)
    {
        _sandboxRoot = Path.GetFullPath(sandboxRoot);
        Directory.CreateDirectory(_sandboxRoot);
    }

    private string? ResolvePath(string memoryPath)
    {
        if (!memoryPath.StartsWith(AliasPrefix, StringComparison.Ordinal))
            return null;

        if (
            memoryPath.Length != AliasPrefix.Length
            && !memoryPath.StartsWith(AliasPrefix + "/", StringComparison.Ordinal)
        )
            return null;

        var relative = memoryPath.Substring(AliasPrefix.Length).TrimStart('/');
        var resolved = Path.GetFullPath(
            relative.Length == 0 ? _sandboxRoot : Path.Combine(_sandboxRoot, relative)
        );

        if (!IsWithinSandbox(resolved))
            return null;

        if (File.Exists(resolved) || Directory.Exists(resolved))
        {
            var info = new FileInfo(resolved);
            var real =
                info.LinkTarget != null
                    ? Path.GetFullPath(info.ResolveLinkTarget(true)!.FullName)
                    : resolved;
            if (!IsWithinSandbox(real))
                return null;
            return real;
        }

        return resolved;
    }

    // The model controls the path string passed to memory tool commands, so it can attempt
    // path traversal (e.g. `/memories/../../etc/passwd`) or, if the leaf is a symlink,
    // escape the sandbox via the link target. We refuse any path that does not normalize
    // (and, for existing entries, does not real-resolve) to a location inside the sandbox
    // root.
    //
    // Note: this check uses Path.GetFullPath, which collapses `.`/`..` but does not follow
    // symlinks in intermediate path components. A symlink at an intermediate component
    // would not be caught here. A production backend should walk each ancestor and resolve
    // symlinks per-component (Java's example uses `Path.toRealPath()`; Python walks each
    // parent calling `.resolve()`).
    private bool IsWithinSandbox(string absolutePath) =>
        absolutePath.Equals(_sandboxRoot, StringComparison.Ordinal)
        || absolutePath.StartsWith(
            _sandboxRoot + Path.DirectorySeparatorChar,
            StringComparison.Ordinal
        );

    protected override Task<BetaToolResultBlockParamContent> ViewAsync(
        BetaMemoryTool20250818ViewCommand command,
        CancellationToken cancellationToken
    )
    {
        var resolved = ResolvePath(command.Path);
        if (resolved == null || (!File.Exists(resolved) && !Directory.Exists(resolved)))
            throw new BetaToolError(
                $"The path {command.Path} does not exist. Please provide a valid path."
            );

        if (Directory.Exists(resolved))
        {
            var sb = new StringBuilder();
            sb.Append("Here're the files and directories in ").Append(command.Path).Append(":\n");
            foreach (var entry in Directory.EnumerateFileSystemEntries(resolved).OrderBy(p => p))
            {
                var name = Path.GetFileName(entry);
                if (Directory.Exists(entry))
                    sb.Append("DIR\t").Append(name).Append('/').Append('\n');
                else
                    sb.Append(new FileInfo(entry).Length).Append('\t').Append(name).Append('\n');
            }
            return Task.FromResult<BetaToolResultBlockParamContent>(sb.ToString().TrimEnd());
        }

        var lines = File.ReadAllLines(resolved, Encoding.UTF8);
        if (lines.Length > MaxLines)
            throw new BetaToolError(
                $"File {command.Path} exceeds maximum line limit of 999,999 lines."
            );

        int start = 1,
            end = lines.Length;
        if (command.ViewRange is { Count: 2 } range)
        {
            start = (int)Math.Max(1, range[0]);
            end = range[1] == -1 ? lines.Length : Math.Min(lines.Length, (int)range[1]);
        }

        var content = new StringBuilder();
        content
            .Append("Here's the content of ")
            .Append(command.Path)
            .Append(" with line numbers:\n");
        for (var i = start; i <= end; i++)
            content.Append(i.ToString().PadLeft(6)).Append('\t').Append(lines[i - 1]).Append('\n');

        return Task.FromResult<BetaToolResultBlockParamContent>(content.ToString().TrimEnd());
    }

    protected override Task<BetaToolResultBlockParamContent> CreateAsync(
        BetaMemoryTool20250818CreateCommand command,
        CancellationToken cancellationToken
    )
    {
        var resolved = ResolvePath(command.Path);
        if (resolved == null)
            throw new BetaToolError($"Invalid path. All paths must start with {AliasPrefix}");

        if (File.Exists(resolved))
            throw new BetaToolError($"File {command.Path} already exists");

        Directory.CreateDirectory(Path.GetDirectoryName(resolved)!);
        File.WriteAllText(resolved, command.FileText, Encoding.UTF8);
        return Task.FromResult<BetaToolResultBlockParamContent>(
            $"File created successfully at: {command.Path}"
        );
    }

    protected override Task<BetaToolResultBlockParamContent> StrReplaceAsync(
        BetaMemoryTool20250818StrReplaceCommand command,
        CancellationToken cancellationToken
    )
    {
        var resolved = ResolvePath(command.Path);
        if (resolved == null || !File.Exists(resolved))
            throw new BetaToolError(
                $"The path {command.Path} does not exist. Please provide a valid path."
            );

        var content = File.ReadAllText(resolved, Encoding.UTF8);
        var occurrences = new List<int>();
        var index = content.IndexOf(command.OldStr, StringComparison.Ordinal);
        while (index != -1)
        {
            var lineNo = content.AsSpan(0, index).Count('\n') + 1;
            occurrences.Add(lineNo);
            index = content.IndexOf(
                command.OldStr,
                index + command.OldStr.Length,
                StringComparison.Ordinal
            );
        }

        if (occurrences.Count == 0)
            throw new BetaToolError(
                $"No replacement was performed, old_str `{command.OldStr}` did not appear verbatim in {command.Path}."
            );

        if (occurrences.Count > 1)
            throw new BetaToolError(
                $"No replacement was performed. Multiple occurrences of old_str `{command.OldStr}` in lines: "
                    + $"{string.Join(", ", occurrences)}. Please ensure it is unique"
            );

        File.WriteAllText(resolved, content.Replace(command.OldStr, command.NewStr), Encoding.UTF8);
        return Task.FromResult<BetaToolResultBlockParamContent>(
            $"The memory file {command.Path} has been edited."
        );
    }

    protected override Task<BetaToolResultBlockParamContent> InsertAsync(
        BetaMemoryTool20250818InsertCommand command,
        CancellationToken cancellationToken
    )
    {
        var resolved = ResolvePath(command.Path);
        if (resolved == null || !File.Exists(resolved))
            throw new BetaToolError(
                $"The path {command.Path} does not exist. Please provide a valid path."
            );

        var lines = new List<string>(File.ReadAllLines(resolved, Encoding.UTF8));
        if (command.InsertLine < 0 || command.InsertLine > lines.Count)
            throw new BetaToolError(
                $"Invalid `insert_line` parameter: {command.InsertLine}. "
                    + $"It should be within the range of lines of the file: [0, {lines.Count}]"
            );

        lines.Insert((int)command.InsertLine, command.InsertText);
        File.WriteAllText(resolved, string.Join('\n', lines), Encoding.UTF8);
        return Task.FromResult<BetaToolResultBlockParamContent>(
            $"The file {command.Path} has been edited."
        );
    }

    protected override Task<BetaToolResultBlockParamContent> DeleteAsync(
        BetaMemoryTool20250818DeleteCommand command,
        CancellationToken cancellationToken
    )
    {
        var resolved = ResolvePath(command.Path);
        if (resolved == null || (!File.Exists(resolved) && !Directory.Exists(resolved)))
            throw new BetaToolError($"The path {command.Path} does not exist");

        if (Directory.Exists(resolved))
            Directory.Delete(resolved, recursive: true);
        else
            File.Delete(resolved);

        return Task.FromResult<BetaToolResultBlockParamContent>(
            $"Successfully deleted {command.Path}"
        );
    }

    protected override Task<BetaToolResultBlockParamContent> RenameAsync(
        BetaMemoryTool20250818RenameCommand command,
        CancellationToken cancellationToken
    )
    {
        var oldResolved = ResolvePath(command.OldPath);
        var newResolved = ResolvePath(command.NewPath);
        if (oldResolved == null || (!File.Exists(oldResolved) && !Directory.Exists(oldResolved)))
            throw new BetaToolError($"The path {command.OldPath} does not exist");
        if (newResolved == null)
            throw new BetaToolError("Invalid destination path");
        if (File.Exists(newResolved) || Directory.Exists(newResolved))
            throw new BetaToolError($"The destination {command.NewPath} already exists");

        Directory.CreateDirectory(Path.GetDirectoryName(newResolved)!);
        if (Directory.Exists(oldResolved))
            Directory.Move(oldResolved, newResolved);
        else
            File.Move(oldResolved, newResolved);

        return Task.FromResult<BetaToolResultBlockParamContent>(
            $"Successfully renamed {command.OldPath} to {command.NewPath}"
        );
    }
}
