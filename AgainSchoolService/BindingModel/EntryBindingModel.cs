using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgainSchoolService.BindingModel
{
    public class EntryBindingModel
    {
        public int Id { get; set; }

        public string EntryName { get; set; }

        public decimal Price { get; set; }

        public List<EntrySectionBindingModel> EntrySections { get; set; }
    }
}
