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
        /// <summary>
        /// UC 8 : SEARCHES FOR THE PERSON IN A PARTICULAR STATE OR CITY ACROSS ALL ADDRESS BOOKS AND DISPLAYS THE DETAILS
        /// </summary>
        public void SearchPersonByCityOrState()
        {
            AddressBookMain adressBook = new AddressBookMain();
            Console.WriteLine("Enter either a city or state name below to search for people:");
            string cityOrStateName = Console.ReadLine().ToUpper();
            Console.WriteLine("Enter first name of the person you are searching");
            string firstName = Console.ReadLine().ToUpper();
            Console.WriteLine("Enter last name");
            string lastName = Console.ReadLine().ToUpper();
            if (addressBook.Count != 0)
            {
                bool flag = false;
                foreach (var kvp in addressBook)
                {
                    for (int i = 0; i < kvp.Value.contactlist.Count; i++)
                    {
                        if (kvp.Value.contactlist[i].city == cityOrStateName || kvp.Value.contactlist[i].state == cityOrStateName)
                        {
                            if (kvp.Value.contactlist[i].firstName == firstName && kvp.Value.contactlist[i].lastName == lastName)
                            {
                                /// IF BOTH NAME AND CITY/STATE OF A CONTACT ACROSS ANY ADDRESS BOOK MATCHES THE ENTERED DETAILS
                                Console.WriteLine("\nContact found inside address book: " + kvp.Key);
                                Console.WriteLine("FullName: " + kvp.Value.contactlist[i].firstName + " " + kvp.Value.contactlist[i].lastName + "\nAddress: " + kvp.Value.contactlist[i].address + "\nCity: " + kvp.Value.contactlist[i].city + "\nState: " + kvp.Value.contactlist[i].state + "\nZip: " + kvp.Value.contactlist[i].zip + "\nPhoneNumber: " + kvp.Value.contactlist[i].phoneNumber + "\nEmail: " + kvp.Value.contactlist[i].email + "\n");
                                flag = true;
                                break;
                            }
                        }
                    }
                }
                /// IF flag VALUE DOES NOT CHANGE MEANS NO MATCH FOR THE ENTERED DETAILS WAS FOUND
                if (flag == false)
                    Console.WriteLine("\nNo such contact found");
            }
            else
                Console.WriteLine("\nNo stored address book found, please add one");
        }
    }
}
