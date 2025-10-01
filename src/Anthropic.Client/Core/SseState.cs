using System.Collections.Generic;

namespace Anthropic.Client.Core;

sealed class SseState
{
    string? _event = null;
    readonly List<string> _data = [];
    string? _lastId = null;
    int? _retry = null;

    // https://html.spec.whatwg.org/multipage/server-sent-events.html#event-stream-interpretation
    internal SseMessage? Decode(string line)
    {
        if (line.Length == 0)
        {
            return Flush();
        }

        if (line.StartsWith(':'))
        {
            return null;
        }

        string fieldName;
        string value;

        var colonIndex = line.IndexOf(':');
        if (colonIndex == -1)
        {
            fieldName = line;
            value = "";
        }
        else
        {
            fieldName = line[..colonIndex];
            value = line[(colonIndex + 1)..];
        }

        if (value.StartsWith(' '))
        {
            value = value[1..];
        }

        switch (fieldName)
        {
            case "event":
                _event = value;
                break;
            case "data":
                _data.Add(value);
                break;
            case "id":
                if (!value.Contains('\u0000'))
                {
                    _lastId = value;
                }
                break;
            case "retry":
                if (int.TryParse(value, out var result))
                {
                    _retry = result;
                }
                break;
        }

        return null;
    }

    SseMessage? Flush()
    {
        if (IsEmpty())
        {
            return null;
        }

        var message = new SseMessage(_event, string.Join('\n', _data), _lastId, _retry);

        // NOTE: Per the SSE spec, do not reset _lastId.
        _event = null;
        _data.Clear();
        _retry = null;

        return message;
    }

    bool IsEmpty() =>
        (_event == null || _event.Length == 0)
        && _data.Count == 0
        && (_lastId == null || _lastId.Length == 0)
        && _retry == null;
}
