namespace ATM_sim.Models
{
    public class CardHolder{
        String cardNum,firstName,lastName;
        int pin;
        double balance;

        public CardHolder(String cardNum,String firstName,String lastName,int pin,double balance){
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
        }}
}