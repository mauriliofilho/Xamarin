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

namespace Endereco.Classes
{
    public class Usuario
    {
        public Usuario ()
        { 
            
        }

        public int ID { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
    }
}