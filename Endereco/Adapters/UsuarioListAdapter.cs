using System;
using System.Collections.Generic;
using Android.App;
using Android.Widget;
using System.Data;
using Android.Content;

namespace Endereco
{
	public class UsuarioListAdapter : BaseAdapter<Classes.Usuario>
	{
		Activity context = null;
		IList<Classes.Usuario> usuarios = new List<Classes.Usuario>();

		public UsuarioListAdapter (Activity context, IList<Classes.Usuario> usuarios) : base ()
		{
			this.context = context;
			this.usuarios = usuarios;
		}

		public override Classes.Usuario this[int position]
		{
			get { return usuarios[position]; }
		}

		public override long GetItemId (int position)
		{
			return position;
		}

		public override int Count
		{
			get { return usuarios.Count; }
		}

		public override Android.Views.View GetView (int position, Android.Views.View convertView, Android.Views.ViewGroup parent)
		{
			var item = usuarios[position];			

			var view = (convertView ?? 
				context.LayoutInflater.Inflate(
					Resource.Layout.Usuario, 
					parent, 
					false)) as LinearLayout;

			var etID = view.FindViewById<TextView>(Resource.Id.etUsuarioID);
			var etNome = view.FindViewById<TextView>(Resource.Id.etUsuarioNome);

			etID.SetText (item.ID, TextView.BufferType.Normal);
			etNome.SetText (item.Nome, TextView.BufferType.Normal);

			return view;
		}
			
	}
}

