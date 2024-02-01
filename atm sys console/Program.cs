// See https://aka.ms/new-console-template for more information
using System;
using System.Threading.Channels;
public class cardHoulder
{
    string cardnum;
    int pin;
    string firstname;
    string lastname;
    double balance;

    public cardHoulder(string cardnum, int pin, string firstname, string lastname, double balance) 
    { 
    this.cardnum = cardnum;
    this.pin = pin;
    this.firstname = firstname;
    this.lastname = lastname;
    this.balance = balance;
    }
    public string getnum(){
        return cardnum;
    }
    public int getpin()
    {
        return pin;
    }
    public string getfirstname()
    {
        return firstname;
    }
    public string getlastname()
    {
        return lastname;
    }
    public double getbalance()
    {
        return balance;
    }
    
    public void setnum(string newcardnum)
    {
        cardnum = newcardnum;
    }
    public void setpin(int newpin)
    {
        pin = newpin;
    }
    public void  setfirstname (string newfirstname)
    {
        firstname = newfirstname;
    }
    public void setladstname(string newlastname)
    {
        lastname = newlastname;
    }
    public void setbalance(double newbalance)
    {
        balance = newbalance;
    }

    public void main(string[] args)
    {
        void printOptions()
        {
            Console.WriteLine("welcome to ATM");
            Console.WriteLine("please select one of those option !!!");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. show balance");
            Console.WriteLine("4. Exit");
        }
        void deposit(cardHoulder currentUser)
        {
            Console.WriteLine("How mush $$ would you like to deposit !!");
            double dopsit = Double.Parse(Console.ReadLine());
            currentUser.setbalance(currentUser.getbalance() + dopsit);
            Console.WriteLine("Thankyou for depositing $$, Your new balance is:" + currentUser.getbalance());
        }
        void withdraw (cardHoulder currentUser)
        {
            Console.WriteLine("How mush $$ would you like to Withdraw !!");
            double withdrawal = Double.Parse(Console.ReadLine());
            //checked if user have enough balance to withdraw
            if (currentUser.getbalance() > withdrawal)
            {
                Console.WriteLine("Sorry you can't withdraw, you don't have enough balance :( ");
            }
            else
            {
                currentUser.setbalance(currentUser.getbalance() - withdrawal);
                Console.WriteLine("You're good to go! Thank you :)");
            }
            void balance (cardHoulder cuurentUser)
            {
                Console.WriteLine("your Current Balance is :" + currentUser.getbalance());
            }

            List<cardHoulder> cardhoulders = new List<cardHoulder>();
            cardhoulders.Add(new cardHoulder("4238679324067835", 1343, "Sameed", "Behari", 17803.52));
            cardhoulders.Add(new cardHoulder("5483679329757835", 1243, "Shabbir", "Taliban", 17833.52));
            cardhoulders.Add(new cardHoulder("6783679367357835", 7343, "Usman", "binladir", 17853.52));
            cardhoulders.Add(new cardHoulder("7983679390257835", 2343, "Asad", "dhobe", 178.52));
            cardhoulders.Add(new cardHoulder("8903679389377835", 4343, "Kabber", "Pashah", 17383.52));
            cardhoulders.Add(new cardHoulder("9026679357857835", 5343, "Ayan", "bhai", 17853.52));


            //prompt user
            Console.WriteLine("Welcome Sir/Madam/behari ");
            Console.WriteLine("I hope you use this ATM in good health :)");
            Console.WriteLine("please enter your detit card: ");
            string detbitCardNum = "";
            cardHoulder currentUsers;

            while (true)
            {
                try
                {
                    detbitCardNum = Console.ReadLine();
                    //check in users list
                    currentUser = cardhoulders.FirstOrDefault(a => a.cardnum == detbitCardNum);
                    if (currentUser != null)
                    {
                        break;
                    }
                    else 
                    { 
                        Console.WriteLine("Sorry Sir/Madam/behri, Card should not recongnized. Please try again :)");
                    }
                }
                catch
                {

                    Console.WriteLine("Sorry Sir/Madam/behri, Card should not recongnized. Please try again :)");

                }
            }
            //pin code
            Console.WriteLine("Enter your Magical 4 digit Number/Code:");
            int userpin = 0;

            while (true)
            {
                try
                {
                    userpin = int.Parse(Console.ReadLine());
                    //check in users list 
                    if (currentUser.getpin() == userpin)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Sorry Sir/Madam/behri, Incorrect Pin. Please try again :)");
                    }
                }
                catch
                {

                    Console.WriteLine("Sorry Sir/Madam/behri, Incorrect Pin. Please try again :)");

                }
            }

            //geting user name
            Console.WriteLine($"wellcome {currentUser.getfirstname} :)");
            int option = 0;
            do
            {
                printOptions();
                try
                {
                    option = int.Parse(Console.ReadLine());
                }
                catch 
                {
                    if (option == 1)
                    {
                        deposit(currentUser);
                    }
                    else if (option == 2)
                    {
                        withdraw(currentUser);

                    }
                    else if (option ==3)
                    {
                        balance(currentUser);
                    }
                    else if (option == 4)
                    {
                        break;
                    }
                }

            } while (option !=4);
            Console.WriteLine("Thank you! Hava a nice day :)");
        }
    }
}