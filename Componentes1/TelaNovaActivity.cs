
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

namespace Componentes1
{
	[Activity (Label = "TelaNovaActivity", Theme = "@android:style/Theme.NoTitleBar")]			
	public class TelaNovaActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView(Resource.Layout.TelaNova);

			TextView txtInfo = FindViewById<TextView> (Resource.Id.txtInfoNovaTela);
			txtInfo.Text = Intent.GetStringExtra ("MyData") ?? "Texto não informado";
		}
	}
}

