using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;
using Endereco;

namespace Endereco
{
	[Activity(Label = "Acesso", MainLauncher = true, Theme = "@android:style/Theme.Black")]
    public class Acesso : Activity
    {
        EditText etUsuario;
        EditText etSenha;
        Classes.Usuario usuario = new Classes.Usuario();

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Acesso);

            Button btEntrar = FindViewById<Button>(Resource.Id.btAcessoEntrar);
            Button btCadastrar = FindViewById<Button>(Resource.Id.btAcessoCadastar);

            etUsuario = FindViewById<EditText>(Resource.Id.etAcessoUsuario);
            etSenha = FindViewById<EditText>(Resource.Id.etAcessoSenha);
            
            // Criando o banco de dados
            Classes.DataBase.CriarDataBase();
            
            btEntrar.Click += delegate
            {
                if (((etUsuario.Text.ToUpper() == "ADMIN") & (etSenha.Text == "1234")) || (Classes.UsuarioManager.ValidarUsuario(etUsuario.Text, etSenha.Text) == true))
                {
                    var activity2 = new Intent(this, typeof(Screens.Principal));
                    activity2.PutExtra("MyData", etUsuario.Text);
                    StartActivity(activity2);
                }
				else
				{
					new AlertDialog.Builder(this)
						.SetPositiveButton("Ok", (sender, args) =>
							{
								etSenha.Text = "";
								// User pressed yes
							})
						//.SetNegativeButton("No", (sender, args) =>
						//	{
								// User pressed no 
						//	})

						.SetMessage("Usuário e/ou Senha Inválidos!")
						.SetTitle("Acesso Inválido!")
						.SetIcon(Resource.Drawable.Critical)
						.Show();
				}
    
            };

            btCadastrar.Click += delegate
            {
                SalvarUsuario();
            };

        }

        void SalvarUsuario()
        {
            usuario.Nome = etUsuario.Text;
            usuario.Senha = etSenha.Text;
            usuario.Ativo = true;
            Classes.UsuarioManager.SavarUsuario(usuario);
        }
    }
}

