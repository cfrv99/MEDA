using Microsoft.Extensions.Caching.Memory;
using Ministry.BlogPage.Helpers;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Ministry.BlogPage.Resources
{
    public interface ILocalizationService
    {
        string GetByKey(string key);
    }
    public class LocalizationService : ILocalizationService
    {
        private readonly IMemoryCache _memoryCache;

        public LocalizationService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }
        public string GetByKey(string key)
        {
            var currentCulture = CultureInfo.CurrentCulture;

            JObject jsonObj;
            string cacheKey = "L" + currentCulture.Name;
            if (!_memoryCache.TryGetValue(cacheKey, out jsonObj))
            {
                string jsonContent;
                switch (currentCulture.Name)
                {
                    case "az":
                        jsonContent = FileReader.ReadFileContentFromEmbeddedRecourse("Ministry.BlogPage.Resources.az.json");
                        break;
                    case "en":
                        jsonContent = FileReader.ReadFileContentFromEmbeddedRecourse("Ministry.BlogPage.Resources.en.json");
                        break;
                    default:
                        jsonContent = FileReader.ReadFileContentFromEmbeddedRecourse("Ministry.BlogPage.Resources.az.json");
                        break;
                }

                jsonObj = JObject.Parse(jsonContent);
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromHours(1));
                _memoryCache.Set(cacheKey, jsonObj, cacheEntryOptions);

            }
            var translatedWord = jsonObj[key]?.Value<string>();

            if (string.IsNullOrEmpty(translatedWord))
            {
                translatedWord = key;
            }

            return translatedWord;
        }
    }
}
