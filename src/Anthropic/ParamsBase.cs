using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Web = System.Web;

namespace Anthropic;

public abstract record class ParamsBase
{
    public Dictionary<string, JsonElement> QueryProperties { get; set; } = [];

    public Dictionary<string, JsonElement> HeaderProperties { get; set; } = [];

    public abstract global::System.Uri Url(IAnthropicClient client);

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

    protected string QueryString(IAnthropicClient client)
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

    protected static void AddDefaultHeaders(HttpRequestMessage request, IAnthropicClient client)
    {
        request.Headers.Add("X-Api-Key", client.APIKey);
        request.Headers.Add("Authorization", string.Format("Bearer {0}", client.AuthToken));
        request.Headers.Add("anthropic-version", "2023-06-01");
    }
}
