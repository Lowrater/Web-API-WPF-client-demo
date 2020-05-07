using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ApiLibary
{
    public static class APIHelper
    {
        // A Web client to make web requests.
        public static HttpClient ApiClient { get; set; }

        /// <summary>
        /// Initialize the ApiClient
        /// </summary>
        public static void InitializeClient()
        {
            //--- Initializes the Apiclient
            ApiClient = new HttpClient();
            //-- Tells the Api where to fetch the Api call from.
            //ApiClient.BaseAddress = new Uri("");
            //--- Clears the Api header
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            //-- Sets the ApiClient, to only accept json header format from etc. an (Restfull WebAPI).
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
