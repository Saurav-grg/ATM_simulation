using ATM_sim.Models;
namespace ATM_sim.Managers
{
    public class TransactionManager {
            List<string> transactionLog = new List<string>();
            public void logTransaction(string message)
            {
                transactionLog.Add($"{DateTime.Now}: {message}");
            }
            public void printOptions(){
                Console.WriteLine("\n1. Check Balance");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. View Transaction History");
                Console.WriteLine("5. Exit\n");
            }
            public void deposit(CardHolder currentUser){
                Console.WriteLine("Enter the amount you want to deposit");
                string? input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Invalid input. Please enter a valid amount.");
                    return;
                }
                if (double.TryParse(input, out double amount))
                {
                    currentUser.setBalance(currentUser.getBalance() + amount);
                    Console.WriteLine($"Deposit successful, your new balance is {currentUser.getBalance()}");
                    logTransaction($"Deposit: {amount} by {currentUser.getCardNum()}");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a numeric value.");
                }
            }
            public void withdraw(CardHolder currentUser){
                Console.WriteLine("Enter the amount you want to withdraw");
                string? input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Invalid input. Please enter a valid amount.");
                    return;
                }
                if (double.TryParse(input, out double amount))
                {
                    if (currentUser.getBalance() >= amount)
                    {
                        currentUser.setBalance(currentUser.getBalance() - amount);
                        Console.WriteLine($"Withdrawal successful, your new balance is {currentUser.getBalance()}");
                    logTransaction($"Withdrawl: {amount} by {currentUser.getCardNum()}");
                    }
                    else
                    {
                        Console.WriteLine("Insufficient balance.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a numeric value.");
                }
            }
            public void checkBalance(CardHolder currentUser){
                Console.WriteLine("Your balance is "+currentUser.getBalance());
            }
            public void printTransactionLog()
            {
                Console.WriteLine("Transaction History:");
                if (transactionLog.Count == 0)
                {
                    Console.WriteLine("No transactions yet.");
                }
                else
                {
                    foreach (string log in transactionLog)
                    {
                        Console.WriteLine(log);
                    }
                }
            }
    }
}