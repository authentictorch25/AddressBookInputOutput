using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AddressBookProgram
{
    class FileIOStream
    {
        /// <summary>
        /// UC 13 : Reads the file present at the path and displays details in console.
        /// </summary>
        public static void ReadFilestream()
        {
            string path = @"C:\Users\akash\OneDrive\Desktop\Standard Input and output\AddressBookProgram\ContactList.txt";
            if (File.Exists(path))
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string line = "";
                    while ((line = sr.ReadLine()) != null)
                        Console.WriteLine(line); ;
                }
            }
            else
                Console.WriteLine("File not found");
        }

        /// <summary>
        /// UC 13 : Writes into the file present at the path the details of the passed address book.
        /// </summary>
        /// <param name="addressBook">The address book.</param>
        public static void WriteFileStream(AddressBookMain addressBook)
        {
            string path = @"C:\Users\akash\OneDrive\Desktop\Standard Input and output\AddressBookProgram\ContactList.txt";
            if (File.Exists(path))
            {
                using (StreamWriter sr = File.AppendText(path))
                {
                    /// Writes the entered string into the file
                    sr.Write("\nCONTACT DETAILS IN ADDRESSBOOK: {0}=>\n", addressBook.addressBookName);
                    for (int i = 0; i < addressBook.contactlist.Count; i++)
                    {
                        string line = "\n" + (i + 1) + ".\tFullName: " + addressBook.contactlist[i].firstName + " " + addressBook.contactlist[i].lastName + "\n\tAddress: " + addressBook.contactlist[i].address + "\n\tCity: " + addressBook.contactlist[i].city + "\n\tState: " + addressBook.contactlist[i].state + "\n\tZip: " + addressBook.contactlist[i].zip + "\n\tPhoneNumber: " + addressBook.contactlist[i].phoneNumber + "\n\tEmail: " + addressBook.contactlist[i].email + "\n";
                        sr.Write(line);
                    }
                }
            }
            ReadFilestream();
        }
    }
}
