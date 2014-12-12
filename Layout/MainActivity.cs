using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Layout
{
	[Activity (Label = "Layout", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		//int count = 1;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

            SetContentView(Resource.Layout.Main);

            Button btInfo = (Button) FindViewById(Resource.Id.btInfo);
            TextView txtInfo = (TextView)FindViewById(Resource.Id.txtInfo);

            btInfo.Click += (sender, e) =>     
            {
                txtInfo.Text = "Ola Xamarin";
            };
				
		}

	}
}


