using Newtonsoft.Json;
using sRecipe.Constants.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;

namespace sRecipe.MVCClient.Helpers
{
    public static class HeaderParser
    {
        public static PagingInfo FindAndParsePagingInfo(HttpResponseHeaders responseHeaders)
        {
            // find the "X-Pagination" info in header
            if (responseHeaders.Contains(PagingInfo.PagingHeader))
            {
                var xPag = responseHeaders.First(ph => ph.Key == PagingInfo.PagingHeader).Value;

                // parse the value - this is a JSON-string.
                return JsonConvert.DeserializeObject<PagingInfo>(xPag.First());
            }


            return null;
        }
    }
}