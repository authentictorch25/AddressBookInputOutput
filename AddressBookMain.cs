using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

namespace AddressBookProgram
{
    class AddressBookMain
    {
        //List Collects data of individual contact
        public List<Contact> contactlist = new List<Contact>();
        /// <summary>
        /// UC 9 : THE DICTIONARY IS MAINTAINED WITH KEY AS CITY/STATE NAME AND VALUE AS A LIST WHICH CONTAINS NAMES OF
        ///        PEOPLE ALONG THE PROPER CITY/STATE NAME,
        ///        static TO STORE VALUES ACROSS ALL ADDRESS BOOKS
        /// </summary>
        public static Dictionary<string, List<string>> cityAndStatePersonDictionary = new Dictionary<string, List<string>>();
        public string addressBookName;
        public AddressBookMain()
        { }
        public AddressBookMain(string addressBookName)
        {
            this.addressBookName = addressBookName;
        }

        /// <summary>
        /// Adds the contact of the user.
        /// </summary>       
        public void AddContact()
        {
            Console.WriteLine("Enter the details of the contact\n");
            Console.WriteLine("Enter the first name");
            string firstName = Console.ReadLine();
            Console.WriteLine("\nEnter the last name");
            string lastName = Console.ReadLine();
            Console.WriteLine("\nEnter the address");
            string address = Console.ReadLine();
            Console.WriteLine("\nEnter the city");
            string city = Console.ReadLine();
            Console.WriteLine("\nEnter the state");
            string state = Console.ReadLine();
            Console.WriteLine("\nEnter the zip");
            double zip = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("\nEnter the Phone Number");
            double phoneNumber = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("\nEnter the email\n");
            string email = Console.ReadLine();

            Contact contact = new Contact(firstName, lastName, address, city, state, zip, phoneNumber, email);
            bool flag = false;
            string fullName = firstName + " " + lastName;
            foreach (var v in contactlist)
            {
                /// CALLING OVERRIDDEN Equals() METHOD WITH EACH OBJECT IN CONTACTLIST AS PARAMETER TO CHECK FOR DUPLICATES
                if (contact.Equals(v))
                {
                    Console.WriteLine("\n A Contact already exists with the entered name, please enter a different name to add new contact");
                    flag = true;
                    break;
                }
            }
            if (flag == false)
            {
                contactlist.Add(contact);
                Console.WriteLine("\nContact " + firstName + " " + lastName + " added successfully");
            }
            AddPersonInStateOrCityDictionary(city, fullName);
            AddPersonInStateOrCityDictionary(state, fullName);
        }
        /// <summary>
        /// Edits the contact.
        /// </summary>
        public void EditContact()
        {
            Console.WriteLine("Enter the name of the contact to be modify");
            string name = Console.ReadLine();
            bool flag = true;
            foreach (var v in contactlist)
            {
                if ((v.firstName + " " + v.lastName).Equals(name))
                {
                    Console.WriteLine("Enter the first name");
                    string firstName = Console.ReadLine();
                    v.firstName = firstName;
                    Console.WriteLine("\nEnter the last name");
                    string lastName = Console.ReadLine();
                    v.lastName = lastName;
                    Console.WriteLine("\nEnter the address");
                    string address = Console.ReadLine();
                    v.address = address;
                    Console.WriteLine("\nEnter the city");
                    string city = Console.ReadLine();
                    v.city = city;
                    Console.WriteLine("\nEnter the state");
                    string state = Console.ReadLine();
                    v.state = state;
                    Console.WriteLine("\nEnter the zip");
                    double zip = Convert.ToDouble(Console.ReadLine());
                    v.zip = zip;
                    Console.WriteLine("\nEnter the Phone Number");
                    double phoneNumber = Convert.ToDouble(Console.ReadLine());
                    v.phoneNumber = phoneNumber;
                    Console.WriteLine("\nEnter the email\n");
                    string email = Console.ReadLine();
                    v.email = email;

                    Console.WriteLine("Details Modified");
                    flag = false;
                    break;
                }
            }
            if (flag == true)
                Console.WriteLine("No such entry");                         
        }
        /// <summary>
        /// Deletes the contact
        /// </summary>
        public void DeleteContact()
        {
            Console.WriteLine("Enter the name of the contact to be modify");
            string name = Console.ReadLine();
            bool flag = true;
            foreach (var v in contactlist)
            {
                if ((v.firstName + " " + v.lastName).Equals(name))
                {
                    contactlist.Remove(v);
                    Console.WriteLine("Contact removed");
                    flag = false;
                    break;
                }
               
            }
            if(flag == true)
            {
                Console.WriteLine("No such Entry");
            }
        }
        /// <summary>
        /// Views the contact in the list.
        /// </summary>
        public void ViewContact()
        {
            foreach(var v in contactlist)
            {
                Console.WriteLine("The Details:\n");
                Console.WriteLine("First Name : " + v.firstName);
                Console.WriteLine("Last Name : " + v.lastName);
                Console.WriteLine("Address : " + v.address);
                Console.WriteLine("City : " + v.city);
                Console.WriteLine("State : " + v.state);
                Console.WriteLine("ZIP : " + v.zip);
                Console.WriteLine("Phone Number : " + v.phoneNumber);
                Console.WriteLine("Email : " + v.email);
            }
        }
        /// <summary>
        /// Searches by Name 
        /// </summary>
        public void SearchByName()
        {
            Console.WriteLine("Enter the name of the contact");
            string name = Console.ReadLine();
            bool flag = true;
            foreach(var v in contactlist)
            {
                if(v.firstName+" "+v.lastName == name)
                {
                    Console.WriteLine("FullName: " + v.firstName + " " + v.lastName + "\nAddress: " + v.address + "\nCity: " + v.city + "\nState: " + v.state + "\nZip: " + v.zip + "\nPhoneNumber: " + v.phoneNumber + "\nEmail: " + v.email + "\n");
                    flag = false;
                    break;
                }
            }
            if (flag == true)
                Console.WriteLine("Contact not found");
        }

        /// <summary>
        /// UC 9 : DISPLAYS NAME OF ALL CONTACTS WHO LIVE IN THE GIVEN STATE OR CITY
        /// </summary>
        public static void ViewPeopleByCityOrState()
        {
            Console.WriteLine("Enter either a city or state name to view contacts:");
            string cityOrStateName = Console.ReadLine().ToUpper();
            foreach (var kvp in cityAndStatePersonDictionary)
            {
                if (kvp.Key == cityOrStateName)
                {
                    foreach (var v in kvp.Value)
                    {
                        Console.WriteLine("Location " + cityOrStateName + ": " + v);
                    }
                    if (kvp.Value.Count == 0)
                        Console.WriteLine("\nNo contact found");
                }
            }
            if (cityAndStatePersonDictionary.Count == 0)
                Console.WriteLine("\nNo contact person found in " + cityOrStateName);
        }

        /// <summary>
        /// UC 9 : ADDS THE NAME OF THE PERSON IN A LIST TO BE UPDATED IN DICTIONARY
        /// </summary>
        /// <param name="cityOrStateName">Name of the city or state.</param>
        /// <param name="fullName">The full name.</param>
        public void AddPersonInStateOrCityDictionary(string cityOrStateName, string fullName)
        {
            if (cityAndStatePersonDictionary.ContainsKey(cityOrStateName))
            {
                cityAndStatePersonDictionary[cityOrStateName].Add(fullName);
            }
            else
            {
                List<string> personNameList = new List<string>();
                personNameList.Add(fullName);
                cityAndStatePersonDictionary.Add(cityOrStateName, personNameList);
            }
        }
        /// <summary>
        /// counting the no. of contacts in given city or state
        /// </summary>
        public static void GetCountByCityOrState()
        {
            Console.WriteLine("Enter either a city or state name to get number of contacts within the location:");
            string cityOrStateName = Console.ReadLine().ToUpper();
            Console.WriteLine("\nNumber of contact persons present at {0}:", cityOrStateName);
            /// CHECKS IF THE DICTIONARY ALREADY CONTAINS THE CITY/STATE
            if (cityAndStatePersonDictionary.ContainsKey(cityOrStateName))
                ///DISPLAYS THE COUNT
                Console.WriteLine(cityAndStatePersonDictionary[cityOrStateName].Count);
            else
                Console.WriteLine(0);
        }
        /// <summary>
        /// UC 11 : Sorts the contactList by names of contact.
        /// </summary>
        public void SortByName()
        {
            if (contactlist.Count == 0)
            {
                Console.WriteLine("\nNo contact found, please add a contact to display");
            }
            /// Sort the list according to condition provided
            var v = contactlist.OrderBy(c => c.firstName + c.lastName);
            foreach (var contact in v)
            {
                Console.WriteLine("\nFullName: " + contact.firstName + " " + contact.lastName + "\nAddress: " + contact.address + "\nCity: " + contact.city + "\nState: " + contact.state + "\nZip: " + contact.zip + "\nPhoneNumber: " + contact.phoneNumber + "\nEmail: " + contact.email + "\n");
            }
        }
        /// <summary>
        /// UC 12 : Sorts the contactList by city, state or zip.
        /// </summary>
        public void SortByCityStateOrZip()
        {
            if (contactlist.Count == 0)
            {
                Console.WriteLine("\nNo contact found, please add a contact to display");
                return;
            }
            Console.WriteLine("Enter:\n1-To sort by city name\n2-To sort by state name\n3-To sort by zip");
            int options = Convert.ToInt32(Console.ReadLine());
            switch (options)
            {
                case 1:
                    var sortedList = contactlist.OrderBy(person => person.city);
                    foreach (var contact in sortedList)
                    {
                        Console.WriteLine("\nCity: " + contact.city + "\nFullName: " + contact.firstName + " " + contact.lastName + "\nAddress: " + contact.address + "\nState: " + contact.state + "\nZip: " + contact.zip + "\nPhoneNumber: " + contact.phoneNumber + "\nEmail: " + contact.email + "\n");
                    }
                    break;
                case 2:
                    sortedList = contactlist.OrderBy(person => person.state);
                    foreach (var contact in sortedList)
                    {
                        Console.WriteLine("\nState: " + contact.state + "\nFullName: " + contact.firstName + " " + contact.lastName + "\nAddress: " + contact.address + "\nCity: " + contact.city + "\nZip: " + contact.zip + "\nPhoneNumber: " + contact.phoneNumber + "\nEmail: " + contact.email + "\n");
                    }
                    break;
                case 3:
                    sortedList = contactlist.OrderBy(person => person.zip);
                    foreach (var contact in sortedList)
                    {
                        Console.WriteLine("\nZip: " + contact.zip + "\nFullName: " + contact.firstName + " " + contact.lastName + "\nAddress: " + contact.address + "\nCity: " + contact.city + "\nState: " + contact.state + "\nPhoneNumber: " + contact.phoneNumber + "\nEmail: " + contact.email + "\n");
                    }
                    break;
            }
        }
    }
}
