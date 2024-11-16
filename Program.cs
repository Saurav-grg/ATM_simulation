
public class cardHolder{
    String cardNum,firstName,lastName;
    int pin;
    double balance;

    public cardHolder(String cardNum,String firstName,String lastName,int pin,double balance){
        this.cardNum=cardNum;
        this.firstName=firstName;
        this.lastName=lastName;
        this.pin=pin;
        this.balance=balance;
    }
    public String getCardNum(){
        return cardNum;
    }
    public String getFirstName(){
        return firstName;
    }
    public String getLastName(){
        return lastName;
    }
    public int getPin(){
        return pin;
    }
    public double getBalance(){
        return balance;
    }
    public void setBalance(double newBalance){
        balance=newBalance;
    }
    public void setPin(int newPin){
        pin=newPin;
    }
    public void setCardNum(String newCardNum){
        cardNum=newCardNum;
    }
    public void setFirstName(String newFirstName){
        firstName=newFirstName;
    }
    public void setLastName(String newLastName){
        lastName=newLastName;
    }
    public static void Main(String[] args) {
        void printOptions(){
            Console.WriteLine("\n1. Check Balance");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Exit\n");
        }
        void deposit(cardHolder currentUser){
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
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a numeric value.");
            }
        }
        void withdraw(cardHolder currentUser){
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
        void checkBalance(cardHolder currentUser){
            Console.WriteLine("Your balance is "+currentUser.getBalance());
        }
        List<cardHolder> cardHolders=new List<cardHolder>();
        cardHolders.Add(new cardHolder("12345678","John","Doe",1234,1000));
        cardHolders.Add(new cardHolder("98765432","Jane","Smith",5678,5000));
        cardHolders.Add(new cardHolder("55555555","Bob","Jones",9999,2000));
        cardHolders.Add(new cardHolder("11111111","Alice","Brown",7777,3000));
        cardHolders.Add(new cardHolder("22222222","Charlie","Davis",8888,4000));

        //
        Console.WriteLine("Enter your card number :");
        String? cardNumInput= "";        
        cardHolder? currentUser;
        while(true){
            try{
                cardNumInput = Console.ReadLine();
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == cardNumInput);
                if(currentUser != null){
                    break;
                }
                else{
                Console.WriteLine("Card not recognized: Pls try again");
                }
            }
            catch{
                Console.WriteLine("Card not recognized: Pls try again");
            }
        }
        Console.WriteLine("Enter your pin : ");
        int pinInput=0;
        while(true){
            try{
                pinInput = int.Parse(Console.ReadLine() ?? "0");
                if(currentUser.getPin()==pinInput){
                    break;
                }
                else{
                    Console.WriteLine("Wrong pin: Pls try again !!!");
                }
            }
            catch{
                Console.WriteLine("Wrong pin: Pls try again !!!");
            }
        }
        Console.WriteLine("Welcome "+currentUser.getFirstName());
        int option = 0;
        do{
            printOptions();
            try{
            option = int.Parse(Console.ReadLine() ?? "0"); 
            }catch{
                Console.WriteLine("Invalid option: Pls try again !!!");
            }
            if(option==1){
                    checkBalance(currentUser);
                }
                else if(option==2){
                    deposit(currentUser);
                }
                else if(option==3){
                    withdraw(currentUser);
                }
                else if(option==4){
                    break;
                }
                else{
                    option = 0;
                }
        }
        while(option!=4);
        Console.WriteLine("Goodbye :) (-_-)");
    }
}