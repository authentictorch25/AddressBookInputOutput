using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.XPath;

namespace AddressBookProgram
{
    class AdressBook
    {
        public static Dictionary<string, AddressBookMain> addressBook = new Dictionary<string,AddressBookMain>();
        public void AddAdressBook()
        {
            Console.WriteLine("Enter the title of the address book");
            string addressBookName = Console.ReadLine();
            AddressBookMain ContactDetails = new AddressBookMain(addressBookName);
            addressBook.Add(addressBookName, ContactDetails);
            Console.WriteLine("\nAddress Book " + addressBookName + " added successfully");
            Console.WriteLine("Updated Address Book List:");
            foreach (var kvp in addressBook)
            {
                Console.WriteLine("Key: {0}, Value: {1}", kvp.Key);
            }
        }

        public string ExistingAddressBook()
        {
            Console.WriteLine("Enter the name of the address book");
            string name = Console.ReadLine();
            bool flag = true;
            string result = "";
            foreach(var kvp in addressBook)
            {
                if(name == kvp.Key)
                    Console.WriteLine("Adress Book "+ name+" exists" );
                result = name;
                flag = false;
                break;
            }
            if(flag == true)
            {
                Console.WriteLine("No such address Book exists");
            }
            return result;
        }
    }
}
