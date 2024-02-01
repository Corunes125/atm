using System;
using System.Collections.Generic;
using System.Linq;

public class CardHolder
{
    string cardnum;
    int pin;
    string firstname;
    string lastname;
    double balance;

    public CardHolder(string cardnum, int pin, string firstname, string lastname, double balance)
    {
        this.cardnum = cardnum;
        this.pin = pin;
        this.firstname = firstname;
        this.lastname = lastname;
        this.balance = balance;
    }

    public string GetNum()
    {
        return cardnum;
    }

    public int GetPin()
    {
        return pin;
    }

    public string GetFirstName()
    {
        return firstname;
    }

    public string GetLastName()
    {
        return lastname;
    }

    public double GetBalance()
    {
        return balance;
    }

    public void SetNum(string newcardnum)
    {
        cardnum = newcardnum;
    }

    public void SetPin(int newpin)
    {
        pin = newpin;
    }

    public void SetFirstName(string newfirstname)
    {
        firstname = newfirstname;
    }

    public void SetLastName(string newlastname)
    {
        lastname = newlastname;
    }

    public void SetBalance(double newbalance)
    {
        balance = newbalance;
    }

    public static void Main(string[] args)
    {
        void PrintOptions()
        {
            Console.WriteLine("Welcome to ATM");
            Console.WriteLine("Please select one of these options:");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show balance");
            Console.WriteLine("4. Exit");
        }

        void Deposit(CardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to deposit?");
            double depositAmount = double.Parse(Console.ReadLine());
            currentUser.SetBalance(currentUser.GetBalance() + depositAmount);
            Console.WriteLine($"Thank you for depositing $$. Your new balance is: {currentUser.GetBalance()}");
        }

        void Withdraw(CardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to withdraw?");
            double withdrawalAmount = double.Parse(Console.ReadLine());

            if (currentUser.GetBalance() < withdrawalAmount)
            {
                Console.WriteLine("Sorry, you can't withdraw. You don't have enough balance.");
            }
            else
            {
                currentUser.SetBalance(currentUser.GetBalance() - withdrawalAmount);
                Console.WriteLine("You're good to go! Thank you :)");
            }
        }

        void ShowBalance(CardHolder currentUser)
        {
            Console.WriteLine($"Your current balance is: {currentUser.GetBalance()}");
        }

        List<CardHolder> cardHolders = new List<CardHolder>
        {
            new CardHolder("4238679324067835", 1343, "Sameed", "Behari", 17803.52),
            new CardHolder("5483679329757835", 1243, "Shabbir", "Taliban", 17833.52),
            new CardHolder("6783679367357835", 7343, "Usman", "binladir", 17853.52),
            new CardHolder("7983679390257835", 2343, "Asad", "dhobe", 178.52),
            new CardHolder("8903679389377835", 4343, "Kabber", "Pashah", 17383.52),
            new CardHolder("9026679357857835", 5343, "Ayan", "bhai", 17853.52)
        };

        Console.WriteLine("Welcome Sir/Madam/Behari");
        Console.WriteLine("I hope you use this ATM in good health :)");
        Console.WriteLine("Please enter your debit card: ");
        string debitCardNum = "";
        CardHolder currentUser;

        while (true)
        {
            try
            {
                debitCardNum = Console.ReadLine();
                currentUser = cardHolders.FirstOrDefault(a => a.GetNum() == debitCardNum);

                if (currentUser != null)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Sorry Sir/Madam/Behari, Card not recognized. Please try again :)");
                }
            }
            catch
            {
                Console.WriteLine("Sorry Sir/Madam/Behari, Card not recognized. Please try again :)");
            }
        }

        Console.WriteLine("Enter your Magical 4 digit Number/Code:");
        int userPin = 0;

        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());

                if (currentUser.GetPin() == userPin)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Sorry Sir/Madam/Behari, Incorrect Pin. Please try again :)");
                }
            }
            catch
            {
                Console.WriteLine("Sorry Sir/Madam/Behari, Incorrect Pin. Please try again :)");
            }
        }

        Console.WriteLine($"Welcome {currentUser.GetFirstName()} :)");
        int option = 0;

        do
        {
            PrintOptions();

            try
            {
                option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Deposit(currentUser);
                        break;
                    case 2:
                        Withdraw(currentUser);
                        break;
                    case 3:
                        ShowBalance(currentUser);
                        break;
                    case 4:
                        Console.WriteLine("Thank you! Have a nice day :)");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
            catch
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }

        } while (option != 4);
    }
}
