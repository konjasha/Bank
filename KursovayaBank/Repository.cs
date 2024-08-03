using KursovayaBank.Models.BaDB;

namespace KursovayaBank
{

    public abstract class Repository : IRepository
    {
        protected BaDB _db;

        protected Repository(BaDB db)
        {
            _db = db;
        }


        public abstract void Create();  

        public abstract void Delete();  

        public abstract void Read();   

        public abstract void Update();  
    }
}
