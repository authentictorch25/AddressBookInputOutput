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
                string addressbookName = "";
                Console.WriteLine("\nEnter:\n1-To add a new address Book\n2-To access an existing address book\n3-To exit");
                int option = Convert.ToInt32(Console.ReadLine());
                switch(option)
                {
                    case 1:
                        adressBook.AddAdressBook();
                        break;
                    case 2:
                        addressbookName = adressBook.ExistingAddressBook();
                        break;
                    case 3:
                        flag = false;
                        break;
                }
                if(addressbookName!="")
                {
                    bool flag1 = true;
                    while(flag1)
                    {
                        Console.WriteLine("Address book:" + addressbookName);
                        Console.WriteLine("Enter:\n1-To add a new contact\n2-To edit an existing contact\n3-To view an existing contact\n4-To delete a contact\n5-To return to main menu");
                        int choice = Convert.ToInt32(Console.ReadLine());
                       
                        switch(choice)
                        {
                            //Adding the contact to the list
                            case 1:
                                AdressBook.addressBook[addressbookName].AddContact();
                                break;
                            //Editing the contact into the list
                            case 2:
                                AdressBook.addressBook[addressbookName].EditContact();
                                break;
                            //Viewing the contact of the list
                            case 3:
                                AdressBook.addressBook[addressbookName].ViewContact();
                                break;
                            //Removing the contact from the list
                            case 4:
                                AdressBook.addressBook[addressbookName].DeleteContact();
                                break;
                            //Exiting the portal
                            case 5:
                                flag1 = false;
                                break;
                        }
                    }
                }
            }
        }
    }
}
