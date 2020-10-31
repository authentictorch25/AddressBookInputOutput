using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Http.Headers;
using System.Text;

namespace AddressBookProgram
{
    class AddressBookMain
    {
        //List Collects data of individual contact
        public List<Contact> contactlist = new List<Contact>();

        string addressBookName;
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

            contactlist.Add(new Contact(firstName, lastName, address, city, state, zip, phoneNumber, email));
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
    }
}
