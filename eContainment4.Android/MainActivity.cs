using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Microsoft.Identity.Client;
using Android.Content;

namespace eContainment4.Droid
{
    [Activity(Label = "eContainment4", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            AppDynamics.Droid.Agent.Init(this, savedInstanceState); //initialize the agent on the Android Platform

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            var config = AppDynamics.Agent.AgentConfiguration.Create("AD-AAB-ABM-CZZ");
            config.CollectorURL = "https://col.eum-appdynamics.com";
            //config.LoggingLevel = AppDynamics.Agent.LoggingLevel.Verbose;
            AppDynamics.Agent.Instrumentation.InitWithConfiguration(config);

            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }


    }
}
