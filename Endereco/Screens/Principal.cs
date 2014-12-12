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

namespace Endereco.Screens
{
    [Activity(Label = "Tela Principal", Theme = "@android:style/Theme.Black")]
    public class Principal : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Principal);

            TextView etUsuario = FindViewById<TextView>(Resource.Id.tvPrincipalUsuario);
            etUsuario.Text = "Usuário Logado: " + Intent.GetStringExtra("MyData") ?? "Não informado";

            Button btCadastrarEndereco = FindViewById<Button>(Resource.Id.btPrincipalCadEndereco);
            Button btConsultarEndereco = FindViewById<Button>(Resource.Id.btPrincipalConsEndereco);
            Button btConsultarUsuarios = FindViewById<Button>(Resource.Id.btPrincipalConsUsuario);
            Button btSair = FindViewById<Button>(Resource.Id.btPrincipalSair);

            btSair.Click += delegate
            {
                Finish();
            };

			btConsultarUsuarios.Click += delegate 
			{
				StartActivity(typeof(Usuario));
			};
        }
    }
}