using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ModernHttpClient;
using Newtonsoft.Json;

namespace HomeRoom_Mobile.Services
{
    /// <summary>
    /// Base Http Service to help send requests to an api.
    /// </summary>
    public abstract class BaseHttpService
    {
        /// <summary>
        /// Sends the request asynchronously.
        /// </summary>
        /// <typeparam name="T">Type of the expected result from the server. For most requests this should be ApiResponse.</typeparam>
        /// <param name="url">The URL.</param>
        /// <param name="httpMethod">The HTTP method.</param>
        /// <param name="headers">The headers.</param>
        /// <param name="requestData">The request data.</param>
        /// <returns></returns>
        protected async Task<T> SendRequestAsync<T>(Uri url, HttpMethod httpMethod = null, IDictionary<string, string> headers = null, object requestData = null)
        {
            T result;

            // default to GET if they didn't pass in a http method
            var method = httpMethod ?? HttpMethod.Get;
            // set the data to send if it is not null
            var data = requestData == null ? null : JsonConvert.SerializeObject(requestData);


            using (var request = new HttpRequestMessage(method, url))
            {
                // add the request content to the request
                if (data != null)
                {
                    request.Content = new StringContent(data, Encoding.UTF8, "application/json");
                }
                // add any headers we need
                if (headers != null)
                {
                    foreach (var header in headers)
                    {
                        request.Headers.Add(header.Key, header.Value);
                    }
                }
                // create a client to send the request out
                // this is ModernHttpClient instead of just the normal HttpClient, so we use a native message handler
                // On Android this will use OkHttp, and on iOS will use NSURLSession
                using (var client = new HttpClient(new NativeMessageHandler()))
                {
                    using (var response = await client.SendAsync(request, HttpCompletionOption.ResponseContentRead))
                    {
                        var content = response.Content == null ? null : await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<T>(content);
                    }
                }
            }

            return result;
        }
    }
}
