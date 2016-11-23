using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;

namespace Xamarin_DigitsDemo.Activities
{
    [Activity(Label = "@string/BaseActivity", Icon = "@drawable/icon")]
    public class BaseActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        /// <summary>
        /// Once registration is successfull we will skip the MainActivity page
        /// And navigate application to the Home Activity with userPhoneNumber
        /// </summary>
        public void NavigatingToHome(Type activityType, string userPhoneNumber)
        {
            var homeActivity = new Intent(this, activityType);

            if (userPhoneNumber != null)
                homeActivity.PutExtra(GetString(Resource.String.userKey), userPhoneNumber);

            StartActivity(homeActivity);
        }
    }
}