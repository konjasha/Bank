namespace KursovayaBank { 


    public interface IMenuItem          
    {
        string GetActivationComand();   
        string GetTitle();             
        void Action();                  
    }
}