using AbstractShopModel;
using System.Collections.Generic;

namespace AbstractShopService
{
    class DataListSingleton
    {
        private static DataListSingleton instance;

        public List<Zakazchik> Zakazchiks { get; set; }

        public List<Payment> Payments { get; set; }

        public List<Rabochi> Rabochis { get; set; }

        public List<Zakaz> Zakazs { get; set; }

        public List<Section> Sections { get; set; }

        public List<SectionPayment> SectionPayments { get; set; }

        public List<BonusFineBlock> BonusFineBlocks { get; set; }

        public List<BonusFineBlockZakazchik> BonusFineBlockPayments { get; set; }

        private DataListSingleton()
        {
            Zakazchiks = new List<Zakazchik>();
            Payments = new List<Payment>();
            Rabochis = new List<Rabochi>();
            Zakazs = new List<Zakaz>();
            Sections = new List<Section>();
            SectionPayments = new List<SectionPayment>();
            BonusFineBlocks = new List<BonusFineBlock>();
            BonusFineBlockPayments = new List<BonusFineBlockZakazchik>();
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

