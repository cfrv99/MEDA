using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Ministry.BlogPage.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Ministry.BlogPage.Helpers
{
    public static class HtmlHelpers
    {
        public static string L(this IHtmlHelper htmlHelper, string localizationKey, ILocalizationService localization)
        {
            var data = localization.GetByKey(localizationKey);
            return data;
        }

        public static string CurrentLanguage(this IHtmlHelper htmlHelper)
        {
            var currentCulture = CultureInfo.CurrentCulture.Name;
            string currentLanguage = string.Empty;
            switch (currentCulture)
            {
                case "az":
                    currentLanguage = "az";
                    break;

                case "en":
                    currentLanguage = "en";
                    break;
                default:
                    currentLanguage = "az";
                    break;
            }
            return currentLanguage;
        }

        public static string CurrentLanguage()
        {
            var currentCulture = CultureInfo.CurrentCulture.Name;
            string currentLanguage = string.Empty;
            switch (currentCulture)
            {
                case "az":
                    currentLanguage = "az";
                    break;

                case "en":
                    currentLanguage = "en";
                    break;
                default:
                    currentLanguage = "az";
                    break;
            }
            return currentLanguage;
        }

        public static string Loc(this IRazorPage razor,string key,ILocalizationService localization)
        {
            var data = localization.GetByKey(key);
            return data;
        }
    }
}
