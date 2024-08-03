using System;

namespace KursovayaBank
{

    public class CreateMenuItem : MenuItem  
    {
        private IRepository _repository; 

        public CreateMenuItem(string title, string activationComand, IRepository repository) : base(title, activationComand)    
        {
            _repository = repository;
        }

        public override void Action()       
        {
            _repository.Create();          
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
    }
}
