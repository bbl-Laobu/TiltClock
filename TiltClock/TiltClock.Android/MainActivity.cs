using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace TiltClock.Droid
{
    [Activity(Label = "TiltClock", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            //global::Xamarin.Forms.Forms.SetTitleBarVisibility(Xamarin.Forms.AndroidTitleBarVisibility.Never);

            global::Xamarin.Forms.Forms.SetTitleBarVisibility(this, Xamarin.Forms.AndroidTitleBarVisibility.Never);
            SetUiFlags();

            LoadApplication(new App());
        }

        

        protected override void OnPause()
        {
            base.OnPause();
            SetUiFlags();
        }

        protected override void OnResume()
        {
            base.OnResume();
            SetUiFlags();
        }

        private void SetUiFlags()
        {
            // this.Window.AddFlags(WindowManagerFlags.Fullscreen); // hide the status bar

            // Set our view from the "main" layout resource
            //SetContentView(Resource.Layout.Main);

            int uiOptions = (int)Window.DecorView.SystemUiVisibility;

            uiOptions |= (int)SystemUiFlags.LowProfile;
            uiOptions |= (int)SystemUiFlags.Fullscreen;
            uiOptions |= (int)SystemUiFlags.HideNavigation;
            uiOptions |= (int)SystemUiFlags.ImmersiveSticky;

            Window.DecorView.SystemUiVisibility =
             (StatusBarVisibility)uiOptions;
        }
    }
}