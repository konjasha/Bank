using KursovayaBank.Models.BaDB;
using System;
using System.Linq;

namespace KursovayaBank
{

    public class CreditRepository : Repository  
    {
        public CreditRepository(BaDB db) : base(db)
        {
        }

        public override void Create()      
        {
            Credit creditToCreate = new Credit();    

            Console.WriteLine("Введите сумму кредита:");
            creditToCreate.sumCredit = Convert.ToInt32(Console.ReadLine());      

            Console.WriteLine("Введите сумму выплат:");
            creditToCreate.SumVyplat = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите id вида кредита:");
            creditToCreate.idVid = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("Введите id клиента:");
            creditToCreate.idClient = Convert.ToInt32(Console.ReadLine());

            _db.Credits.Add(creditToCreate);              
            _db.SaveChanges();                             

            Console.WriteLine("*********************************************");
            Read();                                       
        }

        public override void Delete()      
        {
            Console.WriteLine("Введите ID кредита для удаления:");
            int.TryParse(Console.ReadLine(), out int id);                              

            Credit creditToDelete = _db.Credits.Single(Credit => Credit.idCredit == id);  

            _db.Credits.Remove(creditToDelete);                                     
            _db.SaveChanges();                                                          

            Console.WriteLine("*********************************************");
            Read();                                                                    
        }

        public override void Read()         
        {
            Console.WriteLine("Список кредитов\n");
            Console.WriteLine("idCredit\t| sumCredit\t| sumVyplat\t| idVid\t| idClient");
            Console.WriteLine("---------------------------------------------");

            foreach (Credit credit in _db.Credits)                   
            {
                Console.WriteLine($"{credit.idCredit}\t\t| {credit.sumCredit}\t\t| {credit.SumVyplat}\t\t| {credit.idVid}\t| {credit.idClient}");    
            }
            Console.WriteLine("---------------------------------------------");
        }

        public override void Update()      
        {
            Console.WriteLine("Введите ID кредита для изменения:");
            int.TryParse(Console.ReadLine(), out int id);                              

            Credit creditToUpdate = _db.Credits.Single(Credit => Credit.idCredit == id);  
            _db.Credits.Remove(creditToUpdate);                                       
            _db.SaveChanges();                                                        

            Create();                                                                 
        }
    }
}
