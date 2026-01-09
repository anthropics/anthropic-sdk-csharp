using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Web;

namespace Anthropic.Core;

public abstract record class ParamsBase
{
    static readonly IReadOnlyDictionary<string, string> defaultHeaders;

    static ParamsBase()
    {
        var runtime = GetRuntime();
        defaultHeaders = new Dictionary<string, string>
        {
            ["User-Agent"] = GetUserAgent(),
            ["X-Stainless-Arch"] = GetOSArch(),
            ["X-Stainless-Lang"] = "csharp",
            ["X-Stainless-OS"] = GetOS(),
            ["X-Stainless-Package-Version"] = GetPackageVersion(),
            ["X-Stainless-Runtime"] = runtime.Name,
            ["X-Stainless-Runtime-Version"] = runtime.Version,
            ["anthropic-version"] = "2023-06-01",
        };
    }

    private protected FreezableDictionary<string, JsonElement> _rawQueryData = [];

    private protected FreezableDictionary<string, JsonElement> _rawHeaderData = [];

    protected ParamsBase(ParamsBase paramsBase)
    {
        this._rawHeaderData = [.. paramsBase._rawHeaderData];
        this._rawQueryData = [.. paramsBase._rawQueryData];
    }

    public IReadOnlyDictionary<string, JsonElement> RawQueryData
    {
        get { return this._rawQueryData.Freeze(); }
    }

    public IReadOnlyDictionary<string, JsonElement> RawHeaderData
    {
        get { return this._rawHeaderData.Freeze(); }
    }

    public abstract Uri Url(ClientOptions options);

    protected static void AddQueryElementToCollection(
        NameValueCollection collection,
        string key,
        JsonElement element
    )
    {
        switch (element.ValueKind)
        {
            case JsonValueKind.Undefined:
            case JsonValueKind.Null:
                collection.Add(key, "");
                break;
            case JsonValueKind.String:
            case JsonValueKind.Number:
                collection.Add(key, element.ToString());
                break;
            case JsonValueKind.True:
                collection.Add(key, "true");
                break;
            case JsonValueKind.False:
                collection.Add(key, "false");
                break;
            case JsonValueKind.Object:
                foreach (var item in element.EnumerateObject())
                {
                    AddQueryElementToCollection(
                        collection,
                        string.Format("{0}[{1}]", key, item.Name),
                        item.Value
                    );
                }
                break;
            case JsonValueKind.Array:
                collection.Add(
                    key,
                    string.Join(
                        ",",
                        Enumerable.Select(
                            element.EnumerateArray(),
                            x =>
                                x.ValueKind switch
                                {
                                    JsonValueKind.Null => "",
                                    JsonValueKind.True => "true",
                                    JsonValueKind.False => "false",
                                    _ => x.GetString(),
                                }
                        )
                    )
                );
                break;
        }
    }

    protected static void AddHeaderElementToRequest(
        HttpRequestMessage request,
        string key,
        JsonElement element
    )
    {
        switch (element.ValueKind)
        {
            case JsonValueKind.Undefined:
            case JsonValueKind.Null:
                request.Headers.Add(key, "");
                break;
            case JsonValueKind.String:
            case JsonValueKind.Number:
                request.Headers.Add(key, element.ToString());
                break;
            case JsonValueKind.True:
                request.Headers.Add(key, "true");
                break;
            case JsonValueKind.False:
                request.Headers.Add(key, "false");
                break;
            case JsonValueKind.Object:
                foreach (var item in element.EnumerateObject())
                {
                    AddHeaderElementToRequest(
                        request,
                        string.Format("{0}.{1}", key, item.Name),
                        item.Value
                    );
                }
                break;
            case JsonValueKind.Array:
                foreach (var item in element.EnumerateArray())
                {
                    request.Headers.Add(
                        key,
                        item.ValueKind switch
                        {
                            JsonValueKind.Null => "",
                            JsonValueKind.True => "true",
                            JsonValueKind.False => "false",
                            _ => item.GetString(),
                        }
                    );
                }
                break;
        }
    }

    protected string QueryString(ClientOptions options)
    {
        NameValueCollection collection = [];
        foreach (var item in this.RawQueryData)
        {
            ParamsBase.AddQueryElementToCollection(collection, item.Key, item.Value);
        }
        StringBuilder sb = new();
        bool first = true;
        foreach (var key in collection.AllKeys)
        {
            foreach (var value in collection.GetValues(key) ?? [])
            {
                if (!first)
                {
                    sb.Append('&');
                }
                first = false;
                sb.Append(HttpUtility.UrlEncode(key));
                sb.Append('=');
                sb.Append(HttpUtility.UrlEncode(value));
            }
        }
        return sb.ToString();
    }

    internal abstract void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options);

    internal virtual HttpContent? BodyContent()
    {
        return null;
    }

    protected static void AddDefaultHeaders(HttpRequestMessage request, ClientOptions options)
    {
        foreach (var header in defaultHeaders)
        {
            request.Headers.Add(header.Key, header.Value);
        }

        if (options.APIKey != null)
        {
            request.Headers.Add("X-Api-Key", options.APIKey);
        }
        if (options.AuthToken != null)
        {
            request.Headers.Add("Authorization", string.Format("Bearer {0}", options.AuthToken));
        }
        request.Headers.Add(
            "X-Stainless-Timeout",
            (options.Timeout ?? ClientOptions.DefaultTimeout).TotalSeconds.ToString()
        );
    }

    static string GetUserAgent() => $"{typeof(AnthropicClient).Name}/C# {GetPackageVersion()}";

    static string GetOSArch() =>
        RuntimeInformation.OSArchitecture switch
        {
            Architecture.X86 => "x32",
            Architecture.X64 => "x64",
            Architecture.Arm => "arm",
            Architecture.Arm64 => "arm64",
#if !NETSTANDARD2_0
            Architecture.Armv6 => "arm64",
            Architecture.Wasm
            or Architecture.S390x
            or Architecture.LoongArch64
            or Architecture.Ppc64le => $"other:{RuntimeInformation.OSArchitecture}",
#endif
            _ => "unknown",
        };

    static string GetOS()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            return "Windows";
        }
        if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            return "MacOS";
        }
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            return "Linux";
        }
        return $"Other:{RuntimeInformation.OSDescription}";
    }

    static string GetPackageVersion() =>
        Assembly
            .GetExecutingAssembly()
            .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
            ?.InformationalVersion
        ?? "unknown";

    static Runtime GetRuntime()
    {
        var runtimeDescription = RuntimeInformation.FrameworkDescription;
        var lastSpaceIndex = runtimeDescription.LastIndexOf(' ');
        if (lastSpaceIndex == -1)
        {
            return new() { Name = runtimeDescription, Version = "unknown" };
        }

        var name = runtimeDescription.Substring(0, lastSpaceIndex).Trim();
        var version = runtimeDescription.Substring(lastSpaceIndex + 1).Trim();
        return new()
        {
            Name = name.Length == 0 ? "unknown" : name,
            Version = version.Length == 0 ? "unknown" : version,
        };
    }

    readonly record struct Runtime(string Name, string Version);
}
