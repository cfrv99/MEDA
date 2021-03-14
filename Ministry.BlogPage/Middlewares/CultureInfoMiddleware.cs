using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Ministry.BlogPage.Middlewares
{
    public class CultureInfoMiddleware
    {
        private readonly RequestDelegate next;

        public CultureInfoMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var culture = CultureInfo.CurrentCulture;
        }
    }
}
