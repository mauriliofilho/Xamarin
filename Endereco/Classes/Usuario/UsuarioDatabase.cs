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

using Mono.Data.Sqlite;
using System.Data;
using System.IO;

namespace Endereco.Classes
{
    class UsuarioDatabase
    {
        static object locker = new object();
        public static SqliteConnection connection;

        public static int Salvar(Usuario item)
        {
            int r;
            lock (locker)
            {
                if (item.ID != 0)
                {
                    connection = new SqliteConnection("Data Source=" + Classes.DataBase.dbPath);
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "UPDATE [tbUsuario] SET [dsName] = ?, [dsSenha] = ?, [nuAtivo] = ? WHERE [idUsuario] = ?;";
                        command.Parameters.Add(new SqliteParameter(DbType.String) { Value = item.Nome });
                        command.Parameters.Add(new SqliteParameter(DbType.String) { Value = item.Senha });
                        command.Parameters.Add(new SqliteParameter(DbType.Int32) { Value = item.Ativo });
                        command.Parameters.Add(new SqliteParameter(DbType.Int32) { Value = item.ID });
                        r = command.ExecuteNonQuery();
                    }
                    connection.Close();
                    return r;
                }
                else
                {
                    connection = new SqliteConnection("Data Source=" + Classes.DataBase.dbPath);
                    connection.Open();
                    using (var command = connection.CreateCommand())
                    {
                        command.CommandText = "INSERT INTO [tbUsuario] ([dsNome], [dsSenha], [nuAtivo]) VALUES (? ,?, ?)";
                        command.Parameters.Add(new SqliteParameter(DbType.String) { Value = item.Nome });
                        command.Parameters.Add(new SqliteParameter(DbType.String) { Value = item.Senha });
                        command.Parameters.Add(new SqliteParameter(DbType.Boolean) { Value = item.Ativo });
                        r = command.ExecuteNonQuery();
                    }
                    connection.Close();
                    
                    return r;
                }

            }
        }

        public static int Deletar(int id)
        {
            lock (locker)
            {
                int r;
                connection = new SqliteConnection("Data Source=" + Classes.DataBase.dbPath);
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM [tbUsuario] WHERE [idUsuario] = ?;";
                    command.Parameters.Add(new SqliteParameter(DbType.Int32) { Value = id });
                    r = command.ExecuteNonQuery();
                }
                connection.Close();
                return r;
            }
        }

        public static bool Validar(string dsUsuario, string dsSenha)
        {
            bool valido = false;
            string senha = "";

            connection = new SqliteConnection("Data Source=" + Classes.DataBase.dbPath);
            connection.Open();
            using (var contents = connection.CreateCommand())
            {
                contents.CommandText = "SELECT dsSenha FROM [tbUsuario] WHERE dsNome = '" + dsUsuario.Trim() +"'";
                var i = contents.ExecuteScalar();
                senha = Convert.ToString(i);
            }
            connection.Close();

            if (dsSenha == senha)
            { valido = true; }

            return valido;
        }

		Classes.Usuario FromReader (SqliteDataReader r) {
			var t = new Classes.Usuario ();
			t.ID = Convert.ToInt32 (r ["idUsuario"]);
			t.Nome = r ["dsNome"].ToString ();
			t.Senha = r ["dsSenha"].ToString ();
			t.Ativo = Convert.ToInt32 (r ["nuAtivo"]) == 1 ? true : false;
			return t;
		}

		public IEnumerable<Classes.Usuario> GetItems ()
		{
			var tl = new List<Classes.Usuario> ();

			lock (locker) {
				connection = new SqliteConnection ("Data Source=" + Classes.DataBase.dbPath);
				connection.Open ();
				using (var contents = connection.CreateCommand ()) {
					contents.CommandText = "SELECT [idUsuario], [dsNome], [dsSenha], [nuAtivo] from [tbUsuario]";
					var r = contents.ExecuteReader ();
					while (r.Read ()) {
						tl.Add (FromReader(r));
					}
				}
				connection.Close ();
			}
			return tl;
		}
    }
}