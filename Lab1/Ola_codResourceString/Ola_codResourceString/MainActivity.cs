using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace Ola_codResourceString
{
	[Activity (Label = "Ola_codResourceString", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			//Cria a Interface do usuario com o codigo
			var layout = new LinearLayout(this);
			layout.Orientation = Orientation.Vertical;

			var aLabel = new TextView (this);
			aLabel.SetText(Resource.String.helloLabelText);

			var aButton = new Button (this);
			aButton.SetText(Resource.String.helloButtonText);
			aButton.Click += (sender, e) => 
			{
				aLabel.Text = "Voce CLicou nesse Botao";
			};


			layout.AddView (aLabel);
			layout.AddView (aButton);

			SetContentView (layout);


		}
	}
}



