using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Schema;
using System.Threading;
using System.Threading.Tasks;
using Anthropic.Models.Messages;
using Anthropic.Services;

namespace Anthropic.Tool;

/// <summary>
/// Defines methods for executing an <see cref="IMessageService.Create(MessageCreateParams, CancellationToken)"/> request and provide feedback on tool requests.
/// </summary>
public static class ToolRunnerExtensions
{
    /// <summary>
    /// Obtains a <see cref="Message"/> that is generated using client side tooling.
    /// </summary>
    /// <param name="messageService">The <see cref="IMessageService"/>.</param>
    /// <param name="messageCreateParams">The <see cref="MessageCreateParams"/>.</param>
    /// <param name="configureTools">The callback for registering tools.</param>
    /// <param name="cancellationToken">The <see cref="CancellationToken"/></param>
    /// <returns>A task that completes when all tools have been executed and a final message has been obtained.</returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static async Task<Message> CreateWithToolLoop(
        this IMessageService messageService,
        MessageCreateParams messageCreateParams,
        Func<ToolRegistration, ToolRegistration> configureTools,
        CancellationToken cancellationToken = default
    )
    {
        var toolRegistry = configureTools(new());

        messageCreateParams = messageCreateParams with
        {
            Tools =
            [
                .. messageCreateParams.Tools ?? [], //TODO: does this make sense because user may never be able to invoke anything here. Dynamic bindings of user code?
                .. toolRegistry.LocalTools.Select(e => new ToolUnion(
                    new Models.Messages.Tool()
                    {
                        Name = e.Key,
                        Description = e.Value.Description,
                        InputSchema = e.Value.GenerateSchema(),
                    }
                )),
            ],
        };

        var result = await messageService
            .Create(messageCreateParams, cancellationToken)
            .ConfigureAwait(false);

        //TODO clarify with tomer/stephen why all examples do this one by one instead of running all tools at once
        while (result.StopReason == StopReason.ToolUse)
        {
            var toolUseRequest =
                result.Content.Select(e => e.Value).OfType<ToolUseBlock>().LastOrDefault()
                ?? throw new InvalidOperationException(
                    "Stop reason indicates Tool Usage request but no ToolUse block was found."
                );
            toolRegistry.LocalTools.TryGetValue(toolUseRequest.Name, out var toolRunner);

            JsonDocument toolUseInputArguments = null!; //TODO build input doc
            var toolUseResult = toolRunner is null
                ? null
                : await toolRunner.Invoke(toolUseInputArguments).ConfigureAwait(false);

            messageCreateParams = messageCreateParams with
            {
                Messages =
                [
                    .. messageCreateParams.Messages.Except(
                        messageCreateParams.Messages.Where(e =>
                            e.Content.Value is IReadOnlyList<ContentBlockParam> blockParams
                            && blockParams.Any(f => f.ToolUseID == toolUseRequest.ID)
                        )
                    ),
                    new MessageParam()
                    {
                        Content = new MessageParamContent(
                            [
                                new ToolResultBlockParam()
                                {
                                    ToolUseID = toolUseRequest.ID,
                                    Content = new(
                                        toolUseResult?.ToString()
                                            ?? $"Error: no result from tool '{toolUseRequest.Name}'"
                                    ),
                                    IsError = toolUseResult is null || toolRunner is null,
                                },
                            ]
                        ),
                        Role = Role.Assistant,
                    },
                ],
            };
            var newResult = await messageService
                .Create(messageCreateParams, cancellationToken)
                .ConfigureAwait(false);
            if (newResult.Equals(result))
            {
                throw new InvalidOperationException("Non executing Toolresult detected."); //TODO rephrase
            }
            result = newResult;
        }

        return result;
    }
}

public class ToolRegistration
{
    public Dictionary<string, IToolRegistration> LocalTools { get; } =
        new(StringComparer.InvariantCultureIgnoreCase);

    public ToolRegistration WithTool(
        string name,
        string description,
        Func<JsonDocument, ValueTask<object?>> method
    )
    {
        LocalTools.Add(
            name,
            new LazyDelegateBoundToolRegistration()
            {
                Name = name,
                Description = description,
                Delegate = method,
            }
        );
        return this;
    }

    public ToolRegistration WithTool(
        string name,
        string description,
        Func<JsonDocument, Task<object?>> method
    )
    {
        LocalTools.Add(
            name,
            new LazyDelegateBoundToolRegistration()
            {
                Name = name,
                Description = description,
                Delegate = method,
            }
        );
        return this;
    }

    public ToolRegistration WithTool(
        string name,
        string description,
        Func<JsonDocument, object?> method
    )
    {
        LocalTools.Add(
            name,
            new LazyDelegateBoundToolRegistration()
            {
                Name = name,
                Description = description,
                Delegate = method,
            }
        );
        return this;
    }

    public ToolRegistration WithTool(string name, string description, Func<JsonDocument?> method)
    {
        return WithTool(name, description, new Func<JsonDocument, JsonDocument?>(e => method()));
    }

    public ToolRegistration WithTool<TRunner, TArgument>(string name, string description)
        where TRunner : IToolRunner<TArgument>, new()
        where TArgument : class
    {
        LocalTools.Add(
            name,
            new ObjectToolRegistration<TRunner, TArgument>()
            {
                Name = name,
                Description = description,
            }
        );
        return this;
    }
}

public class ObjectToolRegistration<TRunner, TArgument> : IToolRegistration
    where TRunner : IToolRunner<TArgument>, new()
    where TArgument : class
{
    public required string Name { get; init; }

    public required string Description { get; init; }

    public InputSchema GenerateSchema()
    {
        var options = JsonSerializerOptions.Default;
        var jsonSchema = options.GetJsonSchemaAsNode(typeof(TArgument));

        //TODO: ask tomer or stephen for a copy constructor in codegen for easy transformation
        return jsonSchema.Deserialize<InputSchema>()!;
    }

    public async Task<object?> Invoke(JsonDocument jsonDocument)
    {
        var runner = new TRunner();
        var arguments = JsonSerializer.Deserialize<TArgument>(jsonDocument) ?? default;
        var result = await runner.InvokeTool(arguments).ConfigureAwait(false);
        if (result is null)
        {
            return null;
        }

        if (result is string)
        {
            return result;
        }

        if (result is not JsonDocument resultDoc)
        {
            using var resultStream = new MemoryStream();
            await JsonSerializer.SerializeAsync(resultStream, result).ConfigureAwait(false);
            resultStream.Seek(0, SeekOrigin.Begin);
            return await JsonDocument.ParseAsync(resultStream).ConfigureAwait(false);
        }

        return resultDoc;
    }
}

public class LazyDelegateBoundToolRegistration : IToolRegistration
{
    public required string Name { get; init; }

    public required string Description { get; init; }

    public required Delegate Delegate { get; init; }

    public async Task<object?> Invoke(JsonDocument jsonDocument)
    {
        var delegateMethod = Delegate.GetMethodInfo();
        var parameters = delegateMethod.GetParameters();
        object? result = null;

        // map parameters to delegate or caller object

        // Map to a delegate of Func<JsonDocument, JsonDocument> or Action<JsonDocument>
        if (
            parameters.Length == 1
            && parameters[0].ParameterType.IsAssignableFrom(typeof(JsonDocument))
        )
        {
            result = delegateMethod.Invoke(Delegate.Target, [jsonDocument]);
        }

        //process return value and await task
        if (result != null)
        {
            var val = await UnpackTask(result).ConfigureAwait(false);

            return val switch
            {
                null => null,
                string strValue => strValue,
                JsonDocument resultDocument => resultDocument,
                _ => JsonSerializer.SerializeToDocument(val),
            };
        }
        return null;
    }

    /// <summary>
    ///     Unpacks the task.
    /// </summary>
    /// <returns></returns>
    public static async ValueTask<object> UnpackTask(object maybeTask)
    {
        if (maybeTask is Task task)
        {
            if (!task.IsCompleted)
            {
                await task.ConfigureAwait(false);
            }

            if (task is Task<object> task2)
            {
                return task2.Result;
            }

            var taskType = task.GetType();

            if (taskType != typeof(Task))
            {
                return typeof(Task<>)
                    .MakeGenericType(taskType.GenericTypeArguments[0]) //this must be done for an strange behavior with async's calls in .net core
                    .GetProperty(nameof(Task<object>.Result))!
                    .GetValue(task)!;
            }

            return maybeTask;
        }

        if (maybeTask is ValueTask valTask)
        {
            if (!valTask.IsCompleted)
            {
                await valTask.ConfigureAwait(false);
            }

            var taskType = valTask.GetType();

            if (taskType != typeof(ValueTask))
            {
                return typeof(ValueTask<>)
                    .MakeGenericType(taskType.GenericTypeArguments[0]) //this must be done for an strange behavior with async's calls in .net core
                    .GetProperty(nameof(ValueTask<object>.Result))!
                    .GetValue(valTask)!;
            }
        }

        if (maybeTask is ValueTask<object> objValTask)
        {
            return await objValTask.ConfigureAwait(false);
        }

        return maybeTask;
    }

    public InputSchema GenerateSchema()
    {
        var options = JsonSerializerOptions.Default;
        var jsonSchema = options.GetJsonSchemaAsNode(Delegate.Method.GetType()); //TODO: does this just work? otherwise we have to construct it on our own.
        return jsonSchema.Deserialize<InputSchema>()!;
    }
}

public interface IToolRegistration
{
    string Name { get; }
    string Description { get; }

    InputSchema GenerateSchema();
    Task<object?> Invoke(JsonDocument jsonDocument);
}

public interface IToolRunner<TArguments>
    where TArguments : class
{
    ValueTask<object> InvokeTool(TArguments? arguments);
}
