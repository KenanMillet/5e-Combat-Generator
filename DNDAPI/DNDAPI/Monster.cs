using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DNDAPI
{
    public class Monster
    {
        public string Name { get; set; }
        public string MainType { get; set; }
        public string Subtype { get; set; }
        public string MonsterGroup { get; set; }
        public string Source { get; set; }
        public Die HD { get; set; }
        public int ModHD { get; set; }
        public ChallengeRating CR { get; set; }

        public Monster(MonsterData m)
        {
            Name = m.name;
            MainType = m.type;
            Subtype = m.subtype;
            MonsterGroup = m.group;
            Source = m.document_slug;
            CleanAndAssignData(m);
        }

        public void CleanAndAssignData(MonsterData data )
        {
            Regex toUpperPat = new Regex("\\b[A-Z]", RegexOptions.IgnoreCase);// from website
            Regex HDPat = new Regex("(\\d+?)d(\\d+) \\+ (\\d+)|(\\d+)d(\\d+)");
            Regex CRFracPat = new Regex("([0-9])/([0-9])");
            Match HDMatch = HDPat.Match(data.hit_dice);
            Match CRMatch = CRFracPat.Match(data.challenge_rating);

            if (HDMatch.Groups[3].Value == "")//the way the match is set up, the third value is the modifer. if it doesnt have it, go with the standard formula
            {
                HD = new Die (Convert.ToInt32(HDMatch.Groups[4].Value), Convert.ToInt32(HDMatch.Groups[5].Value));
                ModHD = 0;
            }
            else
            {
                HD = new Die(Convert.ToInt32(HDMatch.Groups[1].Value), Convert.ToInt32(HDMatch.Groups[2].Value));
                ModHD = Convert.ToInt32(HDMatch.Groups[3].Value);
            }
           
            if (CRMatch.Success)
            {
                CR = new ChallengeRating(Convert.ToInt32(CRMatch.Groups[1].Value), Convert.ToInt32(CRMatch.Groups[2].Value));
            }
            else
            {
                CR = new ChallengeRating(Convert.ToInt32(data.challenge_rating));
            } 

            //making source/types look nice, original format: system-reference-document
            MainType = toUpperPat.Replace(MainType, m => m.ToString().ToUpper());
            if (Subtype != null)
            {
                Subtype = toUpperPat.Replace(Subtype, m => m.ToString().ToUpper());
            }
            if (MonsterGroup != null)
            {
                MonsterGroup = toUpperPat.Replace(MonsterGroup, m => m.ToString().ToUpper());
            }
            Source = Source.Replace('-', ' ');
            Source = toUpperPat.Replace(Source, m => m.ToString().ToUpper());
            
        }

        public string GetTitle()
        {
            return Name + "\n";
        }

        public string GetSubTitle()
        {
            return MainType + ", " + Subtype + ", " + MonsterGroup + "\n";
        }

        public string GetNormalText()
        {
            return "CR: " + CR.ToString() + "\n" + "HD: " +  HD.ToString() + " + " + ModHD + "\n";
        }

        public string GetEndNote()
        {
            return Source + "\n" + "\n";
        }

        public override string ToString()
        {
            if(Subtype == null)
            {
                return "\n" + Name + "\n " + MainType + ", " + MonsterGroup + " \n" + CR.ToString() + " \n" + HD.ToString() + " + " + ModHD + " \n" + Source + " \n" + " \n";
            }
            else if(MonsterGroup == null)
            {
                return "\n" + Name + "\n " + MainType + ", " + MonsterGroup + " \n" + CR.ToString() + " \n" + HD.ToString() + " + " + ModHD + " \n" + Source + " \n" + " \n";
            }
            else if(Subtype == null && MonsterGroup == null)
            {
                return "\n" + Name + "\n " + MainType + ", " + " \n" + CR.ToString() + " \n" + HD.ToString() + " + " + ModHD + " \n" + Source + " \n" + " \n";
            }
            else
            {
                return "\n" + Name + "\n " + MainType + ", " + Subtype + ", " + MonsterGroup + " \n" + CR.ToString() + " \n" + HD.ToString() + " + " + ModHD + " \n" + Source + " \n" + " \n";
            }
        }
    }
}
