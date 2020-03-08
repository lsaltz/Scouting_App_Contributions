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
using BCrypt.Net;
using BCrypt = BCrypt.Net.BCrypt;
using System.Net.Mail;
using System.Net;

namespace Draft3
{
    [Activity(Label = "RegisterActivity")]
    public class RegisterActivity : Activity
    {
        EditText teamNumber;
        EditText user;
        EditText pass;
        EditText rePass;
        EditText email;
        Button create;
        Button back;
        Button logintoaccount;
        EditText enterPin;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.register_layout);

            teamNumber = FindViewById<EditText>(Resource.Id.editTextteamm);
            user = FindViewById<EditText>(Resource.Id.editTextname);
            pass = FindViewById<EditText>(Resource.Id.editTextpass1);
            rePass = FindViewById<EditText>(Resource.Id.editTextpass2);
            email = FindViewById<EditText>(Resource.Id.editTextemail);
            create = FindViewById<Button>(Resource.Id.buttonCreate);
            back = FindViewById<Button>(Resource.Id.buttonBack);
            

            back.Click += delegate
            {
                StartActivity(typeof(MainActivity));
            };

            create.Click += Register;
        }
        private void Register(object sender, EventArgs e)
        {
            try
            {
                string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "ScoutingApp.db3");
                var db = new SQLiteConnection(dpPath);
                db.CreateTable<UserTable>();
                UserTable userT = new UserTable();

                if(pass.Text == rePass.Text)
                {
                   
                    string inputPass = global::BCrypt.Net.BCrypt.HashPassword(pass.Text, global::BCrypt.Net.BCrypt.GenerateSalt());
                    
                    userT.Team = Int32.Parse(teamNumber.Text);
                    userT.Name = user.Text;
                    userT.Passcode = inputPass;
                    userT.Email = email.Text;

                    Random random = new Random();
                    string num = random.Next(0, 9999).ToString("D4");
                    userT.PIN = Int32.Parse(num);

                    MailMessage message = new MailMessage();
                    var smtp = new SmtpClient();
                    message.From = new MailAddress("scoutingapp13x@gmail.com");
                    message.To.Add(new MailAddress(email.Text));
                    message.Subject = "Test";
                    message.IsBodyHtml = true;
                    message.Body = num;
                    smtp.Port = 587;
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential("scoutingapp13x@gmail.com", "thisisanewpassword");
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Send(message); 
                    Toast.MakeText(this, "Sent to " + email.Text, ToastLength.Long).Show();

                    SetContentView(Resource.Layout.pin_alert);
                    enterPin = FindViewById<EditText>(Resource.Id.editTextpin);
                    logintoaccount = FindViewById<Button>(Resource.Id.buttonregisterandlogin);
                    logintoaccount.Click += delegate
                    {
                        if (enterPin.Text == num)
                    {

                            StartActivity(typeof(LogInActivity));
                       

                    }
                    else
                    {
                        Toast.MakeText(this, "Try again", ToastLength.Long).Show();
                        }
                    };
                }
                else
                {
                    Toast.MakeText(this, "Passcodes do not match.", ToastLength.Long).Show();
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Long).Show();
            }
        }
    }
}