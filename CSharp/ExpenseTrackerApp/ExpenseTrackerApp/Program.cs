using System.Transactions;

namespace ExpenseTrackerApp
{
    public class Expense
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string Date { get; set; }
    }

    public class Tracker
    {
        List<Expense> list;
        public decimal Income { get; set; }
        public decimal Expenses { get; set; }
        public Tracker()
        {
            list = new List<Expense >();
        }

        public void AddTransaction()
        {
            decimal amount = 0;
            Console.Write("Enter Title ");
            string title = Console.ReadLine();
            Console.Write("Enter Description ");
            string description = Console.ReadLine();
            Console.Write("Enter Amount: ");
            amount = decimal.Parse(Console.ReadLine());
            Console.Write("Enter Date(DD/MM/YYYY): ");
            string date = Console.ReadLine();
            if (amount >= 0)
            {
                Income += amount;
            }
            else
            {
                Expenses += Math.Abs(amount);
            }

            list.Add(new Expense() { Title = title, Description = description, Amount = amount, Date = date });

            Console.WriteLine("Transaction Added Successfully");

        }

        public void ViewExpenses()
        {
            Console.WriteLine("Your Expense list");
            Console.WriteLine("Title\tDescription\tAmount\tDate");
            foreach (Expense  c in list)
            {
                if (c.Amount < 0)
                {
                    Console.WriteLine($"{c.Title}\t{c.Description}\t{c.Amount}\t{c.Date}");
                }
            }
        }
        public void ViewIncome()
        {
            Console.WriteLine("Your Income list");
            Console.WriteLine("Title\tDescription\tAmount\tDate");
            foreach (Expense c in list)
            {
                if (c.Amount >= 0)
                {
                    Console.WriteLine($"{c.Title}\t{c.Description}\t{c.Amount}\t{c.Date}");
                }
            }

        }
        public void ViewBalance()
        {
            decimal Balance = Income - Expenses;
            Console.WriteLine($"Available Balance is {Balance}");
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Tracker tracker = new Tracker();

            while (true)
            {
                Console.WriteLine("MENU");
                Console.WriteLine("1. Add Transaction");
                Console.WriteLine("2. View Expenses");
                Console.WriteLine("3. View Income");
                Console.WriteLine("4. View Balance");
                Console.WriteLine("Enter Your choice: ");
                int choice = Convert.ToInt16(Console.ReadLine());
                switch (choice)
                    {
                        case 1:
                            {
                                tracker.AddTransaction();
                                break;
                            }
                        case 2:
                            {
                                tracker.ViewExpenses();
                                break;
                            }
                        case 3:
                            {
                                tracker.ViewIncome();
                                break;
                            }
                        case 4:
                            {
                                tracker.ViewBalance();
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Wrong Choice Entered");
                                break;
                            }
                    }
            }
        }
    }

}