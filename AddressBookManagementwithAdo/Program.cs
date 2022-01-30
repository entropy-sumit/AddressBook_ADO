using System;

namespace AddressBookManagementwithAdo
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("welcome to address book");
            AddressBookModel addressBookModel = new AddressBookModel();
            addressBookModel.FirstName = "ShayamalDas";
            addressBookModel.LastName = "chanchal";
            addressBookModel.PhoneNumber = "98989789";
            addressBookModel.Address = "Street C Model";
            addressBookModel.City = "Gorakhpur";
            addressBookModel.State = "Maharastra";
            addressBookModel.ZipCode = "8787";
            addressBookModel.Email = "hi.hello@outlook.com";
            AddressRepo repo = new AddressRepo();
            //UC1
            //repo.DataBaseConnection();

            //UC2
            //repo.GetAllContact();

            //uc3
            //repo.AddDataToTable(addressBookModel);

            //uc4
            //Console.WriteLine(repo.EditContactUsingName("442207", "ShayamalDas", "chanchal") ? "Update Record successfully\n" : "Update failed");

            //uc5
            Console.WriteLine(repo.DeleteContactUsingName("ShayamalDas", "chanchal") ? "Record Deleted successfully\n" : "Delete failed");






        }
    }
}
