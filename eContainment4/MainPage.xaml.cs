using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AppDynamics.Agent;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace eContainment4
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            _crashButton.Clicked += _crashButton_Clicked;
        }


        async void _crashButton_Clicked(object sender, EventArgs e)
        {
            _crashButton.IsEnabled = false;

            try
            {
                HttpRequestMessage request = new HttpRequestMessage
                {
                    RequestUri = new Uri("https://google.com"),
                    Method = HttpMethod.Get,
                    //Content = httpContent
                };

                using (HttpClient client = new HttpClient(new HttpRequestTrackerHandler(DefaultHttpClientHandler())))
                {
                    var result = await client.SendAsync(request);
                    _result1Label.Text = result.StatusCode.ToString();
                    _result2Label.Text = await result.Content.ReadAsStringAsync();

                }

            }
            catch (Exception ex)
            {
                _result1Label.Text = $"EXCEPTION: {ex.GetType()} {ex.Message}";
                _result2Label.Text = $"STACKTRACE: {ex.StackTrace}";
            }
            _crashButton.IsEnabled = true;
        }

        private static HttpMessageHandler DefaultHttpClientHandler()
        {
            var handler = new HttpClientHandler();
            if (handler.SupportsAutomaticDecompression)
            {
                handler.AutomaticDecompression = DecompressionMethods.GZip;
            }

            return handler;
        }

    }
}
