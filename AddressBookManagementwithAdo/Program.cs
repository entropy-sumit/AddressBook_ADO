using System;

namespace AddressBookManagementwithAdo
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("welcome to address book");
            

            AddressRepo repo = new AddressRepo();
            //UC1
            repo.DataBaseConnection();




        }
    }
}
