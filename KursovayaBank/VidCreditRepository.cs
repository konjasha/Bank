using KursovayaBank.Models.BaDB;
using System;
using System.Globalization;
using System.Linq;

namespace KursovayaBank
{
 
    public class VidCreditRepository : Repository  
    {
        public VidCreditRepository(BaDB db) : base(db)
        {
        }

        public override void Create()      
        {

            VidCredit vidCreditToCreate = new VidCredit();           

            Console.WriteLine("Введите ставку кредитования:");
            vidCreditToCreate.Stavka = Convert.ToInt32(Console.ReadLine());      

            Console.WriteLine("Введите срок кредитования(в днях):");
            vidCreditToCreate.Srok_dney_ = Convert.ToInt32(Console.ReadLine());

            _db.VidCredits.Add(vidCreditToCreate);                 
            _db.SaveChanges();                            

            Console.WriteLine("*********************************************");
            Read();                                       
        }

        public override void Delete()       
        {
            Console.WriteLine("Введите id вида кредита для удаления:");
            int.TryParse(Console.ReadLine(), out int id);                           

            VidCredit vidCreditToDelete = _db.VidCredits.Single(vidCredit => vidCredit.idVid == id);   

            _db.VidCredits.Remove(vidCreditToDelete);                                     
            _db.SaveChanges();                                                     

            Console.WriteLine("*********************************************");
            Read();                                                                
        }

        public override void Read()         
        {
            Console.WriteLine("Список видов кредита\n");
            Console.WriteLine("idVid\t\t| Stavka\t| Srok(dney)");
            Console.WriteLine("---------------------------------------------");

            foreach (VidCredit vidCredit in _db.VidCredits)                                                   
            {
                Console.WriteLine($"{vidCredit.idVid}\t\t| {vidCredit.Stavka}\t\t| {vidCredit.Srok_dney_}");    
            }
            Console.WriteLine("---------------------------------------------");
        }

        public override void Update()
        {
            Console.WriteLine("Введите ID вида кредита для изменения:");
            int.TryParse(Console.ReadLine(), out int id);                           

            VidCredit vidCreditToUpdate = _db.VidCredits.Single(vidCredit => vidCredit.idVid == id);    
            _db.VidCredits.Remove(vidCreditToUpdate);                                      
            _db.SaveChanges();                                                     

            Create();                                                               
        }
    }
}
