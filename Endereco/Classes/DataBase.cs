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
using System.IO;

namespace Endereco.Classes
{
    class DataBase
    {
        public static string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Endereco.db3");

        public static SqliteConnection connection;
        // Criação do BD
        public static void CriarDataBase()
        {
            
            // Criando as tabelas
            bool exists = File.Exists(dbPath);

            if (!exists)
            {
                connection = new SqliteConnection("Data Source=" + dbPath);

                connection.Open();
                var commands = new[] {
					"CREATE TABLE [tbUsuario] (idUsuario INTEGER PRIMARY KEY ASC, dsNome NTEXT, dsSenha NTEXT, nuAtivo INTEGER);"
				};
                foreach (var command in commands)
                {
                    using (var c = connection.CreateCommand())
                    {
                        c.CommandText = command;
                        var i = c.ExecuteNonQuery();
                    }
                }
            }
            else
            {
                // se já existe as tabelas, não faz nada
            }
        }
    }
}