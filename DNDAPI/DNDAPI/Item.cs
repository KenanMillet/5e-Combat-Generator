using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DNDAPI
{
    public class Item
    {
        public string Name { get; set; }
        public string ItemType { get; set; }
        public string Desc { get; set; }
        public string Rarity { get; set; }
        public int Value { get; set; }
        public string Quality { get; set; }
        public string Source { get; set; }
        string workingString = "";
        Regex toUpperPat = new Regex("\\b[A - Z]", RegexOptions.IgnoreCase);// from website

        public Item(ItemData i)
        {
            Name = i.name;
            ItemType = i.type;
            Desc = i.desc;
            Rarity = i.rarity;
            Quality = "Default";
            Value = 0;
            Source = i.document_slug;

            workingString = Source; //making source look nice, original format: system-reference-document
            workingString = workingString.Replace('-', ' ');
            workingString = toUpperPat.Replace(workingString, m => m.ToString().ToUpper());
            Source = workingString;
        }

        public string GetTitle()
        {
            return Quality+ " " + Name + "\n";
        }

        public string GetSubTitle()
        {
            return ItemType + ", " + Rarity + ", "+ Value + " gp" + "\n";
        }

        public string GetNormalText()
        {
            return Desc + "\n";
        }

        public string GetEndNote()
        {
            return Source + "\n" + "\n";
        }

        public override string ToString()
        {
            return "\n" + Name + "\n" + ItemType + ", " + Rarity + "\n" + Desc + "\n" + Source + "\n" + "\n";
        }
    }
}
