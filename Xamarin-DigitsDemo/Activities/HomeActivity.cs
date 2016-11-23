using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Android.Support.V7.App;
using Com.Digits.Sdk.Android;

namespace Xamarin_DigitsDemo.Activities
{
    [Activity(Label = "@string/HomePage", Theme ="@style/MyTheme", NoHistory =true)]
    public class HomeActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.home);

            var userPhone = FindViewById<TextView>(Resource.Id.phoneId);
            var logoutBtn = FindViewById<Button>(Resource.Id.logoutButton);
            var uploadContactBtn = FindViewById<Button>(Resource.Id.contactButton);

            userPhone.Text = GetString(Resource.String.Hello) + Intent.GetStringExtra(GetString(Resource.String.userKey));
            uploadContactBtn.Click += UploadContacts;
            logoutBtn.Click += UserLogout;
        }

        private void UploadContacts(object sender, System.EventArgs e)
        {
            Digits.UploadContacts();
        }

        private void UserLogout(object sender, System.EventArgs e)
        {
            Digits.ClearActiveSession();
            StartActivity(typeof(LoginActivity));
        }
    }
}