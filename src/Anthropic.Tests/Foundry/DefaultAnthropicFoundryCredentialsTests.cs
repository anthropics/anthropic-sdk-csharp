using System;
using System.Collections.Generic;
using Anthropic.Foundry;

namespace Anthropic.Tests.Foundry;

/// <summary>
/// Verifies that <see cref="DefaultAnthropicFoundryCredentials.FromEnv"/> takes the resource
/// name from its argument first and from <c>ANTHROPIC_FOUNDRY_RESOURCE</c> only as a fallback.
/// </summary>
[Collection("EnvVarMutating")]
public sealed class DefaultAnthropicFoundryCredentialsTests : IDisposable
{
    private const string ResourceVariable = "ANTHROPIC_FOUNDRY_RESOURCE";
    private const string ApiKeyVariable = "ANTHROPIC_FOUNDRY_API_KEY";

    private readonly Dictionary<string, string?> _original = [];

    public DefaultAnthropicFoundryCredentialsTests()
    {
        SetEnvironmentVariable(ResourceVariable, null);
        SetEnvironmentVariable(ApiKeyVariable, "test-key");
    }

    public void Dispose()
    {
        foreach (var variable in _original)
        {
            Environment.SetEnvironmentVariable(variable.Key, variable.Value);
        }
    }

    private void SetEnvironmentVariable(string name, string? value)
    {
        if (!_original.ContainsKey(name))
        {
            _original[name] = Environment.GetEnvironmentVariable(name);
        }
        Environment.SetEnvironmentVariable(name, value);
    }

    [Fact]
    public void FromEnv_ResourceNameArgumentWithoutVariable_UsesTheArgument()
    {
        var credentials = DefaultAnthropicFoundryCredentials.FromEnv("my-resource");

        var apiKeyCredentials = Assert.IsType<AnthropicFoundryApiKeyCredentials>(credentials);
        Assert.Equal("my-resource", apiKeyCredentials.ResourceName);
    }

    [Fact]
    public void FromEnv_ResourceNameArgumentWithoutVariableOrApiKey_UsesTheArgument()
    {
        SetEnvironmentVariable(ApiKeyVariable, null);

        var credentials = DefaultAnthropicFoundryCredentials.FromEnv("my-resource");

        var identityCredentials = Assert.IsType<AnthropicFoundryIdentityTokenCredentials>(
            credentials
        );
        Assert.Equal("my-resource", identityCredentials.ResourceName);
    }

    [Fact]
    public void FromEnv_ResourceNameArgumentAndVariable_ArgumentWins()
    {
        SetEnvironmentVariable(ResourceVariable, "env-resource");

        var credentials = DefaultAnthropicFoundryCredentials.FromEnv("my-resource");

        Assert.Equal("my-resource", credentials?.ResourceName);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("  ")]
    public void FromEnv_NoResourceNameArgument_UsesTheVariable(string? resourceName)
    {
        SetEnvironmentVariable(ResourceVariable, "env-resource");

        var credentials = DefaultAnthropicFoundryCredentials.FromEnv(resourceName);

        Assert.Equal("env-resource", credentials?.ResourceName);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("  ")]
    public void FromEnv_NoResourceNameAnywhere_ReturnsNull(string? variable)
    {
        SetEnvironmentVariable(ResourceVariable, variable);

        Assert.Null(DefaultAnthropicFoundryCredentials.FromEnv());
        Assert.Null(DefaultAnthropicFoundryCredentials.FromEnv("  "));
    }
}
