using System.Collections.Generic;
using System.Text.Json;

namespace Anthropic.Core;

/// <summary>
/// The base class for all API objects that are serialized as JSON objects.
///
/// <para>API objects such as enums and unions do not inherit from this class.</para>
/// </summary>
public abstract record class JsonModel : ModelBase
{
    private protected JsonDictionary _rawData = new();

    /// <summary>
    /// The backing JSON properties of the instance.
    /// </summary>
    public IReadOnlyDictionary<string, JsonElement> RawData
    {
        get { return this._rawData.Freeze(); }
    }

    protected JsonModel(JsonModel jsonModel)
        : base(jsonModel)
    {
        this._rawData = new(jsonModel._rawData);
    }

    public sealed override string ToString() => this._rawData.ToString();

    public virtual bool Equals(JsonModel? other)
    {
        if (other == null)
        {
            return false;
        }

        return this._rawData.Equals(other._rawData);
    }

    public override int GetHashCode() => this._rawData.GetHashCode();
}

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
///
/// <para>NOTE: This interface is in the style of a factory instance instead of using
/// abstract static methods because .NET Standard 2.0 doesn't support abstract static methods.</para>
/// </summary>
interface IFromRawJson<T>
{
    /// <summary>
    /// Returns an instance constructed from the given raw JSON properties.
    ///
    /// <para>Required field and type mismatches are not checked. In these cases accessing
    /// the relevant properties of the constructed instance may throw.</para>
    ///
    /// <para>This method is useful for constructing an instance from already serialized
    /// data or for sending arbitrary data to the API (e.g. for undocumented or not
    /// yet supported properties or values).</para>
    /// </summary>
    T FromRawUnchecked(IReadOnlyDictionary<string, JsonElement> rawData);
}
