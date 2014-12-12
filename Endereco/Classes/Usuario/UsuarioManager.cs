using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Endereco.Classes
{
    class UsuarioManager
    {
        public static int SavarUsuario(Usuario item)
        {
            return Classes.UsuarioDatabase.Salvar(item);
        }

        public static int DeletarUsuario(int id)
        {
            return Classes.UsuarioDatabase.Deletar(id);
        }

        public static bool ValidarUsuario(string dsNome, string dsSenha)
        {
            return Classes.UsuarioDatabase.Validar(dsNome, dsSenha);
        }

		public static IList<Classes.Usuario> GetUsuarios ()
		{
			return new List<Classes.Usuario>(UsuarioRepository.GetUsuarios());
		}
    }
}