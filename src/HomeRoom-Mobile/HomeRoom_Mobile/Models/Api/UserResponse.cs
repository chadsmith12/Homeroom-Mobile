using HomeRoom_Mobile.Enumerations;
using Newtonsoft.Json;

namespace HomeRoom_Mobile.Models.Api
{
    public class UserResponse
    {
        [JsonProperty("userId")]
        public long UserId { get; set; }
        [JsonProperty("apiToken")]
        public string ApiToken { get; set; }
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("firstName")]
        public string FirstName { get; set; }
        [JsonProperty("lastName")]
        public string LastName { get; set; }
        [JsonProperty("accountType")]
        public AccountType AccountType { get; set; }
    }

    public class UserSignInDto
    {
        public string UsernameOrEmailAddress { get; set; }
        public string TenancyName { get; set; }
        public string Password { get; set; }
    }
}
