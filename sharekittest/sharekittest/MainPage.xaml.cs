using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace sharekittest
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();


            // set the request data
            var requestData = new ShareKit.RequestData
            {
                Action = ShareKit.RequestData.ActionAttestation,
                Token = "0x8f31e48a585fd12ba58e70e03292cac712cbae39bc7eb980ec189aa88e24d043",
                Url = "https://receive-kit.bloom.co/api/receive",
                OrgLogoUrl = "https://bloom.co/images/notif/bloom-logo.png",
                OrgName = "Bloom",
                OrgUsagePolicyUrl = "https://bloom.co/legal/terms",
                OrgPrivacyPolicyUrl = "https://bloom.co/legal/privacy",
                Types = new string[] { "full-name", "phone", "email" }
            };

            // set the callback url
            var callBackUrl = "https://google.com";

            // then intialize the button
            var bloomButton = new ShareKit.ShareKit().RequestButton(requestData, callBackUrl);

            // set the layout padding
            MainLayout.Padding = 5;

            // finally add the verify button to the layout
            MainLayout.Children.Add(bloomButton);
            
        }
    }
}
