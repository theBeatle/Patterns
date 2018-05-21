using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade_02
{
    class SubsystemA
    {
        public bool ValidateUser(string userName, string password)
        {
            return (userName == "user") && (password == "pass");
        }
    }

    class SubsystemB
    {
        public void ValidateCreditCard(string cardNumber)
        {
            Console.WriteLine("Validate credit card...");
        }
        public void PayAmount(string cardNumber, double amount)
        {
            Console.WriteLine("Pay amount...");
        }
    }
    public class Facade
    {
        SubsystemA firstSubsystem = new SubsystemA();
        SubsystemB secondSubsystem = new SubsystemB();

        public string Operation1(string userName, string password)
        {
            return firstSubsystem.ValidateUser(userName, password) ? "OK" : "Non Valid User";
        }

        public void Operation2(string userName, string password, double amount, string cardNumber = "1234567890")
        {
            if (firstSubsystem.ValidateUser(userName, password))
            {
                secondSubsystem.ValidateCreditCard("1234567890");
                secondSubsystem.PayAmount(cardNumber, amount);

            }
            else
            {
                Console.WriteLine("Credit card gam-gam!!!");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Facade facade = new Facade();
            Console.WriteLine(facade.Operation1("Joydip", "Joydip123"));
            facade.Operation2("user1", "pass", cardNumber: "1234567890", amount: 100.00);
            //facade.Operation2(cardNumber:"1234567890", amount: 100.00);
            Console.Read();
        }
    }
}
