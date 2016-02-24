using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rolodex
{
    public class RolodexUi
    {
        public void ShowMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("***** Rolodex Menu *******");
            Console.WriteLine("*                        *");
            Console.WriteLine("*   1. Display Contacts  *");
            Console.WriteLine("*   2. Add Contact       *");
            Console.WriteLine("*   3. Edit Contact      *");
            Console.WriteLine("*   4. Delete Contact    *");
            Console.WriteLine("*                        *");
            Console.WriteLine("*   (press q to quit)    *");
            Console.WriteLine("*                        *");
            Console.WriteLine("**************************");
            Console.WriteLine();
            Console.Write("Enter your selection: ");
        }

        public void DisplayAllContacts(List<Contact> contacts)
        {
            Console.Clear();
            Console.WriteLine("************ Contact List ***********");
            if (contacts.Count == 0)
            {
                NoContacts();
            }
            else
            {
                Console.WriteLine();
                foreach (var item in contacts)
                {
                    Console.Write("Name: " + item.FirstName + " " + item.LastName + "   ");
                    Console.WriteLine("Phone: " + item.Phone);
                }
                Console.WriteLine();
                Console.WriteLine("Number of contacts: " + contacts.Count);
                Console.WriteLine();
            }
            PauseForUser();
        }

        public List<Contact> AddContact(List<Contact> contacts)
        {
            Console.Clear();
            Console.WriteLine("******* Add a new contact ********");
            Console.WriteLine();
            string newfirstname = GetFirstName();
            string newlastname = GetLastName();
            string newphone = GetPhone();
            Console.WriteLine();

            bool prompt = false;
            string newcontact = "";
            while (prompt == false)
            {
                Console.Write("Add new contact (y/n)? ");
                newcontact = Console.ReadLine();
                if (newcontact.ToUpper() == "Y" || newcontact.ToUpper() == "YES"
                    || newcontact.ToUpper() == "N" || newcontact.ToUpper() == "NO")
                {
                    prompt = true;
                }
            }
            if (newcontact.ToUpper() == "Y" || newcontact.ToUpper() == "YES")
            {
                Contact contact = new Contact
                {
                    FirstName = newfirstname,
                    LastName = newlastname,
                    Phone = newphone
                };
                contacts.Add(contact);
                Console.WriteLine();
                Console.Write("A new contact has been added. ");
            }
            else
            {
                Console.WriteLine();
                Console.Write("Request cancelled. ");
            }
            PauseForUser();

            return contacts;
        }

        public void RemoveContact(List<Contact> contacts)
        {
            Console.Clear();
            Console.WriteLine("******** Delete a contact ********");
            Console.WriteLine();
            if (contacts.Count == 0)
            {
                NoContacts();
            }
            else
            {
                for (int i = 0; i < contacts.Count; i++)
                {
                    Console.Write((i + 1) + ". ");
                    Console.Write("Name: ");
                    Console.Write(contacts[i].FirstName + " ");
                    Console.Write(contacts[i].LastName + "    ");
                    Console.WriteLine("Phone: " + contacts[i].Phone);
                }
                Console.WriteLine();
                string numbertodelete;

                do
                {
                    Console.Write("Enter number of contact to delete(ENTER to cancel): ");
                    numbertodelete = Console.ReadLine();
                    if (numbertodelete == "")
                        break;

                    int test;
                    bool parsedinput = int.TryParse(numbertodelete, out test);
                    if (parsedinput)
                    {
                        break;
                    }
                } while (true);

                if (numbertodelete == "")
                {
                    Console.WriteLine();
                    Console.WriteLine("Request cancelled.");
                }
                else
                {
                    int num = int.Parse(numbertodelete);
                    if (num >= 1 && num <= contacts.Count)
                    {
                        Console.Clear();
                        Console.WriteLine("******** Delete a contact ********");
                        Console.WriteLine();
                        Console.Write(contacts[num - 1].FirstName + " " + contacts[num - 1].LastName);
                        Console.WriteLine("  " + "Phone: " + contacts[num - 1].Phone);
                        Console.WriteLine();

                        bool prompt = false;
                        string removecontact = "";
                        while (prompt == false)
                        {
                            Console.Write("Are you sure you want to delete this contact(y/n)? ");
                            removecontact = Console.ReadLine();
                            if (removecontact.ToUpper() == "Y" || removecontact.ToUpper() == "YES"
                                || removecontact.ToUpper() == "N" || removecontact.ToUpper() == "NO")
                            {
                                prompt = true;
                            }
                        }

                        Console.WriteLine();
                        if (removecontact.ToUpper() == "Y" || removecontact.ToUpper() == "YES")
                        {
                            contacts.RemoveAt(num - 1);
                            Console.WriteLine("The contact has been deleted.");
                        }
                        else
                        {
                            Console.WriteLine("Request cancelled.");
                        }
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Sorry, that contact number is not valid.");
                    }
                }
            }
            PauseForUser();
        }

        public void UpdateContact(List<Contact> contacts)
        {
            Console.Clear();
            Console.WriteLine("******** Edit a contact ********");
            Console.WriteLine();
            if (contacts.Count == 0)
            {
                NoContacts();
            }
            else
            {
                for (int i = 0; i < contacts.Count; i++)
                {
                    Console.Write((i + 1) + ". ");
                    Console.Write("Name: ");
                    Console.Write(contacts[i].FirstName + " ");
                    Console.Write(contacts[i].LastName + "    ");
                    Console.WriteLine("Phone: " + contacts[i].Phone);
                }
                Console.WriteLine();
                string numbertoedit;

                do
                {
                    Console.Write("Enter number of contact to edit(ENTER to cancel): ");
                    numbertoedit = Console.ReadLine();
                    if (numbertoedit == "")
                        break;

                    int test;
                    bool parsedinput = int.TryParse(numbertoedit, out test);
                    if (parsedinput)
                    {
                        break;
                    }
                } while (true);

                if (numbertoedit == "")
                {
                    Console.WriteLine();
                    Console.WriteLine("Request cancelled.");
                }
                else
                {
                    int num = int.Parse(numbertoedit);
                    if (num >= 1 && num <= contacts.Count)
                    {
                        Console.Clear();
                        Console.WriteLine("******** Edit a contact ********");
                        Console.WriteLine();
                        Console.Write(contacts[num - 1].FirstName + " " + contacts[num - 1].LastName);
                        Console.WriteLine("  " + "Phone: " + contacts[num - 1].Phone);
                        Console.WriteLine();
                        string newfirstname = GetUpdatedFirstName();
                        Console.WriteLine();
                        string newlastname = GetUpdatedLastName();
                        Console.WriteLine();
                        string newphone = GetUpdatedPhone();
                        Console.WriteLine();

                        bool prompt = false;
                        string editcontact = "";
                        while (prompt == false)
                        {
                            Console.Write("Update this contact (y/n)? ");
                            editcontact = Console.ReadLine();
                            if (editcontact.ToUpper() == "Y" || editcontact.ToUpper() == "YES"
                                || editcontact.ToUpper() == "N" || editcontact.ToUpper() == "NO")
                            {
                                prompt = true;
                            }
                        }

                        Console.WriteLine();
                        if (editcontact.ToUpper() == "Y" || editcontact.ToUpper() == "YES")
                        {
                            contacts[num - 1].FirstName = newfirstname;
                            contacts[num - 1].LastName = newlastname;
                            contacts[num - 1].Phone = newphone;
                            Console.WriteLine("The contact has been updated.");
                        }
                        else
                        {
                            Console.WriteLine("Request cancelled.");
                        }
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Sorry, that contact number is not valid.");
                    }
                }
            }
            PauseForUser();
        }

        private string GetFirstName()
        {
            do
            {
                Console.Write("Enter the first name: ");
                string input = Console.ReadLine();
                if (input.Length > 0 && input != "")
                {
                    return input;
                }
            } while (true);

        }

        private string GetLastName()
        {
            do
            {
                Console.Write("Enter the last name: ");
                string input = Console.ReadLine();
                if (input.Length > 0 && input != "")
                {
                    return input;
                }
            } while (true);

        }

        private string GetPhone()
        {
            do
            {
                Console.Write("Enter the phone number: ");
                string input = Console.ReadLine();
                if (input.Length > 0 && input != "")
                {
                    return input;
                }
            } while (true);

        }

        private string GetUpdatedFirstName()
        {
            do
            {
                Console.Write("Enter the new first name: ");
                string input = Console.ReadLine();
                if (input.Length > 0 && input != "")
                {
                    return input;
                }
            } while (true);

        }

        private string GetUpdatedLastName()
        {
            do
            {
                Console.Write("Enter the new last name: ");
                string input = Console.ReadLine();
                if (input.Length > 0 && input != "")
                {
                    return input;
                }
            } while (true);

        }

        private string GetUpdatedPhone()
        {
            do
            {
                Console.Write("Enter the new phone number: ");
                string input = Console.ReadLine();
                if (input.Length > 0 && input != "")
                {
                    return input;
                }
            } while (true);
        }

        private void PauseForUser()
        {
            Console.WriteLine();
            Console.Write("Press any key to return to the main menu... ");
            Console.ReadKey();
        }

        private void NoContacts()
        {
            Console.WriteLine();
            Console.WriteLine("You do not have any contacts.");
        }

        public string GetUserMenuInput()
        {
            return Console.ReadLine();
        }
    }
}