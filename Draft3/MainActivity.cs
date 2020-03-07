using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android;
using Plugin.Media;

namespace Draft3
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button LogIn;
        Button registration;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            LogIn = FindViewById<Button>(Resource.Id.logInButton);
            registration = FindViewById<Button>(Resource.Id.registerButton);

            registration.Click += delegate
            {
                StartActivity(typeof(RegisterActivity));
            };

            LogIn.Click += delegate
            {
                StartActivity(typeof(HomeActivity));
            };
        }
    }
}