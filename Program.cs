using System;

namespace AddressBookProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            AdressBook adressBook = new AdressBook();
            Console.WriteLine("Welcome to Address Book Program");


            bool flag = true;
            while (flag)
            {
                string currentAddressBookName = "";
                Console.WriteLine("\nEnter:\n1-To add a new address Book\n2-To access an existing address book" +
                    "\n3-To search person in a state or city across multiple address books\n4-View all persons of a city or state" +
                    "\n5-To get count of contacts present at a city or state\n6-To exit");
                int options1 = Convert.ToInt32(Console.ReadLine());
                switch (options1)
                {
                    case 1:
                        adressBook.AddAdressBook();
                        break;
                    case 2:
                        currentAddressBookName = adressBook.ExistingAddressBook();
                        break;
                    case 3:
                        adressBook.SearchPersonByCityOrState();
                        break;
                    case 4:
                        AddressBookMain.ViewPeopleByCityOrState();
                        break;
                    case 5:
                        AddressBookMain.GetCountByCityOrState();
                        break;
                    case 6:
                        flag = false;
                        break;
                }
                if (currentAddressBookName != "")
                {
                    bool flag2 = true;
                    while (flag2)
                    {
                        Console.WriteLine("\nCurrent address book:" + currentAddressBookName);
                        Console.WriteLine("Enter:\n1-To add a new contact\n2-To edit an existing contact\n3-To search for an existing contact\n4-To delete a contact\n5-To display all contacts in the address book sorted by Name\n6-To display contacts sorted by city,state or zip\n7-write into file\n8-To return to main menu");
                        int options2 = Convert.ToInt32(Console.ReadLine());
                        switch (options2)
                        {
                            case 1:
                                AdressBook.addressBook[currentAddressBookName].AddContact();
                                break;
                            case 2:
                                AdressBook.addressBook[currentAddressBookName].EditContact();
                                break;
                            case 3:
                                AdressBook.addressBook[currentAddressBookName].SearchByName();
                                break;
                            case 4:
                                AdressBook.addressBook[currentAddressBookName].DeleteContact();
                                break;
                            case 5:
                                AdressBook.addressBook[currentAddressBookName].SortByName();
                                break;
                            case 6:
                                AdressBook.addressBook[currentAddressBookName].SortByCityStateOrZip();
                                break;
                            case 7:
                                FileIOStream.WriteFileStream(AdressBook.addressBook[currentAddressBookName]);
                                break;
                            case 8:
                                flag = false;
                                break;
                        }
                    }
                }
            }
        }
    }   
}
