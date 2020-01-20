﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Draft3
{
    [Activity(Label = "TeamDisplayActivity")]
    public class TeamDisplayActivity : Activity
    {
        TextView tn;
        GridViewActivity gv = new GridViewActivity();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.team_display);
            
        }
    }
}