using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBAPI.Model
{
    public class AdultList
    {
        public List<Adult> Adults { get; set; }
        public AdultList()
        {
            Adults = new List<Adult>();
        }
    }
}
