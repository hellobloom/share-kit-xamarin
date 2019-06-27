using Newtonsoft.Json;

namespace ShareKit
{
    public class RequestData
    {


        public const string Action_attestation = "request_attestation_data";

        [JsonProperty("action")]
        public string Action { get; set; }
        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("org_logo_url")]
        public string OrgLogoUrl { get; set; }
        [JsonProperty("org_name")]
        public string OrgName { get; set; }
        [JsonProperty("org_usage_policy_url")]
        public string OrgUsagePolicyUrl { get; set; }
        [JsonProperty("org_privacy_policy_url")]
        public string OrgPrivacyPolicyUrl { get; set; }
        [JsonProperty("types")]
        public string[] Types { get; set; }


    }
}
