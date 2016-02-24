using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Rolodex
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            RolodexUi rolodexUi = new RolodexUi();
            List<Contact> contacts = new List<Contact>();

            while (true)
            {
                rolodexUi.ShowMenu();
                string c = rolodexUi.GetUserMenuInput();
                MakeMenuChoice(c, contacts);
            }
        }

        static List<Contact> MakeMenuChoice(string character, List<Contact> contacts)
        {
            switch (character.ToUpper())
            {
                case "1":
                    // display all contacts
                    RolodexUi display = new RolodexUi();
                    display.DisplayAllContacts(contacts);
                    break;
                case "2":
                    // add a contact
                    RolodexUi newcontact = new RolodexUi();
                    newcontact.AddContact(contacts);
                    break;
                case "3":
                    // edit a contact
                    RolodexUi contacttoedit = new RolodexUi();
                    contacttoedit.UpdateContact(contacts);
                    break;
                case "4":
                    // delete a contact
                    RolodexUi contacttodelete = new RolodexUi();
                    contacttodelete.RemoveContact(contacts);
                    break;
                case "Q":
                    System.Environment.Exit(0);
                    break;
            }
            return contacts;
        }
    }
}
