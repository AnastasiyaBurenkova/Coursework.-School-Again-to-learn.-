using AgainSchoolModel;
using AgainSchoolService;
using AgainSchoolService.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace AgainSchoolService.ImplementationBD
{
    public class SerializeService : ISerializeService
    {
        private AgSchoolDbContext context;

        public SerializeService(AgSchoolDbContext context)
        {
            this.context = context;
        }

        public void GetData()
        {
            DataContractJsonSerializer dishJS = new DataContractJsonSerializer(typeof(List<Admin>));
            MemoryStream msDish = new MemoryStream();
            dishJS.WriteObject(msDish, context.Admins.ToList());
            msDish.Position = 0;
            StreamReader srDish = new StreamReader(msDish);
            string dishesJSON = srDish.ReadToEnd();
            srDish.Close();
            msDish.Close();

            DataContractJsonSerializer accountJS = new DataContractJsonSerializer(typeof(List<Section>));
            MemoryStream msAccountJS = new MemoryStream();
            accountJS.WriteObject(msAccountJS, context.Sections.ToList());
            msAccountJS.Position = 0;
            StreamReader srAccountJS = new StreamReader(msAccountJS);
            string AccountJSON = srAccountJS.ReadToEnd();
            srAccountJS.Close();
            msAccountJS.Close();

            DataContractJsonSerializer clientJS = new DataContractJsonSerializer(typeof(List<Client>));
            MemoryStream msClient = new MemoryStream();
            clientJS.WriteObject(msClient, context.Clients.ToList());
            msClient.Position = 0;
            StreamReader srClient = new StreamReader(msClient);
            string clientsJSON = srClient.ReadToEnd();
            srClient.Close();
            msClient.Close();

            DataContractJsonSerializer entryJS = new DataContractJsonSerializer(typeof(List<Entry>));
            MemoryStream msEntry = new MemoryStream();
            entryJS.WriteObject(msEntry, context.Entrys.ToList());
            msEntry.Position = 0;
            StreamReader srEntry = new StreamReader(msEntry);
            string entryJSON = srEntry.ReadToEnd();
            srEntry.Close();
            msEntry.Close();

            DataContractJsonSerializer EntrySectionJS = new DataContractJsonSerializer(typeof(List<EntrySection>));
            MemoryStream msEntrySection = new MemoryStream();
            EntrySectionJS.WriteObject(msEntrySection, context.EntrySections.ToList());
            msEntrySection.Position = 0;
            StreamReader srEntrySection = new StreamReader(msEntrySection);
            string EntrySectionJSON = srEntrySection.ReadToEnd();
            srEntrySection.Close();
            msEntrySection.Close();

            DataContractJsonSerializer OrderJS = new DataContractJsonSerializer(typeof(List<Order>));
            MemoryStream msOrder = new MemoryStream();
            OrderJS.WriteObject(msOrder, context.Orders.ToList());
            msOrder.Position = 0;
            StreamReader srOrder = new StreamReader(msOrder);
            string OrderJSON = srOrder.ReadToEnd();
            srOrder.Close();
            msOrder.Close();

            File.WriteAllText(@"E:\bak.txt", "{\n" +
                "    \"Clients\": " + clientsJSON + ",\n" +
                "    \"Admins\": " + dishesJSON + ",\n" +
                "    \"Sections\": " + AccountJSON + "\n" +
                "    \"Entrys\": " + entryJSON + "\n" +
                "    \"EntrySections\": " + EntrySectionJSON + "\n" +
                "    \"Orders\": " + OrderJSON + "\n" +
                "}");
        }
    }
}
