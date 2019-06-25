using System;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace sharekit
{
    public class ShareKit
    {
        private const string ResourceId = "sharekit.Resources.bloombutton";
        private string bloomRequestData;
        private string callBackUrl;

        public ImageButton RequestButton(RequestData requestData, string appCallBackUrl)
        {
            if (requestData == null)
            {
                throw new ArgumentNullException(nameof(requestData));
            }
            else
            {
                // set the share-kit-from query url
                if (!string.IsNullOrEmpty(requestData.url))
                {
                    requestData.url += "?share-kit-from=button";
                }

                bloomRequestData = JsonConvert.SerializeObject(requestData);
            }
           

            if (!string.IsNullOrEmpty(appCallBackUrl))
            {
                callBackUrl = Uri.EscapeDataString(appCallBackUrl);
            }

            ImageButton bloomButton = new ImageButton
            {
                Source = Forms9Patch.ImageSource.FromMultiResource(ResourceId)
            };
           
            bloomButton.Clicked += OnBloomButtonClicked;

            return bloomButton;
        }

        private void OnBloomButtonClicked(object sender, EventArgs e)
        {
            Device.OpenUri(new Uri(GetBloomLink()));
        }

        private string GetBloomLink()
        {
            return $"https://bloom.co/download?request={Base64Encode(bloomRequestData)}&callback-url={callBackUrl}";
        }

        private string Base64Encode(string requestDataString)
        {
            var requestDataBytes = System.Text.Encoding.UTF8.GetBytes(requestDataString);
            return Convert.ToBase64String(requestDataBytes);
        }
    }
}