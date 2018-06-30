using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Routing;

namespace AspNetCoreUriToAssoc
{
    public class PathValueProvider : IValueProvider
    {
        public Dictionary<string, string> _values { get; }

        public PathValueProvider(BindingSource bindingSource, RouteValueDictionary values)
        {
            if(!values.TryGetValue("path", out var path)) 
            {
                var msg = "Route value 'path' was not present in the route.";
                throw new InvalidOperationException(msg);
            }

            _values = (path as string).ToDictionaryFromUriPath();
        }

        public bool ContainsPrefix(string prefix) => _values.ContainsKey(prefix);

        public ValueProviderResult GetValue(string key)
        {
            key = key.ToLower(); // case insensitive model binding
            if(!_values.TryGetValue(key, out var value)) {
                return ValueProviderResult.None;
            }

            return new ValueProviderResult(value);
        }
    }
}
