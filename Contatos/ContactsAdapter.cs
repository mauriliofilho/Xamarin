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

using Android.Provider;
using Android.Database;


namespace Contatos
{
    class ContactsAdapter : BaseAdapter<Contact>
    {
        // Criando uma activity
        Activity activity;

        // Criando um array com os objetos da classe Contact
        List<Contact> contactList;

        // Método contrutor da Classe (O comando que é executado quando a classe é instanciada)
        public ContactsAdapter(Activity activity)
        {
            this.activity = activity;
            FillContacts();
        }

        // Função que retorna o número de contatos 
        // Override: Reescreve
        public override int Count
        {
            get
            {
                int count = contactList.Count;
                return count == 0 ? 1 : count;
            }
        }

        // Função para reescrever a classe contact, retornando o contato da posição
        public override Contact this[int position]
        {
            get { return contactList[position]; }
        }

        // Função para retornar o Id do item na posição indicada
        public override long GetItemId(int position)
        {
            return contactList.Count == 0 ? 0 : contactList[position].Id;
        }


        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(Android.Resource.Layout.ActivityListItem, null);
            var contactName = view.FindViewById<TextView>(Android.Resource.Id.Text1);
            var contactImage = view.FindViewById<ImageView>(Android.Resource.Id.Icon);

            if (contactList.Count == 0)
            {
                contactName.Text = "Nenhum contato encontrado";
            }
            else
            {
                contactName.Text = contactList[position].DisplayName;
                if (contactList[position].PhotoId == null)
                {
                    contactImage.SetImageResource(Resource.Drawable.Icon);
                }
                else
                {
                    var contactUri = ContentUris.WithAppendedId(ContactsContract.Contacts.ContentUri, contactList[position].Id);
                    var contactPhotoUri = Android.Net.Uri.WithAppendedPath(contactUri, Contacts.Photos.ContentDirectory);
                    contactImage.SetImageURI(contactPhotoUri);
                }
            }

            return view;
        }

        void FillContacts()
        {
            var uri = ContactsContract.Contacts.ContentUri;
            string[] projection = {
				ContactsContract.Contacts.InterfaceConsts.Id,
				ContactsContract.Contacts.InterfaceConsts.DisplayName,
				ContactsContract.Contacts.InterfaceConsts.PhotoId
			};

            var loader = new CursorLoader(activity, uri, projection, null, null, null);
            using (var cursor = (ICursor)loader.LoadInBackground())
            {
                contactList = new List<Contact>();
                if (cursor.MoveToFirst())
                {
                    do
                    {
                        contactList.Add(new Contact
                        {
                            Id = cursor.GetLong(cursor.GetColumnIndex(projection[0])),
                            DisplayName = cursor.GetString(cursor.GetColumnIndex(projection[1])),
                            PhotoId = cursor.GetString(cursor.GetColumnIndex(projection[2]))
                        });
                    }
                    while (cursor.MoveToNext());
                }
            }
        }

    }
}