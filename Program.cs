   using ATM_sim.Models;
   using ATM_sim.Managers;
    //main
    class Program {
    public static void Main(String[] args) {
        TransactionManager transaction = new TransactionManager();
        List<CardHolder> cardHolders=new List<CardHolder>();
        cardHolders.Add(new CardHolder("12345678","John","Doe",1234,1000));
        cardHolders.Add(new CardHolder("98765432","Jane","Smith",5678,5000));
        cardHolders.Add(new CardHolder("55555555","Bob","Jones",9999,2000));
        cardHolders.Add(new CardHolder("11111111","Alice","Brown",7777,3000));
        cardHolders.Add(new CardHolder("22222222","Charlie","Davis",8888,4000));

        //
        Console.WriteLine("Enter your card number :");
        String? cardNumInput= "";        
        CardHolder? currentUser;
        while(true){
            try{
                cardNumInput = Console.ReadLine();
                currentUser = cardHolders.FirstOrDefault(a => a.getCardNum() == cardNumInput);
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
           transaction.printOptions();
            try{
            option = int.Parse(Console.ReadLine() ?? "0"); 
            }catch{
                Console.WriteLine("Invalid option: Pls try again !!!");
            }
            if(option==1){
                    transaction.checkBalance(currentUser);
                }
                else if(option==2){
                    transaction.deposit(currentUser);
                }
                else if(option==3){
                    transaction.withdraw(currentUser);
                }
                else if(option==4){
                    transaction.printTransactionLog();
                }
                else if(option==5){
                    break;
                }
                else{
                    option = 0;
                }
        }
        while(option!=5);
        Console.WriteLine("Goodbye :) (-_-)");
    
}}