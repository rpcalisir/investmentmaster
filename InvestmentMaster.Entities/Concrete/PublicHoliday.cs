using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentMaster.Entities.Concrete
{
    public class PublicHoliday
    {
        public string Date { get; set; }
        public string LocalName { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public bool Fixed { get; set; }
        public bool Global { get; set; }
        public object Counties { get; set; }
        public object LaunchYear { get; set; }
        public List<string> Types { get; set; }
    }
}
