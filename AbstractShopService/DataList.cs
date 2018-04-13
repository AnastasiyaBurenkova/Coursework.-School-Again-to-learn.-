using AbstractShopModel;
using System.Collections.Generic;

namespace AbstractShopService
{
    class DataListSingleton
    {
        private static DataListSingleton instance;

        public List<Client> Clients { get; set; }

        public List<Admin> Admins { get; set; }

        public List<Entry> Entrys { get; set; }

        public List<Section> Sections { get; set; }

        public List<BonusFineBlock> BonusFineBlocks { get; set; }

        public List<ClientBonusFineBlock> ClientBonusFineBlocks { get; set; }

        private DataListSingleton()
        {
            Clients = new List<Client>();
            Admins = new List<Admin>();
            Entrys = new List<Entry>();
            Sections = new List<Section>();
            BonusFineBlocks = new List<BonusFineBlock>();
            ClientBonusFineBlocks = new List<ClientBonusFineBlock>();
        }

        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }

            return instance;
        }
    }
}

