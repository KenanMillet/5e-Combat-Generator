using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNDAPI
{
    public class MonsterData
    {
        public string name { get; set; }
        public string type { get; set; }
        public string subtype { get; set; }
        public string group { get; set; }
        public string hit_dice { get; set; }
        public string challenge_rating { get; set; }
        public string document_slug { get; set; }

        public override string ToString()
        {
            return "\n" + name + "\n" + type + ", " + subtype + ", " + group + "\n" + challenge_rating + "\n" + hit_dice + "\n" + document_slug + "\n";
        }

    }
}
