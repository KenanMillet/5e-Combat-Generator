using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNDAPI
{
    public class ItemData
    {
        public string name { get; set; }
        public string type { get; set; }
        public string desc { get; set; }
        public string rarity { get; set; }
        public string document_slug { get; set; }

        public override string ToString()
        {
            return name + ", " + type + ", " + desc + ", " + rarity + ", " + document_slug;
        }
    }
}
