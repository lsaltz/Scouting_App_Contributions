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

namespace Draft3
{
    [Activity(Label = "RegisterActivity")]
    public class RegisterActivity : Activity
    {
        EditText name;
        EditText teamNumber;
        EditText user;
        EditText pass;
        EditText rePass;
        EditText email;
        Button create;
        Button back;
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
                    Random random = new Random();
                    string num = random.Next(0, 9999).ToString("D4");
                    string inputPass = global::BCrypt.Net.BCrypt.HashPassword(pass.Text, global::BCrypt.Net.BCrypt.GenerateSalt());
                    userT.PIN = Int32.Parse(num);
                    userT.Team = Int32.Parse(teamNumber.Text);
                    userT.Name = user.Text;
                    userT.Passcode = inputPass;
                    userT.Email = email.Text;
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
        public static void SendEmail(string htmlString)
        {
            try
            {

              /*  MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("emailaddress@gmail.com");
                message.To.Add(new MailAddress(email.Text));
                message.Subject = "Test";
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = htmlString;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("emailaddress@gmail.com", "password");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);*/
            }
            catch (Exception) { }
        }

    }
}