using Android.App;
using Android.OS;
using Com.Digits.Sdk.Android;
using Com.Twitter.Sdk.Android.Core;
using IO.Fabric.Sdk.Android;

namespace Xamarin_DigitsDemo.Activities
{
    [Activity(Label = "@string/ApplicationName", MainLauncher = true, Theme = "@style/SplashTheme", NoHistory = true)]
    public class SplashScreen : BaseActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            TwitterAuthConfig authConfig = new TwitterAuthConfig
                                                (
                                                   GetString(Resource.String.twitterKey),
                                                   GetString(Resource.String.twitterSecret)
                                                 );

            Fabric.With(this, new TwitterCore(authConfig), 
                              new Digits.Builder().WithTheme(Resource.Style.LoginTheme).Build());
        }

        protected override void OnResume()
        {
            base.OnResume();
            Checkforexistinguser();
        }

        void Checkforexistinguser()
        {
            if (Digits.ActiveSession == null || (Digits.ActiveSession.AuthToken as TwitterAuthToken).IsExpired)
            {
                NavigatingToHome(typeof(LoginActivity), null);
                return;
            }
            NavigatingToHome(typeof(HomeActivity), Digits.ActiveSession.PhoneNumber);
        }
    }
}