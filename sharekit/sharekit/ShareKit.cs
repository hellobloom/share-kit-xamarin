using System;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace sharekit
{
    public class ShareKit
    {
        private const string ResourceId = "sharekit.Resources.bloombutton";
        private const string QueryUrl = "?share-kit-from=button";
        private string BloomRequestData;
        private string CallBackUrl;

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
                    requestData.url += QueryUrl;
                }
                BloomRequestData = JsonConvert.SerializeObject(requestData);
            }
           

            if (!string.IsNullOrEmpty(appCallBackUrl))
            {
                CallBackUrl = Uri.EscapeDataString(appCallBackUrl);
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
            return $"https://bloom.co/download?request={Base64Encode(BloomRequestData)}&callback-url={CallBackUrl}";
        }

        private string Base64Encode(string requestDataString)
        {
            return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(requestDataString));
        }
    }
}