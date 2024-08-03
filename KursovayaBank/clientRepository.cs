using KursovayaBank.Models.BaDB;
using System;
using System.Globalization;
using System.Linq;

namespace KursovayaBank
{

    public class clientRepository : Repository  
    {

        public clientRepository(BaDB db) : base(db)
        {
        }

        public override void Create()     
        {
            Client clientToCreate = new Client();               

            Console.WriteLine("Введите ФИО:");
            clientToCreate.fio = Console.ReadLine();               

            Console.WriteLine("Введите телефон:");
            clientToCreate.phone = Convert.ToInt64(Console.ReadLine());    

            Console.WriteLine("Введите пол:");
            clientToCreate.gender = Console.ReadLine();

            Console.WriteLine("Введите дату рождения:");
            DateOnly.TryParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateOnly dateonly);
            clientToCreate.dateofbirth = dateonly;


            _db.Clients.Add(clientToCreate);                       
            _db.SaveChanges();                                     


            Console.WriteLine("*********************************************");
            Read();                                             
        }

        public override void Delete()      
        {
            Console.WriteLine("Введите ID клиента для удаления:");
            int.TryParse(Console.ReadLine(), out int id);                             

            Client clientToDelete = _db.Clients.Single(client => client.idclient == id); 

            _db.Clients.Remove(clientToDelete);                                        
            _db.SaveChanges();                                                          

            Console.WriteLine("*********************************************");
            Read();                                                                    
        }

        public override void Read()         
        {
            Console.WriteLine("Список клиентов\n");
            Console.WriteLine("idclient\t| fio\t\t| phone\t| gender\t\t| dateofbirth");
            Console.WriteLine("---------------------------------------------");

            foreach (Client client in _db.Clients)
            {
                Console.WriteLine($"{client.idclient}\t\t| {client.fio}\t| {client.phone}\t| {client.gender}\t\t| {client.dateofbirth}");
                Console.WriteLine("---------------------------------------------");
            }
        }


        public override void Update()       
        {
            Console.WriteLine("Введите ID клиента для изменения:");
            int.TryParse(Console.ReadLine(), out int id);                               

            Client clientToUpdate = _db.Clients.Single(client => client.idclient == id);  
            _db.Clients.Remove(clientToUpdate);                                       
            _db.SaveChanges();                                                         

            Create();                                                                   
        }
    }
}
