
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

namespace Endereco
{
	[Activity (Label = "Usuario")]			
	public class Usuario : Activity
	{
		//UsuarioListAdapter UsuariosList;
		IList<Classes.Usuario> usuarios;
		ListView lvUsuarios;
		UsuarioListAdapter UsuariosList;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			lvUsuarios = FindViewById<ListView> (Resource.Id.lvUsuarioExibir);

			SetContentView(Resource.Layout.Usuario);

		}

		protected override void OnResume ()
		{
			base.OnResume ();
			usuarios = Classes.UsuarioManager.GetUsuarios();

			UsuariosList = new UsuarioListAdapter(this, usuarios);

			lvUsuarios.Adapter = UsuariosList;


		}
	}
}

