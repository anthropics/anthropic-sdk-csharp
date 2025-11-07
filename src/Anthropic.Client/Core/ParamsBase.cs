using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using Web = System.Web;

namespace Anthropic.Client.Core;

public abstract record class ParamsBase
{
    private protected FreezableDictionary<string, JsonElement> _queryProperties = [];

    public IReadOnlyDictionary<string, JsonElement> QueryProperties
    {
        get { return this._queryProperties.Freeze(); }
    }

    private protected FreezableDictionary<string, JsonElement> _headerProperties = [];

    public IReadOnlyDictionary<string, JsonElement> HeaderProperties
    {
        get { return this._headerProperties.Freeze(); }
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
        foreach (var item in this.QueryProperties)
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
                sb.Append(Web::HttpUtility.UrlEncode(key));
                sb.Append('=');
                sb.Append(Web::HttpUtility.UrlEncode(value));
            }
        }
        return sb.ToString();
    }

    internal abstract void AddHeadersToRequest(HttpRequestMessage request, ClientOptions options);

    internal virtual StringContent? BodyContent()
    {
        return null;
    }

    protected static void AddDefaultHeaders(HttpRequestMessage request, ClientOptions options)
    {
        request.Headers.Add("X-Stainless-Arch", GetOSArch());
        request.Headers.Add("X-Stainless-Lang", "csharp");
        request.Headers.Add("X-Stainless-OS", GetOS());

        if (options.APIKey != null)
        {
            request.Headers.Add("X-Api-Key", options.APIKey);
        }
        if (options.AuthToken != null)
        {
            request.Headers.Add("Authorization", string.Format("Bearer {0}", options.AuthToken));
        }
        request.Headers.Add("anthropic-version", "2023-06-01");
    }

    static string GetOSArch() =>
        RuntimeInformation.OSArchitecture switch
        {
            Architecture.X86 => "x32",
            Architecture.X64 => "x64",
            Architecture.Arm => "arm",
            Architecture.Arm64 or Architecture.Armv6 => "arm64",
            Architecture.Wasm
            or Architecture.S390x
            or Architecture.LoongArch64
            or Architecture.Ppc64le => $"other:{RuntimeInformation.OSArchitecture}",
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
}
