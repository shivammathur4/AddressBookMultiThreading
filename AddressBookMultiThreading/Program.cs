using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookMultiThreading
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Welcome to Address Book Multi Threading!");
            AddressBookRepository repository = new AddressBookRepository();
            repository.RetrieveAllContactDetails();
           // Console.WriteLine(repository.UpdateExistingContactUsingByName("Akhilesh", "Roy", "Akhilesh@gmail.com") ? "Updated Succesfully" : "Updated Failed");
            repository.RetrieveAllTheContactAddedInBetweenADate(Convert.ToDateTime("5/12/2018"));
        }
    }
}
