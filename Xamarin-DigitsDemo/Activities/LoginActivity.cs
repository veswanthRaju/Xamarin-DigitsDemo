using Android.App;
using Android.Widget;
using Android.OS;
using Com.Digits.Sdk.Android;
using Android.Support.Design.Widget;

namespace Xamarin_DigitsDemo.Activities
{
    [Activity(Label = "@string/ApplicationName", NoHistory =true, Theme = "@style/MyTheme")]
    public class LoginActivity : BaseActivity, IAuthCallback
    {
        string userPhoneNumber;

        RelativeLayout parentLayout;
        
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.login);

            parentLayout = FindViewById<RelativeLayout>(Resource.Id.parentPanel);
            
            var digitsAuthBtn = FindViewById<DigitsAuthButton>(Resource.Id.authButton);
            digitsAuthBtn.Text = GetString(Resource.String.authButton);
            digitsAuthBtn.SetCallback(this);
        }

        #region IAuthCallBack Implementation
        public void Failure(DigitsException exception)
        {
            Snackbar.Make(parentLayout, Resource.String.LoginFail, Snackbar.LengthShort).Show();
        }
        
        public void Success(DigitsSession p0, string p1)
        {
            userPhoneNumber = p1;
            Snackbar.Make(parentLayout, Resource.String.LoginSuccessful + p1, Snackbar.LengthShort).Show();
            NavigatingToHome(typeof(HomeActivity), userPhoneNumber);
        }
        #endregion

        #region CodeBehindAccess
        /// <summary>
        /// Method to trigger the digitsauth button with country extension
        /// </summary>
        private void TriggerDigitsAuthButton()
        {
            AuthConfig.Builder authConfigBuilder = new AuthConfig.Builder()
                        .WithAuthCallBack(this)
                        .WithPhoneNumber("+91");
            Digits.Authenticate(authConfigBuilder.Build());
        }

        #endregion
    }
}