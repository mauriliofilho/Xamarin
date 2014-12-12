using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Controls;

namespace Componentes1
{
	[Activity(Label = "Teste", MainLauncher = true, Icon = "@drawable/sisaut", Theme = "@android:style/Theme.NoTitleBar")]
    public class MainActivity : Activity
    {
        //int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += delegate { 
				StartActivity(typeof(TelaPrincialActivity));
			};

			Button btAlert = FindViewById<Button>(Resource.Id.btAlert);

			btAlert.Click += delegate {
				AlertCenter.Default.Init (Application);
				AlertCenter.Default.PostMessage ("  Desenvolvido por:", "  Sisaut Tecnologia", Resource.Drawable.sisaut);
				//AlertCenter.Default.PostMessage ("Interrupting cow.", "Interrupting cow who?", Resource.Drawable.Icon, () => {
				//		Console.WriteLine ("Moo!");
				//	});
			};
        }
    }
}

