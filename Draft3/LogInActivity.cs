using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;

namespace Draft3
{
    [Activity(Label = "LogInActivity")]
    public class LogInActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.log_in);


            Button back = FindViewById<Button>(Resource.Id.buttonbackbutton);
            Button login = FindViewById<Button>(Resource.Id.buttonlog);
            back.Click += delegate
            {
                StartActivity(typeof(MainActivity));
            };

            login.Click += In;
        }
        public void In(object sender, EventArgs e)
        {
            string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "ScoutingApp.db3");
            var db = new SQLiteConnection(dpPath);
            db.CreateTable<UserTable>();
            UserTable userT = new UserTable();
            var data = db.Table<UserTable>();

            EditText username = FindViewById<EditText>(Resource.Id.editTextnamelog);
            EditText password = FindViewById<EditText>(Resource.Id.editTextpasslog);
            var data1 = data.Where(x => x.Name == username.Text && global::BCrypt.Net.BCrypt.CheckPassword(password.Text, x.Passcode));
            if (data1 != null)
            {

                     StartActivity(typeof(HomeActivity));
                
            }
            else
            {
                Toast.MakeText(this, "Incorrect Login Credentials", ToastLength.Long).Show();
                }
            
        }
    }
}