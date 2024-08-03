using System;

namespace KursovayaBank
{

    public class UpdateMenuItem : MenuItem 
    {
        private IRepository _repository;    

        public UpdateMenuItem(string title, string activationComand, IRepository repository) : base(title, activationComand)
        {
            _repository = repository;
        }

        public override void Action()       
        {
            _repository.Update();          
            Console.WriteLine("Нажмите любую клавишу для продолжения...");
            Console.ReadKey();
        }
    }
}
