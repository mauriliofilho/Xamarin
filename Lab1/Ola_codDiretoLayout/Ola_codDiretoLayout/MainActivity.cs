using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Ola_codDiretoLayout
{
	[Activity (Label = "Ola_codDiretoLayout", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			//Cria a Interface do usuario com o codigo
			var layout = new LinearLayout(this);
			layout.Orientation = Orientation.Vertical;

			var aLabel = new TextView (this);
			aLabel.Text = "Olá Xamarin.Android";

			var aButton = new Button (this);
			aButton.Text = "Diga Ola";
			aButton.Click += (sender, e) => 
			{
				aLabel.Text = "Voce CLicou nesse Botao";
			};


			layout.AddView (aLabel);
			layout.AddView (aButton);

			SetContentView (layout);



			// Set our view from the "main" layout resource
			//SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			//Button button = FindViewById<Button> (Resource.Id.myButton);
			
			//button.Click += delegate {
			//	button.Text = string.Format ("{0} clicks!", count+=10);
		}
	}
}


