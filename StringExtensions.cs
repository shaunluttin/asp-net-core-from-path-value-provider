using System.Collections.Generic;

namespace AspNetCoreUriToAssoc
{
    public static class StringExtensions {
        public static Dictionary<string, string> ToDictionaryFromUriPath(this string path) {
            var parts = path.Split('/');
            var dictionary = new Dictionary<string, string>();
            for(var i = 0; i < parts.Length; i++)
            {
                if(i % 2 != 0) continue;
                var key = parts[i].ToLower(); // case insensitive model binding
                var value = parts[i + 1];
                dictionary.Add(key, value);
            }

            return dictionary;
        }
    }
}
