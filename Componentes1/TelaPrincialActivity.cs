
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
	[Activity (Label = "TelaPrincialActivity", Theme = "@android:style/Theme.NoTitleBar")]			
	public class TelaPrincialActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView(Resource.Layout.TelaPrincipal);

			EditText txtPassword = FindViewById<EditText> (Resource.Id.txtPassword);
			TextView txtPasswordResult = FindViewById<TextView> (Resource.Id.txtPasswordResult);
	
			RadioButton rbCor1 = FindViewById<RadioButton> (Resource.Id.rbCor1);
			RadioButton rbCor2 = FindViewById<RadioButton> (Resource.Id.rbCor2);
			RadioButton rbCor3 = FindViewById<RadioButton> (Resource.Id.rbCor3);
			TextView txtCorResult = FindViewById<TextView> (Resource.Id.txtCorResult);

			CheckBox chkCarro1 = FindViewById<CheckBox> (Resource.Id.chkCarro1);
			CheckBox chkCarro2 = FindViewById<CheckBox> (Resource.Id.chkCarro2);
			CheckBox chkCarro3 = FindViewById<CheckBox> (Resource.Id.chkCarro3);
			TextView txtCarroResult = FindViewById<TextView> (Resource.Id.txtCarroResult);

			SeekBar sbBrilho = FindViewById<SeekBar> (Resource.Id.sbBilho);
			TextView txtBrilhoResult = FindViewById<TextView> (Resource.Id.txtBilhoResult);

			Button btExibir = FindViewById<Button> (Resource.Id.btExibir);



			btExibir.Click += delegate {

				txtPasswordResult.Text = string.Format("Senha Digitada: {0}", txtPassword.Text);

				if (rbCor1.Checked == true)
					txtCorResult.Text = string.Format("A cor {0} foi selecionada", rbCor1.Text);
				else if (rbCor2.Checked == true)
					txtCorResult.Text = string.Format("A cor {0} foi selecionada", rbCor2.Text);
				else if (rbCor3.Checked == true)
					txtCorResult.Text = string.Format("A cor {0} foi selecionada", rbCor3.Text);

				string carros;
				carros = "";
				if (chkCarro1.Checked == true)
					carros += chkCarro1.Text + ", ";
				if (chkCarro2.Checked == true)
					carros += chkCarro2.Text + ", ";
				if (chkCarro3.Checked == true)
					carros += chkCarro3.Text + ", ";

				txtCarroResult.Text = string.Format("Carro(s) selecionado(s): {0}", carros.Substring(0, carros.Length - 2));

				txtBrilhoResult.Text = string.Format("Nivel de brilho: {0}", sbBrilho.Progress);

			};

			EditText txtAux = FindViewById<EditText> (Resource.Id.txtAux);

			// setando foco
			//txtAux.Focusable = true;
			//txtAux.RequestFocus (FocusSearchDirection.Up);

			Button btCarregar = FindViewById<Button> (Resource.Id.btCarregar);

			btCarregar.Click += delegate {
				var activity2 = new Intent(this, typeof(TelaNovaActivity));
				activity2.PutExtra("MyData", txtAux.Text);
				StartActivity(activity2);
			};
				
		}

		protected override void OnStart ()
		{
			base.OnStart ();

		}
	}
}

