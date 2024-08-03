using KursovayaBank.Models.BaDB;
using System;

namespace KursovayaBank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BaDB db = new BaDB();       
            Menu menu = new Menu();             

            clientRepository clientRepository = new clientRepository(db);                                                
            HierarchicalMenuItem clientHierarchicalMenuItem = new HierarchicalMenuItem("Работа с таблицей Клиенты", "1");  

            clientHierarchicalMenuItem.MenuItems.Add(new ReadMenuItem("Просмотр списка клиентов", "1", clientRepository));                
            clientHierarchicalMenuItem.MenuItems.Add(new CreateMenuItem("Добавление нового клиента в список", "2", clientRepository));   
            clientHierarchicalMenuItem.MenuItems.Add(new UpdateMenuItem("Редактирование данных клиента", "3", clientRepository));        
            clientHierarchicalMenuItem.MenuItems.Add(new DeleteMenuItem("Удаления клиента из списка", "4", clientRepository));            

            CreditRepository creditRepository = new CreditRepository(db);                                               
            HierarchicalMenuItem creditHierarchicalMenuItem = new HierarchicalMenuItem("Работа с таблицей Кредиты", "2");  

            creditHierarchicalMenuItem.MenuItems.Add(new ReadMenuItem("Просмотр списка кредитов", "1", creditRepository));                
            creditHierarchicalMenuItem.MenuItems.Add(new CreateMenuItem("Добавление нового кредита в список", "2", creditRepository));    
            creditHierarchicalMenuItem.MenuItems.Add(new UpdateMenuItem("Редактирование данных о кредите", "3", creditRepository));         
            creditHierarchicalMenuItem.MenuItems.Add(new DeleteMenuItem("Удаления кредита из списка", "4", creditRepository));           

            VidCreditRepository vidCreditRepository = new VidCreditRepository(db);                                                  
            HierarchicalMenuItem vidCreditHierarchicalMenuItem = new HierarchicalMenuItem("Работа с таблицей Виды кредитов", "3");   
            vidCreditHierarchicalMenuItem.MenuItems.Add(new ReadMenuItem("Просмотр списка видов", "1", vidCreditRepository));                   
            vidCreditHierarchicalMenuItem.MenuItems.Add(new CreateMenuItem("Добавление нового вида в список", "2", vidCreditRepository));      
            vidCreditHierarchicalMenuItem.MenuItems.Add(new UpdateMenuItem("Редактирование данных 0 виде кредита", "3", vidCreditRepository));         
            vidCreditHierarchicalMenuItem.MenuItems.Add(new DeleteMenuItem("Удаления вида кредита из списка", "4", vidCreditRepository));              

            menu.MenuItems.Add(clientHierarchicalMenuItem);       
            menu.MenuItems.Add(creditHierarchicalMenuItem);     
            menu.MenuItems.Add(vidCreditHierarchicalMenuItem);   

            menu.StartMenuHandle();             

        }
    }
}
