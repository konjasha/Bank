using System;


namespace KursovayaBank
{
    public class MenuItem : IMenuItem                     
    {
   

        private string _activationComand;                       
        private string _title;                                 
        public MenuItem(string title, string activationComand)  
        {
            _title = title;                                     
            _activationComand = activationComand;              
        }

        public string GetActivationComand()                    
        {
            return _activationComand;
        }

        public string GetTitle()                                
        {
            return _title;
        }


        public virtual void Action()
        {
            Console.WriteLine($"(MenuItem) Пользователь вызвал действие {_activationComand} - {_title}");
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
    }
}