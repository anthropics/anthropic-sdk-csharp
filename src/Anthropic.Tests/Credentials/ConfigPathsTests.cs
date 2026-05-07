using System;
using System.Collections.Generic;
using System.IO;
using Anthropic.Credentials;

namespace Anthropic.Tests.Credentials;

[Collection("EnvVarMutating")]
public class ConfigPathsTests : IDisposable
{
    private readonly Dictionary<string, string?> _originalEnvVars = new();

    private void SetEnv(string name, string? value)
    {
        if (!_originalEnvVars.ContainsKey(name))
        {
            _originalEnvVars[name] = Environment.GetEnvironmentVariable(name);
        }
        Environment.SetEnvironmentVariable(name, value);
    }

    public void Dispose()
    {
        foreach (var kvp in _originalEnvVars)
        {
            Environment.SetEnvironmentVariable(kvp.Key, kvp.Value);
        }
        GC.SuppressFinalize(this);
    }

    [Fact]
    public void GetConfigDirectory_RespectsEnvOverride()
    {
        SetEnv("ANTHROPIC_CONFIG_DIR", "/custom/config");

        var dir = ConfigPaths.GetConfigDirectory();
        Assert.Equal("/custom/config", dir);
    }

    [Fact]
    public void GetConfigDirectory_FallsBackToDefault()
    {
        SetEnv("ANTHROPIC_CONFIG_DIR", null);

        var dir = ConfigPaths.GetConfigDirectory();
        Assert.NotEmpty(dir);
        Assert.Contains("anthropic", dir, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public void GetActiveProfile_RespectsEnvOverride()
    {
        SetEnv("ANTHROPIC_PROFILE", "my-profile");

        var profile = ConfigPaths.GetActiveProfile();
        Assert.Equal("my-profile", profile);
    }

    [Fact]
    public void GetActiveProfile_DefaultsToDefault()
    {
        SetEnv("ANTHROPIC_PROFILE", null);
        // Ensure no active_config file would be found
        SetEnv("ANTHROPIC_CONFIG_DIR", "/nonexistent/path");

        var profile = ConfigPaths.GetActiveProfile();
        Assert.Equal("default", profile);
    }

    [Fact]
    public void GetConfigFilePath_ReturnsCorrectPath()
    {
        SetEnv("ANTHROPIC_CONFIG_DIR", "/custom/config");

        var path = ConfigPaths.GetConfigFilePath("myprofile");
        Assert.EndsWith(Path.Combine("configs", "myprofile.json"), path);
        Assert.StartsWith("/custom/config", path);
    }

    [Fact]
    public void GetCredentialsFilePath_ReturnsCorrectPath()
    {
        SetEnv("ANTHROPIC_CONFIG_DIR", "/custom/config");

        var path = ConfigPaths.GetCredentialsFilePath("myprofile");
        Assert.EndsWith(Path.Combine("credentials", "myprofile.json"), path);
        Assert.StartsWith("/custom/config", path);
    }

    [Fact]
    public void GetActiveProfile_RejectsInvalidProfileName()
    {
        SetEnv("ANTHROPIC_PROFILE", "../escape");
        Assert.ThrowsAny<ArgumentException>(() => ConfigPaths.GetActiveProfile());
    }

    [Fact]
    public void GetConfigFilePath_RejectsInvalidProfileName()
    {
        Assert.ThrowsAny<ArgumentException>(() => ConfigPaths.GetConfigFilePath("../escape"));
    }
}
