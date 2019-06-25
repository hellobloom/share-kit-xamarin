namespace sharekit
{
    public class RequestData
    {
#pragma warning disable IDE1006

        public const string Action_attestation = "request_attestation_data";
        public string action { get; set; }
        public string token { get; set; }
        public string url { get; set; }
        public string org_logo_url { get; set; }
        public string org_name { get; set; }
        public string org_usage_policy_url { get; set; }
        public string org_privacy_policy_url { get; set; }
        public string[] types { get; set; }

#pragma warning disable IDE1006
    }
}
