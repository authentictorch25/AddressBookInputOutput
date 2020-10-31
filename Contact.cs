using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBookProgram
{
    public class Contact
    {
        //Added the contact details
        public string firstName;
        public string lastName;
        public string address;
        public string city;
        public string state;
        public double zip;
        public double phoneNumber;
        public string email;
        /// <summary>
        /// Initializes a new instance of the <see cref="Contact"/> class.
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="address">The address.</param>
        /// <param name="city">The city.</param>
        /// <param name="state">The state.</param>
        /// <param name="zip">The zip.</param>
        /// <param name="phoneNumber">The phone number.</param>
        /// <param name="email">The email.</param>
        public Contact(string firstName, string lastName, string address,  string city, string state, double zip, double phoneNumber, string email)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.phoneNumber = phoneNumber;
            this.email = email;
        } 
    }
}
