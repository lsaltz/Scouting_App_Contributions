using System;
using System.Collections.Generic;
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
    class UserTable
    {
        [PrimaryKey, AutoIncrement, Column("Id")]
        public int Id { get; set; }
        public int Team { get; set; }
        [MaxLength(4)]
        public string Name { get; set; }
        public string Passcode { get; set; }
        public string Email { get; set; }
        public int PIN { get; set; }
    }
}