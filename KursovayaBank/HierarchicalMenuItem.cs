using System;

namespace KursovayaBank
{
   

    public class HierarchicalMenuItem : Menu, IMenuItem                    
    {
        

        private string _activationComand;                                   
        private string _title;                                              

        public HierarchicalMenuItem(string title, string activationComand)  
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

        public void Action()                       
        {

            StartMenuHandle();                 
            
        }
    }
}