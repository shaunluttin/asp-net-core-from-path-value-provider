using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace AspNetCoreUriToAssoc
{
    public static class StringExtensions
    {
        public static Dictionary<string, string> ToDictionaryFromUriPath(this string path)
        {
            var parts = path.Split('/');
            var dictionary = new Dictionary<string, string>();
            for (var i = 0; i < parts.Length; i++)
            {
                if (i % 2 != 0) continue;
                var key = parts[i].ToLower(); // case insensitive model binding
                var value = parts[i + 1];
                dictionary.Add(key, value);
            }

            return dictionary;
        }

        // just for fun, here it is with LINQ.
        public static Dictionary<string, string> ToDictionaryFromUriPath(this PathString path)
        {
            var parts = path.Value
                .Substring(1, path.Value.Length - 1)
                .Split('/');

            return parts
                .Where((part, i) => i % 2 == 0)
                .Select((part, i) => new
                {
                    key = part.ToLower(), // case insensitive model binding
                    value = parts[i * 2 + 1]
                })
                .ToDictionary(p => p.key, p => p.value);
        }
    }
}
