using Newtonsoft.Json;

namespace HomeRoom_Mobile.Models.Api
{
    /// <summary>
    /// The base response object that nearly all Api requests will respond back with.
    /// Holds all the basic information about a request
    /// </summary>
    /// <typeparam name="TJsonObject">The type of the json object that you expect Result to be</typeparam>
    public class ApiResponse<TJsonObject>
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ApiResponse{TJsonObject}"/> is successful.
        /// </summary>
        /// <value>
        ///   <c>true</c> if successful; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("success")]
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets the expected api result.
        /// </summary>
        /// <value>
        /// The data you expected back in a response.
        /// </value>
        [JsonProperty("result")]
        public TJsonObject Result { get; set; }

        /// <summary>
        /// Gets or sets the error information from the request.
        /// </summary>
        /// <value>
        /// The error.
        /// </value>
        [JsonProperty("error")]
        public ApiError? Error { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [unauthorized result].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [unauthorized result]; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("unAuthorizedRequest")]
        public bool UnauthorizedResult { get; set; }
    }

    /// <summary>
    /// Basic error information about an api request.
    /// </summary>
    public struct ApiError
    {
        /// <summary>
        /// Gets or sets the error code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        [JsonProperty("code")]
        public int Code { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
