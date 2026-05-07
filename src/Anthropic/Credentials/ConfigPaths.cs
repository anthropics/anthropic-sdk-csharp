using System;
using System.IO;

namespace Anthropic.Credentials;

internal static class ConfigPaths
{
    internal static string GetConfigDirectory()
    {
        var envDir = Environment.GetEnvironmentVariable(CredentialsConstants.EnvConfigDir);
        if (!string.IsNullOrEmpty(envDir))
        {
            return envDir;
        }

#if NET
        if (OperatingSystem.IsWindows())
#else
        if (Environment.OSVersion.Platform == PlatformID.Win32NT)
#endif
        {
            var appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            return Path.Combine(appData, "Anthropic");
        }

        // Linux/macOS: use XDG_CONFIG_HOME or ~/.config
        var xdgConfig = Environment.GetEnvironmentVariable("XDG_CONFIG_HOME");
        if (!string.IsNullOrEmpty(xdgConfig))
        {
            return Path.Combine(xdgConfig, "anthropic");
        }

        var home = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        return Path.Combine(home, ".config", "anthropic");
    }

    internal static string GetActiveProfile()
    {
        var envProfile = Environment.GetEnvironmentVariable(CredentialsConstants.EnvProfile);
        if (!string.IsNullOrEmpty(envProfile))
        {
            SecurityHelpers.ValidateProfileName(envProfile);
            return envProfile;
        }

        var activeConfigPath = Path.Combine(GetConfigDirectory(), "active_config");
        if (File.Exists(activeConfigPath))
        {
            var profile = File.ReadAllText(activeConfigPath).Trim();
            if (!string.IsNullOrEmpty(profile))
            {
                SecurityHelpers.ValidateProfileName(profile);
                return profile;
            }
        }

        return "default";
    }

    internal static string GetConfigFilePath(string profile)
    {
        SecurityHelpers.ValidateProfileName(profile);
        return Path.Combine(GetConfigDirectory(), "configs", profile + ".json");
    }

    internal static string GetCredentialsFilePath(string profile)
    {
        SecurityHelpers.ValidateProfileName(profile);
        return Path.Combine(GetConfigDirectory(), "credentials", profile + ".json");
    }
}
