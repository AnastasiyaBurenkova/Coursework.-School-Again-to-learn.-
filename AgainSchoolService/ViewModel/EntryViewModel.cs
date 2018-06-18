using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgainSchoolService.ViewModel
{
    public class EntryViewModel
    {
        public int Id { get; set; }

        public string EntryName { get; set; }

        public decimal Price { get; set; }

        public List<EntrySectionViewModel> EntrySections { get; set; }
    }
}
